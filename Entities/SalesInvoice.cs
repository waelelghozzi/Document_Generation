using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
using System;
using Generation_Documents.Models;

namespace Generation_Documents.Entities
{
    public class SalesInvoice
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdSales { get; set; }

        public ICollection<Supplier> Suppliers { get; set; } = new List<Supplier>();
        public ICollection<Service> Services { get; set; } = new List<Service>();
        public ICollection<AdditionalFee> Fees { get; set; } = new List<AdditionalFee>();

        [ForeignKey("ClientID")]
        public Client? Client { get; set; }
        public int ClientID { get; set; }

        public SalesInvoice(Client C) 
        {
            Client = C;
        }

    }
}






