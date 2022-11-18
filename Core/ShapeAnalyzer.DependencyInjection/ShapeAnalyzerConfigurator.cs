using ShapeAnalyzer.Geometry;
using ShapeAnalyzer.Analyzes.Strategies;
using ShapeAnalyzer.Geometry.Helpers;

namespace ShapeAnalyzer.DependencyInjection;

internal class ShapeAnalyzerConfigurator : IShapeAnalyzerConfigurator
{
    private readonly IShapeAnalyzerBuilder _shapeAnalyzerBuilder;
    private readonly IShapeFactory _shapeFactory;

    public IShapeAnalyzerBuilder ShapeAnalyzerBuilder => _shapeAnalyzerBuilder;
    public IShapeFactory ShapeFactory => _shapeFactory;

    public ShapeAnalyzerConfigurator(
        IShapeAnalyzerBuilder shapeAnalyzerBuilder,
        IShapeFactory shapeFactory)
    {
        _shapeAnalyzerBuilder = shapeAnalyzerBuilder;
        _shapeFactory = shapeFactory;
    }

    public IShapeAnalyzerConfigurator AddAnalysis<TShape, TAnalysis>()
        where TShape : IShape
        where TAnalysis : AnalysisBase, new()
    {
        _shapeAnalyzerBuilder.AddAnalysis<TShape, TAnalysis>();
        return this;
    }

    public IShapeAnalyzerConfigurator AddShapeBuilder<TShape, TShapeBuilder>()
        where TShape : IShape
        where TShapeBuilder : ICustomShapeBuilder, new()
    {
        _shapeFactory.AddShapeBuilder<TShape, TShapeBuilder>();
        return this;
    }
}
