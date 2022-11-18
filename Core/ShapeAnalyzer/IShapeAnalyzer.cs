using ShapeAnalyzer.Geometry;
using ShapeAnalyzer.Analyzes.Results;

namespace ShapeAnalyzer;

public interface IShapeAnalyzer
{
    IAnalysisResult Analyze(IShape shape);
}
