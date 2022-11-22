using ShapeAnalyzer.Geometry;
using ShapeAnalyzer.Geometry.Helpers;
using ShapeAnalyzer.Analyzes.Results;
using System.Numerics;

namespace ShapeAnalyzer.Analyzes.Strategies;

internal class TriangleAnalysis : AnalysisBase
{
    private readonly Ruler _ruler;

    public TriangleAnalysis()
    {
        _ruler = new Ruler();
    }

    public override IAnalysisResult GetAnalysisResult(IShape triangle)
    {
        var analysisResult = new TriangleAnalysisResult();
        
        var sides = GetSidesOfTriangle(triangle.Vertices, ruler => ruler.GetDistance);
        var sidesSquares = GetSidesOfTriangle(triangle.Vertices, ruler => ruler.GetSquareDistance);

        var isRectangular = IsTriangleRectangularBySidesSquares(sidesSquares);

        var area = isRectangular == IsTriangleRectangular(sides) 
            ? GetAreaBySides(sides)
            : GetAreaByVertices(triangle.Vertices);

        analysisResult.Area = area;
        analysisResult.IsRectangular = isRectangular;

        return analysisResult;
    }

    private double GetAreaByVertices(List<Dictionary<Axis, double>> vertices)
    {
        var v0 = vertices[0];
        var v1 = vertices[1];
        var v2 = vertices[2];

        return 0.5 * Math.Abs(
              (v1[Axis.X] - v0[Axis.X])
            * (v2[Axis.Y] - v0[Axis.Y])
            - (v2[Axis.X] - v0[Axis.X])
            * (v1[Axis.Y] - v0[Axis.Y]));
    }

    private List<double> GetSidesOfTriangle(
        List<Dictionary<Axis, double>> coordinates,
        Func<Ruler, Func<Dictionary<Axis, double>, Dictionary<Axis, double>, double>> getDistanceSelector)
    {
        var getDistance = getDistanceSelector(_ruler);

        var result = new List<double>();

        for (int i = 1; i < coordinates.Count; i++)
            result.Add(getDistance(coordinates[i - 1], coordinates[i]));
        result.Add(getDistance(coordinates[0], coordinates[coordinates.Count - 1]));

        return result;
    }
    
    private bool IsTriangleRectangularBySidesSquares(List<double> sides)
    {
        var max = sides.Max();

        var powsSum = sides
            .Where(s => s < max)
            .Aggregate(0.0, (seed, side) => seed += side);

        return max == powsSum;
    }

    private bool IsTriangleRectangular(List<double> sides)
    {
        var max = sides.Max();

        var powsSum = sides
            .Where(s => s < max)
            .Aggregate(0.0, (seed, side) => seed += Math.Pow(side, 2));

        return Math.Pow(max, 2) == powsSum;
    }

    private double GetAreaBySides(List<double> sidesSquares)
    {
        var halfPerimeter = sidesSquares.Sum() / 2;

        var op = sidesSquares.Aggregate(0.0, (seed, side) =>
        {
            var diff = halfPerimeter - side;
            return seed *= diff;
        });

        return RoundDouble(Math.Sqrt(halfPerimeter * op));
    }
}
