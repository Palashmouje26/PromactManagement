﻿using PromactManagement.DomainModel.Enum;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PromactManagement.DomainModel.Models.OrganizationModuleDetail
{
    public class OrganizationModelDto
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
        public PartnerLevelType PartnerLevel { get; set; }

        
        public bool OrganizationStatus { get; set; }
        public OrganizationType OrganizationType { get; set; }


        [RegularExpression(@"^([0-9]{4})$", ErrorMessage = "please enter in year formate")]
        public int Partnersince { get; set; }


        public bool UseOverrides { get; set; }

       // [RegularExpression(@"^([0-9]{6})$", ErrorMessage = "please enter in year formate")]
        public string AUAOverride { get; set; }
        public string VCOverride { get; set; }
        public string CostsLastQuarter { get; set; }
        [Column(TypeName = "date")]
        public DateTime ActiveSince { get; set; }

        [MaxLength(500)]
        [RegularExpression(@"^[a-zA-Z''-'\s]{1,500}$", ErrorMessage = "Characters are not allowed.")]
        public string Notes { get; set; }

    }
}
