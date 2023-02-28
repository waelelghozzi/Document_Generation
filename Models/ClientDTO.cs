namespace Generation_Documents.Models
{
    public class ClientDTO
    {
        public int IdClient { get; set; }
        public string ClientName { get; set; }
        public string ClientAdress { get; set; }

        public int NumOfSuppliers
        {
            get
            {
                return suppliers.Count;
            }
        }
        public ICollection<SupplierDTO> suppliers { get; set; } = new List<SupplierDTO>();
    }
}
