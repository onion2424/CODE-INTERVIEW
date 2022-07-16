using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CODE_INTERVIEW
{
    public class Problem4
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(Problem4_3.isPermutationOfPalindrome3(args[0]) ? "true" : "false");
        }
        // Space: O(1) (a~zまでの個数分だけ)
        // Time: O(N)
        public static bool isPermutationOfPalindrome(string phrase)
        {
            int[] table = buildCharFrequencyTable(phrase);
            return checkMaxOneOdd(table);
        }

        // 文字数が奇数なのは1つまで(文字長が偶数なら必ず0 or 2以上)
        public static bool checkMaxOneOdd(int[] table)
        {
            bool foundOdd = false;
            foreach (int count in table)
            {
                if (count % 2 == 1)
                {
                    if (foundOdd)
                    {
                        return false;
                    }
                    foundOdd = true;
                }
            }
            return true;
        }

        // 文字を数字に割り当てる a->0, b->1
        // 大文字小文字の区別はしない。文字以外は-1とする
        public static int getCharNumber(char c)
        {
            int a = (int)'a';
            int z = (int)'z';
            int val = (int)c;

            if (a <= val && val <= z)
            {
                return val - a;
            }
            return -1;
        }

        // 各文字が何回現れるかを数える
        public static int[] buildCharFrequencyTable(string phrase)
        {
            int[] table = new int[(int)'z' - (int)'a'];
            foreach (char c in phrase)
            {
                int x = getCharNumber(c);
                if (x != -1)
                {
                    table[x]++;
                }
            }
            return table;
        }

    }
    class Problem4_2
    {
        // 途中で確認する方法
        // アルゴリズムは常に文字列全体を調べなければならないので、計算量自体はO(N)が最適化の限界。しかし工夫をすることでいくらか効率的になる。
        // Space: O(1)
        // Time: O(n) 
        public static bool isPermutationOfPalindrome2(string phrase)
        {
            int countOdd = 0;
            int[] table = new int[(int)'z' - (int)'a'];
            foreach (char c in phrase)
            {
                int x = Problem4.getCharNumber(c);
                if (x != -1)
                {
                    table[x]++;
                    if (table[x] % 2 == 1)
                    {
                        countOdd++;
                    }
                    else
                    {
                        countOdd--;
                    }
                }
            }
            return countOdd <= 1;
        }
    }
    class Problem4_3
    {

        public static bool isPermutationOfPalindrome3(string phrase)
        {
            int bitVector = createBitVector(phrase);
            return bitVector == 0 || checkExactlyOneBitSet(bitVector);
        }

        // 文字列に対するビットベクトルを生成
        // 各文字の文字番号iについてiビット目を切り替える。
        public static int createBitVector(string phrase)
        {
            int bitVector = 0;
            foreach (char c in phrase)
            {
                int x = Problem4.getCharNumber(c);
                bitVector = toggle(bitVector, x);
            }
            return bitVector;
        }

        // 整数のiビット目を切り替える
        public static int toggle(int bitVector, int index)
        {
            if (index < 0) return bitVector;

            int mask = 1 << index;
            if ((bitVector & mask) == 0)
            {
                bitVector |= mask;
            }
            else
            {
                bitVector &= -mask;
            }
            return bitVector;
        }

        // 整数値から1減算したものと元の数とのANDを取り、1ビットだけが1になっているかどうかをチェックする。
        public static bool checkExactlyOneBitSet(int bitVector)
        {
            return (bitVector & (bitVector - 1)) == 0;
        }


    }
}
