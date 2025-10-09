using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserAuthenticationLab.Models
{
	[Serializable]
	public class ApplicationData
	{
		public List<User> Users { get; set; } = new List<User>();

		public ApplicationData()
		{
			if (!Users.Any(u => u.Username == "ADMIN"))
			{
				Users.Add(new User
				{
					Username = "ADMIN",
					PasswordHash = "",
					PasswordRestrictions = false,
					MinPasswordLength = 0,
					PasswordExpiryMonths = 0
				});
			}
		}

		public User FindUser(string username)
		{
			return Users.FirstOrDefault(u =>
				u.Username.Equals(username, StringComparison.OrdinalIgnoreCase));
		}

		public bool UserExists(string username)
		{
			return Users.Any(u =>
				u.Username.Equals(username, StringComparison.OrdinalIgnoreCase));
		}
	}
}
