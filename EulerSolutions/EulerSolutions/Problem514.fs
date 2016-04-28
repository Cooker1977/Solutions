module Problem514
open System
open Geometry

type ShrinkingBoard (geoboardOrder : int) =
    let vertices = [
        {X = 0; Y = 0};
        {X = geoboardOrder; Y = 0};
        {X = geoboardOrder; Y = geoboardOrder};
        {X = 0; Y = geoboardOrder};
    ]