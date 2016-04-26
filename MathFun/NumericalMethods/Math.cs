namespace NumericalMethods
{
    public static class Math
    {
        /// <summary>
        ///     Computes the greatest common divisor of two integers
        /// </summary>
        /// <returns>The greatest common divisor of x and y</returns>
        public static int Gcd(int x, int y)
        {
            if (x < 0)
                x = -x;
            if (y < 0)
                y = -y;
            return RecursiveGcd(x, y);
        }

        private static int RecursiveGcd(int x, int y)
        {
            if (y == 0)
                return x;
            if (x < y)
                return RecursiveGcd(y, x);
            return RecursiveGcd(y, x%y);
        }
    }
}