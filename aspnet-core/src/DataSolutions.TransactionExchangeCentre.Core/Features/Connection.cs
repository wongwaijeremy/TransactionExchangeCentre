namespace DataSolutions.TransactionExchangeCentre.Features
{
    public partial class Channel
    {
        public ConnectionStatus ConnectionStatus { get; set; }
        public string FtpAddress { get; set; }
        public string FtpUserName { get; set; }
        public string FtpPassword { get; set; }
        public FtpProtocol FtpProtocol { get; set; }

        public string SourceLocalPath { get; set; }
        public string DestinationPath { get; set; }
        public string ExtensionName { get; set; }
    }
}
