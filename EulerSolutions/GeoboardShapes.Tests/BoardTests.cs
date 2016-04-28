using GeoboardShapes;
using NUnit.Framework;

namespace GeoboardTests
{
    [TestFixture]
    public class BoardTests
    {
        private const double Tolerance = 1e-16;

        // TODO: Test the Probability method in more complex configurations.
        [TestCase(1, 1.0/16)]
        [TestCase(2, 1.0/81)]
        [TestCase(10, 1.0/14641)]
        [TestCase(100, 1.0/104060401)]
        public void TestShapeProbability(int geoboardOrder, double expectedProbability)
        {
            var board = new ShrinkingBoard(geoboardOrder);
            Assert.That(board.ShapeProbability(), Is.EqualTo(expectedProbability).Within(Tolerance));
        }
    }
}