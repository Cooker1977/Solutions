using System;
using System.Diagnostics;
using Algorithms.SevenDivisibility;
using NUnit.Framework;

namespace Algorithms.Tests
{
    //NOTE: Performance measurement may vary based on machine. On my machine, the hard coded acceptable factors
    // have not been violated and the resulting speed up factors are pretty stable.

    [TestFixture]
    public class SevenDivisibilityPerformanceTests
    {
        private const uint TestValueCount = 10000000;
        
        // Performance test the bitShiftChecker against the standard implementations
        private readonly ICheckDivisibilityBySeven _bitShiftChecker = new BitShiftAlgorithm();

        private readonly ICheckDivisibilityBySeven _modChecker = new SevenDivisibilityCheckerWrapper(new ModAlgorithm());
        private readonly ICheckDivisibilityBySeven _radixChecker = new SevenDivisibilityCheckerWrapper(new RadixAlgorithm());

        [Test]
        public void PerformanceTestBitShiftAgainstMod()
        {
            // Normal mod is very fast due to potential hardware speed up, the fact
            // that the new method is only 5 times slower than mod is a win.
            PerformanceTestBitShiftAlgorithm(_modChecker, 0.2);
        }

        [Test]
        public void PerformanceTestBitShiftAgainstRadix()
        {
            // New method beats a typical radix implementation quite nicely
            PerformanceTestBitShiftAlgorithm(_radixChecker, 2.1);
        }

        private long TimeTakenInMilliseconds(ICheckDivisibilityBySeven checker)
        {
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            for (uint i = 0; i <= TestValueCount; ++i)
            {
                checker.IsDivisibleBySeven(i);
            }
            stopWatch.Stop();
            return stopWatch.ElapsedMilliseconds;
        }

        private void PerformanceTestBitShiftAlgorithm(ICheckDivisibilityBySeven standardChecker, double acceptableFactor)
        {
            // Code to prime the jitter.
            _bitShiftChecker.IsDivisibleBySeven(1337);
            standardChecker.IsDivisibleBySeven(1337);

            long bitShiftMilliseconds = TimeTakenInMilliseconds(_bitShiftChecker);
            long typicalMethodMilliseconds = TimeTakenInMilliseconds(standardChecker);

            var speedUpFactor = typicalMethodMilliseconds/(double) bitShiftMilliseconds;
            Assert.GreaterOrEqual(speedUpFactor, acceptableFactor);
        }
    }
}
