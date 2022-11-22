using ShapeAnalyzer.Geometry;
using ShapeAnalyzer.Analyzes.Results;

namespace ShapeAnalyzer.Analyzes.Strategies;

public abstract class AnalysisBase
{
    private int _accuracy;

    public abstract IAnalysisResult GetAnalysisResult(IShape shape);

    public int Accuracy
    {
        get => _accuracy > 0 ? _accuracy : 2;
        set
        {
            _accuracy = value;
        }
    }

    protected double RoundDouble(double result)
    {
        return Math.Round(result, Accuracy);
    }
}
