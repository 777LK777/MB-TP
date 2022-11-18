namespace ShapeAnalyzer.Geometry.Shapes;

internal class Circle : IShape
{
	public Circle(List<Dictionary<Axis, double>> vertices)
	{
        Vertices =	vertices;
    }

    public List<Dictionary<Axis, double>> Vertices { get; }
}
