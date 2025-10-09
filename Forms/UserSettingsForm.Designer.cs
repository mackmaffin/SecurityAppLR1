namespace UserAuthenticationLab.Forms
{
	partial class UserSettingsForm
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
			this.txtUsername = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.chkBlocked = new System.Windows.Forms.CheckBox();
			this.chkPasswordRestrictions = new System.Windows.Forms.CheckBox();
			this.label2 = new System.Windows.Forms.Label();
			this.numMinPasswordLength = new System.Windows.Forms.NumericUpDown();
			this.label3 = new System.Windows.Forms.Label();
			this.numPasswordExpiry = new System.Windows.Forms.NumericUpDown();
			this.btnSave = new System.Windows.Forms.Button();
			this.btnCancel = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.numMinPasswordLength)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numPasswordExpiry)).BeginInit();
			this.SuspendLayout();
			// 
			// txtUsername
			// 
			this.txtUsername.Location = new System.Drawing.Point(12, 40);
			this.txtUsername.Name = "txtUsername";
			this.txtUsername.Size = new System.Drawing.Size(341, 22);
			this.txtUsername.TabIndex = 0;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(9, 21);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(129, 16);
			this.label1.TabIndex = 1;
			this.label1.Text = "Имя пользователя";
			// 
			// chkBlocked
			// 
			this.chkBlocked.AutoSize = true;
			this.chkBlocked.Location = new System.Drawing.Point(12, 68);
			this.chkBlocked.Name = "chkBlocked";
			this.chkBlocked.Size = new System.Drawing.Size(204, 20);
			this.chkBlocked.TabIndex = 2;
			this.chkBlocked.Text = "Блокировка пользователя";
			this.chkBlocked.UseVisualStyleBackColor = true;
			// 
			// chkPasswordRestrictions
			// 
			this.chkPasswordRestrictions.AutoSize = true;
			this.chkPasswordRestrictions.Location = new System.Drawing.Point(12, 94);
			this.chkPasswordRestrictions.Name = "chkPasswordRestrictions";
			this.chkPasswordRestrictions.Size = new System.Drawing.Size(167, 20);
			this.chkPasswordRestrictions.TabIndex = 3;
			this.chkPasswordRestrictions.Text = "Ограничение пароля";
			this.chkPasswordRestrictions.UseVisualStyleBackColor = true;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(9, 127);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(190, 16);
			this.label2.TabIndex = 4;
			this.label2.Text = "Минимальная длина пароля";
			// 
			// numMinPasswordLength
			// 
			this.numMinPasswordLength.Location = new System.Drawing.Point(233, 125);
			this.numMinPasswordLength.Name = "numMinPasswordLength";
			this.numMinPasswordLength.Size = new System.Drawing.Size(120, 22);
			this.numMinPasswordLength.TabIndex = 5;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(9, 156);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(212, 16);
			this.label3.TabIndex = 6;
			this.label3.Text = "Срок действия пароля (месяцы)";
			// 
			// numPasswordExpiry
			// 
			this.numPasswordExpiry.Location = new System.Drawing.Point(233, 153);
			this.numPasswordExpiry.Name = "numPasswordExpiry";
			this.numPasswordExpiry.Size = new System.Drawing.Size(120, 22);
			this.numPasswordExpiry.TabIndex = 7;
			// 
			// btnSave
			// 
			this.btnSave.Location = new System.Drawing.Point(259, 193);
			this.btnSave.Name = "btnSave";
			this.btnSave.Size = new System.Drawing.Size(94, 29);
			this.btnSave.TabIndex = 8;
			this.btnSave.Text = "Сохранить";
			this.btnSave.UseVisualStyleBackColor = true;
			this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
			// 
			// btnCancel
			// 
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new System.Drawing.Point(12, 193);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(94, 29);
			this.btnCancel.TabIndex = 9;
			this.btnCancel.Text = "Отмена";
			this.btnCancel.UseVisualStyleBackColor = true;
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// UserSettingsForm
			// 
			this.AcceptButton = this.btnSave;
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.btnCancel;
			this.ClientSize = new System.Drawing.Size(365, 245);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnSave);
			this.Controls.Add(this.numPasswordExpiry);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.numMinPasswordLength);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.chkPasswordRestrictions);
			this.Controls.Add(this.chkBlocked);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.txtUsername);
			this.Name = "UserSettingsForm";
			this.Text = "Настройки пользователя";
			((System.ComponentModel.ISupportInitialize)(this.numMinPasswordLength)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numPasswordExpiry)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox txtUsername;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.CheckBox chkBlocked;
		private System.Windows.Forms.CheckBox chkPasswordRestrictions;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.NumericUpDown numMinPasswordLength;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.NumericUpDown numPasswordExpiry;
		private System.Windows.Forms.Button btnSave;
		private System.Windows.Forms.Button btnCancel;
	}
}