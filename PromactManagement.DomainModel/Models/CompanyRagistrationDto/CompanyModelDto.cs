using PromactManagement.DomainModel.Enum;
using PromactManagement.DomainModel.Models.OrganizationModuleRagistration;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PromactManagement.DomainModel.Models.CompanyRagistrationDto
{
    public  class CompanyModelDto
    {

        public int ComapnyId { get; set; }
        public string CompanyName { get; set; }
        public string CompanyOwner { get; set; }
        public int OrganizationId { get; set; }

        public PartnerLevelType PartnerLevel { get; set; }
        public bool CompanyStatus { get; set; }

        public DateTime CompanyCreateDate { get; set; }

        public string Notes { get; set; }
        public string website { get; set; }

        public string URLLinke { get; set; }
    }
}
