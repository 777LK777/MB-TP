using ShapeAnalyzer.Analyzes.Results;

namespace CustomShapes.Square;

public class SquareAnalysisResult : IAnalysisResult
{
    public double Area { get; internal set; }

    public override string ToString()
    {
        return $"area:\t{Area}";
    }

    public string FullToString()
    {
        return this.ToString();
    }
}
