namespace SubWizard
{
    public class Frac
    {
        public int Num { get; private set; }
        public int Denom { get; private set; }

        public Frac(int numerator, int denominator)
        {
            if (denominator == 0)
            {
                throw new ArgumentException("Denominator cannot be zero.");
            }
            if (denominator < 0)
            {
                numerator = -numerator;
                denominator = -denominator;
            }
            int gcd = Utility.GCD(Math.Abs(numerator), Math.Abs(denominator));
            Num = numerator / gcd;
            Denom = denominator / gcd;
        }

        public Frac Add(Frac other)
        {
            int newNumerator = (this.Num * other.Denom) + (other.Num * this.Denom);
            int newDenominator = this.Denom * other.Denom;
            return new Frac(newNumerator, newDenominator);
        }

        public Frac Subtract(Frac other)
        {
            int newNumerator = (this.Num * other.Denom) - (other.Num * this.Denom);
            int newDenominator = this.Denom * other.Denom;
            return new Frac(newNumerator, newDenominator);
        }

        public Frac Multiply(Frac other)
        {
            int newNumerator = this.Num * other.Num;
            int newDenominator = this.Denom * other.Denom;
            return new Frac(newNumerator, newDenominator);
        }

        public Frac Divide(Frac other)
        {
            if (other.Num == 0)
            {
                throw new DivideByZeroException("Cannot divide by zero.");
            }
            int newNumerator = this.Num * other.Denom;
            int newDenominator = this.Denom * other.Num;
            return new Frac(newNumerator, newDenominator);
        }

        public override string ToString()
        {
            return $"{Num}/{Denom}";
        }
    }
}