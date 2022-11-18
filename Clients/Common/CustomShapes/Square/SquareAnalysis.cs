using ShapeAnalyzer.Geometry;
using ShapeAnalyzer.Geometry.Helpers;
using ShapeAnalyzer.Analyzes.Results;
using ShapeAnalyzer.Analyzes.Strategies;

namespace CustomShapes.Square;

public class SquareAnalysis : AnalysisBase
{
    private readonly Ruler _ruler;
    public SquareAnalysis()
    {
        _ruler = new Ruler();
    }
    public override IAnalysisResult GetAnalysisResult(IShape shape)
    {
        var result = new SquareAnalysisResult();
        Dictionary<Axis, double> firstVertex = shape.Vertices[0];
        Dictionary<Axis, double> secondVertex = shape.Vertices[1];

        var diagonal = _ruler.GetDistance(firstVertex, secondVertex);

        result.Area = RoundDouble(diagonal * Math.Cos(Math.PI / 4));

        return result;
    }
}
