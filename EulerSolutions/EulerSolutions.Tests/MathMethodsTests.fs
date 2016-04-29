module MathMethodsTests
open MathMethods
open NUnit.Framework

[<TestFixture>]
type MathMethodsTests =
    val tolerance : float
    new () = { tolerance = 1e-16 }

    [<TestCase(1.0, 2.0, 0)>]
    [<TestCase(2.0, 2.0, 1)>]
    [<TestCase(4.0, 2.0, 2)>]
    [<TestCase(8.0, 2.0, 3)>]
    [<TestCase(16.0, 2.0, 4)>]
    [<TestCase(32.0, 2.0, 5)>]
    [<TestCase(64.0, 2.0, 6)>]
    [<TestCase(128.0, 2.0, 7)>]
    [<TestCase(256.0, 2.0, 8)>]
    [<TestCase(512.0, 2.0, 9)>]
    [<TestCase(1024.0, 2.0, 10)>]
    [<TestCase(2048.0, 2.0, 11)>]
    [<TestCase(1267650600228229401496703205376.0, 2.0, 100)>]
    [<TestCase(1.0, 3.0, 0)>]
    [<TestCase(3.0, 3.0, 1)>]
    [<TestCase(9.0, 3.0, 2)>]
    [<TestCase(27.0, 3.0, 3)>]
    [<TestCase(81.0, 3.0, 4)>]
    [<TestCase(243.0, 3.0, 5)>]
    [<TestCase(729.0, 3.0, 6)>]
    [<TestCase(2187.0, 3.0, 7)>]
    [<TestCase(6561.0, 3.0, 8)>]
    [<TestCase(19683.0, 3.0, 9)>]
    [<TestCase(59049.0, 3.0, 10)>]
    [<TestCase(177147.0, 3.0, 11)>]
    [<TestCase(717897987691852588770249.0, 3.0, 50)>]
    [<TestCase(16.0, 4.0, 2)>]
    [<TestCase(25.0, 5.0, 2)>]
    [<TestCase(36.0, 6.0, 2)>]
    [<TestCase(49.0, 7.0, 2)>]
    [<TestCase(64.0, 8.0, 2)>]
    [<TestCase(81.0, 9.0, 2)>]
    [<TestCase(100.0, 10.0, 2)>]
    [<TestCase(121.0, 11.0, 2)>]
    [<TestCase(144.0, 12.0, 2)>]
    member this.testIntegerPoint (expectedValue : float) (x : float) (y : int) = 
        Assert.That(expectedValue, (x^y |> Is.EqualTo).Within(this.tolerance))