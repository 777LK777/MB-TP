using ShapeAnalyzer.Geometry;

namespace HttpClient.Requests;

public class ShapeAnalysisRequest
{
    public string Name { get; set; }
    public Dictionary<Axis, double>[] Coordinates { get; set; }
}
