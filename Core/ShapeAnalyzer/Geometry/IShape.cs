namespace ShapeAnalyzer.Geometry;

public interface IShape
{
    List<Dictionary<Axis, double>> Vertices { get; }
}
