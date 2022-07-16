using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CODE_INTERVIEW
{
    class Problem1_3
    {

        // Space: O(n) 最悪の場合が、全て空白でO(3n) = O(n) ただし、これは引数なのでO(1)とも考えられる
        // Time: ループ2回は足し算 O(n + n) = O(2n) = O(n)
        public static void replaceSpaces(char[] str, int trueLength)
        {
            int spaceCount = 0;

            for (int i = 0; i < trueLength; i++)
            {
                if (str[i] == ' ')
                {
                    spaceCount++;
                }
            }
            // 配列の幅を置き換えた後の幅する
            int index = trueLength + spaceCount * 2;
            // strに空白が無い場合は、終端文字を入れて終わらせる
            if (trueLength < str.Length)
            {
                str[trueLength] = '0';
            }

            // 後ろから見ることで、str内の動きで完結する
            for (int i = trueLength - 1; i >= 0; i--)
            {
                if (str[i] == ' ')
                {
                    str[index - 1] = '0';
                    str[index - 2] = '2';
                    str[index - 3] = '%';
                    index = index - 3;
                }
                else
                {
                    str[index - 1] = str[i];
                    index--;
                }
            }
            Console.WriteLine(str);
        }
    }
}
