using CustomShapes.Square;
using ShapeAnalyzer.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddShapeAnalyzer(cfg =>
    {
        cfg
            .AddShapeBuilder<Square, SquareBuilder>()
            .AddAnalysis<Square, SquareAnalysis>();
    })
    .AddEndpointsApiExplorer()
    .AddSwaggerGen()
    .AddControllers();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
