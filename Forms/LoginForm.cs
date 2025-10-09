using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UserAuthenticationLab.Forms;
using UserAuthenticationLab.Models;
using UserAuthenticationLab.Services;

namespace UserAuthenticationLab
{
	public partial class LoginForm : Form
	{
		private int _loginAttempts = 0;
		private PasswordHasher _passwordHasher;

		public LoginForm()
		{
			InitializeComponent();
			_passwordHasher = new PasswordHasher();
		}

		private void btnLogin_Click(object sender, EventArgs e)
		{
			string username = txtUsername.Text.Trim();
			string password = txtPassword.Text;

			if (string.IsNullOrEmpty(username))
			{
				MessageBox.Show("Введите имя пользователя!", "Ошибка",
					MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}

			var user = Program.AppData?.FindUser(username);
			if (user == null)
			{
				_loginAttempts++;
				MessageBox.Show($"Пользователь '{username}' не найден. Попытка {_loginAttempts}/3",
					"Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				txtPassword.Text = "";
				txtUsername.Focus();
				if (_loginAttempts >= AppConstants.MAX_LOGIN_ATTEMPTS)
				{
					MessageBox.Show("Превышено количество попыток входа. Программа будет закрыта.",
						"Блокировка", MessageBoxButtons.OK, MessageBoxIcon.Error);
					Application.Exit();
				}
				return;
			}

			if (user.IsBlocked)
			{
				MessageBox.Show("Учетная запись заблокирована. Обратитесь к администратору.",
					"Блокировка", MessageBoxButtons.OK, MessageBoxIcon.Error);
				txtPassword.Text = "";
				return;
			}

			if (!_passwordHasher.VerifyPassword(password, user.PasswordHash))
			{
				_loginAttempts++;
				MessageBox.Show($"Неверный пароль. Попытка {_loginAttempts}/3",
					"Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				txtPassword.Text = "";
				txtPassword.Focus();
				if (_loginAttempts >= AppConstants.MAX_LOGIN_ATTEMPTS)
				{
					MessageBox.Show("Превышено количество попыток входа. Программа будет закрыта.",
						"Блокировка", MessageBoxButtons.OK, MessageBoxIcon.Error);
					Application.Exit();
				}
				return;
			}


			if (user.PasswordExpiryMonths > 0 &&
				DateTime.Now > user.PasswordSetDate.AddMonths(user.PasswordExpiryMonths))
			{
				MessageBox.Show("Срок действия пароля истек. Необходимо сменить пароль.",
					"Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
			}

			_loginAttempts = 0;

			if (username.ToUpper() == AppConstants.ADMIN_USERNAME)
			{
				var adminForm = new AdminForm();
				this.Hide();
				adminForm.ShowDialog();
				this.Show();
			}
			else
			{
				var userForm = new UserForm(user);
				this.Hide();
				userForm.ShowDialog();
				this.Show();
			}

			txtPassword.Text = "";
		}

		private void btnExit_Click(object sender, EventArgs e)
		{
			SaveBeforeClosing();
			Application.Exit();
		}

		private void LoginForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			SaveBeforeClosing();
		}

		private void SaveBeforeClosing()
		{
			try
			{
				if (Program.DataManager != null && !string.IsNullOrEmpty(Program.MasterPassword))
				{
					bool success = Program.DataManager.SaveData(Program.MasterPassword);
					if (!success)
					{
						MessageBox.Show("Ошибка при сохранении данных!", "Ошибка",
							MessageBoxButtons.OK, MessageBoxIcon.Error);
					}
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show($"Ошибка сохранения: {ex.Message}", "Ошибка",
					MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}
	}
}
