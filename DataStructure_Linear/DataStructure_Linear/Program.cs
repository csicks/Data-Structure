using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure_Linear
{
    class Alist  //线性表顺序存储结构
    {
        int[] orderList;
        int lastNumber;
        int maxNumber;

        public int[] OrderList
        {
            get
            {
                return orderList;
            }
            set
            {
                orderList = value;
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
        public int MaxNumber
        {
            get
            {
                return maxNumber;
            }
            set
            {
                maxNumber = value;
            }
        }

        public Alist(int[] list,int max)
        {
            if(list .Length >max)
            {
                Console.WriteLine("输入数组的大小超过设定的最大大小！");
            }
            else
            {
                OrderList = new int[max];
                for(int i=0;i<list.Length;i++)
                {
                    OrderList[i] = list[i];
                }
                MaxNumber = max;
                LastNumber = list.Length;
            }
        }
        public void Clear()
        {
            LastNumber = 0;
        }
        public void Insert(int xx,int val)
        {
            if (xx > MaxNumber || xx < 0)
            {
                Console.WriteLine("插入位置超出线性表界限！");
            }
            else if (xx <= LastNumber)
            {
                LastNumber += 1;
                for (int i = LastNumber - 1; i >= xx - 1; i--)
                {
                    OrderList[i + 1] = OrderList[i];
                }
                OrderList[xx - 1] = val;
            }
            else
            {
                Console.WriteLine("插入位置超出当前线性表最末元素位置，自动将该元素插入到线性表末尾。");
                lastNumber += 1;
                OrderList[lastNumber - 1] = val;
            }                
        }
        public void Delete(int xx)
        {
            if(xx<0||xx>LastNumber)
            {
                Console.WriteLine("删除位置超出线性表界限或为空！");
            }
            else
            {
                LastNumber -= 1;
                for(int i=xx-1;i<LastNumber;i++)
                {
                    OrderList[i] = OrderList[i + 1];
                }
            }
        }
        public void Remove(int xx)
        {
            if (xx < 0 || xx >= LastNumber)
            {
                Console.WriteLine("删除位置超出线性表界限或删除位置之后元素为空！");
            }
            else
            {
                LastNumber = xx;
            }
        }
        public string SetPos(int val)
        {
            //List<int> pos = new List<int>();
            string pos = val.ToString() + "出现位置：";
            for(int i=0;i<LastNumber;i++)
            {
                if(OrderList[i]==val)
                {
                    pos += i.ToString();
                    pos += " ";
                }
            }
            if(pos== "出现位置：")
            {
                return "你要找的元素在线性表中不存在！";
            }
            else
            {
                return pos;
            }
        }
        public int GetValue(int xx)
        {
            if(xx<0||xx>LastNumber )
            {
                Console.WriteLine("你要找的元素超出当前线性表元素界限！");
                return 0;
            }
            else
            {
                return OrderList[xx - 1];
            }
        }
        public bool IsEmpty()
        {
            if (LastNumber == 0)
                return true;
            else
                return false;
        }
        public bool IsFull()
        {
            if (LastNumber == MaxNumber)
                return true;
            else
                return false;
        }
        public void Print()
        {
            if(IsEmpty())
            {
                Console.WriteLine("当前线性表为空！");
            }
            else
            {
                string a = "线性表为：";
                for(int i=0;i<LastNumber;i++)
                {
                    a += OrderList[i].ToString();
                    a += " ";
                }
                Console.WriteLine(a);
            }
        }
        public Alist Duplicate()
        {
            Alist copy = new DataStructure_Linear.Alist(OrderList,MaxNumber);
            copy.LastNumber = LastNumber;
            return copy;
        }
        public Alist Merge(Alist list1)
        {
            int newMaxNumber = LastNumber + list1.MaxNumber;
            int[] newOrderList = new int[newMaxNumber];
            for(int i=0;i<LastNumber;i++)
            {
                newOrderList[i] = OrderList[i];
            } 
            for(int i=LastNumber;i<LastNumber +list1 .LastNumber;i++)
            {
                newOrderList[i] = list1.OrderList[i - LastNumber];
            }
            Alist merge = new Alist(newOrderList, newMaxNumber);
            merge.LastNumber = LastNumber + list1.LastNumber;
            return merge;
        }
        public void Sort()
        {
            for(int i=LastNumber -2;i>=0;i--)
                for(int j=i;j<lastNumber-1;j++)
                {
                    if (OrderList[j] > OrderList[j + 1])
                    {
                        int temp = OrderList[j];
                        OrderList[j] = OrderList[j + 1];
                        OrderList[j + 1] = temp;
                    }
                }
        }
        public void Replace(int xx,int val)
        {
            if(xx<0||xx>LastNumber )
            {
                Console.WriteLine("你要替换的位置超出线性表界限或为空！");
            }
            else
            {
                OrderList[xx] = val;
            }
        }
    }

    class Node
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
        public Node()
        {
            Data = 0;
            Next = null;
        }
        public Node(int x)
        {
            Data = x;
        }
    }  //链式存储结点

    class Blist  //线性表链式存储结构
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

        public Blist(int[] list)
        {
            LastNumber = list.Length;
            Head = new Node();
            Node q = Head;
            for(int i=0;i<list.Length;i++)
            {
                Node li = new Node(list[i]);
                if (i == 0)
                {
                    Head= li;
                    q = Head;
                }
                else
                {
                    q.Next = li;
                }
                q = li;
            }
            q.Next = null;
        }
        public void Print()
        {
            if (Head != null)
            {
                Node p = Head;
                string show = " ";
                while (p.Next != null)
                {
                    show += p.Data.ToString() + " ";
                    p = p.Next;
                }
                Console.WriteLine(show);
            }
            else
                Console.WriteLine("该线性表为空！");

        }
        public int GetValue(int n)
        {
            Node p = Head;
            if (n<=0||n>LastNumber)
            {
                Console.WriteLine("你输入的数字位无效！");
            }
            else 
            {
                for (int i = 0; i < n-1; i++)
                {
                    p = p.Next;
                }
            }
            return p.Data;
        }
        public void Insert(int n,int x)
        {
            if(n<=0)
            {
                Console.WriteLine("你输入的数字位无效！");
            }       
            else if (n>LastNumber)
            {
                Node p = Head;
                Node nn = new Node(x);
                for (int i = 0; i < LastNumber-1 ; i++)
                {
                    p = p.Next;
                }
                p.Next = nn;
                nn.Next = null;
                LastNumber += 1; 
            }
            else
            {
                Node p = Head;
                Node nn = new Node(x);
                if (n == 1)
                {
                    nn.Next = Head;
                    Head = nn;
                }
                else
                {
                    for (int i = 0; i < n - 2; i++)
                    {
                        p = p.Next;
                    }
                    nn.Next = p.Next;
                    p.Next = nn;                    
                }
                LastNumber += 1;
            }              
        }
        public void Delete(int n)
        {
            if (n <= 0 || n > LastNumber)
            {
                Console.WriteLine("你输入的数字位无效！");
            }
            else
            {
                Node p = Head;
                if (n == 1)
                {
                    Head = p.Next;
                }
                else
                {
                    for (int i = 0; i < n - 2; i++)
                    {
                        p = p.Next;
                    }
                    p.Next = p.Next.Next;
                }
                LastNumber -= 1;
            }
        }
        public void Clear()
        {
            Head = null;
            LastNumber = 0;
        }
        public void Remove(int n)
        {
            if (n <= 0 || n > LastNumber)
            {
                Console.WriteLine("你输入的数字位无效！");
            }
            else
            {
                Node p = Head;
                for(int i = 0; i < n-1; i++)
                {
                    p = p.Next;
                }
                p.Next = null;
                LastNumber = n;
            }
        }
        public string GetPos(int x)
        {
            string show = "线性表中出现该数的位置为：";
            Node p = Head;
            for(int i = 0; i < LastNumber; i++)
            {
                if(p.Data == x)
                {
                    show += (i + 1).ToString() + " ";
                }
                p = p.Next;
            }
            if (show == "线性表中出现该数的位置为：")
                return "线性表中不存在该数！";
            else
                return show;
        }
        public bool IsEmpty()
        {
            if(LastNumber ==0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public Blist Duplicate()
        {
            Blist copy = this;
            return copy;
        }
        public void Replace(int n,int x)
        {
            if (n <= 0 || n > LastNumber)
            {
                Console.WriteLine("你输入的数字位无效！");
            }
            else
            {
                Node p = Head;
                Node nn = new Node(x);
                if (n == 1)
                {
                    nn.Next = Head.Next;
                    Head = nn;
                }
                else
                {
                    for (int i = 0; i < n - 2; i++)
                    {
                        p = p.Next;
                    }
                    nn.Next = p.Next.Next;
                    p.Next = nn;
                }
            }
        }
        public Blist Merge(Blist add)
        {
            Blist result = this;
            Node p = result.Head;
            for(int i=0;i<result.LastNumber-1; i++)
            {
                p = p.Next;
            }
            p.Next = add.Head;
            result.LastNumber += add.LastNumber;
            return result;
        }
        public void Sort()
        {
            Node[] save = new DataStructure_Linear.Node[LastNumber];
            Node p = Head;
            int i = 0;
            for(;i<LastNumber - 1; i++)
            {
                save[i] = p;
                p = p.Next;
            }
            save[i] = p;
            for(int j=LastNumber -2;j>=0;j--)
                for(int k=j;k<LastNumber - 1; k++)
                {
                    if(save[k].Data >save [k+1].Data)
                    {
                        Node temp = save[k];
                        save[k] = save[k + 1];
                        save[k + 1] = temp;
                    }
                }
            for(int j = 0; j < LastNumber-1; j++)
            {
                save[j].Next = save[j + 1];
            }
            Head = save[0];
            save[LastNumber - 1].Next = null;
        }        
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            //.Net Framework 4.5
            //代码中存储数据类型选择以整型为例
            //每次主函数中仅保留一个功能模块的代码，其余已被注释，若要运行测试，请自行注释/取消注释
            #region 顺序存储测试
            //int[] exam = { 5, 6, 2, 98, 12, 33, 0, 1 };
            //Alist example = new Alist(exam, 100);
            //Alist example1 = example.Duplicate();
            //Alist example2 = example.Merge(example1);
            //example.Print();
            //example2.Print();

            //example.Sort();
            //example.Print();

            //example.Replace(3, 999);
            //example.Replace(5, 999);
            //example.Print();

            //Console.WriteLine(example.SetPos(999));
            //Console.WriteLine(example.GetValue(4));

            //example.Insert(3, 55);
            //example.Print();

            //example.Delete(1);
            //example.Print();

            //example.Replace(6, 666);
            //example.Print();

            //example.Remove(3);
            //example.Print();

            //example.Clear();
            //Console.WriteLine(example.IsEmpty());
            //Console.WriteLine(example.IsFull());
            //example.Print();
            #endregion

            #region 链式存储测试
            int[] exam2 = { 5, 6, 2, 98, 12, 33, 0, 1, 5, 0, 45 };
            int[] exam3 = { 9, 8, 7, 6, 5, 4, 3, 2, 1 };
            Blist example11 = new Blist(exam2);
            example11.Print();

            Console.WriteLine(example11.GetValue(5));

            example11.Insert(1, 10);
            example11.Print();
            example11.Insert(5, 100);
            example11.Print();

            example11.Delete(1);
            example11.Print();
            example11.Delete(8);
            example11.Print();

            Console.WriteLine(example11.GetPos(5));
            Console.WriteLine(example11.GetPos(999));

            Blist example12 = example11.Duplicate();
            example12.Print();

            example11.Remove(10);
            example11.Print();

            example11.Replace(6, 6666);
            example11.Print();

            Blist example13 = new Blist(exam3);
            example11.Merge(example13).Print();

            example11.Sort();
            example11.Print();
            #endregion

        }
    }
}
