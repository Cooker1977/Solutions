namespace Algorithms.SevenDivisibility
{
    public class ModAlgorithm : ICheckDivisibility
    {
        // NOTE: In order to give honest performance tests in y == 7 case, not providing any
        // checks to correctly handle y == 0.
        public bool IsDivisibleBy(uint x, uint y)
        {
            return x % y == 0;
        }
    }
}