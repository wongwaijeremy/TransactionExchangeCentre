using DataSolutions.Core;

namespace DataSolutions.TransactionExchangeCentre.BackendProcess
{
    public interface ITradelinkUploader
    {
        Result<UploadReportModel> Upload(UploadChannel uploadChannel);
    }
}
