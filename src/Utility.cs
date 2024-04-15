using System.Numerics;

namespace SubWizard
{
    public static class Utility
    {

        public static int GCD(int a, int b)
        {
            while (b != 0)
            {
                int temp = b;
                b = a % b;
                a = temp;
            }
            return Math.Abs(a);
        }

        public static int LCM(int a, int b)
        {
            return a * b / GCD(a, b);
        }

        public static BigInteger Factorial(int n)
        {
            if (n < 0)
            {
                throw new ArgumentException("Factorial is not defined for negative numbers.");
            }
            BigInteger result = 1;
            for (int i = 1; i <= n; i++)
            {
                result *= i;
            }
            return result;
        }

        public static double PError(double o, double t)
        {
            return Math.Abs((o - t) / t);
        }
    }
}