using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackApplication
{
    class LargeNumber  //超大整数类
    {
        //为表示方便，暂定不超过10^100级
        int size;  //整数长度
        int[] num;
        public int[] Num
        {
            get
            {
                return num;
            }
        }
        public int Size
        {
            get
            {
                return size;
            }
        }

        public LargeNumber(int x)  //构造函数，随机生成10^size级超大整数
        {
            size = x;
            num = new int[size];
            Random ran = new Random();
            num[0] = ran.Next(1, 10);
            for(int i = 0; i < size; i++)
                num[i] = ran.Next(0, 10);
        }
        public LargeNumber(int x,int y)  //构造函数，生成10^size
        {
            size = x;
            num = new int[size];
            num[0] = 1;
            for(int i = 1; i < size; i++)
                num[i] = 0;
        }
        public LargeNumber(char a)
        {
            size = 98;
            num = new int[98];
            int i = 0;
            while (i < 95)
            {
                num[i] = 3;
                num[i + 1] = 8;
                num[i + 2] = 4;
                num[i + 3] = 6;
                num[i + 4] = 1;
                num[i + 5] = 5;
                i += 6;
            }
            num[96] = 3;
            num[97] = 8;              
        }  //测试用途
        public void Print()
        {
            Console.WriteLine("生成10^100级超大整数为：");
            NumPrint(Num);
        }
        public void To26Print()
        {
            Console.WriteLine("转化为26进制为：");
            char[] xx = To26System().ToCharArray();
            int k = 0;
            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 50; j++)
                {
                    if (i * 50 + j < xx.Length)
                    {
                        Console.Write(xx[i * 50 + j]);
                        k++;
                    }                       
                    else
                        break;
                }                    
                Console.WriteLine();
                if (k >= xx.Length)
                    break;
            }
        }
        public void NumPrint(int[] xx)
        {
            int k = 0;
            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 50; j++)
                {
                    if (i * 50 + j < xx.Length)
                    {
                        Console.Write(xx[i * 50 + j]);
                        k++;
                    }
                    else
                        break;
                }
                Console.WriteLine();
                if (k >= xx.Length)
                    break;
            }
        }
        public char ExpressionOf26System(int xx)  //0~25用A~Z表示
        {
            return (char)(xx + 'A');
        }  
        public int[] NumDivide26(int[] xx)  //除26取整
        {
            int[] result = new int[xx.Length];
            int[] changeTime = new int[xx.Length];
            int tt = xx[0], ii = 1, kk = 0;
            while (tt < 26&&ii < xx.Length)
            {
                tt = tt * 10 + xx[ii];
                ii++;
                if (tt >= 26)
                {
                    result[kk] = tt / 26;                   
                    tt = tt % 26;                    
                }
                else
                {
                    result[kk] = 0;
                }
                changeTime[kk] += 1;
                kk++;
            }
            int jj = 0;  //修改过的位数
            for(int i = 0; i < changeTime.Length; i++)
            {
                if (changeTime[i] == 1)
                    jj++;
            }           
            int uu = 0;  //至首字0的个数
            for(int i = 0; i < result.Length; i++)
            {
                if (result[i] != 0)
                    break;
                uu++;
            }
            int[] newResult;
            if (uu != result.Length)
            {
                newResult = new int[jj - uu];
                for (int i = 0; i < newResult.Length; i++)
                    newResult[i] = result[i + uu];
            }
            else
            {
                newResult = new int[jj];
                for (int i = 0; i < newResult.Length; i++)
                    newResult[i] = result[i];
            }                         
            return newResult;
        }
        public int NumMod26(int[] xx)  //除26取余
        {
            int tt = Num[0], ii = 1, kk = 0;
            while (tt < 26 && ii < xx.Length)
            {
                tt = tt * 10 + Num[ii];
                ii++;
                if (tt >= 26)
                {
                    tt = tt % 26;
                    kk++;
                }
            }
            return tt;
        }
        public bool IsZero(int[] xx)  //判断超大整数是否为0
        {
            int a = 0;
            for(int i = 0; i < xx.Length; i++)
            {
                if (xx[i] != 0)
                    break;
                else
                    a++;
            }
            if (a == xx.Length)
                return true;
            else
                return false;
        }
        public string To26System()  //转化为26进制
        {
            string show = "";
            MyStack<int> exam = new MyStack<int>(Num.Length);
            int[] tt = Num;
            while (!IsZero(NumDivide26(tt)))
            {
                exam.Push(NumMod26(tt));
                tt = NumDivide26(tt);
            }
            exam.Push(NumMod26(tt));
            for (int i = exam.Top; i < exam.Bottom; i++)
            {
                show += ExpressionOf26System(exam.Pop());
            }
            return show;
        }

    }
}
