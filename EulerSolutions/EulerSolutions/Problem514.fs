module Problem514
open System
open MathMethods
open Geometry

let shapeProbability geoboardOrder fixedHoleCount vertexCount = 
    let pinProbability = 1.0/(geoboardOrder + 1 |> float)
    let holeProbability = (float geoboardOrder)/(geoboardOrder + 1 |> float)

    (pinProbability^vertexCount)*(holeProbability^fixedHoleCount)

type ShrinkingBoard (geoboardOrder : int) =
    let vertices = [
        {X = 0; Y = 0};
        {X = geoboardOrder; Y = 0};
        {X = geoboardOrder; Y = geoboardOrder};
        {X = 0; Y = geoboardOrder};
    ]