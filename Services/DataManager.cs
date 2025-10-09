using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserAuthenticationLab.Models;

namespace UserAuthenticationLab.Services
{
	public class DataManager
	{
		private readonly EncryptionService _encryptionService;
		private ApplicationData _currentData;
		private readonly string _tempFile = AppConstants.TEMP_FILE;

		public DataManager()
		{
			_encryptionService = new EncryptionService();
		}

		public ApplicationData LoadData(string password)
		{
			_currentData = _encryptionService.DecryptData(password);

			if (_currentData.FindUser(AppConstants.ADMIN_USERNAME) == null)
				throw new Exception("Неверная парольная фраза!");

			return _currentData;
		}

		public bool SaveData(string password)
		{
			if (_currentData == null) return false;

			var result = _encryptionService.EncryptData(_currentData, password);

			if (File.Exists(_tempFile))
				File.Delete(_tempFile);

			return result;
		}

		public ApplicationData GetCurrentData() => _currentData;
	}
}
