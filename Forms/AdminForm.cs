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
	public partial class AdminForm : Form
	{
		private ApplicationData _appData;
		private PasswordHasher _passwordHasher;

		public AdminForm()
		{
			InitializeComponent();
			_appData = Program.AppData;
			_passwordHasher = new PasswordHasher();
			LoadUsers();
		}

		private void LoadUsers()
		{
			if (dgvUsers.Columns.Count == 0)
			{
				dgvUsers.AutoGenerateColumns = false;
				dgvUsers.Columns.AddRange(new DataGridViewColumn[]
				{
			new DataGridViewTextBoxColumn() { Name = "Username", HeaderText = "Имя пользователя", DataPropertyName = "Username", Width = 120 },
			new DataGridViewTextBoxColumn() { Name = "IsBlocked", HeaderText = "Заблокирован", DataPropertyName = "IsBlocked", Width = 100 },
			new DataGridViewTextBoxColumn() { Name = "PasswordRestrictions", HeaderText = "Ограничения", DataPropertyName = "PasswordRestrictions", Width = 100 },
			new DataGridViewTextBoxColumn() { Name = "MinPasswordLength", HeaderText = "Мин. длина", DataPropertyName = "MinPasswordLength", Width = 80 },
			new DataGridViewTextBoxColumn() { Name = "PasswordExpiryMonths", HeaderText = "Срок действия (мес.)", DataPropertyName = "PasswordExpiryMonths", Width = 120 },
			new DataGridViewTextBoxColumn() { Name = "PasswordSetDate", HeaderText = "Дата установки", DataPropertyName = "PasswordSetDate", Width = 120 }
				});
			}

			dgvUsers.Rows.Clear();

			foreach (var user in _appData.Users)
			{
				dgvUsers.Rows.Add(
					user.Username,
					user.IsBlocked ? "Да" : "Нет",
					user.PasswordRestrictions ? "Вкл" : "Выкл",
					user.MinPasswordLength,
					user.PasswordExpiryMonths,
					user.PasswordSetDate.ToShortDateString()
				);
			}
		}

		private void btnAddUser_Click(object sender, EventArgs e)
		{
			using (var form = new AddUserForm())
			{
				if (form.ShowDialog() == DialogResult.OK)
				{
					var newUser = new User
					{
						Username = form.Username,
						PasswordHash = "", 
						IsBlocked = false,
						PasswordRestrictions = false,
						MinPasswordLength = 0,
						PasswordExpiryMonths = 0
					};

					if (_appData.UserExists(newUser.Username))
					{
						MessageBox.Show("Пользователь с таким именем уже существует!", "Ошибка");
						return;
					}

					_appData.Users.Add(newUser);
					LoadUsers();
				}
			}
		}

		private void btnBlockUser_Click(object sender, EventArgs e)
		{
			if (dgvUsers.CurrentRow == null) return;

			string username = dgvUsers.CurrentRow.Cells[0].Value.ToString();
			var user = _appData.FindUser(username);

			if (user != null && user.Username != AppConstants.ADMIN_USERNAME)
			{
				user.IsBlocked = !user.IsBlocked;
				LoadUsers();
			}
		}

		private void btnChangeAdminPassword_Click(object sender, EventArgs e)
		{
			using (var form = new UserForm(_appData.FindUser(AppConstants.ADMIN_USERNAME)))
			{
				form.ShowDialog();
			}
		}

		private void dgvUsers_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
		{
			try
			{
				if (e.RowIndex < 0) return;

				string username = dgvUsers.Rows[e.RowIndex].Cells[0].Value.ToString();
				var user = _appData.FindUser(username);

				using (var form = new UserSettingsForm(user))
				{
					if (_appData.UserExists(form.Username))
					{
						MessageBox.Show("Пользователь с таким именем уже существует!", "Ошибка");
						return;
					}
					if (form.ShowDialog() == DialogResult.OK)
					{
						LoadUsers();
					}
				}
			} catch (Exception ex)
			{
				MessageBox.Show("Пользователь не выбран", "Ошибка", MessageBoxButtons.OK);
				return;
			}
		}

		private void оПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
		{
			MessageBox.Show(
				"Программа разграничения полномочий пользователей\n" +
				"Вариант 1: Наличие строчных/прописных букв и арифметических операций\n" +
				"Шифрование: ECB + salt, Хеширование: MD4\n" +
				"Разработчик: Яшин Артём ПИбд-43",
				"О программе"
			);
		}
	}
}
