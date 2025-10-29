using System;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using SecurityAppLR2.Core;

namespace SecurityAppLR2.UI
{
	public partial class MainForm : Form
	{
		public MainForm()
		{
			InitializeComponent();
			AllowDrop = true;
			DragEnter += OnDragEnter;
			DragDrop += OnDragDrop;
			btnBrowse.Click += OnBrowse;
			btnHash.Click += OnHash;
			btnCopy.Click += (s, e) => { if (!string.IsNullOrEmpty(txtHash.Text)) Clipboard.SetText(txtHash.Text); };
			btnSave.Click += OnSave;
			btnOneStep.Click += OnOneStep;
			btnAlgo.Click += (s, e) => new AlgorithmForm().ShowDialog(this);
			btnSelfTest.Click += OnSelfTest;
		}

		void OnBrowse(object sender, EventArgs e)
		{
			OpenFileDialog openFileDialog = new OpenFileDialog { Title = "Выберите файл (≥ 1 КБ)", Filter = "Все файлы|*.*" };
			var ofd = openFileDialog;
			if (ofd.ShowDialog(this) == DialogResult.OK)
			{
				txtPath.Text = ofd.FileName;
				var len = new FileInfo(ofd.FileName).Length;
				if (len < 1024) MessageBox.Show(this, "Нужен файл не менее 1 КБ", "Предупреждение");
			}
		}

		void OnHash(object sender, EventArgs e)
		{
			if (string.IsNullOrWhiteSpace(txtPath.Text) || !File.Exists(txtPath.Text))
			{
				MessageBox.Show(this, "Сначала выберите файл", "Ошибка");
				return;
			}
			try
			{
				txtHash.Text = Md5.ComputeFileHashHex(txtPath.Text);
			}
			catch (Exception ex)
			{
				MessageBox.Show(this, ex.Message, "Ошибка");
			}
		}

		void OnSave(object sender, EventArgs e)
		{
			if (string.IsNullOrWhiteSpace(txtHash.Text))
			{
				MessageBox.Show(this, "Нет данных для сохранения", "Ошибка");
				return;
			}
			var sfd = new SaveFileDialog { Title = "Сохранить MD5", Filter = "Текст|*.txt", FileName = "hash.txt" };
			if (sfd.ShowDialog(this) == DialogResult.OK)
			{
				File.WriteAllText(sfd.FileName, txtHash.Text, Encoding.UTF8);
			}
		}


		void OnSelfTest(object sender, EventArgs e)
		{
			bool ok = true;
			ok &= Check("", "d41d8cd98f00b204e9800998ecf8427e");
			ok &= Check("a", "0cc175b9c0f1b6a831c399e269772661");
			ok &= Check("abc", "900150983cd24fb0d6963f7d28e17f72");
			ok &= Check("message digest", "f96b697d7cb7938d525a2f31aaf161d0");
			ok &= Check("abcdefghijklmnopqrstuvwxyz", "c3fcd3d76192e4007dfb496cca67e13b");
			ok &= Check("ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789", "d174ab98d277d9f5a5611c2c9f419d9f");
			ok &= Check("12345678901234567890123456789012345678901234567890123456789012345678901234567890", "57edf4a22be3c955ac49da2e2107b67a");
			ok &= Check("Hello world", "3e25960a79dbc69b674cd4ec67a72c62");
			MessageBox.Show(this, ok ? "Самотест пройден" : "Самотест провален");
		}

		void OnOneStep(object sender, EventArgs e)
		{
			byte[] data;
			if (!string.IsNullOrWhiteSpace(txtPath.Text) && File.Exists(txtPath.Text))
				data = File.ReadAllBytes(txtPath.Text);
			else
				data = Encoding.ASCII.GetBytes("abc");
			new StepForm(data).ShowDialog(this);
		}

		bool Check(string s, string expectedHex)
		{
			var got = Md5.ComputeHashHex(Encoding.ASCII.GetBytes(s));
			return string.Equals(got, expectedHex, StringComparison.OrdinalIgnoreCase);
		}

		void OnDragEnter(object sender, DragEventArgs e)
		{
			if (e.Data != null && e.Data.GetDataPresent(DataFormats.FileDrop)) e.Effect = DragDropEffects.Copy;
		}

		void OnDragDrop(object sender, DragEventArgs e)
		{
			if (e.Data == null) return;
			var files = (string[])e.Data.GetData(DataFormats.FileDrop);
			if (files.Length > 0)
			{
				txtPath.Text = files[0];
				var len = new FileInfo(files[0]).Length;
				if (len < 1024) MessageBox.Show(this, "Нужен файл не менее 1 КБ", "Предупреждение");
			}
		}
	}
}
