using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTree
{
    class Node<T>  //二叉树结点(三叉链表,前驱后继)
    {      
        private T data;
        public Node<T> leftChild;
        public Node<T> rightChild;
        public T Data
        {
            get
            {
                return data;
            }
        } 

        public Node<T> LeftChild
        {
            get
            {
                return leftChild;
            }
            set
            {
                leftChild = value;
            }
        }
        public Node<T> RightChild
        {
            get
            {
                return rightChild;
            }
            set
            {
                rightChild = value;
            }
        }
        public Node<T> Parent { get; set; }
        public int Tag { get; set; }
        public Node<T> Front { get; set; }
        public Node<T> Next { get; set; }
        
        public bool IsLeaf()
        {
            if (LeftChild == null && RightChild == null)
                return true;
            else
                return false;
        }
        public bool IsSingle()
        {
            if ((leftChild == null && rightChild != null) || (rightChild == null && leftChild != null))
                return true;
            else
                return false;
        }
        public void ChangeData(T xx)
        {
            data = xx;
        }
        public Node()
        {
            data = default(T);
            LeftChild = null;
            RightChild = null;
            Parent = null;
            Tag = 0;
        }
        public Node(T dd)
        {
            data = dd;
            LeftChild = null;
            RightChild = null;
            Parent = null;
            Tag = 0;
        }
        public Node(T dd, Node<T> x, Node<T> y)
        {
            data = dd;
            LeftChild = x;
            RightChild = y;
            Parent = null;
            Tag = 0;
        }
    }

    class BinaryTree<T>  //链式存储结构二叉树(三叉链表)
    {
        //相关说明：
        //二叉树类型限int，double，char，string
        //本来二叉树结点Node中不想添加Tag，但是不添加Tag似乎无法完成三叉链表遍历，故添加Tag
        //同时保留未使用Tag完成的非递归后序遍历函数
        //除三叉链表遍历外，其他遍历未使用双亲指针Parent
        protected Node<T> root;
        public Node<T> Root
        {
            get
            {
                return root;
            }
        }
        struct StackNode  //用于未使用Tag完成的后序遍历非递归算法的结点结构
        {
            public Node<T> p;
            public int tag;
        }
        public struct Position  //描述结点的值及其在二叉树中的位置
        {
            public Node<T> p;
            public int x;  //第几行
            public int y;  //从左往右第几个
        }

        private BinaryTree<T> Contain(T x)  //此下三个函数功能为不太完美的运算符重载
        {
            BinaryTree<T> aa = new BinaryTree<T>(x);
            return aa;
        } 
        public static bool operator == (BinaryTree<T> x1, BinaryTree<T> x2)
        {
            T a1 = x1.Root.Data;
            T a2 = x2.Root.Data;
            if (typeof(T) == typeof(int))
                return (int)(object)a1 == (int)(object)a2;
            else if(typeof(T)==typeof(double))
                return (double)(object)a1 == (double)(object)a2;
            else if(typeof(T) == typeof(string))
                return (string)(object)a1 == (string)(object)a2;
            else
                return (char)(object)a1 == (char)(object)a2;
        }
        public static bool operator !=(BinaryTree<T> x1, BinaryTree<T> x2)
        {
            T a1 = x1.Root.Data;
            T a2 = x2.Root.Data;
            if (typeof(T) == typeof(int))
                return !((int)(object)a1 == (int)(object)a2);
            else if (typeof(T) == typeof(double))
                return !((double)(object)a1 == (double)(object)a2);
            else if (typeof(T) == typeof(string))
                return !((string)(object)a1 == (string)(object)a2);
            else
                return !((char)(object)a1 == (char)(object)a2);
        }

        public BinaryTree()
        {
            root = null;
        }
        public BinaryTree(T data)
        {
            root = new Node<T>(data);
        }
        public BinaryTree(string type)
        {
            //以整型为例，其余相同，因不便使用泛型涵盖，故在此仅写出整型形式
            if (type == "int")
            {
                Console.WriteLine("此种构造仅构造int型二叉树，前序遍历顺序构造，以<999>表示空");
                Console.WriteLine("请开始输入整型二叉树：");
                CreateTree(ref root, "int");
                FindParent();
            }
            else if (type == "double")
            {
                Console.WriteLine("此种构造仅构造double型二叉树，前序遍历顺序构造，以<999>表示空");
                Console.WriteLine("请开始输入双精度型二叉树：");
                CreateTree(ref root, "double");
                FindParent();
            }
            else if (type == "char")
            {
                Console.WriteLine("此种构造仅构造char型二叉树，前序遍历顺序构造，以<#>表示空");
                Console.WriteLine("请开始输入字符型二叉树：");
                CreateTree(ref root, "char");
                FindParent();
            }
            else if (type == "string")
            {
                Console.WriteLine("此种构造仅构造string型二叉树，前序遍历顺序构造，以<#>表示空");
                Console.WriteLine("请开始输入字符串型二叉树：");
                CreateTree(ref root, "string");
                FindParent();
            }
            else
                Console.WriteLine("你构造的二叉树不在包含的类型中！");           
        }
        public BinaryTree(string preOrder, string inOrder)
        {
            char[] prestr = preOrder.ToCharArray();
            char[] instr = inOrder.ToCharArray();
            root = new Node<T>((T)(object)prestr[0]);

        }

        private void CreateTree(ref Node<T> r, string type)  //递归构造二叉树
        {
            if (type == "int")
            {
                int cin = Convert.ToInt32(Console.ReadLine());
                if (cin == 999)
                    r = null;
                else
                {
                    r = new Node<T>((T)(object)cin);
                    CreateTree(ref r.leftChild, "int");
                    CreateTree(ref r.rightChild, "int");
                }
            }
            else if(type == "double")
            {
                double cin = Convert.ToDouble(Console.ReadLine());
                if (cin == 999)
                    r = null;
                else
                {
                    r = new Node<T>((T)(object)cin);
                    CreateTree(ref r.leftChild, "double");
                    CreateTree(ref r.rightChild, "double");
                }
            }
            else if(type == "char")
            {
                char cin = Convert.ToChar(Console.ReadLine());
                if (cin == '#')
                    r = null;
                else
                {
                    r = new Node<T>((T)(object)cin);
                    CreateTree(ref r.leftChild, "char");
                    CreateTree(ref r.rightChild, "char");
                }
            }
            else if(type == "string")
            {
                string cin = Console.ReadLine();
                if (cin == "#")
                    r = null;
                else
                {
                    r = new Node<T>((T)(object)cin);
                    CreateTree(ref r.leftChild, "string");
                    CreateTree(ref r.rightChild, "string");
                }
            }          
        }
        protected void FindParent()  //确定双亲指针
        {
            Stack<Node<T>> exam = new Stack<Node<T>>();
            Node<T> p = root;
            while (p != null || exam.Count != 0)
            {
                if (p != null)
                {
                    exam.Push(p);
                    if (p.leftChild != null)
                        p.LeftChild.Parent = p;
                    p = p.LeftChild;
                }
                else
                {
                    p = exam.Pop();
                    if (p.RightChild != null)
                        p.RightChild.Parent = p;
                    p = p.RightChild;
                }
            }
        }
        private void UsingEmpty()  //利用空指针建立线性结构(中序型前驱后继)
        {

        }
        private void ReturnEmpty()  //将利用空指针建立的线性结构还原为空指针(中序型前驱后继)
        {

        }
        
        public bool IsEmpty()
        {
            if (root == null)
                return true;
            else
                return false;
        }
        public void Clear()
        {
            root = null;
        }
        protected void Visit(Node<T> node)  //访问结点
        {
            Console.Write(node.Data);
            Console.Write(' ');
        }
        public int GetHeight()  //获取二叉树高度
        {
            Node<T> p = root;
            int x = 1, y = 1;
            while (p != null)
            {
                if (p.Tag == 0)
                {
                    p.Tag = 1;
                    if (p.LeftChild != null)
                    {
                        p = p.LeftChild;
                        x++;
                        y = y < x ? x : y;
                    }                       
                }
                else if (p.Tag == 1)
                {
                    p.Tag = 2;
                    if (p.RightChild != null)
                    {
                        p = p.RightChild;
                        x++;
                        y = y < x ? x : y;
                    }                   
                }
                else
                {
                    p.Tag = 0;
                    p = p.Parent;
                    x--;
                }
            }
            if (IsEmpty())
                return 0;
            else
                return y;
        }
        public int GetNumber()  //获取二叉树结点数
        {
            Node<T> p = root;
            int x = 0;
            while (p != null)
            {
                if (p.Tag == 0)
                {
                    p.Tag = 1;
                    x++;
                    if (p.LeftChild != null)
                        p = p.LeftChild;
                }
                else if (p.Tag == 1)
                {
                    p.Tag = 2;
                    if (p.RightChild != null)
                        p = p.RightChild;
                }
                else
                {
                    p.Tag = 0;
                    p = p.Parent;
                }
            }
            return x;
        }
        public Node<T>[] GetLeaf()  //获取二叉树叶子结点
        {
            Node<T>[] result = new Node<T>[GetNumber() - 1];
            int i = 0;
            Node<T> p = root;
            while (p != null)
            {
                if (p.Tag == 0)
                {
                    p.Tag = 1;
                    if (p.LeftChild == null && p.RightChild == null)
                    {
                        result[i] = p;
                        i++;
                    }
                    if (p.LeftChild != null)
                        p = p.LeftChild;                                    
                }
                else if (p.Tag == 1)
                {
                    p.Tag = 2;
                    if (p.RightChild != null)
                        p = p.RightChild;
                }
                else
                {
                    p.Tag = 0;
                    p = p.Parent;
                }
            }
            return result;
        }
        public void Insert(T xx, T yy, char aa, char bb)  //插入节点
        {
            //xx为插入值，yy为被插入值
            //aa确定xx为yy的左子还是右子，bb确定yy的左子(右子)为xx的左子还是右子
            Node<T> p = root;
            Node<T> insert = new Node<T>(xx);
            while (p != null)
            {
                if (p.Tag == 0)
                {
                    p.Tag = 1;
                    if(Contain(p.Data) == Contain(yy))  //若只处理整型可用(int)(object)p.Data == (int)(object)yy
                    {
                        if (aa == 'l' && bb == 'l') 
                        {
                            if (p.LeftChild != null)
                                p.LeftChild.Parent = insert;
                            insert.LeftChild = p.LeftChild;
                            p.LeftChild = insert;
                            insert.Parent = p;                            
                        }
                        else if(aa == 'r' && bb == 'l')
                        {
                            if (p.RightChild != null)
                                p.LeftChild.Parent = insert;
                            insert.LeftChild = p.RightChild;
                            p.RightChild = insert;
                            insert.Parent = p;                           
                        }
                        else if(aa == 'l' && bb == 'r')
                        {
                            if (p.LeftChild != null)
                                p.LeftChild.Parent = insert;
                            insert.RightChild = p.LeftChild;
                            p.LeftChild = insert;
                            insert.Parent = p;                            
                        }
                        else
                        {
                            if (p.RightChild != null)
                                p.LeftChild.Parent = insert;
                            insert.RightChild = p.RightChild;
                            p.RightChild = insert;
                            insert.Parent = p;                            
                        }
                        return;
                    }
                    if (p.LeftChild != null)
                        p = p.LeftChild;
                }
                else if (p.Tag == 1)
                {
                    p.Tag = 2;
                    if (p.RightChild != null)
                        p = p.RightChild;
                }
                else
                {
                    p.Tag = 0;
                    p = p.Parent;
                }
            }
        }
        protected int GetNodeHeight(T xx)  //获取二叉树结点所处的层数
        {
            Node<T> p = root;
            int x = 1, y = 1;
            while (p != null)
            {
                if (Contain(p.Data) == Contain(xx))
                    y = x;
                if (p.Tag == 0)
                {
                    p.Tag = 1;
                    if (p.LeftChild != null)
                    {
                        p = p.LeftChild;
                        x++;
                    }
                }
                else if (p.Tag == 1)
                {
                    p.Tag = 2;
                    if (p.RightChild != null)
                    {
                        p = p.RightChild;
                        x++;
                    }
                }
                else
                {
                    p.Tag = 0;
                    p = p.Parent;
                    x--;
                }
            }
            if (IsEmpty())
                return 0;
            else
                return y;
        }
        public virtual Position Search(T des)  //查询结点的位置
        {
            Position result = new Position();
            result.x = GetNodeHeight(des);
            Node<T>[] order = new Node<T>[GetNumber()];
            int i = 0;
            Queue<Node<T>> exam = new Queue<Node<T>>();
            Node<T> p = root;
            if (p != null)
            {
                exam.Enqueue(p);
                order[i] = p;
                i++;
            }
            while (exam.Count != 0)
            {
                p = exam.Dequeue();
                if (p.LeftChild != null)
                {
                    exam.Enqueue(p.LeftChild);
                    order[i] = p.LeftChild;
                    i++;
                }
                if (p.RightChild != null)
                {
                    exam.Enqueue(p.RightChild);
                    order[i] = p.RightChild;
                    i++;
                }
            }
            int k = 0;
            for(int j = 0; j < order.Length; j++)
            {
                k++;
                if (Contain(order[j].Data) == Contain(des))
                    break;
            }
            int q = 0;
            for(int ii = 0; ii < k; ii++)
            {
                if (GetNodeHeight(order[ii].Data) == result.x)
                {
                    q = ii + 1;
                    break;
                }                 
            }
            result.y = k - q + 1;
            return result;
        }

        public void PreOrderRecursion(Node<T> node)  //递归前序遍历
        {
            if (node == null)
                return;
            Visit(node);
            PreOrderRecursion(node.LeftChild);
            PreOrderRecursion(node.RightChild); 
        }  
        public void PreOrderNoRecursion1()  //非递归前序遍历
        {
            Stack<Node<T>> exam = new Stack<Node<T>>();
            Node<T> p = root;
            while(p!=null || exam.Count != 0)
            {
                if (p != null)
                {
                    Visit(p);
                    exam.Push(p);
                    p = p.LeftChild;
                }
                else
                {
                    p = exam.Pop();
                    p = p.RightChild;
                }
            }
            Console.WriteLine();
        }
        public void PreOrderNoRecursion2()  //非递归前序遍历简化
        {
            Stack<Node<T>> exam = new Stack<Node<T>>();
            Node<T> p = root;
            if (p != null)
                exam.Push(p);
            while (exam.Count != 0)
            {
                p = exam.Pop();
                Visit(p);
                if (p.RightChild != null)
                    exam.Push(p.RightChild);
                if (p.LeftChild != null)
                    exam.Push(p.LeftChild);           
            }
            Console.WriteLine();
        }
        public void InOrderRecursion(Node<T> node)  //递归中序遍历
        {
            if (node == null)
                return;
            InOrderRecursion(node.LeftChild);
            Visit(node);
            InOrderRecursion(node.RightChild);
        }
        public void InOrderNoRecursion()  //非递归中序遍历
        {
            //如果不使用Tag似乎无法像前序遍历简化
            //中序遍历本来不需要Tag，故不在此写出加入Tag后的简化
            //加入Tag的简化可参考后序遍历简化
            Stack<Node<T>> exam = new Stack<Node<T>>();
            Node<T> p = root;
            while(p != null || exam.Count != 0)
            {
                if (p != null)
                {
                    exam.Push(p);
                    p = p.LeftChild;
                }
                else
                {
                    p = exam.Pop();
                    Visit(p);
                    p = p.RightChild;
                }
            }
            Console.WriteLine();
        }       
        public void PostOrderRecursion(Node<T> node)  //递归后序遍历
        {
            if (node == null)
                return;
            PostOrderRecursion(node.LeftChild);
            PostOrderRecursion(node.RightChild);
            Visit(node);
        }
        public void PostOrderNoRecursion1()  //非递归后序遍历(未使用Tag)
        {
            Stack<StackNode> exam = new Stack<StackNode>();
            Node<T> p = root;
            while (p != null || exam.Count != 0)
            {
                if (p != null)
                {
                    StackNode temp = new StackNode();
                    temp.p = p;
                    temp.tag = 1;
                    exam.Push(temp);
                    p = p.LeftChild;
                }
                else
                {
                    StackNode temp = exam.Pop();
                    p = temp.p;
                    if (temp.tag == 1)
                    {
                        temp.tag++;
                        exam.Push(temp);
                        p = p.RightChild;
                    }                       
                    else
                    {
                        Visit(p);
                        p = null;
                    }
                }
            }
            Console.WriteLine();
        }
        public void PostOrderNoRecursion2()  //非递归后序遍历(使用Tag)
        {
            Stack<Node<T>> exam = new Stack<Node<T>>();
            Node<T> p = root;
            while (p != null || exam.Count != 0)
            {
                if (p != null)
                {
                    p.Tag++;
                    exam.Push(p);
                    p = p.LeftChild;
                }
                else
                {
                    p = exam.Pop();
                    if (p.Tag == 1)
                    {
                        p.Tag++;
                        exam.Push(p);
                        p = p.RightChild;
                    }
                    else
                    {
                        Visit(p);
                        p.Tag = 0;
                        p = null;
                    }
                }
            }
            Console.WriteLine();
        }
        public void PostOrderNoRecursion3()  //非递归后序遍历简化(使用Tag)
        {
            Stack<Node<T>> exam = new Stack<Node<T>>();
            Node<T> p = root;
            if (p != null)
                exam.Push(p);
            while (exam.Count != 0)
            {
                p = exam.Pop();
                if (p.Tag == 0)
                {
                    p.Tag++;
                    exam.Push(p);
                    if (p.RightChild != null)
                        exam.Push(p.RightChild);
                    if (p.LeftChild != null)
                        exam.Push(p.LeftChild);
                }
                else
                {
                    Visit(p);
                    p.Tag = 0;
                }                                                                    
            }
            Console.WriteLine();
        }
        public void TriadiusListPreOrder()  //三叉链表前序遍历
        {
            Node<T> p = root;
            while (p != null)
            {
                if (p.Tag == 0) 
                {
                    Visit(p);
                    p.Tag = 1;
                    if (p.LeftChild != null)
                        p = p.LeftChild;
                }
                else if (p.Tag == 1)
                {
                    p.Tag = 2;
                    if (p.RightChild != null)
                        p = p.RightChild;
                }
                else
                {
                    p.Tag = 0;
                    p = p.Parent;
                }
            }
            Console.WriteLine();
        }
        public void TriadiusListInOrder()  //三叉链表中序遍历
        {
            Node<T> p = root;
            while (p != null)
            {
                if (p.Tag == 0)
                {                   
                    p.Tag = 1;
                    if (p.LeftChild != null)
                        p = p.LeftChild;
                }
                else if (p.Tag == 1)
                {
                    Visit(p);
                    p.Tag = 2;
                    if (p.RightChild != null)
                        p = p.RightChild;
                }
                else
                {
                    p.Tag = 0;
                    p = p.Parent;
                }
            }
            Console.WriteLine();
        }
        public void TriadiusListPostOrder()  //三叉链表后序遍历
        {
            Node<T> p = root;
            while (p != null)
            {
                if (p.Tag == 0)
                {
                    p.Tag = 1;
                    if (p.LeftChild != null)
                        p = p.LeftChild;
                }
                else if (p.Tag == 1)
                {                    
                    p.Tag = 2;
                    if (p.RightChild != null)
                        p = p.RightChild;
                }
                else
                {
                    Visit(p);
                    p.Tag = 0;
                    p = p.Parent;
                }
            }
            Console.WriteLine();
        }
        public void LevelOrder()  //层序遍历
        {
            Queue<Node<T>> exam = new Queue<Node<T>>();
            Node<T> p = root;
            if (p != null)
                exam.Enqueue(p);
            while (exam.Count != 0)
            {
                p = exam.Dequeue();
                Visit(p);
                if (p.LeftChild != null)
                    exam.Enqueue(p.LeftChild);
                if (p.RightChild != null) 
                    exam.Enqueue(p.RightChild);
            }
            Console.WriteLine();
        }
        public void TagLineOrder()  //标识线性遍历(中序型前驱后继)
        {

        }
    }

}
