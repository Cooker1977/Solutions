namespace Algorithms.SevenDivisibility
{
    public class RadixAlgorithm : ICheckDivisibility
    {
        // NOTE: In order to give honest performance tests in y == 7 case, not providing any
        // checks to correctly handle y == 0.
        public bool IsDivisibleBy(uint x, uint y)
        {
            return RadixMod(x, y) == 0;
        }

        // The radix implementation is not great. It could be improved by grouping together
        // bits and using a table to remove the subtraction.

        private static uint RadixMod(uint dividend, uint divisor)
        {
            if (divisor > dividend)
            {
                return dividend;
            }

            if (divisor == dividend)
            {
                return 0;
            }

            int leftShifts = 0;
            while (divisor << 1 <= dividend)
            {
                ++leftShifts;
                divisor <<= 1;
            }

            for (int i = leftShifts; i >= 0; --i)
            {
                if (dividend >= divisor)
                    dividend = dividend - divisor;
                divisor >>= 1;
            }

            return dividend;
        }
    }
}