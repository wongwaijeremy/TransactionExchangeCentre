using System;
using System.IO;
using Abp.BackgroundJobs;
using Abp.Dependency;
using Abp.Domain.Repositories;
using Abp.Domain.Uow;
using Abp.Json;
using Hangfire;

namespace DataSolutions.TransactionExchangeCentre.Features.Uploading
{
    public class ChannelUploadJob : BackgroundJob<ChannelUploadJobArgs>, ITransientDependency
    {
        private readonly IRepository<Channel> _channelRepository;

        public ChannelUploadJob(IRepository<Channel> channelRepository)
        {
            _channelRepository = channelRepository;
        }

        [UnitOfWork]
        [AutomaticRetry(Attempts = 1)]
        public override void Execute(ChannelUploadJobArgs args)
        {
            var channel = _channelRepository.Get(args.ChannelId);
            //JsonSerializationHelper.SerializeWithType
            //TODO
        }

        
    }

    [Serializable]
    public class ChannelUploadJobArgs
    {
        public int ChannelId { get; set; }

        public ChannelUploadJobArgs()
        {
        }

        public static ChannelUploadJobArgs FromChannel(Channel channel)
        {
            var args = new ChannelUploadJobArgs()
            {
                ChannelId = channel.Id
            };
            return args;
        }
    }
}
