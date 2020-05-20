using Abp.Domain.Repositories;
using Abp.Domain.Services;
using Hangfire;

namespace DataSolutions.TransactionExchangeCentre.Features.Uploading
{
    public interface IChannelUploadScheduler : IDomainService
    {
        void AddOrUpdate(Channel channel);
        void Disable(Channel channel);
    }

    public class ChannelUploadScheduler : DomainService, IChannelUploadScheduler
    {
        private readonly IRepository<Channel> _channelRepository;

        public ChannelUploadScheduler(IRepository<Channel> channelRepository)
        {
            _channelRepository = channelRepository;
        }

        public void AddOrUpdate(Channel channel)
        {
            var args = ChannelUploadJobArgs.FromChannel(channel);
            RecurringJob.AddOrUpdate(channel.Id.ToString(),
                () => new ChannelUploadJob(_channelRepository).Execute(args),
                channel.GetCron);
        }

        public void Disable(Channel channel)
        {
            RecurringJob.RemoveIfExists(channel.Id.ToString());
        }
    }
}
