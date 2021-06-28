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

		string calcu_list;//储存用户输入的无分母表达式
		[Obsolete]
		Microsoft.JScript.Vsa.VsaEngine ve = Microsoft.JScript.Vsa.VsaEngine.CreateEngine();  //初始化JS解释器引擎

		private bool operatorFlag; //检测是否已经输入了一个符号
		private bool firstNum = true;
		private bool hasNum=false;
		private bool fenMuFlag; //检测分母输入



		public Form1()
		{

			operatorFlag = false;
			InitializeComponent();
		}


		private void Num_push(string num)
		{



			if (firstNum)
			{

			if ((num == "1" || num == "2" || num == "3" || num == "4" || num == "5" || num == "6" || num == "7" || num == "8"
														 || num == "9" || num == "0"))
			{
					calcu_list += num;
					textBox1.Text += num;
					hasNum = true;
					return;
			}
				if (hasNum && (num == "+" || num == "-" || num == "*" || num == "/" ))
				{
					firstNum = false;
					if (num == "/")
					{
						calcu_list += "/";
						textBox1.Text += "÷";
						return;
					}
					calcu_list += num;
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
					if (num == "/")
					{
						calcu_list += "/";
						textBox1.Text += "÷";
						return;
					}
					calcu_list += num;
					textBox1.Text += num;
					return;
				}

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

			textBox2.Text = Eval.JScriptEvaluate(calcu_list, ve).ToString();
			textBox1.Clear();
			operatorFlag = false;
			firstNum = true;
		}

		private void button12_Click(object sender, EventArgs e) //加号
		{
			
			Num_push("+");
			operatorFlag = true;

		}

		private void button13_Click(object sender, EventArgs e)//减号
		{
			

			Num_push("-");
			operatorFlag = true;

		}

		private void button14_Click(object sender, EventArgs e)  //乘号
		{
		

			Num_push("*");
			operatorFlag = true;
		}

		private void button15_Click(object sender, EventArgs e)  //除号
		{
			
			Num_push("/");
			operatorFlag = true;

		}

		private void button16_Click(object sender, EventArgs e)//退格
		{
			textBox1.Text += "\b";
		}

		private void button17_Click(object sender, EventArgs e)   //倒数
		{

		}

		private void button18_Click(object sender, EventArgs e)  //分数线
		{
			fenMuFlag = true;

		}
		private void textBox1_TextChanged(object sender, EventArgs e)//current textbox
		{

		}

		private void textBox2_TextChanged(object sender, EventArgs e) //result textbox
		{

		}
	}
}
