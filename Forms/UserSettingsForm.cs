using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UserAuthenticationLab.Models;

namespace UserAuthenticationLab.Forms
{
	public partial class UserSettingsForm : Form
	{
		private User _user;
		public string Username;

		public UserSettingsForm(User user)
		{
			InitializeComponent();
			_user = user;
			LoadUserSettings();
		}

		private void LoadUserSettings()
		{
			txtUsername.Text = _user.Username;
			chkBlocked.Checked = _user.IsBlocked;
			chkPasswordRestrictions.Checked = _user.PasswordRestrictions;
			numMinPasswordLength.Value = _user.MinPasswordLength;
			numPasswordExpiry.Value = _user.PasswordExpiryMonths;
		}

		private void btnSave_Click(object sender, EventArgs e)
		{
			Username = txtUsername.Text;
			_user.IsBlocked = chkBlocked.Checked;
			_user.PasswordRestrictions = chkPasswordRestrictions.Checked;
			_user.MinPasswordLength = (int)numMinPasswordLength.Value;
			_user.PasswordExpiryMonths = (int)numPasswordExpiry.Value;

			this.DialogResult = DialogResult.OK;
			this.Close();
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			this.DialogResult = DialogResult.Cancel;
			this.Close();
		}
	}
}
