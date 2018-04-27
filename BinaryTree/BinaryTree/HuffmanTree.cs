using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTree
{
    class HuffmanTreeNode<T>  //哈弗曼树结点
    {
        private T data;
        private int weight;
        public T Data
        {
            get
            {
                return data;
            }
        }
        public int Weight
        {
            get
            {
                return weight;
            }
        }
        public HuffmanTreeNode<T> LeftChild { get; set; }
        public HuffmanTreeNode<T> RightChild { get; set; }
        public HuffmanTreeNode<T> Parent { get; set; }
        public int Tag { get; set; }

        public bool IsLeaf()
        {
            if (LeftChild == null && RightChild == null)
                return true;
            else
                return false;
        }
        public HuffmanTreeNode()
        {
            data = default(T);
            weight = 0;
            LeftChild = null;
            RightChild = null;
            Parent = null;
            Tag = 0;
        }
        public HuffmanTreeNode(T dd, int xx)
        {
            data = dd;
            weight = xx;
            LeftChild = null;
            RightChild = null;
            Parent = null;
            Tag = 0;
        }
    }

    class HuffmanTree<T>  //哈弗曼树
    {
        //简单起见，不继承BinaryTree，也不写出二叉树中众多函数
        //为方便Huffman编码，HuffmanTreeNode中添加Tag与Parent指针
        HuffmanTreeNode<T> root;
        public HuffmanTreeNode<T> Root
        {
            get
            {
                return root;
            }
        }

        public HuffmanTree()
        {
            root = null;
        }
        public HuffmanTree(T data, int weight)
        {
            root = new HuffmanTreeNode<T>(data, weight);
        }
        public HuffmanTree(T[] data, int[] weight)  //唯一构造
        {
            if (data.Length != weight.Length)
                Console.WriteLine("输入数据数组与权值数组长度不同！");
            else
            {
                HuffmanTree<T>[] forest = new HuffmanTree<T>[data.Length];
                int leng = forest.Length;
                for (int i = 0; i < forest.Length; i++)
                {
                    forest[i] = new HuffmanTree<T>();
                    forest[i].root = new HuffmanTreeNode<T>(data[i], weight[i]);
                }
                for (int i = 0; i < leng-1; i++) 
                {
                    int x = FindSmall(forest)[0], y = FindSmall(forest)[1];
                    HuffmanTree<T> temp1 = forest[x];
                    HuffmanTree<T> temp2 = forest[y];
                    forest[x] = null;
                    forest[y] = null;
                    HuffmanTree<T> newtree = new HuffmanTree<T>(default(T), temp1.root.Weight + temp2.root.Weight);
                    if(temp1.root.Weight < temp2.root.Weight)
                    {
                        newtree.root.LeftChild = temp1.root;
                        newtree.root.RightChild = temp2.root;
                    }
                    else if(temp1.root.Weight > temp2.root.Weight)
                    {
                        newtree.root.LeftChild = temp2.root;
                        newtree.root.RightChild = temp1.root;
                    }
                    else
                    {
                        if(GetHeight(temp1.root)< GetHeight(temp2.root))
                        {
                            newtree.root.LeftChild = temp1.root;
                            newtree.root.RightChild = temp2.root;
                        }
                        else if(GetHeight(temp1.root) > GetHeight(temp2.root))
                        {
                            newtree.root.LeftChild = temp2.root;
                            newtree.root.RightChild = temp1.root;
                        }
                        else
                        {
                            if (x < y)
                            {
                                newtree.root.LeftChild = temp1.root;
                                newtree.root.RightChild = temp2.root;
                            }
                            else
                            {
                                newtree.root.LeftChild = temp2.root;
                                newtree.root.RightChild = temp1.root;
                            }
                        }
                    }
                    forest[x] = newtree;
                    forest = ClearNull(forest);
                }
                root = forest[0].root;
                FindParent();
            }
        }

        private HuffmanTree<T>[] ClearNull(HuffmanTree<T>[] forest)  //清除森林中空树
        {
            int x = 0;
            for(int i = 0; i < forest.Length; i++)
            {
                if (forest[i] != null)
                    x++;
            }
            HuffmanTree<T>[] result = new HuffmanTree<T>[x];
            int y = 0;
            for(int i=0; i< forest.Length; i++)
            {
                if(forest[i] != null)
                {
                    result[y] = forest[i];
                    y++;
                }
            }
            return result;
        }  
        private int[] FindSmall(HuffmanTree<T>[] forest)  //找到森林中权值最小的两棵树
        {
            int[] result = new int[2];
            HuffmanTree<T>[] temp = new HuffmanTree<T>[forest.Length];      
            for(int i = 0; i < temp.Length; i++) 
            {
                temp[i] = forest[i];
            }     
            for (int i = 0; i < temp.Length; i++)
                for(int j = i; j > 0; j--)
                    if(temp[j].root.Weight< temp[j - 1].root.Weight)
                    {
                        HuffmanTree<T> temp1 = temp[j];
                        temp[j] = temp[j - 1];
                        temp[j - 1] = temp1;
                    }
            int x = temp[0].root.Weight, y = temp[1].root.Weight;
            for(int i = 0; i < forest.Length; i++)
            {
                if (forest[i].root.Weight == x)
                    result[0] = i;
            }
            for (int i = 0; i < forest.Length; i++)
            {
                if (forest[i].root.Weight == y && i != result[0]) 
                    result[1] = i;
            }
            return result;
        }  
        private void Visit(HuffmanTreeNode<T> node)  //访问结点
        {
            Console.Write("{0}&{1}", node.Data, node.Weight);
            Console.Write(' ');
        }
        private void FindParent()  //确定双亲指针
        {
            Stack<HuffmanTreeNode<T>> exam = new Stack<HuffmanTreeNode<T>>();
            HuffmanTreeNode<T> p = root;
            while (p != null || exam.Count != 0)
            {
                if (p != null)
                {
                    exam.Push(p);
                    if (p.LeftChild != null)
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
        public int GetHeight(HuffmanTreeNode<T> xx)  //获取二叉树高度
        {
            if (xx == null) 
                return 0;
            return Math.Max(GetHeight(xx.LeftChild), GetHeight(xx.RightChild)) + 1;
        }
        public void LevelOrder()  //层序遍历
        {
            Console.WriteLine("该Huffman树的层序遍历为：");
            Queue<HuffmanTreeNode<T>> exam = new Queue<HuffmanTreeNode<T>>();
            HuffmanTreeNode<T> p = root;
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

    }
}
