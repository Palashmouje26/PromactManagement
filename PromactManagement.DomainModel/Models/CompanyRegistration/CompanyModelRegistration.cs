using PromactManagement.DomainModel.Models.OrganizationModuleRegistration;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PromactManagement.DomainModel.Models.CompanyRegistration
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


        [RegularExpression(@"\b[A-Za-z0-9._%-]+@(live\.wcs\.ac\.uk)\b")]
        public string website { get; set; }

        [RegularExpression(@"^(www.|[a-zA-Z].)[a-zA-Z0-9\-\.]+\.(com|edu|gov|mil|net|org|biz|info|name|museum|us|ca|uk)(\:[0-9]+)*(/($|[a-zA-Z0-9\.\,\;\?\'\\\+&amp;%\$#\=~_\-]+))*$")]
        public string URLLinke { get; set; }

    }
}

