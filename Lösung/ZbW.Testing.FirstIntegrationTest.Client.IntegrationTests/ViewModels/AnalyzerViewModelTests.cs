namespace ZbW.Testing.FirstIntegrationTest.Client.IntegrationTests.ViewModels
{
    using NUnit.Framework;

    using ZbW.Testing.FirstIntegrationTest.Client.IntegrationTests.Shared;
    using ZbW.Testing.FirstIntegrationTest.Client.Providers;
    using ZbW.Testing.FirstIntegrationTest.Client.ViewModels;

    [TestFixture]
    internal class AnalyzerViewModelTests
    {
        [Test]
        public void CmdAnalyze_SamplePdf_GetTextAndQrCode()
        {
            // arrange
            var analyzerViewModel = new AnalyzerViewModel(new IronOcrProvider());
            analyzerViewModel.FilePath = SharedFunctions.GetPathToSamplePdf();

            // act
            analyzerViewModel.CmdAnalyze.Execute();

            // assert
            Assert.That(analyzerViewModel.ExtractedText, Contains.Substring(SharedValues.OCR_TEXT_PART));
            Assert.That(analyzerViewModel.QrCodeValue, Contains.Substring(SharedValues.QR_CODE_VALUE_PART));
        }
    }
}