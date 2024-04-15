using SubWizard.Data;
using System.Numerics;

namespace SubWizard
{
    public class Program
    {
        public static void Main()
        {
            Gather.Init();
            Gather.TotalLetterInt();
            
            string input = Console.ReadLine() ?? "";
            BigInteger upper = UpperBound(input);
            Console.WriteLine(upper);
            //start algo
            
        }

        public static double Confidence()
        {
            double sum = 0;

            //BY TOTAL PROPORTION
            
            return sum / 26;
        }

        public static BigInteger UpperBound(string s)
        {
            List<char> found = [];
            foreach (char c in s)
            {
                if (c == ' ')
                {
                    continue;
                }
                if (!found.Contains(c))
                {
                    found.Add(c);
                }
            }
            int n = found.Count;
            BigInteger result = 1;
            for (int i = 26; i > 0; i--)
            {
                if (n == 0)
                {
                    break;
                }
                n--;
                result *= i;
            }
            return result;
        }
    }
}