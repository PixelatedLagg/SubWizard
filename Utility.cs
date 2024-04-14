namespace SubWizard
{
    public static class Utility
    {
        public static (int, int) AddFrac(int num1, int denom1, int num2, int denom2)
        {
            int lcm = LCM(denom1, denom2);
            return (num1 * (lcm / denom1) + num2 * (lcm / denom2), lcm);
        }

        private static int GCD(int a, int b)
        {
            while (b != 0)
            {
                int temp = b;
                b = a % b;
                a = temp;
            }
            return Math.Abs(a);
        }

        private static int LCM(int a, int b)
        {
            return a * b / GCD(a, b);
        }
    }
}