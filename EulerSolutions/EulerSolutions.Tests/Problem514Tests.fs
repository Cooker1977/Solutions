module Problem514Tests
open Problem514
open NUnit.Framework

[<TestFixture>]
type Problem514Tests =
    val tolerance : float
    new () = { tolerance = 1e-16 }

    // These are just full squares
    [<TestCase(1, 16, 1, 0, 4)>]
    [<TestCase(1, 81, 2, 0, 4)>]
    [<TestCase(1, 14641, 10, 0, 4)>]
    [<TestCase(1, 104060401, 100, 0, 4)>]
    // One corner removed
    [<TestCase(1, 16, 1, 1, 3)>]
    [<TestCase(2, 729, 2, 1, 5)>]
    [<TestCase(10, 1771561, 10, 1, 5)>]
    [<TestCase(25, 308915776, 25, 1, 5)>]
    // Two opposite corners removed
    [<TestCase(1, 16, 1, 2, 2)>]
    [<TestCase(4, 6561, 2, 2, 6)>]
    [<TestCase(100, 214358881, 10, 2, 6)>]
    // These are triangles encompassing half squares
    [<TestCase(1, 16, 1, 1, 3)>]
    [<TestCase(8, 729, 2, 3, 3)>]
    member this.testShapeProbability expectedNumerator expectedDenominator geoboardOrder fixedHoleCount vertexCount = 
        let expectedValue = float expectedNumerator / float expectedDenominator
        Assert.That(expectedValue, ((shapeProbability geoboardOrder fixedHoleCount vertexCount)|> Is.EqualTo).Within(this.tolerance))
