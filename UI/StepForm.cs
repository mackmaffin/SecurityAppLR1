using System;
using System.Data;
using System.Text;
using System.Windows.Forms;
using SecurityAppLR2.Core;

namespace SecurityAppLR2.UI
{
	public partial class StepForm : Form
	{
		readonly byte[] data;

		public StepForm()
		{
			InitializeComponent();
		}

		public StepForm(byte[] source) : this()
		{
			data = source;
			Load += (s, e) => InitAndCalc();
			btnCalk.Click += (s, e) => Calc();
		}

		void InitAndCalc()
		{
			cmbStep.Items.Clear();
			for (int i = 0; i < 64; i++) cmbStep.Items.Add(i);
			cmbStep.SelectedIndex = 0;
			Calc();
		}

		void Calc()
		{
			int i = (int)cmbStep.SelectedItem;
			var r = Md5.AnalyzeOneStep(data, i);

			var dt = new DataTable();
			dt.Columns.Add("Параметр", typeof(string));
			dt.Columns.Add("Значение", typeof(string));

			dt.Rows.Add("i", r.Step.ToString());
			dt.Rows.Add("A до", Hex(r.A_Before));
			dt.Rows.Add("B до", Hex(r.B_Before));
			dt.Rows.Add("C до", Hex(r.C_Before));
			dt.Rows.Add("D до", Hex(r.D_Before));
			dt.Rows.Add("F", Hex(r.F));
			dt.Rows.Add("g", r.GIndex.ToString());
			dt.Rows.Add("M[g]", Hex(r.M_g));
			dt.Rows.Add("K[i]", Hex(r.K_i));
			dt.Rows.Add("S[i]", r.S_i.ToString());
			dt.Rows.Add("Sum", Hex(r.Sum));
			dt.Rows.Add("Rol(Sum,S)", Hex(r.Rot));
			dt.Rows.Add("A после", Hex(r.A_After));
			dt.Rows.Add("B после", Hex(r.B_After));
			dt.Rows.Add("C после", Hex(r.C_After));
			dt.Rows.Add("D после", Hex(r.D_After));

			grid.DataSource = dt;
		}

		string Hex(uint v) => v.ToString("x8");
	}
}
