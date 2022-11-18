using ShapeAnalyzer.Geometry;
using ShapeAnalyzer.Analyzes.Results;

namespace ShapeAnalyzer.Analyzes.Strategies;

public abstract class AnalysisBase
{
    public abstract IAnalysisResult GetAnalysisResult(IShape shape);
    protected double RoundDouble(double result)
    {
        return Math.Round(result, 5);
    }
}
