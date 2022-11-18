using Microsoft.AspNetCore.Mvc;

using HttpClient.Requests;
using HttpClient.Responses;
using ShapeAnalyzer;
using ShapeAnalyzer.Geometry;

namespace HttpClient.Controllers;

[ApiController]
public class ShapeAnalysisController : ControllerBase
{
    private readonly ILogger<ShapeAnalysisController> _logger;

    public ShapeAnalysisController(ILogger<ShapeAnalysisController> logger)
    {
        _logger = logger;
    }

    [Route("shapes")]
    [HttpGet]
    public IEnumerable<string> GetShapes(
        [FromServices] IShapeFinder shapeFinder)
    {
        return shapeFinder.Find();
    }

    [Route("analysis")]
    [HttpPost]
    public ShapeAnalysisResponse GetAnalysis(
        [FromServices] IShapeAnalyzerBuilder shapeAnalyzerBuilder,
        [FromServices] IShapeFactory shapeBuilder,
        [FromBody] ShapeAnalysisRequest request)
    {
        return null;
    }
}