using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace test
{
	class Integrat
	{
		public int fenZi;


	
	}

	class Fraction:Integrat
	{
		public int fenMu;
		public Fraction()
		{

		}
		public Fraction(int zi, int mu)
		{

			try
			{
				int temp = 1 / fenMu;
			}
			catch (DivideByZeroException)
			{
				MessageBox.Show("分母不能为0","Error");
				return;
			}
			fenMu = mu;
			fenZi = zi;
			}

		public Fraction(int mu)   //单变量的构造函数 只构造分母
		{
			try
			{
				int temp = 1 / fenMu;
			}
			catch (DivideByZeroException)
			{
				MessageBox.Show("分母不能为0", "Error");
				return;
			}
			fenMu = mu;
			fenZi = 0;
		}
		public void SetZi(int zi)
		{
			fenZi = zi;
		}

		public void SetMu(int mu)
		{
			try
			{
				int temp = 1 / fenMu;
			}
			catch (DivideByZeroException)
			{
				MessageBox.Show("分母不能为0", "Error");
				return;
			}
			fenMu = mu;
		}


		public static int Gcd(int m, int n) { return n == 0 ? m : Gcd(n, m % n); }

		public static Fraction operator +(Fraction L, Fraction R)
		{

			if (L.fenMu == R.fenMu)   //分子相同
			{
				return new Fraction(L.fenZi + R.fenZi, L.fenMu);
			}
			Fraction result = new Fraction(L.fenMu * R.fenMu);
			L.fenZi *= R.fenMu;  //通分
			R.fenZi *= L.fenMu;
			result.fenZi = L.fenZi + R.fenZi;
			int temp = Gcd(result.fenZi, result.fenMu);
			result.fenMu /= temp;
			result.fenZi /= temp;
			return result;
		}
	}
}
