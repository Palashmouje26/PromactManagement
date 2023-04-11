using PromactManagement.DomainModel.Enum;
using System;

namespace PromactManagement.DomainModel.ApplicationClass.DTO.CompanyRegistrationDTO
{
    public class CompanyDTO
    {

        public int ComapnyId { get; set; }
        public string CompanyName { get; set; }
        public string CompanyOwner { get; set; }

        public int OrganizationId { get; set; }

        public string PartnerLevel { get; set; }
        public bool CompanyStatus { get; set; }

        public DateTime CompanyCreateDate { get; set; }

        public string Notes { get; set; }
        public string website { get; set; }

        public string URLLinke { get; set; }
    }
}
