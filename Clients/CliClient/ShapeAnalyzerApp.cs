using CommandDotNet;

using CliClient.Helpers;
using CustomShapes.Square;
using ShapeAnalyzer;
using ShapeAnalyzer.Geometry;
using System.Linq.Expressions;
using ShapeAnalyzer.Geometry.Helpers;

namespace CliClient;

[Command(Description = "Shape analyzer application")]
internal class ShapeAnalyzerApp
{
    private readonly IShapeFactory _shapeFactory;
    private readonly IShapeAnalyzer _shapeAnalyzer;
    private readonly StringToCordinateConverter _coordReader;
    private readonly IShapeFinder _shapeFinder;

    public ShapeAnalyzerApp()
    {
        _shapeFactory = new ShapeFactory()
            .AddShapeBuilder<Square, SquareBuilder>();
        _shapeAnalyzer = new ShapeAnalyzerBuilder()
            .SetAccuracy(7)
            .AddAnalysis<Square, SquareAnalysis>()
            .Build();

        _coordReader = new StringToCordinateConverter();
        _shapeFinder = new ShapeFinder();
    }

    [Command("circle", Description = "  returns circle area",
        UsageLines = new[]
        {
            "circle [0;0] [0;1]",
            "enter start and end of the radius",
            "coordinates terminology: [X, Y]"}
        )]
    public void Circle(
        IConsole console, string startRadius, string endRadius,
        [Option('f', "full", Description = "Print full analysis?")] bool? isPrintFullAnalysisResult = null)
    {
        var shape = _shapeFactory.Create(
            "circle",
            _coordReader.Convert<Axis>(startRadius), 
            _coordReader.Convert<Axis>(endRadius));

        PrintAnalysis(console, shape, isPrintFullAnalysisResult);
    }

    [Command("analysis", Description = "  returns analysis for shape",
        UsageLines = new[]
        {
            "circle '[0;0] [0;1]'",
            "enter shape name and coordinates for shape parameter",
            "coordinates terminology: [X, Y]"}
        )]
    public void Analysis(
        IConsole console, string shapeName, string coordinates,
        [Option('f', "full", Description = "Print full analysis?")] bool? isPrintFullAnalysisResult = null)
    {
        var coords = _coordReader.ConvertMany<Axis>(coordinates);

        var shape = _shapeFactory.Create(
            shapeName,
            coords.ToArray());

        PrintAnalysis(console, shape, isPrintFullAnalysisResult);
    }

    [Command("triangle", Description = "    returns triangle area",
        UsageLines = new[]
        {
            "triangle [0;0] [0;1] [1;0]",
            "enter the coordinates of the triangle's vertices",
            "coordinates terminology: [X, Y]"}
        )]
    public void Triangle(
        IConsole console, string firstVertex, string secondVertex,
        string thirdVertex,
        [Option('f', "full", Description = "Print full analysis?")] bool? isPrintFullAnalysisResult = null)
    {
        var shape = _shapeFactory.Create(
            "triangle",
             _coordReader.Convert<Axis>(firstVertex),
             _coordReader.Convert<Axis>(secondVertex),
             _coordReader.Convert<Axis>(thirdVertex));

        PrintAnalysis(console, shape, isPrintFullAnalysisResult);
    }

    [Command("square", Description = "  returns square area",
        UsageLines = new[]
        {
            "square [0;0] [1;1]",
            "enter start and end of the diagonal",
            "coordinates terminology: [X, Y]"}
        )]
    public void Square(
        IConsole console, string firstVertex, string secondVertex,
        [Option('f', "full", Description = "Print full analysis?")] bool? isPrintFullAnalysisResult = null)
    {
        var shape = _shapeFactory.Create(
            "square",
            _coordReader.Convert<Axis>(firstVertex),
            _coordReader.Convert<Axis>(secondVertex));

        PrintAnalysis(console, shape, isPrintFullAnalysisResult);
    }

    [Command("shapes", Description = "  returns all shapes in assembly")]
    public void Shapes(IConsole console)
    {
        var shapes = _shapeFinder.Find();

        foreach (var shape in shapes)
            console.WriteLine(shape);
    }

    private void PrintAnalysis(IConsole console, IShape shape, bool? isPrintFullAnalysisResult)
    {
        var result = _shapeAnalyzer.Analyze(shape);

        if (isPrintFullAnalysisResult ?? false)
        {
            console.WriteLine(result.FullToString());
            return;
        }

        console.WriteLine(result);
    }
}
