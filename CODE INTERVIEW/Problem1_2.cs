using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CODE_INTERVIEW
{
    class Problem1_2
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(permutation(args[0], args[1]) ? "true" : "false");
        }
        // Space: O(N)
        // Time: O(N log N)
        public static string sort(string s)
        {
            char[] content = s.ToCharArray();
            Array.Sort(content);
            // var sortedStr1 = string.Concat(string1.OrderBy(c => c));
            // var sortedStr2 = string.Concat(string2.OrderBy(c => c));
            return new string(content);
        }
        public static bool permutation(string s, string t)
        {
            if (s.Length != t.Length)
            {
                return false;
            }
            return sort(s).Equals(sort(t));
        }

        // Space: O(1)
        // Time: O(N)
        public static bool permutation2(string s, string t)
        {
            if (s.Length != t.Length)
            {
                return false;
            }
            int[] letters = new int[128]; //ASCII予定
            for (int i = 0; i < s.Length; i++)
            {
                letters[(int)s[i]]++;
            }

            for (int i = 0; i < t.Length; i++)
            {
                letters[(int)t[i]]--;
                if (letters[(int)t[i]] < 0)
                {
                    return false;
                }
            }
            // 同じ長さで、負にならない = 正にもならない
            return true;
        }

        // C#的解法 (hashSetでよさそうだけど)
        // Space: O(N) MAX(Dictionary.length) = 128だろうし、O(1)?
        // Time: O(N)
        public static bool artStrngsPermutationNoSort(string string1, string string2)
        {
            if (string1.Length != string2.Length)
            {
                return false;
            }

            var allChars = new Dictionary<char, int>();

            for (int i = 0; i < string1.Length; i++)
            {
                var c = string1[i];
                if (allChars.ContainsKey(c))
                {
                    allChars[c]++;
                }
                else
                {
                    allChars[c] = 1;
                }
            }

            for (int i = 0; i < string2.Length; i++)
            {
                var c = string2[i];
                int occurences = 0;
                if (!allChars.ContainsKey(c))
                {
                    return false;
                }
                else if (occurences == 1)
                {
                    allChars.Remove(c);
                }
                else
                {
                    allChars[c]--;
                }
            }

            return true;
        }
    }
}
