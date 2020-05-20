using System;
using System.Configuration;
using Exception = System.Exception;

namespace DataSolutions.TransactionExchangeCentre.BackendProcess
{
    public class Configurations
    {
        public string RabbitMqHostName { get; private set; }
        public string RabbitMqConsumingExchangeName { get; private set; }
        public string RabbitMqConsumingExchangeType { get; private set; }
        public string RabbitMqConsumingRoutingKey { get; private set; }
        public string RabbitMqPublishingExchangeName { get; private set; }

        private Configurations()
        {
            try
            {
                RabbitMqHostName = ConfigurationManager.AppSettings["RabbitMqHostName"];
                RabbitMqConsumingExchangeName = ConfigurationManager.AppSettings["RabbitMqConsumingExchangeName"];
                RabbitMqConsumingExchangeType = ConfigurationManager.AppSettings["RabbitMqConsumingExchangeType"];
                RabbitMqConsumingRoutingKey = ConfigurationManager.AppSettings["RabbitMqConsumingRoutingKey"];
                RabbitMqPublishingExchangeName = ConfigurationManager.AppSettings["RabbitMqPublishingExchangeName"];
                
            }
            catch (Exception e)
            {
                Console.WriteLine("Configuration initiate error: " + e);
            }
        }
        private static readonly Configurations UniqueInstance = new Configurations();
        public static Configurations GetInstance()
        {
            return UniqueInstance;
        }
    }
}
