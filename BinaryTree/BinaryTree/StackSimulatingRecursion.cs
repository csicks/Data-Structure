using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTree
{
    static class SimuRecursion
    {
        static int step = 1;  //移动步数记录
        struct HanoiData  //汉诺塔存储结构
        {
            int n;
            char start, middle, end;
            public int N
            {
                get
                {
                    return n;
                }
            }
            public char Start
            {
                get
                {
                    return start;
                }
            }
            public char Middle
            {
                get
                {
                    return middle;
                }
            }
            public char End
            {
                get
                {
                    return end;
                }
            }
            public HanoiData(int x, char s, char m, char e)
            {
                n = x;
                start = s;
                middle = m;
                end = e;
            }
        }

        private static void Move(char a, char b)  //汉诺塔移动薄片显示
        {
            Console.WriteLine("Step {0} : Move slice form {1} to {2}", step, a, b);
        }
        public static void SimuHanoi(int n, char a, char b, char c)  //栈模拟汉诺塔
        {
            Stack<HanoiData> stack = new Stack<HanoiData>();
            HanoiData temp = new HanoiData(n, a, b, c);                     
            stack.Push(temp);
            int num = 1;
            while (stack.Count != 0)
            {
                temp = stack.Pop();
                if (temp.N == 1) 
                {
                    Move(temp.Start, temp.End);
                    step++;
                }
                else
                {
                    HanoiData temp1 = new HanoiData(temp.N - 1, temp.Start, temp.End, temp.Middle);
                    HanoiData temp2 = new HanoiData(1, temp.Start, temp.Middle, temp.End);                                      
                    HanoiData temp3 = new HanoiData(temp.N - 1, temp.Middle, temp.Start, temp.End);
                    stack.Push(temp3);
                    stack.Push(temp2);
                    stack.Push(temp1);
                    num++;
                }
            }
            step = 1;                
        }
        
    }
}
