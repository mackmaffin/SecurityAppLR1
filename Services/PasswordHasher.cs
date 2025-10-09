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
		public string ComputeMD4Hash(string input)
		{
			if (string.IsNullOrEmpty(input))
				return string.Empty;

			using (var md4 = new MD4CryptoServiceProvider())
			{
				byte[] inputBytes = Encoding.UTF8.GetBytes(input);
				byte[] hashBytes = md4.ComputeHash(inputBytes);

				return ByteArrayToHexString(hashBytes);
			}
		}

		public bool VerifyPassword(string inputPassword, string storedHash)
		{
			if (string.IsNullOrEmpty(inputPassword) && string.IsNullOrEmpty(storedHash))
				return true; 

			if (string.IsNullOrEmpty(inputPassword) || string.IsNullOrEmpty(storedHash))
				return false; 

			string inputHash = ComputeMD4Hash(inputPassword);
			return string.Equals(inputHash, storedHash, StringComparison.OrdinalIgnoreCase);
		}

		private string ByteArrayToHexString(byte[] bytes)
		{
			var sb = new StringBuilder();
			foreach (byte b in bytes)
			{
				sb.Append(b.ToString("x2")); 
			}
			return sb.ToString();
		}
	}
}
