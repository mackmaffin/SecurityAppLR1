using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace UserAuthenticationLab.Services
{
	public class MD4CryptoServiceProvider : HashAlgorithm
	{
		private uint _a, _b, _c, _d;
		private readonly uint[] _x = new uint[16];
		private int _bytesCount;

		public MD4CryptoServiceProvider()
		{
			Initialize();
		}

		public override void Initialize()
		{
			_a = 0x67452301;
			_b = 0xefcdab89;
			_c = 0x98badcfe;
			_d = 0x10325476;
			_bytesCount = 0;
		}

		protected override void HashCore(byte[] array, int ibStart, int cbSize)
		{
			for (int i = 0; i < cbSize; i++)
			{
				int index = _bytesCount >> 2;
				if (index < 16) _x[index] = (_x[index] << 8) | array[ibStart + i];
				_bytesCount++;

				if (_bytesCount == 64)
				{
					ProcessBlock();
					_bytesCount = 0;
				}
			}
		}

		protected override byte[] HashFinal()
		{
			int padLength = (_bytesCount < 56) ? (56 - _bytesCount) : (120 - _bytesCount);
			byte[] padding = new byte[padLength + 8];
			padding[0] = 0x80;

			long bitCount = (long)_bytesCount * 8;
			for (int i = 0; i < 8; i++)
			{
				padding[padLength + i] = (byte)(bitCount >> (8 * i));
			}

			HashCore(padding, 0, padding.Length);

			byte[] hash = new byte[16];
			for (int i = 0; i < 4; i++)
			{
				hash[i] = (byte)(_a >> (8 * i));
				hash[i + 4] = (byte)(_b >> (8 * i));
				hash[i + 8] = (byte)(_c >> (8 * i));
				hash[i + 12] = (byte)(_d >> (8 * i));
			}

			return hash;
		}

		private void ProcessBlock()
		{
			uint a = _a, b = _b, c = _c, d = _d;

			for (int i = 0; i < 16; i++)
			{
				uint f = (b & c) | (~b & d);
				uint g = (uint)i;
				a = RotateLeft(a + f + _x[g], 3);
				(a, b, c, d) = (d, a, b, c);
			}

			for (int i = 0; i < 16; i++)
			{
				uint f = (b & c) | (b & d) | (c & d);
				uint g = (uint)((i * 4) % 16);
				a = RotateLeft(a + f + _x[g] + 0x5a827999, 5);
				(a, b, c, d) = (d, a, b, c);
			}

			for (int i = 0; i < 16; i++)
			{
				uint f = b ^ c ^ d;
				uint g = (uint)((i * 8) % 16);
				a = RotateLeft(a + f + _x[g] + 0x6ed9eba1, 9);
				(a, b, c, d) = (d, a, b, c);
			}

			_a += a; _b += b; _c += c; _d += d;
		}

		private static uint RotateLeft(uint value, int bits)
		{
			return (value << bits) | (value >> (32 - bits));
		}
	}
}
