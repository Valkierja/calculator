using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace test
{
	class fraction
	{
		public int fenMu;
		public int fenZi;
		public fraction()
		{

		}
		public fraction(int zi, int mu)
		{

			try
			{
				int temp = 1 / fenMu;
			}
			catch (DivideByZeroException e)
			{
				MessageBox.Show("分母不能为0","Error");
			}
			fenMu = mu;
			fenZi = zi;

			}

		public fraction(int mu)   //单变量的构造函数 只构造分母
		{
			fenMu = mu;
			fenZi = 0;
		}
		public void setZi(int zi)
		{
			fenZi = zi;
		}

		public void setMu(int mu)
		{
			fenMu = mu;
		}


		public int Gcd(int m, int n) { return n == 0 ? m : Gcd(n, m % n); }

		public static fraction operator +(fraction L, fraction R)
		{

			if (L.fenMu == R.fenMu)   //分子相同
			{
				return new fraction(L.fenZi + R.fenZi, L.fenMu);
			}
			fraction result = new fraction(L.fenMu * R.fenMu);





			return result;
		}
	}
}
