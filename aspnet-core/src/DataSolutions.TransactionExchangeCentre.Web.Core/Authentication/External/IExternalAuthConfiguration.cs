using System.Collections.Generic;

namespace DataSolutions.TransactionExchangeCentre.Authentication.External
{
    public interface IExternalAuthConfiguration
    {
        List<ExternalLoginProviderInfo> Providers { get; }
    }
}
