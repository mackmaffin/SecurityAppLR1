using System;
using System.IO;
using System.Text;

namespace SecurityAppLR2.Core
{
	public static class Md5
	{
		public static byte[] ComputeHash(byte[] input)
		{
			var padded = Pad(input);
			uint a0 = 0x67452301u;
			uint b0 = 0xefcdab89u;
			uint c0 = 0x98badcfeu;
			uint d0 = 0x10325476u;

			for (int offset = 0; offset < padded.Length; offset += 64)
			{
				uint[] M = new uint[16];
				for (int j = 0; j < 16; j++)
				{
					int baseIndex = offset + j * 4;
					M[j] = (uint)(padded[baseIndex]
						   | (padded[baseIndex + 1] << 8)
						   | (padded[baseIndex + 2] << 16)
						   | (padded[baseIndex + 3] << 24));
				}

				uint A = a0, B = b0, C = c0, D = d0;

				for (int i = 0; i < 64; i++)
				{
					uint F, g;
					if (i < 16)
					{
						F = (B & C) | (~B & D);
						g = (uint)i;
					}
					else if (i < 32)
					{
						F = (D & B) | (C & ~D);
						g = (uint)((5 * i + 1) & 0x0F);
					}
					else if (i < 48)
					{
						F = B ^ C ^ D;
						g = (uint)((3 * i + 5) & 0x0F);
					}
					else
					{
						F = C ^ (B | ~D);
						g = (uint)((7 * i) & 0x0F);
					}

					uint temp = D;
					D = C;
					C = B;
					uint sum = A + F + K[i] + M[g];
					B = B + Rol(sum, S[i]);
					A = temp;
				}

				a0 += A;
				b0 += B;
				c0 += C;
				d0 += D;
			}

			byte[] output = new byte[16];
			WriteUIntLE(output, 0, a0);
			WriteUIntLE(output, 4, b0);
			WriteUIntLE(output, 8, c0);
			WriteUIntLE(output, 12, d0);
			return output;
		}

		public static string ComputeHashHex(byte[] input) => ToHex(ComputeHash(input));
		public static string ComputeFileHashHex(string path) => ComputeHashHex(File.ReadAllBytes(path));

		public static StepResult AnalyzeOneStep(byte[] input, int stepIndex)
		{
			if (stepIndex < 0 || stepIndex > 63) throw new ArgumentOutOfRangeException(nameof(stepIndex));
			var padded = Pad(input);
			if (padded.Length < 64) Array.Resize(ref padded, 64);
			uint[] M = new uint[16];
			for (int j = 0; j < 16; j++)
			{
				int baseIndex = j * 4;
				M[j] = (uint)(padded[baseIndex]
					   | (padded[baseIndex + 1] << 8)
					   | (padded[baseIndex + 2] << 16)
					   | (padded[baseIndex + 3] << 24));
			}

			uint A = 0x67452301u;
			uint B = 0xefcdab89u;
			uint C = 0x98badcfeu;
			uint D = 0x10325476u;

			for (int i = 0; i < stepIndex; i++)
			{
				uint Fp, gp;
				if (i < 16)
				{
					Fp = (B & C) | (~B & D);
					gp = (uint)i;
				}
				else if (i < 32)
				{
					Fp = (D & B) | (C & ~D);
					gp = (uint)((5 * i + 1) & 0x0F);
				}
				else if (i < 48)
				{
					Fp = B ^ C ^ D;
					gp = (uint)((3 * i + 5) & 0x0F);
				}
				else
				{
					Fp = C ^ (B | ~D);
					gp = (uint)((7 * i) & 0x0F);
				}
				uint tempP = D;
				D = C;
				C = B;
				uint sumP = A + Fp + K[i] + M[gp];
				B = B + Rol(sumP, S[i]);
				A = tempP;
			}

			uint F, g;
			if (stepIndex < 16)
			{
				F = (B & C) | (~B & D);
				g = (uint)stepIndex;
			}
			else if (stepIndex < 32)
			{
				F = (D & B) | (C & ~D);
				g = (uint)((5 * stepIndex + 1) & 0x0F);
			}
			else if (stepIndex < 48)
			{
				F = B ^ C ^ D;
				g = (uint)((3 * stepIndex + 5) & 0x0F);
			}
			else
			{
				F = C ^ (B | ~D);
				g = (uint)((7 * stepIndex) & 0x0F);
			}

			uint A0 = A, B0 = B, C0 = C, D0 = D;
			uint sum = A + F + K[stepIndex] + M[g];
			uint rot = Rol(sum, S[stepIndex]);
			uint Bnew = B + rot;
			uint Anew = D;
			uint Dnew = C;
			uint Cnew = B;

			return new StepResult
			{
				Step = stepIndex,
				A_Before = A0,
				B_Before = B0,
				C_Before = C0,
				D_Before = D0,
				F = F,
				GIndex = g,
				M_g = M[g],
				K_i = K[stepIndex],
				S_i = S[stepIndex],
				Sum = sum,
				Rot = rot,
				B_After = Bnew,
				A_After = Anew,
				C_After = Cnew,
				D_After = Dnew
			};
		}

