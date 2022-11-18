using ShapeAnalyzer.Geometry;
using ShapeAnalyzer.Geometry.Helpers;
using ShapeAnalyzer.Analyzes.Results;

namespace ShapeAnalyzer.Analyzes.Strategies;

internal class CircleAnalysis : AnalysisBase
{
    private readonly Ruler _ruler;

    public CircleAnalysis()
    {
        _ruler = new Ruler();
    }

    public override IAnalysisResult GetAnalysisResult(IShape shape)
    {
        var analysisResult = new CircleAnalysisResult();
        var radius = _ruler.GetDistance(shape.Vertices[0], shape.Vertices[1]);

        analysisResult.Area = RoundDouble(Math.PI * Math.Pow(radius, 2));

        return analysisResult;
    }
}
