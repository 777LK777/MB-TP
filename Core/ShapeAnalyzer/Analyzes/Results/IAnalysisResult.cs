namespace ShapeAnalyzer.Analyzes.Results;

public interface IAnalysisResult
{
    double Area { get; }
    string FullToString();
}
