using ShapeAnalyzer.Geometry;
using ShapeAnalyzer.Geometry.Helpers;

namespace CustomShapes.Square;

public class SquareBuilder : ICustomShapeBuilder
{
    public IShape Build(params Dictionary<Axis, double>[] vertices)
    {
        return new Square(vertices);
    }
}
