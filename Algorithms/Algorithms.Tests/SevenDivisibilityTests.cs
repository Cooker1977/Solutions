using System.Collections.Generic;
using Algorithms.SevenDivisibility;
using NUnit.Framework;

namespace Algorithms.Tests
{
    [TestFixture]
    public class SevenDivisibilityTests
    {
        private const uint MaxTestValue = 100000;
        
        // The ModAlorithm class is so simple, it will be considered correct except for a single test.
        private readonly ICheckDivisibilityBySeven _modChecker = new SevenDivisibilityCheckerWrapper(new ModAlgorithm());

        private readonly ICheckDivisibilityBySeven _bitShiftChecker = new BitShiftAlgorithm();
        private readonly ICheckDivisibilityBySeven _radixChecker = new SevenDivisibilityCheckerWrapper(new RadixAlgorithm());

        [Test]
        public void TestModAlgorithm()
        {
            var multiplesOfSeven = new HashSet<uint> {0,7,14,21,28,35,42,49,56,63,70,77,84,91,98};
            for(uint i = 0; i <= 100; ++i)
                Assert.AreEqual(multiplesOfSeven.Contains(i), _modChecker.IsDivisibleBySeven(i));
        }

        [Test]
        public void TestBitShiftAlgorithm()
        {
            TestDivisibilityChecker(_bitShiftChecker);
        }

        [Test]
        public void TestRadixAlgorithm()
        {
            TestDivisibilityChecker(_radixChecker);
        }

        private void TestDivisibilityChecker(ICheckDivisibilityBySeven divisibilityChecker)
        {
            for (uint i = 0; i <= MaxTestValue; ++i)
                Assert.AreEqual(_modChecker.IsDivisibleBySeven(i), divisibilityChecker.IsDivisibleBySeven(i));
        }
    }
}
