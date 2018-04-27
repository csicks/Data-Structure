using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackApplication
{
    public class MyStack<T>  //泛型顺序栈
    {
        int size;
        public int Size
        {
            get
            {
                return size;
            }
            set
            {
                size = value > 0 ? value : 0;
            }
        }
        public T[] ExamStack { get; set; }
        public int Top { get; set; }
        public int Bottom { get; set; }

        public MyStack(int a)
        {
            Size = a;
            ExamStack = new T[a];
            Bottom = a - 1;
            Top = Bottom;
        }
        public MyStack(int a, T[] b)
        {
            Size = a;
            ExamStack = new T[a];
            if (b.Length > a)
                Console.WriteLine("数组超过栈的最大空间！");
            else
            {
                for(int i = 0; i < b.Length; i++)
                    ExamStack[a - 2 - i] = b[b.Length - 1 - i];                    
                Bottom = a - 1;
                Top = a - 1 - b.Length;
            }
        }
        public bool IsEmpty()  //判断栈是否为空
        {
            if (Top == Bottom)
                return true;
            else
                return false;
        }
        public bool IsFull()  //判断栈是否为满
        {
            if (Top == 0)
                return true;
            else
                return false;
        }
        public T GetTop()  //获取栈首元素的值
        {
            return ExamStack[Top];
        }
        public void Clear()  //清空栈
        {
            Top = Bottom;
        }
        public int GetLength()  //获取栈中元素个数
        {
            return Bottom - Top;
        }
        public void Push(T xx)  
        {
            if (IsFull())
                Console.WriteLine("栈已满！");
            else
            {
                Top -= 1;
                ExamStack[Top] = xx;
            }
        }
        public T Pop()
        {
            if (IsEmpty())
            {
                Console.WriteLine("栈已空！");
                T x = default(T);
                return x;
            }               
            else
            {
                Top += 1;
                return ExamStack[Top - 1];
            }
        }

    }
}
