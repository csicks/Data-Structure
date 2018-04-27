using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Queue
{
    class Program
    {
        static void Main(string[] args)
        {
            //.Net Framework 4.5
            //MyQueue等类定义见解决方案
            //包含以下功能代码：泛型顺序循环队列、杨辉三角
            //每次主函数中仅保留一个功能模块的代码，其余已被注释，若要运行测试，请自行注释/取消注释
            #region 循环队列函数测试
            //int[] xx = { 1, 3, 5, 7, 4, 3, 7, 3, 5, 8, 4, 2 };
            //MyQueue<int> test0 = new MyQueue<int>(12, xx);
            //test0.Print();
            //test0.OutQueue();
            //test0.Print();
            //test0.InQueue(4);
            //test0.Print();
            //Console.WriteLine(test0.GetLength());
            //Console.WriteLine(test0.GetFirst());
            //test0.Clear();
            //test0.Print();
            #endregion

            #region 杨辉三角
            YangHui(7);
            #endregion
        }

        static void YangHui(int n)
        {
            MyQueue<int> qq = new MyQueue<int>(n + 1);
            Console.WriteLine(1);
            qq.InQueue(0);
            qq.InQueue(1);
            for (int i = 2; i <= n; i++)
            {
                qq.InQueue(0);
                int[] s = new int[i];        
                for(int j = 0; j < i; j++) 
                {
                    s[j] = qq.OutQueue() + qq.GetFirst();
                    Console.Write(s[j]);
                    Console.Write(' ');
                    qq.InQueue(s[j]);
                }
                Console.WriteLine();
            }
        }
    }
}
