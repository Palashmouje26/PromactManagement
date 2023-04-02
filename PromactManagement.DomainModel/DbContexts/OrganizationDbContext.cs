using Microsoft.EntityFrameworkCore;
using PromactManagement.DomainModel.Models.CompanyModuleRagistration;
using PromactManagement.DomainModel.Models.OrganizationModuleRagistration;

namespace PromactManagement.DomainModel.DbContexts
{
    public class OrganizationDbContext : DbContext
    {
        public OrganizationDbContext(DbContextOptions<OrganizationDbContext> options) : base(options)
        {

        }
        public DbSet<OrganizationModel> organizationModules { get; set; }
        public DbSet<CompanyModelRegistration> companyModules { get; set; }
    }
}
