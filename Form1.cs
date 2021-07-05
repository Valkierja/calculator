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

//
namespace test
{





	public partial class Form1 : Form
	{
		List<string> FenZi = new List<string>(100);   //小写名称已被占用
		List<string> FenMu = new List<string>(100);
		List<string> Ptr = new List<string>(); //符号栈
		static private int numCounter=0;

		[Obsolete]
		Microsoft.JScript.Vsa.VsaEngine JSEngine = Microsoft.JScript.Vsa.VsaEngine.CreateEngine();  //初始化JS解释器引擎

		private bool operatorFlag = false; //检测是否已经输入了一个符号
		private bool fenMuFlag=false; //检测分母输入
		string tempFenMu = "";
		string tempFenZi = "";


		public Form1()
		{

	
			//初始化分母list,默认分母为1
			


			
			InitializeComponent();
		}

	


		private void pushNum(string num)
		{
	

			if (fenMuFlag)
			{
				tempFenMu += num;
				textBox1.Text += num;
				return;
			}
			tempFenZi +=num;

			textBox1.Text += num;

			return;
		}

		private void pushPrt(string item)
		{
			if (operatorFlag)
			{
				return;
			}

			FenMu[numCounter] =(tempFenMu);
			FenZi[numCounter] =(tempFenZi);
			tempFenMu = "";
			tempFenZi = "";
			if (item=="/")
			{

				Ptr.Add("/");
				textBox1.Text += "÷";
				numCounter++;
				return;
			}
			Ptr.Add(item);
			textBox1.Text += item;
			numCounter++;	
			return;

		}





		private void Form1_Load(object sender, EventArgs e)
		{
			
			for (int i = 0; i <100; i++)
			{
				FenMu.Add("1");
			}

			for (int i = 0; i < 100; i++)
			{
				FenZi.Add("");
			}
		}

		private void button1_Click(object sender, EventArgs e)
		{
			pushNum("1");
			operatorFlag = false;


		}



		private void button2_Click(object sender, EventArgs e)
		{
			pushNum("2");
			operatorFlag = false;
		}

		private void button3_Click(object sender, EventArgs e)
		{
			pushNum("3");
			operatorFlag = false;
		}

		private void button4_Click(object sender, EventArgs e)
		{
			pushNum("4");
			operatorFlag = false;
		}

		private void button5_Click(object sender, EventArgs e)
		{
			pushNum("5");
			operatorFlag = false;
		}

		private void button6_Click(object sender, EventArgs e)
		{
			pushNum("6");
			operatorFlag = false;
		}
		private void button7_Click(object sender, EventArgs e)
		{
			pushNum("7");
			operatorFlag = false;
		}

		private void button8_Click(object sender, EventArgs e)
		{
			pushNum("8");
			operatorFlag = false;
		}

		private void button9_Click(object sender, EventArgs e)
		{
			pushNum("9");
			operatorFlag = false;
		}

		private void button10_Click(object sender, EventArgs e)  //数字0
		{
			pushNum("0");
			operatorFlag = false;

		}

		private void button11_Click(object sender, EventArgs e) //等于号
			
		{
			if (operatorFlag)
			{
				return;
			}
			pushPrt("=");
			int GongFenMu = 1;
			for (int i = 0; i < numCounter; i++)
			{
			
				GongFenMu *= Int32.Parse(FenMu[i]);
			}

			for (int i = 0; i < FenZi.Count; i++)
			{
				FenZi[i] =( (Int32.Parse(FenZi[i]))* (GongFenMu / Int32.Parse(FenMu[i])) ).ToString();  //通分
			}
			string temp="";

			for (int i = 0; i < FenZi.Count; i++)
			{
				temp += FenZi[i];
				if (Ptr[i] == "=")
				{
					break;
				}
				temp += Ptr[i];
			}
				int a = Int32.Parse(Eval.JScriptEvaluate(temp, JSEngine).ToString());



			textBox2.Text = a.ToString();
			//未完工


			textBox1.Clear();
			operatorFlag = false;

		}

		private void button12_Click(object sender, EventArgs e) //加号
		{
			pushPrt("+");

		}

		private void button13_Click(object sender, EventArgs e)//减号
		{


			pushPrt("-");
			

		}

		private void button14_Click(object sender, EventArgs e)  //乘号
		{


			pushPrt("*");
		}

		private void button15_Click(object sender, EventArgs e)  //除号
		{


			pushPrt("/");

		}

		private void button16_Click(object sender, EventArgs e)//退格
		{

			if (fenMuFlag)
			{
				if (FenMu.Count()==0)
				{
					return;
				}
				textBox1.Text = textBox1.Text.Substring(0, textBox1.Text.Length - 1);
				FenMu[numCounter] = FenMu[numCounter].Substring(0, FenMu[numCounter].Length - 1);
				return;
			}





		}

		private void button17_Click(object sender, EventArgs e)   //倒数
		{

		}

		private void button18_Click(object sender, EventArgs e)  //分数线
		{
			fenMuFlag = true;
			textBox1.Text += "/";



		}
		private void textBox1_TextChanged(object sender, EventArgs e)//current textbox
		{

		}

		private void textBox2_TextChanged(object sender, EventArgs e) //result textbox
		{

		}
	}
}


