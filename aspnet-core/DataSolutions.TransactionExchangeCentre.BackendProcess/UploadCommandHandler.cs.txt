using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using RabbitMQ.Client;

namespace DataSolutions.TransactionExchangeCentre.BackendProcess
{
    // https://docs.microsoft.com/en-us/dotnet/standard/collections/thread-safe/blockingcollection-overview
    public class UploadCommandHandler
    {
        private readonly IBasicProperties _rabbitMqProperties;
        private readonly IModel _channel;
        private readonly WinScpUploader _winScpUploader;
        private readonly Configurations _config;

        public UploadCommandHandler(Configurations config, IModel channel)
        {
            _rabbitMqProperties = channel.CreateBasicProperties();
            _rabbitMqProperties.Persistent = true;
            _channel = channel;
            _config = config;
            _winScpUploader = new WinScpUploader();
        }

        public void HandleNew(UploadChannel uploadChannel, int trial = 2)
        {
            var uploadResult = _winScpUploader.Upload(uploadChannel);
            if (uploadResult.IsSuccess)
            {
                try
                {
                    var reportBody = uploadResult.Model.GetSerializedBytesBody();
                    _channel.BasicPublish(
                        exchange: _config.RabbitMqPublishingExchangeName,
                        routingKey: "upload.success",
                        basicProperties: _rabbitMqProperties,
                        body: reportBody);
                }
                catch (Exception e)
                {
                    Console.WriteLine("Rabbit MQ Connection Error");
                }
            }
            else if (trial > 0)
            {
                DelayedHandleNew(uploadChannel, trial - 1);
            }
            else
            {
                try
                {
                    var failResult = new UploadFailRabbitMqPackage(uploadResult);
                    _channel.BasicPublish(
                        exchange: _config.RabbitMqPublishingExchangeName,
                        routingKey: failResult.RoutingKey,
                        basicProperties: _rabbitMqProperties,
                        body: failResult.ReportBody);
                }
                catch (Exception e)
                {
                    Console.WriteLine("Rabbit MQ Connection Error");
                }
            }
        }

        private async Task DelayedHandleNew(UploadChannel uploadChannel, int trial = 2)
        {
            await Task.Delay(TimeSpan.FromSeconds(1));
            HandleNew(uploadChannel, trial);
        }
    }
}