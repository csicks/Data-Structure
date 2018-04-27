using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Queue  //泛型顺序循环队列
{
    public class MyQueue<T>
    {
        int size;
        T[] examQuene;
        int front;
        int rear;
        public int Size
        {
            get
            {
                return size > 0 ? size : 0;
            }
        }
        public T[] ExamQuene
        {
            get
            {
                return examQuene;
            }
        }
        public int Front
        {
            get
            {
                return front;
            }
        }
        public int Rear
        {
            get
            {
                return rear;
            }
        }

        public MyQueue(int xx)
        {
            size = xx + 1;
            examQuene = new T[size];
            front = 1;
            rear = 1;
        }
        public MyQueue(int xx, T[] yy)
        {
            if (yy.Length > xx)
            {
                Console.WriteLine("数组超过上限！");
                return;
            }
            size = xx + 1;
            examQuene = new T[size];
            for (int i = 0; i < yy.Length; i++)
            {
                examQuene[i] = yy[i];
            }
            front = 1;
            rear = yy.Length + 1;
        }
        public bool IsEmpty()
        {
            if (Front == Rear)
                return true;
            else
                return false;
        }
        public bool IsFull()
        {
            if (Front == (Rear + 1) % Size)
                return true;
            else
                return false;
        }
        public void Clear()
        {
            rear = front;
        }
        public int GetLength()
        {
            if (Front <= Rear)
                return Rear - Front - 1;
            else
                return Size - (Front - Rear);
        }
        public T GetFirst()
        {
            return ExamQuene[Front - 1];
        }
        public void InQueue(T xx)
        {
            if (IsFull())
            {
                Console.WriteLine("队列已满，无法入队！");
                return;
            }
            else
            {
                examQuene[Rear - 1] = xx;
                if (Rear !=Size)
                    rear++;
                else
                    rear = 1;
            }                         
        }
        public T OutQueue()
        {
            if (IsEmpty())
            {
                Console.WriteLine("队列已空，无法出队！");
                T xx = default(T);
                return xx;
            }
            else
            {
                T x = ExamQuene[Front - 1];
                if (Front != Size)
                    front++;
                else
                    front = 1;
                return x;
            }
        }
        public void Print()
        {
            if (IsEmpty())
                Console.WriteLine("队列为空！");
            else
            {
                int i = Front - 1;
                while (i != Rear - 1) 
                {
                    Console.Write(ExamQuene[i]);
                    Console.Write(" ");
                    if (i != Size - 1)
                        i++;
                    else
                        i = 0;
                }
                Console.WriteLine();
            }
        }
    }
}
