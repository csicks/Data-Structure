using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            //.Net Framework 4.5
            //MyStack等类定义见解决方案
            //包含以下功能代码：泛型顺序栈，中心对称串，数制转换，超大整数转换为26进制，表达式计算
            //每次主函数中仅保留一个功能模块的代码，其余已被注释，若要运行测试，请自行注释/取消注释
            #region 中心对称串
            //char[] li1 = { 'a', 'x', '*', '1', 'e', '1', '*', 'x', 'a' };
            //if (IsSymmetry(li1))
            //    Console.WriteLine("是中心对称串");
            //else
            //    Console.WriteLine("不是中心对称串");
            #endregion

            #region 数制转换
            int xx = 100 * 20;  //原数
            Console.WriteLine(NumSysConverter(xx, 10, 2));
            #endregion

            #region 超大整数转化为26进制
            //LargeNumber exam1 = new LargeNumber(100,1);
            //exam1.Print();
            //exam1.To26Print();
            //exam1.NumPrint(exam1.NumDivide26(exam1.Num));
            //LargeNumber exam2 = new LargeNumber(99);
            //exam2.Print();
            //exam2.To26Print();
            #endregion

            #region 表达式计算
            //string xx = "y+2*x+3";
            //string yy = "a+b*c+(d*e+f)*g";
            //string zz = "2+(5+6)*1-5/7";
            //Expression test1 = new Expression(xx);
            //test1.Print();
            //Expression test2 = new Expression(yy);
            //test2.Print();
            //Expression test3 = new Expression(zz);
            //test3.Print();
            #endregion
        }

        static bool IsSymmetry(char[] xx)  //判断是否为中心对称串的函数
        {
            int leng = xx.Length + 1;
            MyStack<char> exam1 = new MyStack<char>(leng);
            int a = xx.Length % 2;
            if (a == 0)
            {
                for (int i = 0; i < xx.Length; i++)
                {
                    if (i == 0 || (i > 0 && xx[i] != exam1.GetTop()))
                        exam1.Push(xx[i]);
                    else
                        exam1.Pop();
                }
            }
            else
            {
                for (int i = 0; i < xx.Length; i++)
                {
                    if (i == (xx.Length - 1) / 2)
                        continue;
                    else if (i == 0 || (i > 0 && xx[i] != exam1.GetTop()))
                        exam1.Push(xx[i]);
                    else
                        exam1.Pop();
                }
            }
            if (exam1.IsEmpty())
                return true;
            else
                return false;
        }  

        static string NumSysConverter(int xx, int x, int a)  //数制转换的函数
        {
            string show = "";
            int tt = 0, ii = 0;
            while (xx != 0)
            {
                tt += (xx % 10) * (int)Math.Pow(x, ii);
                xx = xx / 10;
                ii += 1;
            }
            MyStack<int> exam = new MyStack<int>(100);
            while (tt / a > 0)
            {
                exam.Push(tt % a);
                tt = tt / a;
            }
            exam.Push(tt);
            for (int i = exam.Top; i < exam.Bottom; i++)
            {
                show += "("+exam.Pop().ToString()+")";
            }
            return show;
        }    

    }
}
