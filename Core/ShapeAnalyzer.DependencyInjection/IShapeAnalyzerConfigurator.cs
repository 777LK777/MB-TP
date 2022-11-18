using ShapeAnalyzer.Geometry;
using ShapeAnalyzer.Geometry.Helpers;
using ShapeAnalyzer.Analyzes.Strategies;

namespace ShapeAnalyzer.DependencyInjection;

public interface IShapeAnalyzerConfigurator
{
    IShapeAnalyzerConfigurator AddShapeBuilder<TShape, TShapeBuilder>()
        where TShape : IShape
        where TShapeBuilder : ICustomShapeBuilder, new ();
    IShapeAnalyzerConfigurator AddAnalysis<TShape, TAnalysis>()
        where TShape : IShape
        where TAnalysis : AnalysisBase, new();
}
