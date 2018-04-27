using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTree
{
    class HuffmanCode
    {
        HuffmanTree<char> codeTree;
        string message;
        public string Message
        {
            get
            {
                return message;
            }
        }

        public HuffmanCode(string xx)
        {
            message = xx;
            codeTree = BuildTree();
        }
        private int Contain(char[] xx, char y)  //数组xx中含y元素的个数
        {
            int num = 0;
            for(int i = 0; i < xx.Length; i++)
            {
                if (xx[i] == y)
                    num++;
            }
            return num;
        }
        private HuffmanTree<char> BuildTree()  //建立Huffman树
        {
            char[] temp = message.ToCharArray();
            char[] letter1 = new char[temp.Length];
            int k = 0;
            for(int i = 0; i < temp.Length; i++)
            {
                if (Contain(letter1, temp[i]) == 0)
                {
                    letter1[k] = temp[i];
                    k++;
                }                    
            }
            int num = 0;
            for(int i = 0; i < letter1.Length; i++)
            {
                if (letter1[i] != '\0')
                    num++;
            }
            char[] letter = new char[num];
            int[] weight = new int[num];
            for(int i = 0; i < letter.Length; i++)
            {
                letter[i] = letter1[i];
            }
            for (int i = 0; i < weight.Length; i++)
            {
                weight[i] = Contain(temp, letter[i]);
            }
            HuffmanTree<char> codeTree = new HuffmanTree<char>(letter, weight);
            return codeTree;
        }
        private string FindCode(char xx)  //将单字符翻译成Huffman编码
        {
            string result = "";
            string result1 = "";
            HuffmanTreeNode<char> p = codeTree.Root;
            while (p != null)
            {
                if (p.Tag == 0)
                {
                    p.Tag = 1;
                    if (p.LeftChild != null)
                    {
                        p = p.LeftChild;
                        result += "0";
                    }
                }
                else if (p.Tag == 1)
                {
                    p.Tag = 2;
                    if (p.RightChild != null)
                    {
                        p = p.RightChild;
                        result += "1";
                    }
                }
                else
                {
                    p.Tag = 0;
                    if (p.Data == xx)
                        result1 = result;                  
                    p = p.Parent;
                    if (p!= codeTree.Root || (p == codeTree.Root&& codeTree.Root.Tag==1)) 
                        result = result.Substring(0, result.Length - 1);
                }
            }
            return result1;
        }
        public string ToCode(string xx)  //将字符串翻译成Huffman编码
        {
            char[] temp = xx.ToCharArray();
            string result = "";
            for(int i = 0; i < temp.Length; i++)
            {
                result += FindCode(temp[i]);
            }
            return result;
        }
        private bool CharArrayJuddge(char[] xx)  //判断字符数组是否为空
        {
            int k = 0;
            for (int i = 0; i < xx.Length; i++)
                if (xx[i] == '\0')
                    k++;
            return k == xx.Length;
        }
        public string TranslateCode(string xx)  //翻译Huffman编码至原始信息
        {
            char[] temp = xx.ToCharArray();
            string result = "";
            int i = 0;
            HuffmanTreeNode<char> p = codeTree.Root;
            while (!CharArrayJuddge(temp)) 
            {
                int x = i;
                while (!p.IsLeaf())
                {
                    if (temp[i] == '0')
                        p = p.LeftChild;
                    else
                        p = p.RightChild;
                    i++;
                }
                result += p.Data;
                p = codeTree.Root;
                for (int j = x; j < i; j++)
                    temp[j] = '\0';
                
            }
            return result;
        }

    }
}
