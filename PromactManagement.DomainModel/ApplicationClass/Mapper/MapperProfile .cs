using AutoMapper;
using PromactManagement.DomainModel.Models.CompanyModuleRagistration;
using PromactManagement.DomainModel.Models.CompanyRagistrationDto;
using PromactManagement.DomainModel.Models.OrganizationListDto;
using PromactManagement.DomainModel.Models.OrganizationModuleDetail;
using PromactManagement.DomainModel.Models.OrganizationModuleRagistration;
using System;
using System.Collections.Generic;
using System.Text;

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
            CreateMap<CompanyModelDto, CompanyModelRagistration>().ReverseMap();
            CreateMap<CompanyModelRagistration, CompanyModelDto>().ReverseMap();
        }
    }
}
