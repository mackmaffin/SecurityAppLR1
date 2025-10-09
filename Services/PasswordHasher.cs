using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace UserAuthenticationLab.Services
{
	public class PasswordHasher
	{
		// Твой вариант: MD4 (это нестандартный алгоритм в .NET, поэтому реализуем вручную)
		public string ComputeMD4Hash(string input)
		{
			if (string.IsNullOrEmpty(input))
				return string.Empty;

			using (var md4 = new MD4CryptoServiceProvider())
			{
				byte[] inputBytes = Encoding.UTF8.GetBytes(input);
				byte[] hashBytes = md4.ComputeHash(inputBytes);

				// Конвертируем в hex-строку
				return ByteArrayToHexString(hashBytes);
			}
		}

		public bool VerifyPassword(string inputPassword, string storedHash)
		{
			if (string.IsNullOrEmpty(inputPassword) && string.IsNullOrEmpty(storedHash))
				return true; // Оба пустые

			if (string.IsNullOrEmpty(inputPassword) || string.IsNullOrEmpty(storedHash))
				return false; // Один пустой, другой нет

			string inputHash = ComputeMD4Hash(inputPassword);
			return string.Equals(inputHash, storedHash, StringComparison.OrdinalIgnoreCase);
		}

		private string ByteArrayToHexString(byte[] bytes)
		{
			var sb = new StringBuilder();
			foreach (byte b in bytes)
			{
				sb.Append(b.ToString("x2")); // x2 = hex в нижнем регистре
			}
			return sb.ToString();
		}
	}
}
