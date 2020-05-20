namespace DataSolutions.TransactionExchangeCentre.BackendProcess
{
    public class UploadChannel
    {
        public int ChannelId { get; set; }
        //public string BuyerShortCode {get;set;}
        //public string DocumentType {get;set;}

        public string DestinationPath { get; set; }
        public string SourceLocalPath { get; set; }
        public string ExtensionName { get; set; }
        public string FtpAddress { get; set; }
        public string FtpUserName { get; set; }
        public string FtpPassword { get; set; }
        public FtpProtocol FtpProtocol { get; set; }
    }

    public enum FtpProtocol
    {
        FTP = 1,
        SFTP = 2
    }
}
