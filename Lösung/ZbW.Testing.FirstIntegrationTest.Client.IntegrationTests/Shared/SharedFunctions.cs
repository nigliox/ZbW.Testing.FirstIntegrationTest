namespace ZbW.Testing.FirstIntegrationTest.Client.IntegrationTests.Shared
{
    using System.IO;

    using NUnit.Framework;

    internal static class SharedFunctions
    {
        public static string GetPathToSamplePdf()
        {
            var sampleFile = Path.Combine(TestContext.CurrentContext.TestDirectory, "_TestResources", "Sample.pdf");
            return sampleFile;
        }
    }
}