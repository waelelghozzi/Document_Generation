using AutoMapper;
using Generation_Documents.Models;

namespace Generation_Documents.Profiles
{
    public class ClientProfile : Profile
    {
        public ClientProfile()
        {
            CreateMap<Entities.Client, Models.ClientAddDTO>();
            CreateMap<Models.ClientAddDTO, Entities.Client>();

            CreateMap<Entities.Client, Models.ClientDTO>();
            CreateMap<Models.ClientDTO, Entities.Client>(); 

                
            CreateMap<Entities.Client, Models.RecivedDataDTO>();
        }
    }
}
