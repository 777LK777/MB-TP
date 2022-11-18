using Microsoft.Extensions.DependencyInjection;

using ShapeAnalyzer.Geometry;

namespace ShapeAnalyzer.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddShapeAnalyzer(
        this IServiceCollection @this,
        Action<IShapeAnalyzerConfigurator> configurate)
    {
        var configurator = new ShapeAnalyzerConfigurator(
            new ShapeAnalyzerBuilder(),
            new ShapeFactory());
        configurate(configurator);

        @this
            .AddTransient<IShapeFinder, ShapeFinder>()
            .AddTransient(sp => configurator.ShapeAnalyzerBuilder)
            .AddTransient(sp => configurator.ShapeFactory);

        return @this;
    }
}
