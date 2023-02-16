﻿// <auto-generated />
using System;
using JellyFish.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace JellyFish.Migrations
{
    [DbContext(typeof(JellyFishDbContext))]
    [Migration("20230216183008_initial")]
    partial class initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("AspNetUserRole", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex(new[] { "RoleId" }, "IX_AspNetUserRoles_RoleId");

                    b.ToTable("AspNetUserRole");
                });

            modelBuilder.Entity("JellyFish.Models.Address", b =>
                {
                    b.Property<int>("AddressId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("address_id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AddressId"));

                    b.Property<string>("City")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("city");

                    b.Property<string>("PostalCode")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("postal_code");

                    b.Property<string>("Province")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("province");

                    b.Property<string>("Street")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("street");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasMaxLength(450)
                        .HasColumnType("nvarchar(450)")
                        .HasColumnName("user_id");

                    b.HasKey("AddressId")
                        .HasName("PK__Address__CAA247C8C3879F02");

                    b.HasIndex("UserId");

                    b.ToTable("Address", (string)null);
                });

            modelBuilder.Entity("JellyFish.Models.Applicant", b =>
                {
                    b.Property<int>("ApplicantId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("applicant_id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ApplicantId"));

                    b.Property<int>("JobId")
                        .HasColumnType("int")
                        .HasColumnName("job_id");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasMaxLength(450)
                        .HasColumnType("nvarchar(450)")
                        .HasColumnName("user_id");

                    b.HasKey("ApplicantId")
                        .HasName("PK__Applican__F49C60C1E1297E3A");

                    b.HasIndex("JobId");

                    b.HasIndex("UserId");

                    b.ToTable("Applicant", (string)null);
                });

            modelBuilder.Entity("JellyFish.Models.AspNetRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "NormalizedName" }, "RoleNameIndex")
                        .IsUnique()
                        .HasFilter("([NormalizedName] IS NOT NULL)");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("JellyFish.Models.AspNetRoleClaim", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "RoleId" }, "IX_AspNetRoleClaims_RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("JellyFish.Models.AspNetUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("DateOfBirth")
                        .HasColumnType("date");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FirstName")
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.Property<string>("HomeAddress")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("LastName")
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ShippingAddress")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "NormalizedEmail" }, "EmailIndex");

                    b.HasIndex(new[] { "NormalizedUserName" }, "UserNameIndex")
                        .IsUnique()
                        .HasFilter("([NormalizedUserName] IS NOT NULL)");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("JellyFish.Models.AspNetUserClaim", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "UserId" }, "IX_AspNetUserClaims_UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("JellyFish.Models.AspNetUserLogin", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex(new[] { "UserId" }, "IX_AspNetUserLogins_UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("JellyFish.Models.AspNetUserToken", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("JellyFish.Models.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("category_id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CategoryId"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("name");

                    b.HasKey("CategoryId")
                        .HasName("PK__Category__D54EE9B4CA2129B2");

                    b.ToTable("Category", (string)null);
                });

            modelBuilder.Entity("JellyFish.Models.Company", b =>
                {
                    b.Property<int>("CompanyId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("company_id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CompanyId"));

                    b.Property<string>("EmployerId")
                        .IsRequired()
                        .HasMaxLength(450)
                        .HasColumnType("nvarchar(450)")
                        .HasColumnName("employer_id");

                    b.Property<int?>("Name")
                        .HasColumnType("int")
                        .HasColumnName("name");

                    b.Property<int?>("Url")
                        .HasColumnType("int")
                        .HasColumnName("url");

                    b.HasKey("CompanyId")
                        .HasName("PK__Company__3E267235C3F3083A");

                    b.HasIndex("EmployerId");

                    b.ToTable("Company", (string)null);
                });

            modelBuilder.Entity("JellyFish.Models.Employer", b =>
                {
                    b.Property<string>("EmployerId")
                        .HasColumnType("nvarchar(450)")
                        .HasColumnName("employer_id");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("title");

                    b.HasKey("EmployerId")
                        .HasName("PK__Employer__365FA4E7BC36C176");

                    b.ToTable("Employer", (string)null);
                });

            modelBuilder.Entity("JellyFish.Models.Job", b =>
                {
                    b.Property<int>("JobId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("job_id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("JobId"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("description");

                    b.Property<int>("JobCategoryId")
                        .HasColumnType("int")
                        .HasColumnName("job_category_id");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("title");

                    b.HasKey("JobId")
                        .HasName("PK__Job__6E32B6A5B726C77F");

                    b.ToTable("Job", (string)null);
                });

            modelBuilder.Entity("JellyFish.Models.JobCategory", b =>
                {
                    b.Property<int>("JobCategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("job_category_id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("JobCategoryId"));

                    b.Property<int>("CategoryId")
                        .HasColumnType("int")
                        .HasColumnName("category_id");

                    b.Property<int>("JobId")
                        .HasColumnType("int")
                        .HasColumnName("job_id");

                    b.HasKey("JobCategoryId")
                        .HasName("PK__JobCateg__73D531883C88A373");

                    b.HasIndex("CategoryId");

                    b.HasIndex("JobId");

                    b.ToTable("JobCategory", (string)null);
                });

            modelBuilder.Entity("JellyFish.Models.Skill", b =>
                {
                    b.Property<int>("SkillId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("skill_id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SkillId"));

                    b.Property<string>("Name")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("name");

                    b.HasKey("SkillId")
                        .HasName("PK__Skill__FBBA83797F5E5BAF");

                    b.ToTable("Skill", (string)null);
                });

            modelBuilder.Entity("JellyFish.Models.UserSkill", b =>
                {
                    b.Property<int>("UserSkillId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("user_skill_id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserSkillId"));

                    b.Property<int>("SkillId")
                        .HasColumnType("int")
                        .HasColumnName("skill_id");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasMaxLength(450)
                        .HasColumnType("nvarchar(450)")
                        .HasColumnName("user_id");

                    b.HasKey("UserSkillId")
                        .HasName("PK__UserSkil__FD3B576B9169385A");

                    b.HasIndex("SkillId");

                    b.HasIndex("UserId");

                    b.ToTable("UserSkill", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NormalizedName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("IdentityRole");

                    b.HasData(
                        new
                        {
                            Id = "919d93a8-3810-4ee4-8b51-a6b0a1605508",
                            ConcurrencyStamp = "616b1ad0-7587-4443-a579-2deaf0ebf4ba",
                            Name = "Administrator",
                            NormalizedName = "ADMINISTRATOR"
                        },
                        new
                        {
                            Id = "919d93a8-3810-4ee4-8b51-a6b0a1605509",
                            ConcurrencyStamp = "5949a622-def7-4f4b-9277-fba1930fb6bf",
                            Name = "JobSeeker",
                            NormalizedName = "JOBSEEKER"
                        },
                        new
                        {
                            Id = "919d93a8-3810-4ee4-8b51-a6b0a1605510",
                            ConcurrencyStamp = "3d1ddc00-dcc4-492f-aec7-f1a71635972c",
                            Name = "Employer",
                            NormalizedName = "EMPLOYER"
                        });
                });

            modelBuilder.Entity("AspNetUserRole", b =>
                {
                    b.HasOne("JellyFish.Models.AspNetRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("JellyFish.Models.AspNetUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("JellyFish.Models.Address", b =>
                {
                    b.HasOne("JellyFish.Models.AspNetUser", "User")
                        .WithMany("Addresses")
                        .HasForeignKey("UserId")
                        .IsRequired()
                        .HasConstraintName("FKAddress726313");

                    b.Navigation("User");
                });

            modelBuilder.Entity("JellyFish.Models.Applicant", b =>
                {
                    b.HasOne("JellyFish.Models.Job", "Job")
                        .WithMany("Applicants")
                        .HasForeignKey("JobId")
                        .IsRequired()
                        .HasConstraintName("FKApplicant506596");

                    b.HasOne("JellyFish.Models.AspNetUser", "User")
                        .WithMany("Applicants")
                        .HasForeignKey("UserId")
                        .IsRequired()
                        .HasConstraintName("FKApplicant720822");

                    b.Navigation("Job");

                    b.Navigation("User");
                });

            modelBuilder.Entity("JellyFish.Models.AspNetRoleClaim", b =>
                {
                    b.HasOne("JellyFish.Models.AspNetRole", "Role")
                        .WithMany("AspNetRoleClaims")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");
                });

            modelBuilder.Entity("JellyFish.Models.AspNetUserClaim", b =>
                {
                    b.HasOne("JellyFish.Models.AspNetUser", "User")
                        .WithMany("AspNetUserClaims")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("JellyFish.Models.AspNetUserLogin", b =>
                {
                    b.HasOne("JellyFish.Models.AspNetUser", "User")
                        .WithMany("AspNetUserLogins")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("JellyFish.Models.AspNetUserToken", b =>
                {
                    b.HasOne("JellyFish.Models.AspNetUser", "User")
                        .WithMany("AspNetUserTokens")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("JellyFish.Models.Company", b =>
                {
                    b.HasOne("JellyFish.Models.Employer", "Employer")
                        .WithMany("Companies")
                        .HasForeignKey("EmployerId")
                        .IsRequired()
                        .HasConstraintName("FKCompany237877");

                    b.Navigation("Employer");
                });

            modelBuilder.Entity("JellyFish.Models.Employer", b =>
                {
                    b.HasOne("JellyFish.Models.AspNetUser", "EmployerNavigation")
                        .WithOne("Employer")
                        .HasForeignKey("JellyFish.Models.Employer", "EmployerId")
                        .IsRequired()
                        .HasConstraintName("FKEmployer37240");

                    b.Navigation("EmployerNavigation");
                });

            modelBuilder.Entity("JellyFish.Models.JobCategory", b =>
                {
                    b.HasOne("JellyFish.Models.Category", "Category")
                        .WithMany("JobCategories")
                        .HasForeignKey("CategoryId")
                        .IsRequired()
                        .HasConstraintName("FKJobCategor418821");

                    b.HasOne("JellyFish.Models.Job", "Job")
                        .WithMany("JobCategories")
                        .HasForeignKey("JobId")
                        .IsRequired()
                        .HasConstraintName("FKJobCategor238289");

                    b.Navigation("Category");

                    b.Navigation("Job");
                });

            modelBuilder.Entity("JellyFish.Models.UserSkill", b =>
                {
                    b.HasOne("JellyFish.Models.Skill", "Skill")
                        .WithMany("UserSkills")
                        .HasForeignKey("SkillId")
                        .IsRequired()
                        .HasConstraintName("FKUserSkill942971");

                    b.HasOne("JellyFish.Models.AspNetUser", "User")
                        .WithMany("UserSkills")
                        .HasForeignKey("UserId")
                        .IsRequired()
                        .HasConstraintName("FKUserSkill459199");

                    b.Navigation("Skill");

                    b.Navigation("User");
                });

            modelBuilder.Entity("JellyFish.Models.AspNetRole", b =>
                {
                    b.Navigation("AspNetRoleClaims");
                });

            modelBuilder.Entity("JellyFish.Models.AspNetUser", b =>
                {
                    b.Navigation("Addresses");

                    b.Navigation("Applicants");

                    b.Navigation("AspNetUserClaims");

                    b.Navigation("AspNetUserLogins");

                    b.Navigation("AspNetUserTokens");

                    b.Navigation("Employer");

                    b.Navigation("UserSkills");
                });

            modelBuilder.Entity("JellyFish.Models.Category", b =>
                {
                    b.Navigation("JobCategories");
                });

            modelBuilder.Entity("JellyFish.Models.Employer", b =>
                {
                    b.Navigation("Companies");
                });

            modelBuilder.Entity("JellyFish.Models.Job", b =>
                {
                    b.Navigation("Applicants");

                    b.Navigation("JobCategories");
                });

            modelBuilder.Entity("JellyFish.Models.Skill", b =>
                {
                    b.Navigation("UserSkills");
                });
#pragma warning restore 612, 618
        }
    }
}
