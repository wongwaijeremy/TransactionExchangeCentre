using Abp.AutoMapper;
using DataSolutions.TransactionExchangeCentre.Authentication.External;

namespace DataSolutions.TransactionExchangeCentre.Models.TokenAuth
{
    [AutoMapFrom(typeof(ExternalLoginProviderInfo))]
    public class ExternalLoginProviderInfoModel
    {
        public string Name { get; set; }

        public string ClientId { get; set; }
    }
}
