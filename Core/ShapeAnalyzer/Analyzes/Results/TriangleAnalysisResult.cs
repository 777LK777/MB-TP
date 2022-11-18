namespace ShapeAnalyzer.Analyzes.Results;

public class TriangleAnalysisResult : IAnalysisResult
{
    public double Area { get; internal set; }
    public bool IsRectangular { get; internal set; }

    public override string ToString()
    {
        return $"area:\t{Area}";
    }

    public string FullToString()
    {
        return this.ToString()+$"\nis rectangular:\t{IsRectangular}";
    }
}
