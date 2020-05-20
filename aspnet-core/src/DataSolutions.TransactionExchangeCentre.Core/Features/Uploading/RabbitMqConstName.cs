namespace DataSolutions.TransactionExchangeCentre.Features.Uploading
{
    public static class RabbitMqConstName
    {
        public const string HostName = "RabbitMQ.HostName";

        public static class Consuming
        {
            public static class Exchange
            {
                public const string Name = "RabbitMQ.Consuming.Exchange.Name";
                public const string Type = "RabbitMQ.Consuming.Exchange.Type";
            }

            public static class RoutingKey
            {
                public const string General = "RabbitMQ.Consuming.RoutingKey.General";
                public const string Success = "RabbitMQ.Consuming.RoutingKey.Success";
                public const string Fail = "RabbitMQ.Consuming.RoutingKey.Fail";
            }
        }

        public static class Publishing
        {
            public static class Exchange
            {
                public const string Name = "RabbitMQ.Publishing.Exchange.Name";
            }
        }
    }
}
