using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Abp.Configuration;
using Abp.Dependency;
using Castle.Core.Logging;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace DataSolutions.TransactionExchangeCentre.Features.Uploading
{
    public class RabbitMqMessager : ISingletonDependency
    {
        private readonly ILogger _logger;

        private static ConnectionFactory _factory;
        private static IConnection _connection;
        private static IModel _channel;
        private static string _successRoutingKey;
        private static string _failRoutingKey;

        public bool Initialized { get; private set; } = false;

        public RabbitMqMessager(ILogger logger)
        {
            _logger = logger;
            Initialize();
        }

        private Task Initialize()
        {
            var hostName = AppConfigHelper.GetBy(RabbitMqConstName.HostName);
            var consumingExchangeName = AppConfigHelper.GetBy(RabbitMqConstName.Consuming.Exchange.Name);
            var consumingExchangeType = AppConfigHelper.GetBy(RabbitMqConstName.Consuming.Exchange.Type);
            var consumingRoutingKey = AppConfigHelper.GetBy(RabbitMqConstName.Consuming.RoutingKey.General);
            _successRoutingKey = AppConfigHelper.GetBy(RabbitMqConstName.Consuming.RoutingKey.Success);
            _failRoutingKey = AppConfigHelper.GetBy(RabbitMqConstName.Consuming.RoutingKey.Fail);
            
            //rabbit mq user
            //rabbit mq password

            _factory = new ConnectionFactory { HostName = hostName };
            _connection = _factory.CreateConnection();
            _channel = _connection.CreateModel();

            //UploadCommandHandler = new UploadCommandHandler(Config, Channel);

            _logger.Info("RabbitMQ connected");

            _channel.ExchangeDeclare(
                exchange: consumingExchangeName,
                type: consumingExchangeType,
                durable: true,
                autoDelete: false);

            var queueName = _channel.QueueDeclare(
                    queue: "",
                    durable: true,
                    exclusive: true,
                    autoDelete: false)
                .QueueName;

            _channel.QueueBind(
                queue: queueName,
                exchange: consumingExchangeName,
                routingKey: consumingRoutingKey);

            _channel.BasicQos(
                prefetchSize: 0,
                prefetchCount: 1,
                global: false);


            var consumer = new EventingBasicConsumer(_channel);


            consumer.Received += OnConsumerOnReceived;
            _channel.BasicConsume(queue: queueName, autoAck: false, consumer: consumer);


            Initialized = true;
            return Task.CompletedTask;
        }

        private void OnConsumerOnReceived(object sender, BasicDeliverEventArgs e)
        {
            var body = e.Body;

            if (e.RoutingKey == _successRoutingKey)
                HandleSuccessCase(body);
            else if (e.RoutingKey == _failRoutingKey)
                HandleFailCase(body);
        }

        private void HandleSuccessCase(byte[] body)
        {
            var message = Encoding.UTF8.GetString(body);
            var uploadChannel = JsonConvert.DeserializeObject<UploadChannel>(message);
        }

        private void HandleFailCase(byte[] body)
        {
            var message = Encoding.UTF8.GetString(body);
            var uploadChannel = JsonConvert.DeserializeObject<UploadChannel>(message);
        }
    }
}
