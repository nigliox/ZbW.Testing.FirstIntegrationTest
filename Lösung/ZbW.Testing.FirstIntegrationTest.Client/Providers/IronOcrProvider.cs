namespace ZbW.Testing.FirstIntegrationTest.Client.Providers
{
    using System.Linq;

    using IronOcr;
    using IronOcr.Languages;

    using ZbW.Testing.FirstIntegrationTest.Client.Models;

    internal class IronOcrProvider : IOcrProvider
    {
        public AnalyzeResult Analyze(string path)
        {
            var advancedOcr = SetupOcrAnalyzer();
            var ocrResult = advancedOcr.ReadPdf(path);
            var qrCodeValue = GetQrCodeValue(ocrResult);

            var analyzeResult = new AnalyzeResult(ocrResult.Text, qrCodeValue);
            return analyzeResult;
        }

        private string GetQrCodeValue(OcrResult ocrResult)
        {
            var qrCode = ocrResult.Barcodes.FirstOrDefault(x => x.Format == OcrResult.OcrBarcode.BarcodeFormat.QRCode);
            return qrCode?.Value;
        }

        private AdvancedOcr SetupOcrAnalyzer()
        {
            var advancedOcr = new AdvancedOcr()
                                  {
                                      CleanBackgroundNoise = true,
                                      EnhanceContrast = true,
                                      EnhanceResolution = true,
                                      Language = German.OcrLanguagePack,
                                      Strategy = AdvancedOcr.OcrStrategy.Advanced,
                                      ColorSpace = AdvancedOcr.OcrColorSpace.Color,
                                      DetectWhiteTextOnDarkBackgrounds = true,
                                      InputImageType = AdvancedOcr.InputTypes.AutoDetect,
                                      RotateAndStraighten = true,
                                      ReadBarCodes = true,
                                      ColorDepth = 4,
                                  };
            return advancedOcr;
        }
    }
}