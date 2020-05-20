using Abp.Configuration.Startup;
using Abp.Localization.Dictionaries;
using Abp.Localization.Dictionaries.Xml;
using Abp.Reflection.Extensions;

namespace DataSolutions.TransactionExchangeCentre.Localization
{
    public static class TransactionExchangeCentreLocalizationConfigurer
    {
        public static void Configure(ILocalizationConfiguration localizationConfiguration)
        {
            localizationConfiguration.Sources.Add(
                new DictionaryBasedLocalizationSource(TransactionExchangeCentreConsts.LocalizationSourceName,
                    new XmlEmbeddedFileLocalizationDictionaryProvider(
                        typeof(TransactionExchangeCentreLocalizationConfigurer).GetAssembly(),
                        "DataSolutions.TransactionExchangeCentre.Localization.SourceFiles"
                    )
                )
            );
        }
    }
}
