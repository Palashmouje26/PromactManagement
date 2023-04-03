using AutoMapper;
using PromactManagement.DomainModel.Models.CompanyRegistration;
using PromactManagement.DomainModel.Models.OrganizationListDto;
using PromactManagement.DomainModel.Models.OrganizationModuleDetail;
using PromactManagement.DomainModel.Models.OrganizationModuleRegistration;
using PromactManagement.DomainModel.Models.CompanyRegistrationDTO;

namespace PromactManagement.DomainModel.ApplicationClass.Mapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()      
        {
            CreateMap<OrganizationModelDto, OrganizationModel>().ReverseMap();
            CreateMap<OrganizationModel, OrganizationModelDto>().ReverseMap();
            CreateMap<OrganizationListDto, OrganizationModel>().ReverseMap();
            CreateMap<OrganizationModel, OrganizationListDto>().ReverseMap();
            CreateMap<CompanyModelDTO, CompanyModelRegistration>().ReverseMap();
            CreateMap<CompanyModelRegistration, CompanyModelDTO>().ReverseMap();
        }
    }
}
