namespace ShapeAnalyzer.Geometry.Helpers;

public interface ICustomShapeBuilder
{
    IShape Build(params Dictionary<Axis, double>[] vertices);
}
