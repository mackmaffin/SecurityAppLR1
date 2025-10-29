using System.Windows.Forms;

namespace SecurityAppLR2.UI
{
	public partial class AlgorithmForm : Form
	{
		public AlgorithmForm()
		{
			InitializeComponent();
			txtInfo.Text =
				"MD5 — хэш-функция с выводом 128 бит. " +
				"Паддинг: 0x80, нули до длины ≡ 56 (mod 64), затем 64-битная длина в битах (LE). " + 
				"Инициализация: A=67452301, B=efcdab89, C=98badcfe, D=10325476. " +
				"64 шага в 4 раунда: F,G,H,I; сдвиги S; константы K[i]=floor(2^32*abs(sin(i+1))). " +
				"После каждого 512-битного блока A,B,C,D прибавляются к исходным. " +
				"Результат — A||B||C||D в little-endian (16 байт, hex).";
		}
	}
}
