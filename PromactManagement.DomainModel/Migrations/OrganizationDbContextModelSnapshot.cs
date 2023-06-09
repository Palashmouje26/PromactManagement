﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PromactManagement.DomainModel.DbContexts;

namespace PromactManagement.DomainModel.Migrations
{
    [DbContext(typeof(OrganizationDbContext))]
    partial class OrganizationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("PromactManagement.DomainModel.Models.CompanyModuleRagistration.CompanyModelRegistration", b =>
                {
                    b.Property<int>("ComapnyId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CompanyCreateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("CompanyName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CompanyOwner")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("CompanyStatus")
                        .HasColumnType("bit");

                    b.Property<string>("Notes")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("OrganizationId")
                        .HasColumnType("int");

                    b.Property<int?>("OrganizationModuleOrganizationId")
                        .HasColumnType("int");

                    b.Property<string>("PartnerLevel")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("URLLinke")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("website")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ComapnyId");

                    b.HasIndex("OrganizationModuleOrganizationId");

                    b.ToTable("companyModules");
                });

            modelBuilder.Entity("PromactManagement.DomainModel.Models.OrganizationModuleRagistration.OrganizationModel", b =>
                {
                    b.Property<int>("OrganizationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AUAOverride")
                        .HasColumnType("nvarchar(6)")
                        .HasMaxLength(6);

                    b.Property<int>("ActiveCompany")
                        .HasColumnType("int");

                    b.Property<DateTime>("ActiveSince")
                        .HasColumnType("date");

                    b.Property<string>("CostsLastQuarter")
                        .HasColumnType("nvarchar(9)")
                        .HasMaxLength(9);

                    b.Property<string>("Notes")
                        .HasColumnType("nvarchar(500)")
                        .HasMaxLength(500);

                    b.Property<string>("OrganizationName")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("OrganizationOwnerEmailId")
                        .IsRequired()
                        .HasColumnType("nvarchar(200)")
                        .HasMaxLength(200);

                    b.Property<bool>("OrganizationStatus")
                        .HasColumnType("bit");

                    b.Property<int>("OrganizationType")
                        .HasColumnType("int");

                    b.Property<int>("PartnerLevel")
                        .HasColumnType("int");

                    b.Property<int>("Partnersince")
                        .HasColumnType("int");

                    b.Property<bool>("UseOverrides")
                        .HasColumnType("bit");

                    b.Property<string>("VCOverride")
                        .HasColumnType("nvarchar(6)")
                        .HasMaxLength(6);

                    b.HasKey("OrganizationId");

                    b.ToTable("organizationModules");
                });

            modelBuilder.Entity("PromactManagement.DomainModel.Models.CompanyModuleRagistration.CompanyModelRegistration", b =>
                {
                    b.HasOne("PromactManagement.DomainModel.Models.OrganizationModuleRagistration.OrganizationModel", "OrganizationModule")
                        .WithMany()
                        .HasForeignKey("OrganizationModuleOrganizationId");
                });
#pragma warning restore 612, 618
        }
    }
}
