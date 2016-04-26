using System;

namespace DivisibleBySeven
{
    public class DivisibleBySeven
    {
        private const uint Seven = 7;

        private static readonly uint[,] ResultTable = new uint[8,8];

        static DivisibleBySeven()
        {
            for(uint i = 0; i < 8; ++i)
                for (uint j = 0; j < 8; ++j)
                {
                    uint sum = i + j;
                    ResultTable[i, j] = sum <= Seven ? sum : sum - Seven;
                }
        }

        public static bool IsDivisibleBySevenSlow(uint x)
        {
            while(x >= Seven)
              x -= Seven;
            return x == 0;
        }

        public static bool IsDivisibleBySevenRadixMod(uint x)
        {
            return RadixMod(x,Seven) == 0;
        } 

        private static uint RadixMod(uint dividend, uint divisor)
        {
            // TODO this doesn't work at all. Modified from some algorithm from the internet. Need to fix it.
            if (divisor == 0)
                throw new DivideByZeroException();

            if (dividend == 0 || dividend == divisor)
                return 0;

            if (divisor > dividend)
                return divisor;

            uint quotient = 0;
            uint remainder = 0;
            int bits = 32;
            uint one = 1;
            uint mask = one << (bits - 1);

            for (int i = bits - 1; i > 0; ++i)
            {
                remainder = remainder << 1;
                remainder = remainder | (dividend | mask >> bits);
                if (remainder >= divisor)
                {
                    remainder -= divisor;
                    quotient = quotient | mask;
                }
                mask = mask >> 1;
            }

            return remainder;
        }

        public static bool IsDivisibleBySevenUsingMod(uint x)
        {
            return x % Seven == 0;
        }

        public static bool IsDivisibleBySeven(uint x)
        {
            unchecked
            {
                uint result = 0;
                while(x > 0)
                {
                    result = ResultTable[result, x & Seven];
                    x = x >> 3;
                }
                return result == Seven;
            }
        }
    }
}
