namespace SecurityAppLR2.UI
{
	partial class MainForm
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
			this.txtStudent = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.txtGroup = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.txtVariant = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.txtPath = new System.Windows.Forms.TextBox();
			this.btnBrowse = new System.Windows.Forms.Button();
			this.label5 = new System.Windows.Forms.Label();
			this.txtHash = new System.Windows.Forms.TextBox();
			this.btnHash = new System.Windows.Forms.Button();
			this.btnCopy = new System.Windows.Forms.Button();
			this.btnSave = new System.Windows.Forms.Button();
			this.btnOneStep = new System.Windows.Forms.Button();
			this.btnAlgo = new System.Windows.Forms.Button();
			this.btnSelfTest = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// txtStudent
			// 
			this.txtStudent.Location = new System.Drawing.Point(12, 38);
			this.txtStudent.Name = "txtStudent";
			this.txtStudent.ReadOnly = true;
			this.txtStudent.Size = new System.Drawing.Size(213, 22);
			this.txtStudent.TabIndex = 0;
			this.txtStudent.Text = "Яшин Артём Александрович";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 19);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(38, 16);
			this.label1.TabIndex = 1;
			this.label1.Text = "ФИО";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(230, 19);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(54, 16);
			this.label2.TabIndex = 3;
			this.label2.Text = "Группа";
			// 
			// txtGroup
			// 
			this.txtGroup.Location = new System.Drawing.Point(231, 38);
			this.txtGroup.Name = "txtGroup";
			this.txtGroup.ReadOnly = true;
			this.txtGroup.Size = new System.Drawing.Size(68, 22);
			this.txtGroup.TabIndex = 2;
			this.txtGroup.Text = "ПИбд-43";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(305, 19);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(63, 16);
			this.label3.TabIndex = 5;
			this.label3.Text = "Вариант";
			// 
			// txtVariant
			// 
			this.txtVariant.Location = new System.Drawing.Point(305, 38);
			this.txtVariant.Name = "txtVariant";
			this.txtVariant.ReadOnly = true;
			this.txtVariant.Size = new System.Drawing.Size(63, 22);
			this.txtVariant.TabIndex = 4;
			this.txtVariant.Text = "2 (MD5)";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(12, 90);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(42, 16);
			this.label4.TabIndex = 7;
			this.label4.Text = "Файл";
			// 
			// txtPath
			// 
			this.txtPath.Location = new System.Drawing.Point(12, 109);
			this.txtPath.Name = "txtPath";
			this.txtPath.ReadOnly = true;
			this.txtPath.Size = new System.Drawing.Size(244, 22);
			this.txtPath.TabIndex = 6;
			// 
			// btnBrowse
			// 
			this.btnBrowse.Location = new System.Drawing.Point(265, 100);
			this.btnBrowse.Name = "btnBrowse";
			this.btnBrowse.Size = new System.Drawing.Size(89, 41);
			this.btnBrowse.TabIndex = 8;
			this.btnBrowse.Text = "Выбрать";
			this.btnBrowse.UseVisualStyleBackColor = true;
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(374, 19);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(35, 16);
			this.label5.TabIndex = 10;
			this.label5.Text = "MD5";
			// 
			// txtHash
			// 
			this.txtHash.Font = new System.Drawing.Font("Consolas", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.txtHash.Location = new System.Drawing.Point(377, 38);
			this.txtHash.Multiline = true;
			this.txtHash.Name = "txtHash";
			this.txtHash.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.txtHash.Size = new System.Drawing.Size(336, 323);
			this.txtHash.TabIndex = 9;
			// 
			// btnHash
			// 
			this.btnHash.Location = new System.Drawing.Point(12, 150);
			this.btnHash.Name = "btnHash";
			this.btnHash.Size = new System.Drawing.Size(110, 37);
			this.btnHash.TabIndex = 11;
			this.btnHash.Text = "Вычислить";
			this.btnHash.UseVisualStyleBackColor = true;
			// 
			// btnCopy
			// 
			this.btnCopy.Location = new System.Drawing.Point(128, 150);
			this.btnCopy.Name = "btnCopy";
			this.btnCopy.Size = new System.Drawing.Size(110, 37);
			this.btnCopy.TabIndex = 12;
			this.btnCopy.Text = "Копировать";
			this.btnCopy.UseVisualStyleBackColor = true;
			// 
			// btnSave
			// 
			this.btnSave.Location = new System.Drawing.Point(244, 150);
			this.btnSave.Name = "btnSave";
			this.btnSave.Size = new System.Drawing.Size(110, 37);
			this.btnSave.TabIndex = 13;
			this.btnSave.Text = "Сохранить";
			this.btnSave.UseVisualStyleBackColor = true;
			// 
			// btnOneStep
			// 
			this.btnOneStep.Location = new System.Drawing.Point(12, 313);
			this.btnOneStep.Name = "btnOneStep";
			this.btnOneStep.Size = new System.Drawing.Size(110, 48);
			this.btnOneStep.TabIndex = 14;
			this.btnOneStep.Text = "Один цикл";
			this.btnOneStep.UseVisualStyleBackColor = true;
			// 
			// btnAlgo
			// 
			this.btnAlgo.Location = new System.Drawing.Point(244, 313);
			this.btnAlgo.Name = "btnAlgo";
			this.btnAlgo.Size = new System.Drawing.Size(110, 48);
			this.btnAlgo.TabIndex = 15;
			this.btnAlgo.Text = "Алгоритм MD5";
			this.btnAlgo.UseVisualStyleBackColor = true;
			// 
			// btnSelfTest
			// 
			this.btnSelfTest.Location = new System.Drawing.Point(128, 313);
			this.btnSelfTest.Name = "btnSelfTest";
			this.btnSelfTest.Size = new System.Drawing.Size(110, 48);
			this.btnSelfTest.TabIndex = 16;
			this.btnSelfTest.Text = "Проверка";
			this.btnSelfTest.UseVisualStyleBackColor = true;
			// 
			// MainForm
			// 
			this.AllowDrop = true;
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(742, 373);
			this.Controls.Add(this.btnSelfTest);
			this.Controls.Add(this.btnAlgo);
			this.Controls.Add(this.btnOneStep);
			this.Controls.Add(this.btnSave);
			this.Controls.Add(this.btnCopy);
			this.Controls.Add(this.btnHash);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.txtHash);
			this.Controls.Add(this.btnBrowse);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.txtPath);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.txtVariant);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.txtGroup);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.txtStudent);
			this.Name = "MainForm";
			this.Text = "Главная форма";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox txtStudent;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox txtGroup;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox txtVariant;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox txtPath;
		private System.Windows.Forms.Button btnBrowse;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox txtHash;
		private System.Windows.Forms.Button btnHash;
		private System.Windows.Forms.Button btnCopy;
		private System.Windows.Forms.Button btnSave;
		private System.Windows.Forms.Button btnOneStep;
		private System.Windows.Forms.Button btnAlgo;
		private System.Windows.Forms.Button btnSelfTest;
	}
}