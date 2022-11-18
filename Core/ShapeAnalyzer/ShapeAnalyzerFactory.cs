using ShapeAnalyzer.Geometry;
using ShapeAnalyzer.Geometry.Shapes;
using ShapeAnalyzer.Analyzes.Strategies;

namespace ShapeAnalyzer;

public class ShapeAnalyzerBuilder : IShapeAnalyzerBuilder
{
    private readonly Dictionary<string, AnalysisBase> _shapesAnalyzesMatchings;
    private readonly BaseShapeAnalyzer _shapeAnalyzer;

    public ShapeAnalyzerBuilder(BaseShapeAnalyzer shapeAnalyzer)
    {
        _shapeAnalyzer = shapeAnalyzer;
        _shapesAnalyzesMatchings = new Dictionary<string, AnalysisBase>();

        this
            .AddAnalysis<Triangle, TriangleAnalysis>()
            .AddAnalysis<Circle, CircleAnalysis>();
    }

    public ShapeAnalyzerBuilder() : this(new DefaultShapeAnalyzer()) {}

    public IShapeAnalyzerBuilder AddAnalysis<TShape, TAnalysis>()
        where TShape : IShape
        where TAnalysis : AnalysisBase, new()
    {
        var shapeType = typeof(TShape).Name.ToLower();
        var analysisStrategy = new TAnalysis();

        if (!_shapesAnalyzesMatchings.ContainsKey(shapeType))
            _shapesAnalyzesMatchings.Add(shapeType, analysisStrategy);

        return this;
    }

    public IShapeAnalyzer Build()
    {
        _shapeAnalyzer.LoadShapeStrategyMatchings(_shapesAnalyzesMatchings);

        return _shapeAnalyzer;
    }
}
