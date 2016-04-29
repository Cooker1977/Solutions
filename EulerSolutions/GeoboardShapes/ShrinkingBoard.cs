using System;
using System.Collections.Generic;

namespace GeoboardShapes
{
    // Implementing a board that finds the smallest concave polynomial area of a generic configuration, then iterating over the
    // possible configurations is a fool's errand for the N=100 case which will have 2^((N+1)(N+1)) configurations. That even neglects
    // the difficulty of shape and area calculation.
    // We will attempt to iterate through all the possible concave polygons that will fit on the board, and take advantage of the fact
    // that any shape has 
    //           probability = (probability of hole)^(number of exterior points) * (probability of pin)^(number of vertices of polynomial)
    // There is some difficulty in not producing the same shape multiple times, but that will be handled outside this class.
    //
    // This class is initially configured to have vertices at the 4 corners of the geoboard with no points off.
    // Initially, the vertices start with (0,0) and procede in counter-clockwise order around the polygon.
    // The TryRemoveVertex Method removes a specified vertex if present and locates the new vertices that would appear
    // on a full geoboard adding them to the _vertices list in the appropriate location to preserve the counter-clockwise
    // ordering.
    public class ShrinkingBoard
    {
        private readonly List<Geometry.Point> _vertices;

        public ShrinkingBoard(int geoboardOrder)
        {
            var lowerLeft = new Geometry.Point(0, 0);
            var lowerRight = new Geometry.Point(geoboardOrder, 0);
            var upperRight = new Geometry.Point(geoboardOrder, geoboardOrder);
            var upperLeft = new Geometry.Point(0, geoboardOrder);
            _vertices = new List<Geometry.Point>
                        {
                            lowerLeft,
                            lowerRight,
                            upperRight,
                            upperLeft
                        };
        }

        public void RemoveVertex(Geometry.Point vertex)
        {
            int indexToRemove;
            for (indexToRemove = 0; indexToRemove < _vertices.Count; ++indexToRemove)
            {
                if(_vertices[indexToRemove].Equals(vertex))
                    break;
            }
            if (indexToRemove == _vertices.Count)
                return;

            if (_vertices.Count == 1)
            {
                _vertices.RemoveAt(indexToRemove);
                return;
            }

            if (_vertices.Count <= 2)
            {
                HandleVertexRemovalTwoPoint(indexToRemove);
                return;
            }


            //TODO: Find new vertices that will emerge from removing the vertex
            //TODO: preserve the cyclical ordering of the vertices to aid in area calculation.
        }

        private void HandleVertexRemovalTwoPoint(int indexToRemove)
        {
            if(indexToRemove > 1 || _vertices.Count != 2)
                throw new ArgumentException("Should not call HandleVertexRemovalTwoPoint with invalid index or with more than 2 verticies.");

            var vertexToRemove = _vertices[indexToRemove];
            var otherVertex = _vertices[indexToRemove == 0 ? 1 : 0];
            var totalRise = vertexToRemove.Y - otherVertex.X;
            var totalRun = vertexToRemove.X - otherVertex.X;
            var gcd = NumericalMethods.Math.Gcd(totalRise, totalRun);
            var rise = totalRise/gcd;
            var run = totalRun/gcd;

            var trialAdditionalVertex = new Geometry.Point(vertexToRemove.X + run, vertexToRemove.Y + rise);
            _vertices.RemoveAt(indexToRemove);
            if(!trialAdditionalVertex.Equals(otherVertex))
                _vertices.Insert(indexToRemove, trialAdditionalVertex);
        }
    }
}
