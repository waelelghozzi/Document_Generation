using Generation_Documents.Entities;

namespace Generation_Documents.Models
{
    public class SupplierDTO
    {
        public int IdSupplier { get; set; }
        public string SupplierName { get; set; }
        public string SupplierAdress { get; set; }

        public IEnumerable<Service> services { get; set; } = new List<Service>();


    }
}
