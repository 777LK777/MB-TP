using ShapeAnalyzer.Geometry.Helpers;

namespace ShapeAnalyzer.Geometry;

public class ShapeFactory : IShapeFactory
{
    private readonly Dictionary<string, ICustomShapeBuilder> _shapeToBuilderMatchings;

    public ShapeFactory()
    {
        _shapeToBuilderMatchings = new Dictionary<string, ICustomShapeBuilder>();
    }

    public IShapeFactory AddShapeBuilder<TShape, TShapeBuilder>()
        where TShape : IShape
        where TShapeBuilder : ICustomShapeBuilder, new()
    {
        var typeName = typeof(TShape).Name.ToLower();
        var builder = new TShapeBuilder();

        if (!_shapeToBuilderMatchings.ContainsKey(typeName))
            _shapeToBuilderMatchings.Add(typeName, builder);

        return this;
    }

    public IShape Create(string shapeName, params Dictionary<Axis, double>[] coordinates)
    {
        var builder = _shapeToBuilderMatchings[shapeName.ToLower()];
        return builder.Build(coordinates);
    }
}
