using AutoMapper;
using PromactManagement.DomainModel.Models.CompanyRegistration;
using PromactManagement.DomainModel.Models.OrganizationModuleRegistration;
using PromactManagement.DomainModel.ApplicationClass.DTO.CompanyRegistrationDTO;
using PromactManagement.DomainModel.ApplicationClass.DTO.OrganizationListDTO;
using PromactManagement.DomainModel.ApplicationClass.DTO.OrganizationModuleDTO;

namespace PromactManagement.DomainModel.ApplicationClass.Mapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()      
        {
            CreateMap<OrganizationDTO, OrganizationModel>().ReverseMap();
            CreateMap<OrganizationModel, OrganizationDTO>().ReverseMap();
            CreateMap<OrganizationListDTO, OrganizationModel>().ReverseMap();
            CreateMap<OrganizationModel, OrganizationListDTO>().ReverseMap();
            CreateMap<CompanyDTO, CompanyModelRegistration>().ReverseMap();
            CreateMap<CompanyModelRegistration, CompanyDTO>().ReverseMap();
        }
    }
}
