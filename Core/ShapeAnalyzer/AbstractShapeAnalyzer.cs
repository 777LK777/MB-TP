using ShapeAnalyzer.Geometry;
using ShapeAnalyzer.Analyzes.Results;
using ShapeAnalyzer.Analyzes.Strategies;

namespace ShapeAnalyzer;

public abstract class BaseShapeAnalyzer : IShapeAnalyzer
{
    private readonly Dictionary<string, AnalysisBase> _shapeAnalysisMatchings;

    public BaseShapeAnalyzer()
    {
        _shapeAnalysisMatchings = new Dictionary<string, AnalysisBase>();
    }

    public IAnalysisResult Analyze(IShape shape)
    {
        var analysis = _shapeAnalysisMatchings[shape.GetType().Name.ToLower()];
        var analisysResult = analysis.GetAnalysisResult(shape);
        return analisysResult;
    }

    internal void LoadShapeStrategyMatchings(Dictionary<string, AnalysisBase> shapeAnalysisMatchings)
    {
        foreach (var shapeAnalysisMatching in shapeAnalysisMatchings)
        {
            var key = shapeAnalysisMatching.Key;

            if (!_shapeAnalysisMatchings.ContainsKey(key))
                _shapeAnalysisMatchings.Add(shapeAnalysisMatching.Key, shapeAnalysisMatching.Value);
        }
    }
}
