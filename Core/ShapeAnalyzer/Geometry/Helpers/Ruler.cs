namespace ShapeAnalyzer.Geometry.Helpers;

public class Ruler
{
    public double GetDistance(
        Dictionary<Axis, double> firstVertex, 
        Dictionary<Axis, double> secondVertex)
    {
        var deltaX = secondVertex[Axis.X] - firstVertex[Axis.X];
        var deltaY = secondVertex[Axis.Y] - firstVertex[Axis.Y];

        return Math.Sqrt(Math.Pow(deltaX, 2) + Math.Pow(deltaY, 2));
    }

    public double GetSquareDistance(
        Dictionary<Axis, double> firstVertex,
        Dictionary<Axis, double> secondVertex)
    {
        var deltaX = secondVertex[Axis.X] - firstVertex[Axis.X];
        var deltaY = secondVertex[Axis.Y] - firstVertex[Axis.Y];

        return Math.Pow(deltaX, 2) + Math.Pow(deltaY, 2);
    }
}
