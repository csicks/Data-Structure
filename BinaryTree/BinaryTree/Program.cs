using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTree
{
    class Program
    {
        static int step = 1;  //为递归汉诺塔计步 

        static void Main(string[] args)
        {
            //.Net Framework 4.5
            //BinaryTree等类定义见解决方案
            //包含以下功能代码：二叉树，栈模拟递归(汉诺塔)，Huffman树及Huffman编码解码，
            //每次主函数中仅保留一个功能模块的代码，其余已被注释，若要运行测试，请自行注释/取消注释
            #region 栈模拟汉诺塔
            //Hanoi(4, 'A', 'B', 'C');
            //step = 1;
            //Console.WriteLine("************************************");
            //SimuRecursion.SimuHanoi(4, 'A', 'B', 'C');
            #endregion

            #region 二叉树建构、函数及各种遍历测试
            ////下面以字符串型二叉树为例
            //BinaryTree<string> test = new BinaryTree<string>("string");
            //Console.WriteLine();
            //test.PreOrderNoRecursion1();
            //test.PreOrderNoRecursion2();
            //test.TriadiusListPreOrder();
            //test.PreOrderRecursion(test.Root);
            //Console.WriteLine();
            //Console.WriteLine();
            //test.InOrderNoRecursion();
            //test.TriadiusListInOrder();
            //test.InOrderRecursion(test.Root);
            //Console.WriteLine();
            //Console.WriteLine();
            //test.PostOrderNoRecursion1();
            //test.PostOrderNoRecursion2();
            //test.PostOrderNoRecursion3();
            //test.TriadiusListPostOrder();
            //test.PostOrderRecursion(test.Root);
            //Console.WriteLine();
            //Console.WriteLine();
            //test.LevelOrder();

            //Console.WriteLine("高度为：{0}", test.GetHeight());
            //Console.WriteLine("结点数为：{0}", test.GetNumber());
            //Console.Write("该二叉树的叶子节点为： ");
            //Node<string>[] aa = test.GetLeaf();
            //for (int i = 0; i < aa.Length; i++)
            //{
            //    if (aa[i] != null)
            //        Console.Write(aa[i].Data);
            //    Console.Write(' ');
            //}
            //Console.WriteLine();
            //Console.WriteLine("1的位置为：第{0}行，第{1}个。", test.Search("1").x, test.Search("1").y);

            //test.Insert("9", "qw", 'l', 'r');
            ////test.Insert(9, 1, 'l', 'r');
            //test.LevelOrder();

            #endregion

            #region Huffman树测试及Huffman编码解码
            //char[] examData = { 'Z', 'B', 'P', 'A', 'X', 'E' };
            //int[] examWeight = { 2, 10, 24, 32, 32, 110 };
            //HuffmanTree<char> test = new HuffmanTree<char>(examData, examWeight);
            //test.LevelOrder();
            ////char[] examData1 = { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };
            ////int[] examWeight1 = { 2, 10, 24, 32, 32, 110, 56, 5, 6, 7, 2, 5, 5, 5, 5, 88, 33, 654, 4, 1, 2, 2, 3, 66, 3, 26 };
            ////HuffmanTree<char> test1 = new HuffmanTree<char>(examData1, examWeight1);
            ////test1.LevelOrder();
            //string xx = "hellomysongoodgo,,,ods...t!udy 'daydayupbadMIcom efuckinjuggnod  queuertsun  iversit ywav  exozack";
            //HuffmanCode newCode = new HuffmanCode(xx);
            //string zz = "hello world, zz!  I'm Mr.cisks!!";
            //string cc = newCode.ToCode(zz);
            //Console.WriteLine(cc);
            //Console.WriteLine(newCode.TranslateCode(cc));
            #endregion

            #region BST树(二叉搜索树)测试
            //BinarySearchTree test = new BinarySearchTree();
            //test.NoneRecurseInsert(5);
            //test.NoneRecurseInsert(8);
            //test.NoneRecurseInsert(3);
            //test.NoneRecurseInsert(1);
            //Console.WriteLine(test.Search(1));
            //Console.WriteLine();
            //int[] xx = { 5, 3, 7, 9, 4, 42, 56, 6, 1 };
            //BinarySearchTree test1 = new BinarySearchTree(xx);
            //test1.LevelOrder();

            //test1.DeleteOne(5);
            //test1.LevelOrder();

            //test1.CutOne(7);
            //test1.LevelOrder();
            #endregion

            #region AVL树(平衡二叉搜索树)测试
            
            #endregion

            Console.ReadLine();
        }

        static void Hanoi(int n, char a, char b, char c)  //递归汉诺塔
        {
            if (n == 1)
            {
                Console.WriteLine("Step {0} : Move slice form {1} to {2}", step, a, c);
                step++;
            }                
            else
            {
                Hanoi(n - 1, a, c, b);
                Console.WriteLine("Step {0} : Move slice form {1} to {2}", step, a, c);
                step++;
                Hanoi(n - 1, b, a, c);
            }
        }

    }
}
