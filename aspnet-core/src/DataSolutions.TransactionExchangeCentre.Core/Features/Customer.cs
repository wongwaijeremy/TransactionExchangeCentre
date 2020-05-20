using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Abp.Timing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataSolutions.TransactionExchangeCentre.Features
{
    [Table("Customers")]
    public class Customer : Entity, IHasCreationTime
    {
        private const int MaxNameLength = 256;
        private const int MaxShortCodeLength = 16;

        [Required]
        [MaxLength(MaxNameLength)]
        public string Name { get; set; }

        [Required]
        [MaxLength(MaxShortCodeLength)]
        public string ShortCode { get; set; }

        [Required]
        public CustomerRoleType CustomerRole { get; set; }

        public DateTime CreationTime { get; set; }

        public virtual ICollection<Channel> Channels { get; set; }

        public Customer()
        {
            CreationTime = Clock.Now;
        }

        public Customer(string name, string shortCode)
            : this()
        {
            Name = name;
            ShortCode = shortCode;
        }
    }
}
