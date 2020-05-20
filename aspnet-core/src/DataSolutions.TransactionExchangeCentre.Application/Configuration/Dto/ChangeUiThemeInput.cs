using System.ComponentModel.DataAnnotations;

namespace DataSolutions.TransactionExchangeCentre.Configuration.Dto
{
    public class ChangeUiThemeInput
    {
        [Required]
        [StringLength(32)]
        public string Theme { get; set; }
    }
}
