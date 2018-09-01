namespace ZbW.Testing.FirstIntegrationTest.Client.Providers
{
    using ZbW.Testing.FirstIntegrationTest.Client.Models;

    internal interface IOcrProvider
    {
        AnalyzeResult Analyze(string path);
    }
}