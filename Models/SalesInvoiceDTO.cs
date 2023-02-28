namespace Generation_Documents.Models
{
    public class SalesInvoiceDTO
    {
        public int IdSales { get; set; }
        public ClientDTO Client { get; set; }


        public int NumOfSuppliers
        {
            get
            {
                return Suppliers.Count;
            }
        }
        public int NumOfServices
        {
            get
            {
                return Services.Count;
            }
        }
        public ICollection<SupplierDTO> Suppliers { get; set; }

        public ICollection<ServiceDTO> Services { get; set; }

        public ICollection<AdditionalFeeDTO> Fees { get; set; }
        public SalesInvoiceDTO(ClientAddDTO client)
        {
           
        }
    }

}
