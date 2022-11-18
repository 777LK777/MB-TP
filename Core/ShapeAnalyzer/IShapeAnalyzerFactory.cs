using ShapeAnalyzer.Geometry;
using ShapeAnalyzer.Analyzes.Strategies;

namespace ShapeAnalyzer;

public interface IShapeAnalyzerBuilder
{
    IShapeAnalyzer Build();
    IShapeAnalyzerBuilder AddAnalysis<TShape, TAnalysisStrategy>()
        where TShape : IShape
        where TAnalysisStrategy : AnalysisBase, new();
}
