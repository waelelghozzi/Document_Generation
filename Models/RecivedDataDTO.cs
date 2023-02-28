using System.ComponentModel.DataAnnotations;

namespace Generation_Documents.Models
{
    public class RecivedDataDTO
    {
        [Required]
        [MaxLength(50)]
        public string ClientName { get; set; }

        [Required]
        [MaxLength(100)]
        public string ClientAdress { get; set; }

        public double Total { get; set; }

        public double TVA_BTW {get; set;}


        // We don't have an idea of the data structure that's why we can't create the rest of the attributes.
        // Using DTOs and entities is more beneficial than transferring the data directly to the pdf because
        // we have understood the data flow and the different entities and what every piece of data belongs to,
        // that makes the maintenance easier
    }
}
