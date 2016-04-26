using System;
using System.Diagnostics;
using NUnit.Framework;

namespace DivisibleBySeven.Tests
{
    [TestFixture]
    public class Div7Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [TearDown]
        public void TearDown()
        {
        }

        [Test]
        public void CorrectnessTest()
        {
            for(uint count = 1; count <= 1000; ++count)
            {
                Assert.AreEqual(DivisibleBySeven.IsDivisibleBySevenUsingMod(count), DivisibleBySeven.IsDivisibleBySeven(count));
            }
        }

        private long TimeTakenInMilliseconds(Action actionToTime)
        {
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            actionToTime();
            stopWatch.Stop();
            return stopWatch.ElapsedMilliseconds;
        }

        [Test, Explicit]
        public void PerformanceTest()
        {
            DivisibleBySeven.IsDivisibleBySeven(7);
            uint testTrials = 100000;
            long newMethodMilliseconds = TimeTakenInMilliseconds(() =>
            {
                for (uint count = 1; count <= testTrials; ++count)
                {
                    DivisibleBySeven.IsDivisibleBySeven(count);
                }
            });

            long typicalMethodMilliseconds = TimeTakenInMilliseconds(() =>
            {
                for (uint count = 1; count <= testTrials; ++count)
                {
                    DivisibleBySeven.IsDivisibleBySevenSlow(count);
                }
            });

            double percentImprovement = typicalMethodMilliseconds / (double)newMethodMilliseconds;
            Assert.IsTrue(percentImprovement > 2);
        }
    }
}
