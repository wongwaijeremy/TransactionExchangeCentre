using System;
using Hangfire;

namespace DataSolutions.TransactionExchangeCentre.Features
{
    public partial class Channel
    {
        public UploadIntervalOption UploadIntervalOption { get; set; }
        public int IntervalValue { get; set; }
        public DateTime? OnExactDayTime { get; set; }


        public bool DoesNotChangeByInput(UploadIntervalOption uploadIntervalOption,
            int intervalValue, DateTime? onExactDayTime)
        {
            return UploadIntervalOption == uploadIntervalOption
                   && IntervalValue == intervalValue
                   && OnExactDayTime == onExactDayTime;
        }

        public string GetCron()
        {
            switch (UploadIntervalOption)
            {
                case UploadIntervalOption.Instantly:
                    return Cron.Minutely();
                case UploadIntervalOption.InMinutes:
                    return Cron.MinuteInterval(IntervalValue);
                case UploadIntervalOption.InHours:
                    return Cron.HourInterval(IntervalValue);
                case UploadIntervalOption.InDays:
                    if (!OnExactDayTime.HasValue)
                        throw new ArgumentOutOfRangeException();
                    int minute = OnExactDayTime.Value.Minute;
                    int hour = OnExactDayTime.Value.Hour;
                    return $"{minute} {hour} */{IntervalValue} * *";
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}
