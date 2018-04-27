using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure_Polynomial
{
    #region 失败的泛型例

    //class Node<T> where T : struct  //结点
    //{
    //    public T Index { get; set; }
    //    public T Coefficient { get; set; }
    //    public Node<T> Next { get; set; }
    //    public Node()
    //    {
    //        Next = null;
    //    }
    //    public Node(T x, T y)
    //    {
    //        Index = x;
    //        Coefficient = y;
    //        Next = null;
    //    }
    //}

    //class Polynomial<T> where T: struct, IComparable  //多项式
    //{
    //    public Node<T> Head { get; set; }
    //    public int LastNumber { get; set; }

    //    public Polynomial(T[,] list)
    //    {
    //        LastNumber = list.Length;
    //        Head = new Node<T>();
    //        Node<T> q = Head;
    //        for (int i = 0; i < list.Length; i++)
    //        {
    //            Node<T> li = new Node<T>(list[i, 0], list[i, 1]);
    //            if (i == 0)
    //            {
    //                Head = li;
    //                q = Head;
    //            }
    //            else
    //            {
    //                q.Next = li;
    //            }
    //            q = li;
    //        }
    //        q.Next = null;
    //    }
    //    public Polynomial<T> Plus(Polynomial<T> li1, Polynomial<T> li2)
    //    {
    //        Node<T> p = li1.Head;
    //        Node<T> q = li2.Head;
    //        for (int i = 0; i < li1.LastNumber; i++)
    //        {
    //            if(typeof(T)==typeof(int))
    //            {
    //                if (p.Index.CompareTo(q.Index) < 0)
    //                {
    //                    p = p.Next;
    //                }
    //                else if (Convert.ToDouble(p.Index) == Convert.ToDouble(q.Index))
    //                {
    //                    p.Coefficient = q.Coefficient + p.Coefficient;
    //                }
    //            }
    //        }

    //    }
    //}

    #endregion

    class Node  //结点
    {
        public int Index { get; set; }
        public int Coefficient { get; set; }
        public Node Next { get; set; }
        public Node()
        {
            Next = null;
        }
        public Node(int x, int y)
        {
            Index = y;
            Coefficient = x;
            Next = null;
        }
    }

    class Polynomial //多项式
    {
        public Node Head { get; set; }
        public int LastNumber { get; set; }

        public Polynomial(int[,] list)
        {
            LastNumber = list.Length / 2;
            Head = new Node();
            Node q = Head;
            for (int i = 0; i < list.Length/2; i++)
            {
                Node li = new Node(list[i, 0], list[i, 1]);
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
                    if (p.Coefficient != 0)
                    {
                        if (p == Head)
                        {
                            if (p.Index == 0)
                                show += p.Coefficient.ToString();
                            else
                            {
                                if (p.Coefficient != 1)
                                    show += p.Coefficient.ToString();
                                show += "x^" + p.Index.ToString();
                            }
                        }
                        else
                        {
                            if (p.Index == 0)
                            {
                                if (p.Coefficient > 0)
                                    show += "+";
                                show += p.Coefficient.ToString();
                            }
                            else
                            {
                                if (p.Coefficient > 0)
                                    show += "+";
                                if (p.Coefficient != 1)
                                    show += p.Coefficient.ToString();
                                show += "x^" + p.Index.ToString();
                            }
                        }                                               
                    }
                    p = p.Next;
                }
                if (p.Index == 0)
                {
                    if (p.Coefficient > 0)
                        show += "+";
                    show += p.Coefficient.ToString();
                }
                else
                {
                    if (p.Coefficient > 0)
                        show += "+";
                    if (p.Coefficient != 1)
                        show += p.Coefficient.ToString();
                    show += "x^" + p.Index.ToString();
                }
                Console.WriteLine(show);
            }
            else
                Console.WriteLine("该线性表为空！");

        }
        public Polynomial Plus(Polynomial li1, Polynomial li2)
        {
            Node p = li1.Head;
            Node q = li2.Head;
            int x = li1.LastNumber;
            for (int i = 0; i<x; i++)
            {
                if (p.Index< q.Index&&p.Next !=null)
                {
                    p = p.Next;
                }
                else if (p.Index == q.Index)
                {
                    p.Coefficient += q.Coefficient;
                    q = q.Next;
                    p = p.Next;
                    li2.LastNumber -= 1;
                }
                else if(p.Next == null)
                {
                    break;
                }
                else
                {
                    i -= 1;
                    if (p == li1.Head)
                    {
                        Head = q;
                        Node xx = q.Next;
                        q.Next = p;
                        q = xx;
                    }
                    else
                    {
                        Node xx = q;
                        Node ww = new Node(p.Coefficient, p.Index);
                        ww.Next = p.Next;
                        p.Coefficient = q.Coefficient;
                        p.Index = q.Index;
                        p.Next = ww;
                        p = p.Next;
                        q = q.Next;
                    }
                    li1.LastNumber += 1;
                    li2.LastNumber -= 1;
                }
            }
            p.Next = q;
            li1.LastNumber += li2.LastNumber;
            return li1;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            //.Net Framework 4.5
            //代码中存储数据类型选择以整型为例，即多项式系数、指数均采取整数
            int[,] a = { { 5, 2 }, { 4, 3 }, { 8, 8 }, { 16, 12 }, { 7, 19 }, { -20, 20 } };
            int[,] b = { { 5, 0 }, { 1, 1 }, { 3, 4 }, { 6, 7 }, { 24, 8 }, { -16, 12 }, { 50, 30 }, { 80, 90 } };
            Polynomial exam1 = new Polynomial(a);
            Polynomial exam2 = new Polynomial(b);
            Console.WriteLine("两式：");
            exam1.Print();
            exam2.Print();
            Polynomial result = exam1.Plus(exam1, exam2);
            Console.WriteLine("和：");
            result.Print();
        }


    }
}
