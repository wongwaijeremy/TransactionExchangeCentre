using System;
using System.IO;
using DataSolutions.Core;
using WinSCP;

namespace DataSolutions.TransactionExchangeCentre.BackendProcess
{
    public class WinScpUploader : ITradelinkUploader
    {
        public Result<UploadReportModel> Upload(UploadChannel uploadChannel)
        {
            //lock
            Result<UploadReportModel> result = new UploadReportModel(uploadChannel.ChannelId);

            var sessionOptions = GetSession(uploadChannel);
            using (var session = new Session())
            {
                try
                {
                    session.Open(sessionOptions);
                }
                catch (SessionRemoteException e)
                {
                    result.ToFail(new WinScpConnectionError(e.ToString()));
                    return result;
                }

                var transferResult = session.PutFiles(GetTransferSourcePath(uploadChannel), GetDestinationPath(uploadChannel),
                    false, GetTransferOptions()); //TODO: Should be true

                foreach (TransferEventArgs transfer in transferResult.Transfers)
                {
                    var fileName = transfer.FileName;
                    var uploadAt = DateTime.Now;

                    var file = new SingleFileReportModel() { FileName = fileName, UploadAt = uploadAt };
                    result.Model.Files.Add(file);
                    Console.WriteLine("File sent: " + fileName + " at " + uploadAt);
                }

                try
                {
                    transferResult.Check();
                }
                catch (SessionRemoteException e)
                {
                    result.ToFail(new WinScpUploadError(e.ToString()));
                    return result;
                }
            }
            return result;
        }


        private static TransferOptions GetTransferOptions() => new TransferOptions { TransferMode = TransferMode.Binary };

        private static string GetDestinationPath(UploadChannel uploadChannel) => Path.Combine(uploadChannel.DestinationPath, "*");

        private static string GetTransferSourcePath(UploadChannel uploadChannel) => Path.Combine(uploadChannel.SourceLocalPath, "*." + uploadChannel.ExtensionName);

        private static SessionOptions GetSession(UploadChannel uploadChannel)
        {
            var sessionOptions = new SessionOptions()
            {
                HostName = uploadChannel.FtpAddress,
                UserName = uploadChannel.FtpUserName,
                Password = uploadChannel.FtpPassword,
            };
            switch (uploadChannel.FtpProtocol)
            {
                case FtpProtocol.FTP:
                    sessionOptions.Protocol = Protocol.Ftp;
                    sessionOptions.PortNumber = 21;
                    return sessionOptions;

                case FtpProtocol.SFTP:
                    sessionOptions.Protocol = Protocol.Sftp;
                    sessionOptions.PortNumber = 22;
                    return sessionOptions;

                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}
