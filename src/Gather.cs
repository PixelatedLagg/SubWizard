using System.Text.Json;
using ExtendedNumerics;

namespace SubWizard.Data
{
    public static class Gather
    {
        private static string[] data;
        public static void Init()
        {
            data = File.ReadAllLines("words_alpha.txt");
        }
        public static void Init(string phrase)
        {
            data = phrase.Split(' ');
        }
        public static void ProbLetterInWord()
        {
            int[] prob = new int[26];
            foreach (string s in data)
            {
                for (int i = 0; i < 26; i++)
                {
                    if (s.Contains((char)('a' + i)))
                    {
                        prob[i]++;
                    }
                }
            }
            for (int i = 0; i < 26; i++)
            {
                Console.WriteLine($"{(char)('a' + i)} - {(double)prob[i] / data.Length}");
            }
        }
        public static double[] TotalLetterFreq()
        {
            int[] count = new int[26];
            int total = 0;
            for (int i = 0; i < 26; i++)
            {
                count[i] = 0;
            }
            foreach (string s in data)
            {
                foreach (char c in s)
                {
                    for (int i = 0; i < 26; i++)
                    {
                        if (c == 'a' + i)
                        {
                            count[i]++;
                        }
                    }
                    total++;
                }
            }
            double[] result = new double[26];
            for (int i = 0; i < 26; i++)
            {
                result[i] = (double)count[i] / total;
            }
            return result;
        }
        /*public static void AvgLetterWordFreq()
        {
            int[] wordCount = new int[26];
            (int, int)[] sum = new (int, int)[26];
            for (int i = 0; i < 26; i++)
            {
                wordCount[i] = 0;
                sum[i] = (0, 1);
            }
            foreach (string s in data)
            {
                for (int i = 0; i < 26; i++)
                {
                    if (s.Contains((char)('a' + i)))
                    {
                        wordCount[i]++;
                        int count = 0;
                        foreach (char c in s)
                        {
                            if (c == 'a' + i)
                            {
                                count++;
                            }
                        }
                        sum[i] = Utility.AddFrac(sum[i].Item1, sum[i].Item2, count, s.Length);
                    }
                }
            }
            for (int i = 0; i < 26; i++)
            {
                Console.WriteLine($"AVG_LETTER_WORD {(char)('a' + i)} - {(double)sum[i].Item1 / sum[i].Item2 / wordCount[i]}");
            }
        }*/
        public static void AvgLetterWordFreq()
        {
            int[] wordCount = new int[26];
            double[] sum = new double[26];
            for (int i = 0; i < 26; i++)
            {
                wordCount[i] = 0;
                sum[i] = 0;
            }
            foreach (string s in data)
            {
                for (int i = 0; i < 26; i++)
                {
                    if (s.Contains((char)('a' + i)))
                    {
                        wordCount[i]++;
                        int count = 0;
                        foreach (char c in s)
                        {
                            if (c == 'a' + i)
                            {
                                count++;
                            }
                        }
                        sum[i] = (double)count / s.Length;
                    }
                }
            }
            for (int i = 0; i < 26; i++)
            {
                Console.WriteLine($"AVG_LETTER_WORD {(char)('a' + i)} - {sum[i] / wordCount[i]}");
            }
        }
        public static void TotalLetterInt()
        {
            int[] count = new int[26];
            int total = 0;
            for (int i = 0; i < 26; i++)
            {
                count[i] = 0;
            }
            foreach (string s in data)
            {
                foreach (char c in s)
                {
                    for (int i = 0; i < 26; i++)
                    {
                        if (c == 'a' + i)
                        {
                            count[i]++;
                        }
                    }
                    total++;
                }
            }
            for (int i = 0; i < 26; i++)
            {
                Console.WriteLine($"TOTAL_FREQ {(char)('a' + i)} - {count[i]} - TOTAL: {total}");
            }
        }
        public static double FreqLetterWord(string word, char letter)
        {
            int count = 0;
            foreach (char c in word)
            {
                if (c == letter)
                {
                    count++;
                }
            }
            return count / word.Length;
        }
        public static BigDecimal FreqLetterWords(string[] words, char letter)
        {
            int count = 0;
            int total = 0;
            foreach (string s in words)
            {
                total += s.Length;
                foreach (char c in s)
                {
                    if (c == letter)
                    {
                        count++;
                    }
                }
            }
            return count / total;
        }
    }
}