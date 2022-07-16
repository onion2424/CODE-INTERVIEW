using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CODE_INTERVIEW
{
    public class Problem1
    {

        public static void Main(string[] args)
        {
            Console.WriteLine(isUniqueChars3(args[0]) ? "true" : "false");
            Console.WriteLine(isUniqueChars4(args[0]) ? "true" : "false");


            return;
        }
        // Space: O(1)
        // Time: O(n^2)
        public static bool isUniqueChars1(string str)
        {
            int cnt = 0;
            for (int i = 0; i < str.Length - 1; i++) // length-1まででいいことに注意
            {
                for (int j = i + 1; j < str.Length; j++)
                {
                    if (str[i] == str[j])
                    {
                        return false;
                    }
                    cnt++;
                }
            }
            Console.WriteLine(cnt);
            return true;
        }

        // Space: O(1)
        // Time: O(1) or O(n)
        public static bool isUniqueChars2(string str)
        {
            if (str.Length > 128) return false;

            bool[] char_set = new bool[128];
            for (int i = 0; i < str.Length; i++)
            {
                int val = (int)str[i];
                if (char_set[val])
                {
                    return false;
                }
                char_set[val] = true;
            }
            return true;
        }

        // 1Byte 8bit * 32文字 = 32bitの8倍
        // Space: O(1)
        // Time: O(n) or O(1)　理屈上32回ループまで
        public static bool isUniqueChars3(string str)
        {
            int checker = 0;
            for (int i = 0; i < str.Length; i++)
            {
                int val = (int)str[i] - 'a';
                // アルファベットの番号の位置をチェックし、その位置のビットを立てる
                if ((checker & (1 << val)) > 0)
                {
                    return false;
                }
                checker |= (1 << val);
            }
            return true;
        }

        // C#的解法
        // Space: O(N)
        // Time: O(N)
        public static bool isUniqueChars4(string str)
        {
            for (int i = 0; i < str.Length; i++)
            {
                var charHashSet = new HashSet<char>();
                foreach (var c in str)
                {
                    if (!charHashSet.Add(c))
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}
