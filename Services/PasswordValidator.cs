using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserAuthenticationLab.Models;

namespace UserAuthenticationLab.Services
{
	public class PasswordValidator
	{
		// Вариант 1: наличие строчных/прописных букв + арифметические операции
		public static bool ValidatePassword(string password)
		{
			if (string.IsNullOrEmpty(password))
				return false;

			bool hasLower = password.Any(char.IsLower);
			bool hasUpper = password.Any(char.IsUpper);
			bool hasArithmetic = password.Any(c => "+-*/".Contains(c));

			return hasLower && hasUpper && hasArithmetic;
		}
	}
}
