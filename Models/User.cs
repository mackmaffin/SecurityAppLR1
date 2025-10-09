using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserAuthenticationLab.Models
{
	[Serializable]
	public class User
	{
		public string Username { get; set; }
		public string PasswordHash { get; set; }
		public bool IsBlocked { get; set; }
		public bool PasswordRestrictions { get; set; }
		public int MinPasswordLength { get; set; }
		public int PasswordExpiryMonths { get; set; }
		public DateTime PasswordSetDate { get; set; }
		public DateTime AccountCreated { get; set; }

		public User()
		{
			MinPasswordLength = 0;
			PasswordExpiryMonths = 0;
			PasswordSetDate = DateTime.Now;
			AccountCreated = DateTime.Now;
			IsBlocked = false;
			PasswordRestrictions = false;
		}
	}
}
