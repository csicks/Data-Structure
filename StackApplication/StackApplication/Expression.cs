using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackApplication
{
    class Expression  //参量为单字符的整型表达式类
    {
        //暂未找到含'^'的优先级表，故运算符暂不含'^'
        string middleExpression;
        string postExpression;
        public string MiddleExpression
        {
            get { return middleExpression; }
        }
        public string PostExpression
        {
            get { return postExpression; }
        }

        public Expression(string xx)
        {
            middleExpression = xx;
            postExpression = MiddleToPost();
        }
        public string CharJuddging(char xx)  //判断符号为OPD还是OPT
        {
            switch (xx)
            {
                case '(':
                case '+':
                case '-':
                case '*':
                case '/':
                case ')':
                    return "OPT";
                default:
                    return "OPD";
            }
        }   
        public int CharComparing(char x,char y)  //运算符优先级比较
        {
            #region 原优先级表
            /*char[,] comp = { { ' ', '+', '-', '*', '/', '(', ')', '#' },
                                     {'+', '>', '>', '<', '<', '<', '>', '>' },
                                     {'-', '>', '>', '<', '<', '<', '>', '>' },
                                     {'*', '>', '>', '>', '>', '<', '>', '>' },
                                     {'/', '>', '>', '>', '>', '<', '>', '>' },
                                     {'(', '<', '<', '<', '<', '<', '=', ' ' },
                                     {')', '>', '>', '>', '>', ' ', '>', '>' },
                                     {'#', '<', '<', '<', '<', '<', ' ', '=' },
            };*/
            #endregion
            char[,] comp = { { ' ', '+', '-', '*', '/', '#' },
                                     {'+', '=', '=', '<', '<', '>' },
                                     {'-', '=', '=', '<', '<', '>' },
                                     {'*', '>', '>', '=', '=', '>' },
                                     {'/', '>', '>', '=', '=', '>' },
                                     {'#', '<', '<', '<', '<', '=' },
            };
            int ii = 0, jj = 0;
            for(int i = 0; i < 6; i++)
            {
                if (x == comp[i, 0])
                    ii = i;
            }
            for(int i = 0; i < 6; i++)
            {
                if (y == comp[0, i])
                    jj = i;
            }
            if (y == '(')
                return 1;
            else
            {
                switch (comp[ii, jj])
                {
                    case '>':
                        return 1;
                    case '<':
                        return -1;
                    default:
                        return 0;
                }
            }
        }
        public double Operate(char xx, double a, double b)  //运算符的运算操作
        {
            switch (xx)
            {
                case '+':
                    return a + b;
                case '-':
                    return a - b;
                case '*':
                    return a * b;
                case '/':
                    return a / b;
                default:
                    return 0;
            }
        }
        public bool IsContain(char aa, char[] bb)
        {
            int x = 0;
            for(int i = 0; i < bb.Length; i++)
            {
                if (aa == bb[i])
                    x++;
            }
            if (x == 0)
                return false;
            else
                return true;
        }
        public bool IsNumString(string xx)
        {
            char[] aa = xx.ToCharArray();
            char[] bb = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', '+', '-', '*', '/', '(', ')' };
            int x = 0, y = 0;
            for(int i = 0; i < aa.Length; i++)
            {
                if (IsContain(aa[i], bb))
                    x++;
                if (aa[i] != '\0')
                    y++;
            }
            if (x == y)
                return true;
            else
                return false;
        }
        public string MiddleToPost()  //中缀表达式转换为后缀表达式
        {
            char[] aa = middleExpression.ToCharArray();
            int leng = aa.Length + 1;
            MyStack<char> save = new MyStack<char>(leng);
            save.Push('#');
            char[] showCase = new char[aa.Length];
            int showNum = 0;
            for(int i = 0; i < aa.Length; i++)
            {
                if(CharJuddging(aa[i]) == "OPD")
                {
                    showCase[showNum] = aa[i];
                    showNum++;
                }
                else if (aa[i] != '(' && aa[i] != ')')
                {
                    if (CharComparing(aa[i], save.GetTop()) == 1 || save.GetTop() == '(') 
                    {
                        save.Push(aa[i]);
                    }
                    else
                    {
                        while (CharComparing(aa[i], save.GetTop()) < 1)
                        {
                            showCase[showNum] = save.Pop();
                            showNum++;
                        }
                        save.Push(aa[i]);
                    }
                }
                else
                {
                    if (aa[i] == '(')
                        save.Push(aa[i]);
                    else
                    {
                        while (save.GetTop() != '(')
                        {
                            showCase[showNum] = save.Pop();
                            showNum++;
                        }
                        save.Pop();
                    }
                }
            }
            while(save.GetLength() > 1) 
            {
                    showCase[showNum] = save.Pop();
                    showNum++;
            }
            string tt = new string(showCase);
            return tt;
        }
        public int CharToInt(char xx)
        {
            return (int)xx - (int)'0';
        }
        public double PostExpressionStackCompute()  //后缀表达式求值
        {
            char[] bb = postExpression.ToCharArray();
            int y = 0;
            for (int i = 0; i < bb.Length; i++)
            {
                if (bb[i] != '\0')
                    y++;
            }
            char[] aa = new char[y];
            for(int i = 0; i < aa.Length; i++)
            {
                aa[i] = bb[i];
            }
            int leng = aa.Length + 1;
            MyStack<double> save = new MyStack<double>(leng);
            double result = 0;
            for(int i = 0; i < aa.Length; i++)
            {
                if (CharJuddging(aa[i]) == "OPD")
                    save.Push(CharToInt(aa[i]));
                else
                {
                    double qq = save.Pop();
                    double ww = save.Pop();
                    save.Push(Operate(aa[i], ww, qq));
                }
            }
            result = save.Pop();
            return result;
        }
        public void Print()
        {
            Console.Write("中缀表达式为： ");
            Console.WriteLine(MiddleExpression);
            Console.Write("后缀表达式为： ");
            Console.WriteLine(PostExpression);
            if (IsNumString(PostExpression))
            {
                Console.Write("结果为： ");
                Console.WriteLine(PostExpressionStackCompute());
            }              
        }
    }
}
