using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PromactManagement.DomainModel.ApplicationClass.DTO.OrganizationListDTO
{
    public class OrganizationListDTO
    {
        public int OrganizationId { get; set; }

        public string OrganizationName { get; set; }

        public string OrganizationOwnerEmailId { get; set; }

        public string PartnerLevel { get; set; }

        public int ActiveCompany { get; set; }
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
