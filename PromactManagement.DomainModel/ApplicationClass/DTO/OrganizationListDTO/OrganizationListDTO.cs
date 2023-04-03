using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PromactManagement.DomainModel.ApplicationClass.DTO.OrganizationListDTO
{
    public class OrganizationListDto
    {
        public int OrganizationId { get; set; }

        [Required]
        [MaxLength(100)]
        [RegularExpression(@"^[a-zA-Z''-'\s]{1,100}$", ErrorMessage = "Characters are not allowed.")]
        public string OrganizationName { get; set; }

        [Required]
        [MaxLength(200)]
        [RegularExpression(@"^([a-zA-Z0-9_\.\-])+\@(([a-zA-Z0-9\-])+\.)+([a-zA-Z0-9]{2,4})+$", ErrorMessage = "Invalid Email Address")]
        public string OrganizationOwnerEmailId { get; set; }

        [Required]
        public string PartnerLevel { get; set; }

        public int ActiveCompany { get; set; }
        public bool OrganizationStatus { get; set; }
        public string OrganizationType { get; set; }


        [RegularExpression(@"^\([0-9]{4})$", ErrorMessage = "please enter in year format")]
        public int PartnerSince { get; set; }


        public bool UseOverrides { get; set; }
        public string AUAOverride { get; set; }
        public string VCOverride { get; set; }
        public string CostsLastQuarter { get; set; }

        [DataType(DataType.Date)]
        public DateTime ActiveSince { get; set; }

        [MaxLength(500)]
        [RegularExpression(@"^[a-zA-Z''-'\s]{1,500}$", ErrorMessage = "Characters are not allowed.")]
        public string Notes { get; set; }
    }
}
