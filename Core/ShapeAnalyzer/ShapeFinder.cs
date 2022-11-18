using System.Reflection;
using ShapeAnalyzer.Geometry;

namespace ShapeAnalyzer;

public class ShapeFinder : IShapeFinder
{
    public string[] Find() =>
        AppDomain.CurrentDomain
            .GetAssemblies()
            .Select(a => a.DefinedTypes.ToList())
            .Aggregate(new List<TypeInfo>(), (seed, dts) =>
            {
                seed.AddRange(dts);
                return seed;
            })
            .Where(ti => ti.ImplementedInterfaces.Contains(typeof(IShape)))
            .Select(t => t.Name.ToLower())
            .ToArray();
}
