using NumericalMethods;
using NUnit.Framework;

namespace NumericalMethodsTests
{
    [TestFixture]
    public class GcdTests
    {
        [TestCase(2, 3, 1, Description = "Gcd(2,3)=1", Category = "Test Positive integers")]
        [TestCase(3, 2, 1, Description = "Gcd(3,2)=1", Category = "Test Positive integers")]
        [TestCase(11, 17, 1, Description = "Gcd(11,17)=1", Category = "Test Positive integers")]
        [TestCase(17, 11, 1, Description = "Gcd(17,11)=1", Category = "Test Positive integers")]
        [TestCase(22, 11, 11, Description = "Gcd(22,11)=11", Category = "Test Positive integers")]
        [TestCase(11, 22, 11, Description = "Gcd(11,22)=11", Category = "Test Positive integers")]
        [TestCase(48, 80, 16, Description = "Gcd(48,80)=16", Category = "Test Positive integers")]
        [TestCase(80, 48, 16, Description = "Gcd(80,48)=16", Category = "Test Positive integers")]
        [TestCase(22, 121, 11, Description = "Gcd(22,121)=11", Category = "Test Positive integers")]
        [TestCase(32, 28, 4, Description = "Gcd(32,28)=4", Category = "Test Positive integers")]
        [TestCase(52, 24, 4, Description = "Gcd(52,24)=4", Category = "Test Positive integers")]
        [TestCase(2, -3, 1, Description = "Gcd(2,-3)=1", Category = "Test Negative integers")]
        [TestCase(-3, 2, 1, Description = "Gcd(-3,2)=1", Category = "Test Negative integers")]
        [TestCase(-11, -17, 1, Description = "Gcd(-11,-17)=1", Category = "Test Negative integers")]
        [TestCase(-17, 11, 1, Description = "Gcd(-17,11)=1", Category = "Test Negative integers")]
        [TestCase(22, -11, 11, Description = "Gcd(22,-11)=11", Category = "Test Negative integers")]
        [TestCase(-11, 22, 11, Description = "Gcd(-11,22)=11", Category = "Test Negative integers")]
        [TestCase(48, -80, 16, Description = "Gcd(48,-80)=16", Category = "Test Negative integers")]
        [TestCase(-80, -48, 16, Description = "Gcd(-80,-48)=16", Category = "Test Negative integers")]
        [TestCase(22, -121, 11, Description = "Gcd(22,-121)=11", Category = "Test Negative integers")]
        [TestCase(-32, 28, 4, Description = "Gcd(-32,28)=4", Category = "Test Negative integers")]
        [TestCase(-52, -24, 4, Description = "Gcd(-52,-24)=4", Category = "Test Negative integers")]
        public void TestGcd(int x, int y, int expectedGcd)
        {
            Assert.AreEqual(expectedGcd, Math.Gcd(x, y));
        }
    }
}