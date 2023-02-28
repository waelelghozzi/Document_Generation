using AutoMapper;

namespace Generation_Documents.Profiles
{
    public class SalesInvoiceProfile : Profile
    {
        public SalesInvoiceProfile() 
        {
            CreateMap<Entities.SalesInvoice, Models.SalesInvoiceDTO>();
            CreateMap<Models.SalesInvoiceDTO, Entities.SalesInvoice>();
        }
  
    }
}
