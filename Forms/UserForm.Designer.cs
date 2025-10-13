namespace UserAuthenticationLab.Forms
{
	partial class UserForm
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.lblUserInfo = new System.Windows.Forms.Label();
			this.txtOldPassword = new System.Windows.Forms.TextBox();
			this.txtNewPassword = new System.Windows.Forms.TextBox();
			this.txtConfirmPassword = new System.Windows.Forms.TextBox();
			this.btnExit = new System.Windows.Forms.Button();
			this.btnChangePassword = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// lblUserInfo
			// 
			this.lblUserInfo.AutoSize = true;
			this.lblUserInfo.Location = new System.Drawing.Point(32, 32);
			this.lblUserInfo.Name = "lblUserInfo";
			this.lblUserInfo.Size = new System.Drawing.Size(269, 32);
			this.lblUserInfo.TabIndex = 0;
			this.lblUserInfo.Text = "Смена пароля пользователя [Username]\r\n\r\n";
			// 
			// txtOldPassword
			// 
			this.txtOldPassword.Location = new System.Drawing.Point(35, 58);
			this.txtOldPassword.Name = "txtOldPassword";
			this.txtOldPassword.Size = new System.Drawing.Size(403, 22);
			this.txtOldPassword.TabIndex = 1;
			this.txtOldPassword.UseSystemPasswordChar = true;
			// 
			// txtNewPassword
			// 
			this.txtNewPassword.Location = new System.Drawing.Point(35, 126);
			this.txtNewPassword.Name = "txtNewPassword";
			this.txtNewPassword.Size = new System.Drawing.Size(403, 22);
			this.txtNewPassword.TabIndex = 2;
			this.txtNewPassword.UseSystemPasswordChar = true;
			// 
			// txtConfirmPassword
			// 
			this.txtConfirmPassword.Location = new System.Drawing.Point(35, 154);
			this.txtConfirmPassword.Name = "txtConfirmPassword";
			this.txtConfirmPassword.Size = new System.Drawing.Size(403, 22);
			this.txtConfirmPassword.TabIndex = 3;
			this.txtConfirmPassword.UseSystemPasswordChar = true;
			// 
			// btnExit
			// 
			this.btnExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnExit.Location = new System.Drawing.Point(35, 195);
			this.btnExit.Name = "btnExit";
			this.btnExit.Size = new System.Drawing.Size(100, 38);
			this.btnExit.TabIndex = 4;
			this.btnExit.Text = "Выход";
			this.btnExit.UseVisualStyleBackColor = true;
			this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
			// 
			// btnChangePassword
			// 
			this.btnChangePassword.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnChangePassword.Location = new System.Drawing.Point(299, 195);
			this.btnChangePassword.Name = "btnChangePassword";
			this.btnChangePassword.Size = new System.Drawing.Size(139, 38);
			this.btnChangePassword.TabIndex = 5;
			this.btnChangePassword.Text = "Сменить пароль";
			this.btnChangePassword.UseVisualStyleBackColor = true;
			this.btnChangePassword.Click += new System.EventHandler(this.btnChangePassword_Click);
			// 
			// UserForm
			// 
			this.AcceptButton = this.btnChangePassword;
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.btnExit;
			this.ClientSize = new System.Drawing.Size(474, 264);
			this.Controls.Add(this.btnChangePassword);
			this.Controls.Add(this.btnExit);
			this.Controls.Add(this.txtConfirmPassword);
			this.Controls.Add(this.txtNewPassword);
			this.Controls.Add(this.txtOldPassword);
			this.Controls.Add(this.lblUserInfo);
			this.Name = "UserForm";
			this.Text = "Форма пользователя";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label lblUserInfo;
		private System.Windows.Forms.TextBox txtOldPassword;
		private System.Windows.Forms.TextBox txtNewPassword;
		private System.Windows.Forms.TextBox txtConfirmPassword;
		private System.Windows.Forms.Button btnExit;
		private System.Windows.Forms.Button btnChangePassword;
	}
}