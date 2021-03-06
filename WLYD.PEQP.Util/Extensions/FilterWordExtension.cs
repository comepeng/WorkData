﻿using System.Collections.Generic;

namespace Compeng.PEQP.Util.Extensions
{
 
    #region 非法关键字过滤
    /// <summary>
    /// 非法关键词过滤(自动忽略汉字数字字母间的其他字符)
    /// </summary>
    public class FilterWordExtension
    {
        public FilterWordExtension() { }

        public FilterWordExtension(string dictionaryPath)
        {
            this.dictionaryPath = dictionaryPath;
        }

        private string dictionaryPath = string.Empty;
        /// <summary>
        /// 词库路径
        /// </summary>
        public string DictionaryPath
        {
            get { return dictionaryPath; }
            set { dictionaryPath = value; }
        }
        /// <summary>
        /// 内存词典
        /// </summary>
        private WordGroup[] MEMORYLEXICON = new WordGroup[(int)char.MaxValue];

        private string sourctText = string.Empty;
        /// <summary>
        /// 检测源
        /// </summary>
        public string SourctText
        {
            get { return sourctText; }
            set { sourctText = value; }
        }

        /// <summary>
        /// 检测源游标
        /// </summary>
        int cursor = 0;

        /// <summary>
        /// 匹配成功后偏移量
        /// </summary>
        int wordlenght = 0;

        /// <summary>
        /// 检测词游标
        /// </summary>
        int nextCursor = 0;


        private List<string> illegalWords=new List<string>();

        /// <summary>
        /// 检测到的非法词集
        /// </summary>
        public List<string> IllegalWords
        {
            get { return illegalWords; }
        }

        /// <summary>
        /// 判断是否是中文
        /// </summary>
        /// <param name="character"></param>
        /// <returns></returns>
        private bool isCHS(char character)
        {
            //  中文表意字符的范围 4E00-9FA5
            int charVal = (int)character;
            return (charVal >= 0x4e00 && charVal <= 0x9fa5);
        }

        /// <summary>
        /// 判断是否是数字
        /// </summary>
        /// <param name="character"></param>
        /// <returns></returns>
        private bool isNum(char character)
        {
            int charVal = (int)character;
            return (charVal >= 48 && charVal <= 57);
        }

        /// <summary>
        /// 判断是否是字母
        /// </summary>
        /// <param name="character"></param>
        /// <returns></returns>
        private bool isAlphabet(char character)
        {
            int charVal = (int)character;
            return ((charVal >= 97 && charVal <= 122) || (charVal >= 65 && charVal <= 90));
        }


        /// <summary>
        /// 转半角小写的函数(DBC case)
        /// </summary>
        /// <param name="input">任意字符串</param>
        /// <returns>半角字符串</returns>
        ///<remarks>
        ///全角空格为12288，半角空格为32
        ///其他字符半角(33-126)与全角(65281-65374)的对应关系是：均相差65248
        ///</remarks>
        private string ToDBC(string input)
        {
            char[] c = input.ToCharArray();
            for (int i = 0; i < c.Length; i++)
            {
                if (c[i] == 12288)
                {
                    c[i] = (char)32;
                    continue;
                }
                if (c[i] > 65280 && c[i] < 65375)
                    c[i] = (char)(c[i] - 65248);
            }
            return new string(c).ToLower();
        }

     

        /// <summary>
        /// 检测
        /// </summary>
        /// <param name="blackWord"></param>
        /// <returns></returns>
        private bool Check(string blackWord)
        {
            wordlenght = 0;
            //检测源下一位游标
            nextCursor = cursor + 1;
            bool found = false;
            //遍历词的每一位做匹配
            for (int i = 0; i < blackWord.Length; i++)
            {
                //特殊字符偏移游标
                int offset = 0;
                if (nextCursor >= sourctText.Length)
                {
                    break;
                }
                else
                {
                    //检测下位字符如果不是汉字 数字 字符 偏移量加1
                    for (int y = nextCursor; y < sourctText.Length; y++)
                    {

                        if (!isCHS(sourctText[y]) && !isNum(sourctText[y]) && !isAlphabet(sourctText[y]))
                        {
                            offset++;
                            //避让特殊字符，下位游标如果>=字符串长度 跳出
                            if (nextCursor + offset >= sourctText.Length) break;
                            wordlenght++;

                        }
                        else break;
                    }

                    if ((int)blackWord[i] == (int)sourctText[nextCursor + offset])
                    {
                        found = true;
                    }
                    else
                    {
                        found = false;
                        break;
                    }


                }
                nextCursor = nextCursor + 1 + offset;
                wordlenght++;


            }
            return found;
        }

      
    }
    /// <summary>
    /// 具有相同首字符的词组集合
    /// </summary>
    class WordGroup
    {
        /// <summary>
        /// 集合
        /// </summary>
        private List<string> groupList;

        public WordGroup()
        {
            groupList = new List<string>();
        }

        /// <summary>
        /// 添加词
        /// </summary>
        /// <param name="word"></param>
        public void Add(string word)
        {
            groupList.Add(word);
        }

        /// <summary>
        /// 获取总数
        /// </summary>
        /// <returns></returns>
        public int Count()
        {
            return groupList.Count;
        }

        /// <summary>
        /// 根据下标获取词
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public string GetWord(int index)
        {
            return groupList[index];
        }
    }

    #endregion
}

