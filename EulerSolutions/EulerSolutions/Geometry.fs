module Geometry
open System

type Point = { X : int; Y : int}
type Triangle = { Point1 : Point; Point2 : Point; Point3 : Point }

// TODO improve polygon calculation to detect/handle problem situations like concavity
// and self crossing.
module Area = 
    type private TriangleState = { CurrentTriangle : Triangle; AccumulatedArea : int}
    type private AccumulatorState =
        | Empty
        | SinglePoint of Point
        | TwoPoints of Point*Point
        | Triangle of TriangleState

    // Twice the area of a triangle whose points have integer coefficients
    // is also an integer, so there is no loss of precision.
    let twiceTriangleArea triangle =
        let twiceArea = 
            (triangle.Point2.Y - triangle.Point3.Y)*triangle.Point1.X + 
            (triangle.Point3.Y - triangle.Point1.Y)*triangle.Point2.X + 
            (triangle.Point1.Y - triangle.Point2.Y)*triangle.Point3.X
        (Math.Sign twiceArea)*twiceArea

    // Twice the area of a convex polygon whose points have integer coefficients
    // is also an integer, so there is no loss of precision. Assumes the vertices
    // are in order as you traverse the sides of the polygon and that the polygon
    // is convex.
    let twicePolygonArea vertices =
        let areaAccumulation currentState nextPoint =
            match currentState with
            | Empty -> SinglePoint nextPoint 
            | SinglePoint point -> TwoPoints (point, nextPoint)
            | TwoPoints (point1, point2) -> 
                let currentTriangle = { Point1 = point1; Point2 = point2; Point3 = nextPoint }
                Triangle { CurrentTriangle = currentTriangle; AccumulatedArea = twiceTriangleArea currentTriangle }
            | Triangle state -> 
                let nextTriangle = 
                    { 
                        Point1 = state.CurrentTriangle.Point1;
                        Point2 = state.CurrentTriangle.Point3;
                        Point3 = nextPoint
                    }
                let nextArea = state.AccumulatedArea + twiceTriangleArea nextTriangle
                Triangle { CurrentTriangle = nextTriangle; AccumulatedArea = nextArea; }
        
        match vertices |> List.fold areaAccumulation Empty with
        | Triangle state  -> state.AccumulatedArea
        | _ -> 0
    
    // Assumes the vertices are in order as you traverse the sides of the polygon 
    // and that the polygon is convex.
    let polygonArea vertices =
        (twicePolygonArea >> float) vertices / 2.0