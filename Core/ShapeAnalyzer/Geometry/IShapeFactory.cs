using ShapeAnalyzer.Geometry.Helpers;

namespace ShapeAnalyzer.Geometry;

public interface IShapeFactory
{
    IShape Create(string shapeName, params Dictionary<Axis, double>[] coordinates);
    IShapeFactory AddShapeBuilder<TShape, TShapeBuilder>()
        where TShape : IShape
        where TShapeBuilder : ICustomShapeBuilder, new();
}
