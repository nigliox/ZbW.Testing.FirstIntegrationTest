namespace ZbW.Testing.FirstIntegrationTest.Client.ViewModels
{
    using Prism.Commands;
    using Prism.Mvvm;

    using ZbW.Testing.FirstIntegrationTest.Client.Providers;

    internal class AnalyzerViewModel : BindableBase
    {
        private readonly IOcrProvider _ocrProvider;

        private string _extractedText;

        private string _filePath;

        private string _qrCodeValue;

        public AnalyzerViewModel(IOcrProvider ocrProvider)
        {
            _ocrProvider = ocrProvider;
            CmdAnalyze = new DelegateCommand(OnCmdAnalyze, OnCmdCanAnalyze);
        }

        public string FilePath
        {
            get
            {
                return _filePath;
            }

            set
            {
                if (SetProperty(ref _filePath, value))
                {
                    CmdAnalyze.RaiseCanExecuteChanged();
                }
            }
        }

        public DelegateCommand CmdAnalyze { get; }

        public string ExtractedText
        {
            get
            {
                return _extractedText;
            }

            set
            {
                SetProperty(ref _extractedText, value);
            }
        }

        public string QrCodeValue
        {
            get
            {
                return _qrCodeValue;
            }

            set
            {
                SetProperty(ref _qrCodeValue, value);
            }
        }

        private bool OnCmdCanAnalyze()
        {
            return !string.IsNullOrEmpty(FilePath);
        }

        private void OnCmdAnalyze()
        {
            var analyzeResult = _ocrProvider.Analyze(FilePath);

            QrCodeValue = analyzeResult.QrCodeText;
            ExtractedText = analyzeResult.Fulltext;
        }
    }
}