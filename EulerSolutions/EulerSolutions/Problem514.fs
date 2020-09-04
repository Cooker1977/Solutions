module Problem514
open System.Collections.Generic
open MathMethods
open Geometry

let shapeProbability geoboardOrder fixedHoleCount vertexCount = 
    let pinProbability = 1.0/(geoboardOrder + 1 |> float)
    let holeProbability = (float geoboardOrder)/(geoboardOrder + 1 |> float)

    (pinProbability**vertexCount)*(holeProbability**fixedHoleCount)

//let unpinVertex (vertices : List<Point>) (unpinNumber : int) =
//    if unpinNumber < 0 || unpinNumber >= vertices.Count then
//        failwithf "Cannot remove vertex at %d from a list with length %d" unpinNumber vertices.Count
//
//    let point1 = 
//        match unpinNumber with
//        | 0 -> vertices.[vertices.Count - 1]
//        | _ -> vertices.[unpinNumber - 1]
//
//    let point2 = vertices.[unpinNumber]
//
//    let point3 =
//        match unpinNumber with
//        | _ when unpinNumber = (vertices.Count - 1) -> vertices.[0]
//        | _ -> vertices.[unpinNumber + 1]
//
//    vertices

let unpinVertex (vertices : Point list) (unpinNumber : int) =
    if unpinNumber < 0 || unpinNumber >= vertices.Length then
        failwithf "Cannot remove vertex at %d from a list with length %d" unpinNumber vertices.Length

    let point1 = 
        match unpinNumber with
        | 0 -> vertices.[vertices.Length - 1]
        | _ -> vertices.[unpinNumber - 1]

    let point2 = vertices.[unpinNumber]

    let point3 =
        match unpinNumber with
        | _ when unpinNumber = (vertices.Length - 1) -> vertices.[0]
        | _ -> vertices.[unpinNumber + 1]

    vertices

type ShrinkingBoard (geoboardOrder : int) =
    let vertices = [
        {X = 0; Y = 0};
        {X = geoboardOrder; Y = 0};
        {X = geoboardOrder; Y = geoboardOrder};
        {X = 0; Y = geoboardOrder};
    ]