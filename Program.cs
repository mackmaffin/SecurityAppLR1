using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using UserAuthenticationLab.Forms;
using UserAuthenticationLab.Models;
using UserAuthenticationLab.Services;

namespace UserAuthenticationLab
{
	internal static class Program
	{
		public static ApplicationData AppData { get; set; }
		public static DataManager DataManager { get; set; } = new DataManager();
		public static string MasterPassword { get; set; }
		/// <summary>
		/// Главная точка входа для приложения.
		/// </summary>
		[STAThread]
		static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);

			// Запрашиваем парольную фразу
			using (var masterForm = new MasterPasswordForm())
			{
				if (masterForm.ShowDialog() == DialogResult.OK && masterForm.IsAuthenticated)
				{
					// Запускаем основную форму входа
					Application.Run(new LoginForm());

					// При закрытии программы сохраняем данные
					SaveDataBeforeExit();
				}
				else
				{
					MessageBox.Show("Работа программы завершена.", "Выход",
						MessageBoxButtons.OK, MessageBoxIcon.Information);
				}
			}
		}

		static void SaveDataBeforeExit()
		{
			try
			{
				if (AppData != null && DataManager != null)
				{
					bool success = DataManager.SaveData(MasterPassword);
					if (success)
					{
						MessageBox.Show("Работа программы успешно завершена, данные зашифрованы и сохранены", "Успех", MessageBoxButtons.OK);
					}
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show($"Ошибка при сохранении данных: {ex.Message}", "Ошибка",
					MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}
	}
}
