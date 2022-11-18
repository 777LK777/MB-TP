using ShapeAnalyzer.Geometry;

namespace CustomShapes.Square;

public class Square : IShape
{
    public Square(Dictionary<Axis, double>[] vertices)
    {
        Vertices = vertices.ToList();
    }

    public List<Dictionary<Axis, double>> Vertices { get; }
}
