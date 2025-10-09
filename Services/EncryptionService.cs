using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using UserAuthenticationLab.Models;

namespace UserAuthenticationLab.Services
{
	public class EncryptionService
	{
		private readonly string _dataFile = AppConstants.DATA_FILE;
		private readonly string _tempFile = AppConstants.TEMP_FILE;

		public bool EncryptData(ApplicationData data, string password)
		{
			try
			{
				using (var des = DES.Create())
				{
					des.Mode = CipherMode.ECB;
					des.Padding = PaddingMode.PKCS7;

					var salt = GenerateRandomSalt();
					var key = DeriveKeyFromPassword(password, salt);

					des.Key = key;

					using (var encryptor = des.CreateEncryptor())
					using (var fs = new FileStream(_dataFile, FileMode.Create))
					{
						fs.Write(salt, 0, salt.Length);

						using (var cryptoStream = new CryptoStream(fs, encryptor, CryptoStreamMode.Write))
						using (var writer = new BinaryWriter(cryptoStream, Encoding.UTF8))
						{
							SerializeData(writer, data);
						}
					}
				}
				return true;
			}
			catch (Exception ex)
			{
				// TODO: Логирование ошибок
				return false;
			}
		}

		public ApplicationData DecryptData(string password)
		{
			try
			{
				if (!File.Exists(_dataFile))
				{
					var newData = new ApplicationData();
					// Сохраняем с паролем "admin" по умолчанию
					EncryptData(newData, "admin");
					return newData;
				}

				using (var des = DES.Create())
				{
					des.Mode = CipherMode.ECB;
					des.Padding = PaddingMode.PKCS7;

					using (var fs = new FileStream(_dataFile, FileMode.Open))
					{
						var salt = new byte[16];
						fs.Read(salt, 0, salt.Length);

						var key = DeriveKeyFromPassword(password, salt);
						des.Key = key;

						using (var decryptor = des.CreateDecryptor())
						using (var cryptoStream = new CryptoStream(fs, decryptor, CryptoStreamMode.Read))
						using (var reader = new BinaryReader(cryptoStream, Encoding.UTF8))
						{
							return DeserializeData(reader);
						}
					}
				}
			}
			catch (CryptographicException)
			{
				throw new Exception("Неверная парольная фраза!");
			}
			catch (Exception ex)
			{
				throw new Exception($"Ошибка дешифровки: {ex.Message}");
			}
		}

		private byte[] GenerateRandomSalt()
		{
			var salt = new byte[16];
			using (var rng = new RNGCryptoServiceProvider())
			{
				rng.GetBytes(salt);
			}
			return salt;
		}

		private byte[] DeriveKeyFromPassword(string password, byte[] salt)
		{
			using (var deriveBytes = new Rfc2898DeriveBytes(password, salt, 1000))
			{
				return deriveBytes.GetBytes(8);
			}
		}

		private void SerializeData(BinaryWriter writer, ApplicationData data)
		{
			writer.Write(data.Users.Count);
			foreach (var user in data.Users)
			{
				writer.Write(user.Username ?? "");
				writer.Write(user.PasswordHash ?? "");
				writer.Write(user.IsBlocked);
				writer.Write(user.PasswordRestrictions);
				writer.Write(user.MinPasswordLength);
				writer.Write(user.PasswordExpiryMonths);
				writer.Write(user.PasswordSetDate.Ticks);
				writer.Write(user.AccountCreated.Ticks);
			}
		}

		private ApplicationData DeserializeData(BinaryReader reader)
		{
			var data = new ApplicationData();
			data.Users.Clear();

			int userCount = reader.ReadInt32();
			for (int i = 0; i < userCount; i++)
			{
				var user = new User
				{
					Username = reader.ReadString(),
					PasswordHash = reader.ReadString(),
					IsBlocked = reader.ReadBoolean(),
					PasswordRestrictions = reader.ReadBoolean(),
					MinPasswordLength = reader.ReadInt32(),
					PasswordExpiryMonths = reader.ReadInt32(),
					PasswordSetDate = new DateTime(reader.ReadInt64()),
					AccountCreated = new DateTime(reader.ReadInt64())
				};
				data.Users.Add(user);
			}
			return data;
		}
	}
}
