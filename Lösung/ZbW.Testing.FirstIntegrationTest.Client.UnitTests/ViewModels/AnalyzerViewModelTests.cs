namespace ZbW.Testing.FirstIntegrationTest.Client.UnitTests.ViewModels
{
    using FakeItEasy;

    using NUnit.Framework;

    using ZbW.Testing.FirstIntegrationTest.Client.Models;
    using ZbW.Testing.FirstIntegrationTest.Client.Providers;
    using ZbW.Testing.FirstIntegrationTest.Client.ViewModels;

    [TestFixture]
    internal class AnalyzerViewModelTests
    {
        private const string NO_PATH = "";

        private const string VALID_PATH = "";

        private const string FULLTEXT_VALUE = "FullTextValue";

        private const string QR_CODE_VALUE = "QrCodeValue";

        [Test]
        public void CanAnalyze_HasPath_IsEnabled()
        {
            // arrange
            var analyzerViewModel = new AnalyzerViewModel(null);

            // act
            analyzerViewModel.FilePath = VALID_PATH;
            var result = analyzerViewModel.CmdAnalyze.CanExecute();

            // assert
            Assert.That(result, Is.False);
        }

        [Test]
        public void CanAnalyze_NoPath_IsDisabled()
        {
            // arrange
            var analyzerViewModel = new AnalyzerViewModel(null);

            // act
            analyzerViewModel.FilePath = NO_PATH;
            var result = analyzerViewModel.CmdAnalyze.CanExecute();

            // assert
            Assert.That(result, Is.False);
        }

        [Test]
        public void OnCmdAnalyze_ValidPath_CorrectReturnValueAssignments()
        {
            // arrange
            var ocrProviderStub = A.Fake<IOcrProvider>();
            A.CallTo(() => ocrProviderStub.Analyze(VALID_PATH)).Returns(new AnalyzeResult(FULLTEXT_VALUE, QR_CODE_VALUE));

            var analyzerViewModel = new AnalyzerViewModel(ocrProviderStub);
            analyzerViewModel.FilePath = VALID_PATH;

            // act
            analyzerViewModel.CmdAnalyze.Execute();

            // assert
            Assert.That(analyzerViewModel.ExtractedText, Is.EqualTo(FULLTEXT_VALUE));
            Assert.That(analyzerViewModel.QrCodeValue, Is.EqualTo(QR_CODE_VALUE));
        }

        [Test]
        public void OnCmdAnalyze_ValidPath_ExpectedResult()
        {
            // arrange
            var ocrProviderMock = A.Fake<IOcrProvider>();
            var analyzerViewModel = new AnalyzerViewModel(ocrProviderMock);
            analyzerViewModel.FilePath = VALID_PATH;

            // act
            analyzerViewModel.CmdAnalyze.Execute();

            // assert
            A.CallTo(() => ocrProviderMock.Analyze(VALID_PATH)).MustHaveHappenedOnceExactly();
        }
    }
}