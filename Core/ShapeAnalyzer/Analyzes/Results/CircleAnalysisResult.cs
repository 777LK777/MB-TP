namespace ShapeAnalyzer.Analyzes.Results;

public class CircleAnalysisResult : IAnalysisResult
{
    public double Area { get; internal set; }

    public string FullToString()
    {
        return $"area:\t{Area}";
    }
}
