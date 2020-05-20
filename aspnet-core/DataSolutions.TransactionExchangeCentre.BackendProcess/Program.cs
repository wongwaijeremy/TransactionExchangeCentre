using System;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace DataSolutions.TransactionExchangeCentre.BackendProcess
{
    class Program
    {
        private static Configurations Config { get; set; }
        private static ConnectionFactory Factory { get; set; }
        private static IConnection Connection { get; set; }
        private static IModel Channel { get; set; }
        private static UploadCommandHandler UploadCommandHandler { get; set; }

        static void Main(string[] args)
        {
            Console.WriteLine("Tradelink messaging hub backendProcess launching");
            Config = Configurations.GetInstance();

            Factory = new ConnectionFactory() { HostName = Config.RabbitMqHostName };
            Connection = Factory.CreateConnection();
            Channel = Connection.CreateModel();
            UploadCommandHandler = new UploadCommandHandler(Config, Channel);
            Console.WriteLine("RabbitMQ connected");

            Channel.ExchangeDeclare(
                exchange: Config.RabbitMqConsumingExchangeName,
                type: Config.RabbitMqConsumingExchangeType,
                durable: true,
                autoDelete: false);

            var queueName = Channel.QueueDeclare(
                queue: "",
                durable: true,
                exclusive: true,
                autoDelete: false)
                .QueueName;

            Channel.QueueBind(
                queue: queueName,
                exchange: Config.RabbitMqConsumingExchangeName,
                routingKey: Config.RabbitMqConsumingRoutingKey);

            Channel.BasicQos(
                prefetchSize: 0, 
                prefetchCount: 1,
                global: false);


            var consumer = new EventingBasicConsumer(Channel);


            consumer.Received += OnConsumerOnReceived;
            Channel.BasicConsume(queue: queueName, autoAck: false, consumer: consumer);

            Console.WriteLine("Type \"quit\" to exit");
            while (Console.ReadLine() != "quit")
            {
            }
            
        }

        static void OnConsumerOnReceived(object model, BasicDeliverEventArgs ea)
        {
            var body = ea.Body;
            var message = Encoding.UTF8.GetString(body);
            var uploadChannel = JsonConvert.DeserializeObject<UploadChannel>(message);
            Console.WriteLine($"Received: {message}");

            Channel.BasicAck(
                deliveryTag: ea.DeliveryTag,
                multiple: false);

            UploadCommandHandler.HandleNew(uploadChannel);
            
        }
    }
}
