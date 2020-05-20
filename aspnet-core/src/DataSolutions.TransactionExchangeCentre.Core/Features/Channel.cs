using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Abp.Timing;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataSolutions.TransactionExchangeCentre.Features
{
    [Table("Channels")]
    public partial class Channel : Entity, IHasCreationTime
    {
        private const int MaxNameLength = 256;
        
        public bool Enable { get; set; }
        [Required]
        public DataDirectionType DataDirection { get; set; }
        [Required]
        public DocumentType DocumentType { get; set; }
        
        [ForeignKey(nameof(Customer))]
        [Required]
        public int CustomerId { get; set; }
        public virtual Customer Customer { get; set; }
        
        public DateTime CreationTime { get; set; }
        
        public Channel()
        {
            CreationTime = Clock.Now;
            Enable = false;
            ConnectionStatus = ConnectionStatus.Inactivated;
            FtpProtocol = FtpProtocol.FTP;
            UploadIntervalOption = UploadIntervalOption.Instantly;
            OnExactDayTime = null;
        }
    }
}
