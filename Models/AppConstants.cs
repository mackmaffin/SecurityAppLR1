using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserAuthenticationLab.Models
{
	public static class AppConstants
	{
		public const string ADMIN_USERNAME = "ADMIN";
		public const string DATA_FILE = "encrypted_users.dat";
		public const string TEMP_FILE = "temp_users.json";
		public const int MAX_LOGIN_ATTEMPTS = 3;

		public const string LOWERCASE_LETTERS = "abcdefghijklmnopqrstuvwxyz";
		public const string UPPERCASE_LETTERS = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
		public const string ARITHMETIC_OPERATORS = "+-*/";
	}
}
