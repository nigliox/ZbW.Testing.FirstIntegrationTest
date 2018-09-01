namespace ZbW.Testing.FirstIntegrationTest.Client.Models
{
    public class AnalyzeResult
    {
        public AnalyzeResult(string fulltext, string qrCodeText)
        {
            Fulltext = fulltext;
            QrCodeText = qrCodeText;
        }

        public string Fulltext { get; }

        public string QrCodeText { get; }
    }
}