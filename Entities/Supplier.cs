using Newtonsoft.Json.Linq;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Generation_Documents.Entities
{
    public class Supplier
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdSupplier { get; set; }

        [Required]
        public string SupplierName { get; set; }

        [Required]
        public string SupplierAdress { get; set; }

        [ForeignKey("IdClient")]
        public Client? client { get; set; }
        public int IdClient { get; set; }

        public ICollection<Service> services { get; set; }
            = new List<Service>();

    }
}
