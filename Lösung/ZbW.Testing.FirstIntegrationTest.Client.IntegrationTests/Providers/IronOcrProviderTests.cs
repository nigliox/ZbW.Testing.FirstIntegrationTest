namespace ZbW.Testing.FirstIntegrationTest.Client.IntegrationTests.Providers
{
    using NUnit.Framework;

    using ZbW.Testing.FirstIntegrationTest.Client.IntegrationTests.Shared;
    using ZbW.Testing.FirstIntegrationTest.Client.Providers;

    [TestFixture]
    internal class IronOcrProviderTests
    {
        [Test]
        public void Analyze_SamplePdf_GetTextAndQrCode()
        {
            // arrange
            var ironOcrProvider = new IronOcrProvider();
            var pathToSamplePdf = SharedFunctions.GetPathToSamplePdf();

            // act
            var analyzeResult = ironOcrProvider.Analyze(pathToSamplePdf);

            // assert
            Assert.That(analyzeResult.Fulltext, Contains.Substring(SharedValues.OCR_TEXT_PART));
            Assert.That(analyzeResult.QrCodeText, Contains.Substring(SharedValues.QR_CODE_VALUE_PART));
        }
    }
}