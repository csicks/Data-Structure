using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure_CircleLinear
{
    class Node  //结点
    {
        int data;
        Node next;
        public int Data
        {
            get
            {
                return data;
            }
            set
            {
                data = value;
            }
        }
        public Node Next
        {
            get
            {
                return next;
            }
            set
            {
                next = value;
            }
        }
        public int CheckTime { get; set; }
        public Node()
        {
            Data = 0;
            Next = null;
        }
        public Node(int x)
        {
            Data = x;
        }
        public bool IsChecked()
        {
            if (CheckTime == 0)
                return false;
            else
                return true;
        }
    }  

    class CircleLinear  //环形链式表
    {
        Node head;
        int lastNumber;
        public Node Head
        {
            get
            {
                return head;
            }
            set
            {
                head = value;
            }
        }
        public int LastNumber
        {
            get
            {
                return lastNumber;
            }
            set
            {
                lastNumber = value;
            }
        }

        public CircleLinear(int[] list)
        {
            LastNumber = list.Length;
            Head = new Node();
            Node q = Head;
            for (int i = 0; i < list.Length; i++)
            {
                Node li = new Node(list[i]);
                if (i == 0)
                {
                    Head = li;
                    q = Head;
                }
                else
                {
                    q.Next = li;
                }
                q = li;
            }
            q.Next = Head;
        }
        public void Print()
        {
            if (Head != null)
            {
                Node p = Head;
                string show = " ";
                while (!p.IsChecked())
                {
                    show += p.Data.ToString() + " ";
                    p.CheckTime = 1;
                    p = p.Next;
                }
                Console.WriteLine(show);
            }
            else
                Console.WriteLine("该线性表为空！");

        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            //.NET Framework 4.5
            //代码中存储数据类型选择以整型为例
            //所选环形链表以首尾相接为例
            int[] exam = { 5, 6, 2, 98, 12, 33, 0, 1 };
            CircleLinear xx = new CircleLinear(exam);
            xx.Print();
            Console.ReadLine();
        }
    }
}
