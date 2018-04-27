using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTree
{
    class BinarySearchTree : BinaryTree<int>
    {
        public BinarySearchTree() { }
        public BinarySearchTree(int xx) : base(xx) { }
        public BinarySearchTree(int[] xx)
        {
            for (int i = 0; i < xx.Length; i++)
                RecurseInsert(ref root, xx[i]);
            FindParent();
        }

        public new int Search(int xx)  //改写父类的Search，返回坐标
        {
            //为了不违背二叉查找树快速查找的目的，这里仅求出xx位于行数
            Node<int> p = root;
            int x = 1;
            while (p.Data != xx)
            {
                if (xx < p.Data)
                    p = p.leftChild;
                else
                    p = p.rightChild;
                x++;
            }
            return x;
        }
        public Node<int> RecurseNewSearch(Node<int> r, int xx)  //递归Search，返回结点
        {
            if (r == null)
                return null;
            else if (xx < r.Data)
                return RecurseNewSearch(r.leftChild, xx);
            else if (xx > r.Data)
                return RecurseNewSearch(r.rightChild, xx);
            else
                return r;
        }
        public Node<int> NoneRecurseNewSearch(int xx)  //非递归Search，返回结点
        {
            Node<int> p = root;
            while (p != null)
            {
                if (xx < p.Data)
                    p = p.leftChild;
                else if (xx > p.Data)
                    p = p.rightChild;
                else
                    return p;
            }
            return null;
        }
        public void RecurseInsert(ref Node<int> r, int xx)  //递归插入
        {
            //因为root的保护级别，无法在外部调用
            if (r == null)
            {
                r = new Node<int>(xx);
                return;
            }
            else
            {
                if (xx == r.Data)
                    return;
                else if (xx < r.Data)
                    RecurseInsert(ref r.leftChild, xx);
                else
                    RecurseInsert(ref r.rightChild, xx);
            }
        }
        public void NoneRecurseInsert(int xx)  //非递归插入
        {
            if (root == null)
            {
                root = new Node<int>(xx);
            }
            Node<int> p = root, q = null;
            while (p != null)
            {
                q = p;
                if (xx == p.Data)
                    return;
                else if (xx < p.Data)
                    p = p.leftChild;
                else
                    p = p.rightChild;
            }
            if (xx < q.Data)
                q.leftChild = new Node<int>(xx);
            else
                q.rightChild = new Node<int>(xx);
        }
        private void Insert(Node<int> insert, Node<int> node)  //结点插入结点
        {
            if (node == null)
            {
                node = insert;
            }
            Node<int> p = node, q = null;
            while (p != null)
            {
                q = p;
                if (insert.Data == p.Data)
                    return;
                else if (insert.Data < p.Data)
                    p = p.leftChild;
                else
                    p = p.rightChild;
            }
            if (insert.Data < q.Data)
                q.leftChild = insert;
            else
                q.rightChild = insert;
        }
        private Node<int> FindPre(Node<int> pp)  //找到中序前驱
        {
            Stack<Node<int>> exam = new Stack<Node<int>>();
            Node<int> p = root;
            Node<int>[] preorder = new Node<int>[GetNumber()];
            int k = 0;
            while (p != null || exam.Count != 0)
            {
                if (p != null)
                {
                    exam.Push(p);
                    p = p.LeftChild;
                }
                else
                {
                    p = exam.Pop();
                    preorder[k] = p;
                    k++;
                    p = p.RightChild;
                }
            }
            for(int i = 0; i < preorder.Length; i++)
            {
                if (preorder[i] == pp)
                    return preorder[i - 1];
            }
            return null;
        }
        public void DeleteOne(int xx)  //删除单结点(递归)
        {
            //以左子树最大元素替换为例
            Node<int> f = NoneRecurseNewSearch(xx);
            if (f == null)
            {
                Console.WriteLine("你要删除的结点不存在！");
                return;
            }
            else if (f.IsLeaf())
            {
                if (f.Parent.LeftChild == f)
                    f.Parent.LeftChild = null;
                else
                    f.Parent.RightChild = null;
            }
            else if (f.IsSingle())
            {
                if (f.Parent.LeftChild == f)
                {
                    if (f.LeftChild == null)
                        f.Parent.LeftChild = f.RightChild;
                    else
                        f.Parent.LeftChild = f.LeftChild;
                }
                else
                {
                    if (f.LeftChild == null)
                        f.Parent.RightChild = f.RightChild;
                    else
                        f.Parent.RightChild = f.LeftChild;
                }
            }
            else
            {
                int x = FindPre(f).Data;
                DeleteOne(x);
                f.ChangeData(x);
            }
            FindParent();
        }
        public void CutOne(int xx)  //截枝删除
        {
            //左子树挂右子树
            Node<int> f = NoneRecurseNewSearch(xx);
            if (f == null)
            {
                Console.WriteLine("你要删除的结点不存在！");
                return;
            }
            else if (f.IsLeaf())
            {
                if (f.Parent.LeftChild == f)
                    f.Parent.LeftChild = null;
                else
                    f.Parent.RightChild = null;
            }
            else if (f.IsSingle())
            {
                if (f.Parent.LeftChild == f)
                {
                    if (f.LeftChild == null)
                        f.Parent.LeftChild = f.RightChild;
                    else
                        f.Parent.LeftChild = f.LeftChild;
                }
                else
                {
                    if (f.LeftChild == null)
                        f.Parent.RightChild = f.RightChild;
                    else
                        f.Parent.RightChild = f.LeftChild;
                }
            }
            else
            {
                if (f.Parent.LeftChild == f)
                {
                    f.Parent.LeftChild = f.RightChild;
                }
                else
                {
                    f.Parent.RightChild = f.RightChild;
                }
                Insert(f.leftChild, f.rightChild);
            }
            FindParent();
        }
    }
}
