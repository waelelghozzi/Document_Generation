using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Generation_Documents.Entities
{
    public class Client
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdClient { get; set; }

        [Required]
        [StringLength(50)]
        public string ClientName { get; set; }

        [Required]
        [StringLength(250)]
        public string ClientAdress { get; set; }

        public ICollection<Supplier> suppliers { get; set; }
           = new List<Supplier>();
        public Client(string CN, string CA) 
        {
            ClientName = CN;
            ClientAdress = CA;
        }
    }
}
