namespace Algorithms.SevenDivisibility
{
    public interface ICheckDivisibility
    {
        /// <summary>
        /// Checks if x is divisible by y.
        /// </summary>
        /// <returns>true if x is divisible by y, otherwise false.</returns>
        bool IsDivisibleBy(uint x, uint y);
    }

    public interface ICheckDivisibilityBySeven
    {
        /// <summary>
        /// Checks if x is divisible by seven.
        /// </summary>
        /// <returns>true if x is divisible by 7, otherwise false.</returns>
        bool IsDivisibleBySeven(uint x);
    }

    public class SevenDivisibilityCheckerWrapper : ICheckDivisibilityBySeven
    {
        private const uint Seven = 7;
        private readonly ICheckDivisibility _divisibilityChecker;

        public SevenDivisibilityCheckerWrapper(ICheckDivisibility divisibilityChecker)
        {
            _divisibilityChecker = divisibilityChecker;
        }

        public bool IsDivisibleBySeven(uint x)
        {
            return _divisibilityChecker.IsDivisibleBy(x, Seven);
        }
    }
}