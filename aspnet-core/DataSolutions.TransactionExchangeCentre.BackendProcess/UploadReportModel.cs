using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataSolutions.Core;
using Newtonsoft.Json;

namespace DataSolutions.TransactionExchangeCentre.BackendProcess
{
    public class UploadReportModel
    {
        public int ChannelId { get; set; }
        public List<SingleFileReportModel> Files { get; set; } = new List<SingleFileReportModel>();

        public byte[] GetSerializedBytesBody()
        {
            var serialized = JsonConvert.SerializeObject(this);
            return Encoding.UTF8.GetBytes(serialized);
        }

        public UploadReportModel(int channelId)
        {
            ChannelId = channelId;
        }
    }

    public class SingleFileReportModel
    {
        public string FileName { get; set; }
        public DateTime UploadAt { get; set; }
    }





    public class UploadFailRabbitMqPackage
    {
        public string RoutingKey { get; }
        public byte[] ReportBody { get; }
        public UploadFailModel UploadFailModel { get; }

        public UploadFailRabbitMqPackage(Result<UploadReportModel> failedUploadResult)
        {
            RoutingKey = "upload.fail";
            UploadFailModel = new UploadFailModel(failedUploadResult);
            var serialized = JsonConvert.SerializeObject(UploadFailModel);
            ReportBody = Encoding.UTF8.GetBytes(serialized);
        }
    }

    public class UploadFailModel
    {
        public UploadFailModel(Result<UploadReportModel> failedUploadResult)
        {
            var originalModel = failedUploadResult.Model;
            if (originalModel == null)
                throw new ArgumentNullException();
            ChannelId = originalModel.ChannelId;
            Files = originalModel.Files.Select(file => new SingleFileFailReportModel(file.FileName, file.UploadAt)).ToList();
            var error = failedUploadResult.Error;
            Reason = error.ToString();
            ErrorType = error.GetType().Name;
        }

        public int ChannelId { get; set; }
        public List<SingleFileFailReportModel> Files { get; set; }
        public string Reason { get; set; }
        public string ErrorType { get; set; }
    }

    public class SingleFileFailReportModel
    {
        public string FileName { get; set; }
        public DateTime TryUploadAt { get; set; }

        public SingleFileFailReportModel(string fileName, DateTime tryUploadAt)
        {
            FileName = fileName;
            TryUploadAt = tryUploadAt;
        }
    }
}
