using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.JScript;


namespace test
{





	public partial class Form1 : Form
	{
		List<int> FenZi = new List<int>();   //小写名称已被占用
		List<int> FenMu = new List<int>();


		string calcuList ="";//储存用户输入的无分母表达式
		string calcuMem = "";
		[Obsolete]
		Microsoft.JScript.Vsa.VsaEngine JSEngine = Microsoft.JScript.Vsa.VsaEngine.CreateEngine();  //初始化JS解释器引擎

		private bool operatorFlag; //检测是否已经输入了一个符号
		static private bool firstNum = true;
		private bool hasNum=false;
		private bool hasFenMu = false;  //不要复用hasNum
		private bool fenMuFlag; //检测分母输入



		public Form1()
		{

			operatorFlag = false;
			InitializeComponent();
		}


		private void Num_push(string num)
		{



			if (firstNum|| hasNum)
			{
				textBox2.Clear();
			if ((num == "1" || num == "2" || num == "3" || num == "4" || num == "5" || num == "6" || num == "7" || num == "8"
														 || num == "9" || num == "0"))
			{
					calcuMem += num;
					textBox1.Text += num;
					hasNum = true;
					firstNum = false;
					return;
			}
				if (hasNum && (num == "+" || num == "-" || num == "*" || num == "/" ))
				{
					calcuList += calcuMem;
					calcuMem = "";
					operatorFlag = true;
					hasNum = false;
					firstNum = false;
					if (num == "/")
					{
						calcuList += "/";
						textBox1.Text += "÷";
						return;
					}
					calcuList += num;
					textBox1.Text += num;
					return;
				}
				return;
			}
			else
			{
				if (operatorFlag && (num == "+" || num == "-" || num == "*" || num == "/" || fenMuFlag))
				{
					return;
				}
				if (!operatorFlag && (num == "+" || num == "-" || num == "*" || num == "/"))
				{
					calcuList += calcuMem;
					calcuMem = "";
					operatorFlag = true;
					if (num == "/")
					{
						calcuList += "/";
						textBox1.Text += "÷";

						return;
					}
					textBox1.Text += num;
					calcuList += num;
					return;
				}
				if (fenMuFlag)
				{
					if (!hasNum)
					{
						if ( num == "+" || num == "-" || num == "*" || num == "/")
						{
							return;
						}
						calcuMem += num;
						textBox1.Text += num;
						hasNum = true;
						return;
					}
					if (num == "+" || num == "-" || num == "*" || num == "/")
					{
						FenMu.Add(Int32.Parse(calcuMem));
					}


				}
				operatorFlag = false;
				calcuList += num;
				textBox1.Text += num;
				return;



				//↑显示并压栈符号
			}


		}


		private void Form1_Load(object sender, EventArgs e)
		{

		}

		private void button1_Click(object sender, EventArgs e)
		{
			Num_push("1");
			operatorFlag = false;


		}



		private void button2_Click(object sender, EventArgs e)
		{
			Num_push("2");
			operatorFlag = false;
		}

		private void button3_Click(object sender, EventArgs e)
		{
			Num_push("3");
			operatorFlag = false;
		}

		private void button4_Click(object sender, EventArgs e)
		{
			Num_push("4");
			operatorFlag = false;
		}

		private void button5_Click(object sender, EventArgs e)
		{
			Num_push("5");
			operatorFlag = false;
		}

		private void button6_Click(object sender, EventArgs e)
		{
			Num_push("6");
			operatorFlag = false;
		}
		private void button7_Click(object sender, EventArgs e)
		{
			Num_push("7");
			operatorFlag = false;
		}

		private void button8_Click(object sender, EventArgs e)
		{
			Num_push("8");
			operatorFlag = false;
		}

		private void button9_Click(object sender, EventArgs e)
		{
			Num_push("9");
			operatorFlag = false;
		}

		private void button10_Click(object sender, EventArgs e)  //数字0
		{
			Num_push("0");
			operatorFlag = false;

		}

		private void button11_Click(object sender, EventArgs e) //等于号
			
		{
			if (operatorFlag)
			{
				return;
			}
			calcuList += calcuMem;


			int a = Int32.Parse(Eval.JScriptEvaluate(calcuList, JSEngine).ToString());



			textBox2.Text = a.ToString();
			//未完工


			textBox1.Clear();
			operatorFlag = false;
			firstNum = true;
			calcuList = "";
			calcuMem = "";

		}

		private void button12_Click(object sender, EventArgs e) //加号
		{
			Num_push("+");

		}

		private void button13_Click(object sender, EventArgs e)//减号
		{


			Num_push("-");
			

		}

		private void button14_Click(object sender, EventArgs e)  //乘号
		{


			Num_push("*");
		}

		private void button15_Click(object sender, EventArgs e)  //除号
		{


			Num_push("/");

		}

		private void button16_Click(object sender, EventArgs e)//退格
		{
			if (textBox1.Text != "")
			{
				if (!firstNum && !operatorFlag)
				{
					textBox1.Text = textBox1.Text.Substring(0, textBox1.Text.Length - 1);
					calcuMem = calcuMem.Substring(0, calcuMem.Length - 1);
					return;
				}
				if (!firstNum && operatorFlag)
				{
					textBox1.Text = textBox1.Text.Substring(0, textBox1.Text.Length - 1);
					calcuList = calcuList.Substring(0, calcuList.Length - 1);
					operatorFlag = false;
					return;
				}
				if (fenMuFlag)
				{
					if (calcuMem == "")
					{
						fenMuFlag = false;
						operatorFlag = false;
						hasFenMu = false;
						textBox1.Text = textBox1.Text.Substring(0, textBox1.Text.Length - 1);
					}

				}
			}
		}

		private void button17_Click(object sender, EventArgs e)   //倒数
		{

		}

		private void button18_Click(object sender, EventArgs e)  //分数线
		{
			if (fenMuFlag)
			{
				return;   //多重分数太复杂
			}
			fenMuFlag = true;
			operatorFlag = true;  //分母如果包含其他运算太复杂,略去
			hasFenMu = false;
			textBox1.Text += "/";
			FenZi.Add(Int32.Parse(calcuMem));



		}
		private void textBox1_TextChanged(object sender, EventArgs e)//current textbox
		{

		}

		private void textBox2_TextChanged(object sender, EventArgs e) //result textbox
		{

		}
	}
}


