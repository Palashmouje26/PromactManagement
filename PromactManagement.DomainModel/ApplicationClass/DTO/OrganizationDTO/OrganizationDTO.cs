using PromactManagement.DomainModel.Enum;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PromactManagement.DomainModel.ApplicationClass.DTO.OrganizationModuleDTO
{
    public class OrganizationDTO
    {
        public int OrganizationId { get; set; }

        public string OrganizationName { get; set; }

        public string OrganizationOwnerEmailId { get; set; }

        public string PartnerLevel { get; set; }

        public bool OrganizationStatus { get; set; }

        public string OrganizationType { get; set; }

        public int PartnerSince { get; set; }

        public bool UseOverrides { get; set; }

        public string AUAOverride { get; set; }

        public string VCOverride { get; set; }

        public string CostsLastQuarter { get; set; }

        public DateTime ActiveSince { get; set; }

        public string Notes { get; set; }

    }
}
