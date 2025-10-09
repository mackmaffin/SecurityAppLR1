namespace UserAuthenticationLab.Forms
{
	partial class AdminForm
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
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.главноеМенюToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.dgvUsers = new System.Windows.Forms.DataGridView();
			this.btnAddUser = new System.Windows.Forms.Button();
			this.btnBlockUser = new System.Windows.Forms.Button();
			this.btnChangeAdminPassword = new System.Windows.Forms.Button();
			this.добавитьПользователяToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.блокироватьПользователяToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.изменитьПароляАдминаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.оПрограммеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.menuStrip1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvUsers)).BeginInit();
			this.SuspendLayout();
			// 
			// menuStrip1
			// 
			this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.главноеМенюToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(800, 28);
			this.menuStrip1.TabIndex = 0;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// главноеМенюToolStripMenuItem
			// 
			this.главноеМенюToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.добавитьПользователяToolStripMenuItem,
            this.блокироватьПользователяToolStripMenuItem,
            this.изменитьПароляАдминаToolStripMenuItem,
            this.оПрограммеToolStripMenuItem});
			this.главноеМенюToolStripMenuItem.Name = "главноеМенюToolStripMenuItem";
			this.главноеМенюToolStripMenuItem.Size = new System.Drawing.Size(124, 24);
			this.главноеМенюToolStripMenuItem.Text = "Главное меню";
			// 
			// dgvUsers
			// 
			this.dgvUsers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvUsers.Location = new System.Drawing.Point(12, 31);
			this.dgvUsers.Name = "dgvUsers";
			this.dgvUsers.RowHeadersWidth = 51;
			this.dgvUsers.RowTemplate.Height = 24;
			this.dgvUsers.Size = new System.Drawing.Size(634, 407);
			this.dgvUsers.TabIndex = 1;
			this.dgvUsers.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvUsers_CellDoubleClick);
			// 
			// btnAddUser
			// 
			this.btnAddUser.Location = new System.Drawing.Point(653, 31);
			this.btnAddUser.Name = "btnAddUser";
			this.btnAddUser.Size = new System.Drawing.Size(135, 52);
			this.btnAddUser.TabIndex = 2;
			this.btnAddUser.Text = "Добавить пользователя";
			this.btnAddUser.UseVisualStyleBackColor = true;
			this.btnAddUser.Click += new System.EventHandler(this.btnAddUser_Click);
			// 
			// btnBlockUser
			// 
			this.btnBlockUser.Location = new System.Drawing.Point(653, 90);
			this.btnBlockUser.Name = "btnBlockUser";
			this.btnBlockUser.Size = new System.Drawing.Size(135, 52);
			this.btnBlockUser.TabIndex = 3;
			this.btnBlockUser.Text = "Блокировать пользователя";
			this.btnBlockUser.UseVisualStyleBackColor = true;
			this.btnBlockUser.Click += new System.EventHandler(this.btnBlockUser_Click);
			// 
			// btnChangeAdminPassword
			// 
			this.btnChangeAdminPassword.Location = new System.Drawing.Point(653, 148);
			this.btnChangeAdminPassword.Name = "btnChangeAdminPassword";
			this.btnChangeAdminPassword.Size = new System.Drawing.Size(135, 52);
			this.btnChangeAdminPassword.TabIndex = 4;
			this.btnChangeAdminPassword.Text = "Изменить пароль админа";
			this.btnChangeAdminPassword.UseVisualStyleBackColor = true;
			this.btnChangeAdminPassword.Click += new System.EventHandler(this.btnChangeAdminPassword_Click);
			// 
			// добавитьПользователяToolStripMenuItem
			// 
			this.добавитьПользователяToolStripMenuItem.Name = "добавитьПользователяToolStripMenuItem";
			this.добавитьПользователяToolStripMenuItem.Size = new System.Drawing.Size(282, 26);
			this.добавитьПользователяToolStripMenuItem.Text = "Добавить пользователя";
			// 
			// блокироватьПользователяToolStripMenuItem
			// 
			this.блокироватьПользователяToolStripMenuItem.Name = "блокироватьПользователяToolStripMenuItem";
			this.блокироватьПользователяToolStripMenuItem.Size = new System.Drawing.Size(282, 26);
			this.блокироватьПользователяToolStripMenuItem.Text = "Блокировать пользователя";
			// 
			// изменитьПароляАдминаToolStripMenuItem
			// 
			this.изменитьПароляАдминаToolStripMenuItem.Name = "изменитьПароляАдминаToolStripMenuItem";
			this.изменитьПароляАдминаToolStripMenuItem.Size = new System.Drawing.Size(282, 26);
			this.изменитьПароляАдминаToolStripMenuItem.Text = "Изменить пароля админа";
			// 
			// оПрограммеToolStripMenuItem
			// 
			this.оПрограммеToolStripMenuItem.Name = "оПрограммеToolStripMenuItem";
			this.оПрограммеToolStripMenuItem.Size = new System.Drawing.Size(282, 26);
			this.оПрограммеToolStripMenuItem.Text = "О программе";
			this.оПрограммеToolStripMenuItem.Click += new System.EventHandler(this.оПрограммеToolStripMenuItem_Click);
			// 
			// AdminForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 450);
			this.Controls.Add(this.btnChangeAdminPassword);
			this.Controls.Add(this.btnBlockUser);
			this.Controls.Add(this.btnAddUser);
			this.Controls.Add(this.dgvUsers);
			this.Controls.Add(this.menuStrip1);
			this.MainMenuStrip = this.menuStrip1;
			this.Name = "AdminForm";
			this.Text = "AdminForm";
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvUsers)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem главноеМенюToolStripMenuItem;
		private System.Windows.Forms.DataGridView dgvUsers;
		private System.Windows.Forms.Button btnAddUser;
		private System.Windows.Forms.Button btnBlockUser;
		private System.Windows.Forms.Button btnChangeAdminPassword;
		private System.Windows.Forms.ToolStripMenuItem добавитьПользователяToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem блокироватьПользователяToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem изменитьПароляАдминаToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem оПрограммеToolStripMenuItem;
	}
}