		static byte[] Pad(byte[] input)
		{
			ulong bitLen = (ulong)input.Length * 8UL;
			int newLen = input.Length + 1;
			while ((newLen % 64) != 56) newLen++;
			byte[] output = new byte[newLen + 8];
			Buffer.BlockCopy(input, 0, output, 0, input.Length);
			output[input.Length] = 0x80;
			for (int i = 0; i < 8; i++) output[newLen + i] = (byte)((bitLen >> (8 * i)) & 0xFF);
			return output;
		}

		static void WriteUIntLE(byte[] dst, int offset, uint value)
		{
			dst[offset + 0] = (byte)(value & 0xFF);
			dst[offset + 1] = (byte)((value >> 8) & 0xFF);
			dst[offset + 2] = (byte)((value >> 16) & 0xFF);
			dst[offset + 3] = (byte)((value >> 24) & 0xFF);
		}

		static uint Rol(uint x, int s) => (x << s) | (x >> (32 - s));

		static string ToHex(byte[] bytes)
		{
			var sb = new StringBuilder(bytes.Length * 2);
			foreach (var b in bytes) sb.Append(b.ToString("x2"));
			return sb.ToString();
		}

		public struct StepResult
		{
			public int Step;
			public uint A_Before;
			public uint B_Before;
			public uint C_Before;
			public uint D_Before;
			public uint F;
			public uint GIndex;
			public uint M_g;
			public uint K_i;
			public int S_i;
			public uint Sum;
			public uint Rot;
			public uint A_After;
			public uint B_After;
			public uint C_After;
			public uint D_After;
		}

		static readonly int[] S = new int[64]
		{
			7,12,17,22, 7,12,17,22, 7,12,17,22, 7,12,17,22,
			5, 9,14,20, 5, 9,14,20, 5, 9,14,20, 5, 9,14,20,
			4,11,16,23, 4,11,16,23, 4,11,16,23, 4,11,16,23,
			6,10,15,21, 6,10,15,21, 6,10,15,21, 6,10,15,21
		};

		static readonly uint[] K = new uint[64]
		{
			0xd76aa478,0xe8c7b756,0x242070db,0xc1bdceee,
			0xf57c0faf,0x4787c62a,0xa8304613,0xfd469501,
			0x698098d8,0x8b44f7af,0xffff5bb1,0x895cd7be,
			0x6b901122,0xfd987193,0xa679438e,0x49b40821,

			0xf61e2562,0xc040b340,0x265e5a51,0xe9b6c7aa,
			0xd62f105d,0x02441453,0xd8a1e681,0xe7d3fbc8,
			0x21e1cde6,0xc33707d6,0xf4d50d87,0x455a14ed,
			0xa9e3e905,0xfcefa3f8,0x676f02d9,0x8d2a4c8a,

			0xfffa3942,0x8771f681,0x6d9d6122,0xfde5380c,
			0xa4beea44,0x4bdecfa9,0xf6bb4b60,0xbebfbc70,
			0x289b7ec6,0xeaa127fa,0xd4ef3085,0x04881d05,
			0xd9d4d039,0xe6db99e5,0x1fa27cf8,0xc4ac5665,

			0xf4292244,0x432aff97,0xab9423a7,0xfc93a039,
			0x655b59c3,0x8f0ccc92,0xffeff47d,0x85845dd1,
			0x6fa87e4f,0xfe2ce6e0,0xa3014314,0x4e0811a1,
			0xf7537e82,0xbd3af235,0x2ad7d2bb,0xeb86d391
		};
	}
}
