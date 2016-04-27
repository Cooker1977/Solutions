namespace Algorithms.SevenDivisibility
{
    public class BitShiftAlgorithm : ICheckDivisibilityBySeven
    {
        // This algorithm doesn't extend to other numbers, so shifting the definition
        // of Seven will not provide a working algorithm for any number. This
        // could probably be extended to generic numbers one below powers of 2
        private const uint Seven = 7;

        private static readonly uint[,] ResultTable = new uint[Seven + 1, Seven + 1];

        static BitShiftAlgorithm()
        {
            for(uint i = 0; i <= Seven; ++i)
                for (uint j = 0; j <= Seven; ++j)
                {
                    uint sum = i + j;
                    ResultTable[i, j] = sum <= Seven ? sum : sum - Seven;
                }
        }

        public bool IsDivisibleBySeven(uint x)
        {
            uint result = 0;
            while (x > 0)
            {
                result = ResultTable[result, x & Seven];
                x = x >> 3;
            }
            return result == Seven || result == 0;
        }
    }
}
