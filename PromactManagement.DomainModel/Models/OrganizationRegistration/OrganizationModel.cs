using Microsoft.EntityFrameworkCore.Metadata.Internal;
using PromactManagement.DomainModel.Enum;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PromactManagement.DomainModel.Models.OrganizationModuleRegistration
{
    public class OrganizationModel 
    {
        [Key]
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
        public PartnerLevelType PartnerLevel { get; set; }

        public int ActiveCompany { get; set; }
        public bool OrganizationStatus { get; set; }
        public OrganizationType OrganizationType { get; set; }

        [RegularExpression(@"^\([0-9]{4})$", ErrorMessage = "please enter in year formate")]
        public int PartnerSince{ get; set; }

        public bool UseOverrides { get; set; }
        [RegularExpression(@"^\([0-9]{4})$", ErrorMessage = "please enter in year formate")]

        [MaxLength(6)]
        
        public string AUAOverride { get; set; }

        [MaxLength(6)]
        [RegularExpression(@"^\([1-9][0-9]*)$", ErrorMessage = "Count must be a natural number")]
        public string VCOverride { get; set; }

        [MaxLength(9)]
        public string CostsLastQuarter { get; set; }
        [Column(TypeName = "date")]
        public DateTime ActiveSince { get; set; }

        [MaxLength(500)]
        [RegularExpression(@"^[a-zA-Z''-'\s]{1,500}$", ErrorMessage = "Characters are not allowed.")]
        public string Notes { get; set; }



    }
}



