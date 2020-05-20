using System.Configuration;

namespace DataSolutions.TransactionExchangeCentre
{
    public static class AppConfigHelper
    {
        public static string GetBy(string name)
        {
            var value = ConfigurationManager.AppSettings[name];

            return value ?? "";
        }
    }
}
