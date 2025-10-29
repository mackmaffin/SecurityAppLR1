namespace SecurityAppLR2.UI
{
	partial class StepForm
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
			this.cmbStep = new System.Windows.Forms.ComboBox();
			this.label1 = new System.Windows.Forms.Label();
			this.btnCalk = new System.Windows.Forms.Button();
			this.grid = new System.Windows.Forms.DataGridView();
			((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
			this.SuspendLayout();
			// 
			// cmbStep
			// 
			this.cmbStep.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbStep.FormattingEnabled = true;
			this.cmbStep.Location = new System.Drawing.Point(12, 36);
			this.cmbStep.Name = "cmbStep";
			this.cmbStep.Size = new System.Drawing.Size(102, 24);
			this.cmbStep.TabIndex = 0;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 17);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(38, 16);
			this.label1.TabIndex = 1;
			this.label1.Text = "Шаг i";
			// 
			// btnCalk
			// 
			this.btnCalk.Location = new System.Drawing.Point(135, 36);
			this.btnCalk.Name = "btnCalk";
			this.btnCalk.Size = new System.Drawing.Size(112, 23);
			this.btnCalk.TabIndex = 2;
			this.btnCalk.Text = "Рассчитать";
			this.btnCalk.UseVisualStyleBackColor = true;
			// 
			// grid
			// 
			this.grid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
			this.grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.grid.Location = new System.Drawing.Point(12, 78);
			this.grid.Name = "grid";
			this.grid.ReadOnly = true;
			this.grid.RowHeadersWidth = 51;
			this.grid.RowTemplate.Height = 24;
			this.grid.Size = new System.Drawing.Size(818, 403);
			this.grid.TabIndex = 3;
			// 
			// StepForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(842, 493);
			this.Controls.Add(this.grid);
			this.Controls.Add(this.btnCalk);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.cmbStep);
			this.Name = "StepForm";
			this.Text = "StepForm";
			((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ComboBox cmbStep;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button btnCalk;
		private System.Windows.Forms.DataGridView grid;
	}
}