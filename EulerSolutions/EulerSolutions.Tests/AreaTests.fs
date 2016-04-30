module AreaTests
open Geometry
open NUnit.Framework

[<TestFixture>]
type AreaTests =
    val tolerance : float
    new () = { tolerance = 1e-16 }

    [<TestCase(1)>]
    [<TestCase(2)>]
    [<TestCase(3)>]
    [<TestCase(4)>]
    [<TestCase(5)>]
    [<TestCase(10)>]
    [<TestCase(25)>]
    [<TestCase(50)>]
    [<TestCase(75)>]
    [<TestCase(100)>]
    [<TestCase(500)>]
    [<TestCase(1000)>]
    [<TestCase(10000)>]
    member this.testSquareArea sideLength = 
        let vertices = [
            {X = 0; Y = 0};
            {X = sideLength; Y = 0};
            {X = sideLength; Y = sideLength};
            {X = 0; Y = sideLength};
        ]

        let expectedArea = sideLength * sideLength |> float
        Assert.That(Area.polygonArea(vertices), Is.EqualTo(expectedArea).Within(this.tolerance))

    [<TestCase(1, 1)>]
    [<TestCase(2, 2)>]
    [<TestCase(3, 3)>]
    [<TestCase(4, 4)>]
    [<TestCase(5, 5)>]
    [<TestCase(10, 10)>]
    [<TestCase(1, 10)>]
    [<TestCase(2, 5)>]
    [<TestCase(3, 4)>]
    [<TestCase(4, 3)>]
    [<TestCase(5, 2)>]
    [<TestCase(10, 1)>]
    [<TestCase(10, 1)>]
    [<TestCase(5, 2)>]
    [<TestCase(4, 3)>]
    [<TestCase(3, 4)>]
    [<TestCase(2, 5)>]
    [<TestCase(1, 10)>]
    member this.testRightTriangleArea length height = 
        let vertices = [
            {X = 0; Y = 0};
            {X = length; Y = 0};
            {X = 0; Y = height};
        ]

        let expectedArea = (length * height |> float) / 2.0
        Assert.That(Area.polygonArea(vertices), Is.EqualTo(expectedArea).Within(this.tolerance))

    [<TestCase(1, 1)>]
    [<TestCase(2, 2)>]
    [<TestCase(3, 3)>]
    [<TestCase(4, 4)>]
    [<TestCase(5, 5)>]
    [<TestCase(10, 10)>]
    [<TestCase(1, 10)>]
    [<TestCase(2, 5)>]
    [<TestCase(3, 4)>]
    [<TestCase(4, 3)>]
    [<TestCase(5, 2)>]
    [<TestCase(10, 1)>]
    [<TestCase(10, 1)>]
    [<TestCase(5, 2)>]
    [<TestCase(4, 3)>]
    [<TestCase(3, 4)>]
    [<TestCase(2, 5)>]
    [<TestCase(1, 10)>]
    member this.testTriangleArea length height = 
        let vertices = [
            {X = 0; Y = 0};
            {X = length; Y = 0};
            {X = length/2; Y = height};
        ]

        let expectedArea = (length * height |> float) / 2.0
        Assert.That(Area.polygonArea(vertices), Is.EqualTo(expectedArea).Within(this.tolerance))

    [<TestCase(2, 3)>]
    [<TestCase(3, 4)>]
    [<TestCase(4, 5)>]
    [<TestCase(10, 10)>]
    [<TestCase(25, 30)>]
    [<TestCase(50, 60)>]
    [<TestCase(75, 65)>]
    [<TestCase(100, 100)>]
    [<TestCase(2, 100)>]
    [<TestCase(3, 65)>]
    [<TestCase(4, 60)>]
    [<TestCase(10, 30)>]
    [<TestCase(25, 10)>]
    [<TestCase(50, 5)>]
    [<TestCase(75, 4)>]
    [<TestCase(100, 3)>]
    member this.testPentagonArea height width = 
        let x1 = width/4
        let x2 = width - x1
        let x3 = width/2
        let y1 = height - height/2
        let vertices = [
            {X = x1; Y = 0};
            {X = x2; Y = 0};
            {X = width; Y = y1};
            {X = x3; Y = height};
            {X = 0; Y = y1};
        ]

        let expectedArea = (height*width + (x2 - x1)*y1 |> float) / 2.0
        Assert.That(Area.polygonArea(vertices), Is.EqualTo(expectedArea).Within(this.tolerance))