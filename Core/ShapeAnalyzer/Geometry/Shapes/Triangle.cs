namespace ShapeAnalyzer.Geometry.Shapes;

internal class Triangle : IShape
{
	public Triangle(List<Dictionary<Axis, double>> vertices)
	{
		Vertices = vertices;
	}

    public List<Dictionary<Axis, double>> Vertices { get; }
}
