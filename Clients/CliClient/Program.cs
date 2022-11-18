using CommandDotNet;

namespace CliClient;

internal class Program
{
    static int Main(string[] args) =>
        new AppRunner<ShapeAnalyzerApp>().Run(args);    
}