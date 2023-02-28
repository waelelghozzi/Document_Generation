using AutoMapper;
using Generation_Documents.Models;

namespace Generation_Documents.Profiles
{
    public class SupplierProfile : Profile
    {
        public SupplierProfile()
        {
            CreateMap<Entities.Supplier, Models.RecivedDataDTO>();
        }
    }
}
