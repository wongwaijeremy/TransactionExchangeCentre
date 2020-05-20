namespace DataSolutions.TransactionExchangeCentre.BackendProcess
{
    public class WinScpConnectionError : Core.Error
    {
        public override string Description { get; } = "WinSCP Connection error";
        public override string Message { get; }

        public WinScpConnectionError(string exMsg)
        {
            Message = exMsg;
        }
    }

    public class WinScpUploadError : Core.Error
    {
        public override string Description { get; } = "WinSCP Upload error";
        public override string Message { get; }

        public WinScpUploadError(string exMsg)
        {
            Message = exMsg;
        }
    }
}
