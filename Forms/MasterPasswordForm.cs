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
	public partial class MasterPasswordForm : Form
	{
		public string MasterPassword;
		public bool IsAuthenticated { get; private set; } = false;

		public MasterPasswordForm()
		{
			InitializeComponent();
		}

		private void btnOK_Click(object sender, EventArgs e)
		{
			try
			{
				if (string.IsNullOrEmpty(txtMasterPassword.Text))
				{
					MessageBox.Show("Парольная фраза не может быть пустой!", "Ошибка",
						MessageBoxButtons.OK, MessageBoxIcon.Error);
					return;
				}

				Program.AppData = Program.DataManager.LoadData(txtMasterPassword.Text);
				IsAuthenticated = true;
				Program.MasterPassword = txtMasterPassword.Text;
				this.DialogResult = DialogResult.OK;
				this.Close();
			}
			catch (Exception ex)
			{
				MessageBox.Show($"Ошибка: {ex.Message}\nПроверьте парольную фразу.", "Ошибка доступа",
					MessageBoxButtons.OK, MessageBoxIcon.Error);
				txtMasterPassword.Text = "";
				txtMasterPassword.Focus();
			}
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			Application.Exit();
		}
	}
}
