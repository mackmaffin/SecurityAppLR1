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
using UserAuthenticationLab.Services;

namespace UserAuthenticationLab.Forms
{
	public partial class UserForm : Form
	{
		private User _user;
		private PasswordHasher _passwordHasher;

		public UserForm(User user)
		{
			InitializeComponent();
			_user = user;
			_passwordHasher = new PasswordHasher();

			lblUserInfo.Text = $"Смена пароля для пользователя: {_user.Username}";
		}

		private void btnChangePassword_Click(object sender, EventArgs e)
		{
			try
			{
				if (!_passwordHasher.VerifyPassword(txtOldPassword.Text, _user.PasswordHash))
				{
					MessageBox.Show("Неверный старый пароль!", "Ошибка",
						MessageBoxButtons.OK, MessageBoxIcon.Error);
					return;
				}

				if (txtNewPassword.Text != txtConfirmPassword.Text)
				{
					MessageBox.Show("Новый пароль и подтверждение не совпадают!", "Ошибка",
						MessageBoxButtons.OK, MessageBoxIcon.Error);
					return;
				}

				if (txtNewPassword.Text.Length < _user.MinPasswordLength)
				{
					MessageBox.Show($"Минимальная длина пароля: {_user.MinPasswordLength} символов!",
						"Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
					return;
				}
				
				if (_user.PasswordRestrictions && !PasswordValidator.ValidatePassword(txtNewPassword.Text))
				{
					MessageBox.Show("Пароль не соответствует требованиям!\n" +
						"Должны быть: строчные и прописные буквы, арифметические операции (+, -, *, /)",
						"Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
					return;
				}

				_user.PasswordHash = _passwordHasher.ComputeMD4Hash(txtNewPassword.Text);
				_user.PasswordSetDate = DateTime.Now;

				MessageBox.Show("Пароль успешно изменен!", "Успех",
					MessageBoxButtons.OK, MessageBoxIcon.Information);

				txtOldPassword.Text = "";
				txtNewPassword.Text = "";
				txtConfirmPassword.Text = "";

				this.DialogResult = DialogResult.OK;
				this.Close();
			}
			catch (Exception ex)
			{
				MessageBox.Show($"Ошибка при смене пароля: {ex.Message}", "Ошибка",
					MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void btnExit_Click(object sender, EventArgs e)
		{
			this.DialogResult = DialogResult.Cancel;
			this.Close();
		}
	}
}
