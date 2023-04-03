﻿using AutoMapper;
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
            CreateMap<OrganizationModelDto, OrganizationModel>().ReverseMap();
            CreateMap<OrganizationModel, OrganizationModelDto>().ReverseMap();
            CreateMap<OrganizationListDto, OrganizationModel>().ReverseMap();
            CreateMap<OrganizationModel, OrganizationListDto>().ReverseMap();
            CreateMap<CompanyModelDTO, CompanyModelRegistration>().ReverseMap();
            CreateMap<CompanyModelRegistration, CompanyModelDTO>().ReverseMap();
        }
    }
}
