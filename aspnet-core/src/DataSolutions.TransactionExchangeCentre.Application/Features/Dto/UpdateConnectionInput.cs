using Abp.Application.Services.Dto;
using Abp.AutoMapper;

namespace DataSolutions.TransactionExchangeCentre.Features.Dto
{
    [AutoMapTo(typeof(Channel))]
    public class UpdateConnectionInput : EntityDto
    {
        public string FtpAddress { get; set; }
        public string FtpUserName { get; set; }
        public string FtpPassword { get; set; }
        public FtpProtocol FtpProtocol { get; set; }

        public string SourceLocalPath { get; set; }
        public string DestinationPath { get; set; }
        public string ExtensionName { get; set; }
    }
}
