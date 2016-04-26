using System;
using System.Collections.Generic;
using Math = System.Math;

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
    class ShrinkingBoard
    {
        private readonly List<Vertex> _vertices;
        private int _holeCount;
        private readonly int _geoboardOrder;

        public ShrinkingBoard(int geoboardOrder)
        {
            _geoboardOrder = geoboardOrder;
            var lowerLeft = new Vertex(0, 0);
            var lowerRight = new Vertex(_geoboardOrder, 0);
            var upperRight = new Vertex(_geoboardOrder, _geoboardOrder);
            var upperLeft = new Vertex(0, _geoboardOrder);
            _vertices = new List<Vertex>
                        {
                            lowerLeft,
                            lowerRight,
                            upperRight,
                            upperLeft
                        };
        }

        public void RemoveVertex(Vertex vertex)
        {
            int indexToRemove;
            for (indexToRemove = 0; indexToRemove < _vertices.Count; ++indexToRemove)
            {
                if(_vertices[indexToRemove].Equals(vertex))
                    break;
            }
            if (indexToRemove == _vertices.Count)
                return;

            ++_holeCount;
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
            var totalRise = vertexToRemove.YPosition - otherVertex.XPosition;
            var totalRun = vertexToRemove.XPosition - otherVertex.XPosition;
            var gcd = NumericalMethods.Math.Gcd(totalRise, totalRun);
            var rise = totalRise/gcd;
            var run = totalRun/gcd;

            var trialAdditionalVertex = new Vertex(vertexToRemove.XPosition + run, vertexToRemove.YPosition + rise);
            _vertices.RemoveAt(indexToRemove);
            if(!trialAdditionalVertex.Equals(otherVertex))
                _vertices.Insert(indexToRemove, trialAdditionalVertex);
        }

        public double Area()
        {
            return Area(0);
        }

        // recursively finds the area by finding the triangle defined by the last vertex, the
        // vertex at currentIndex and the vertex at currentIndex + 1 and proceeding down the 
        // vertices computing all those areas and then summing.
        private double Area(int currentIndex)
        {
            if (currentIndex + 1 >= _vertices.Count - 1)
                return 0.0;

            var twiceArea = TwiceTriangleArea(_vertices[currentIndex],
                                              _vertices[currentIndex + 1],
                                              _vertices[_vertices.Count - 1]);
            // if all 3 vertices lie on a straight line, something has gone wrong, and twice the area will be 0 
            if (twiceArea == 0)
                throw new Exception("Invalid shape generated!!");
            // use recursion to keep on trucking.
            return Math.Abs(twiceArea)/2.0 + Area(currentIndex + 1);
        }

        // It is a curious fact that twice the area of a triangle whose vertices are all at integer
        // x-y coordinates is also an integer. I will make use of this fact to avoid
        // double rounding errors and the like.
        private static int TwiceTriangleArea(Vertex point1, Vertex point2, Vertex point3)
        {
            var twiceArea = (point2.YPosition - point3.YPosition)*point1.XPosition +
                            (point3.YPosition - point1.YPosition)*point2.XPosition +
                            (point1.YPosition - point2.YPosition)*point3.XPosition;
            return Math.Sign(twiceArea)*twiceArea;
        }

        public double ShapeProbability()
        {
            var vertexProbaility = 1.0;
            for (var i = 0; i < _vertices.Count; ++i)
                vertexProbaility *= 1.0/(_geoboardOrder + 1.0);

            var holeProbability = 1.0;
            for (var i = 0; i < _holeCount; ++i)
                holeProbability *= _geoboardOrder/(_geoboardOrder + 1.0);
            return holeProbability*vertexProbaility;
        }
    }

    class Vertex : IEquatable<Vertex>
    {
        private readonly int _xPosition;
        private readonly int _yPosition;

        public Vertex(int xPosition, int yPosition)
        {
            _xPosition = xPosition;
            _yPosition = yPosition;
        }

        public int XPosition => _xPosition;

        public int YPosition => _yPosition;

        public bool Equals(Vertex other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return _xPosition == other._xPosition && _yPosition == other._yPosition;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((Vertex) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (_xPosition*397) ^ _yPosition;
            }
        }
    }
}
