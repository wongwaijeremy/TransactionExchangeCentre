using System.ComponentModel.DataAnnotations;

namespace DataSolutions.TransactionExchangeCentre.Users.Dto
{
    public class ChangeUserLanguageDto
    {
        [Required]
        public string LanguageName { get; set; }
    }
}