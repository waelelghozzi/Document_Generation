using System.ComponentModel.DataAnnotations;

namespace Generation_Documents.Models
{
    public class ClientAddDTO
    {
        [Required]
        [MaxLength(50)]
        public string ClientName { get; set; }

        [Required]
        [MaxLength(100)]
        public string ClientAdress { get; set; }
    }
}
