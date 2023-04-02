using PromactManagement.DomainModel.Models.OrganizationModuleRagistration;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PromactManagement.DomainModel.Models.CompanyModuleRagistration
{
    public class CompanyModelRegistration
    {
        [Key]
        public int ComapnyId { get; set; }
        public string CompanyName { get; set; }
        public string CompanyOwner { get; set; }

        [ForeignKey("OrganizationId")]
        public int OrganizationId { get; set; }
        public virtual OrganizationModel OrganizationModule { get; set; }

        public string PartnerLevel { get; set; }

        public bool CompanyStatus { get; set; }

        public DateTime CompanyCreateDate { get; set; }

        public string Notes { get; set; }
        public string website { get; set; }

        public string URLLinke { get; set; }




    }
}

