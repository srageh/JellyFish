using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace JellyFish.Models
{
	public partial class JellyFishDbContext : DbContext
	{
		public JellyFishDbContext()
		{
		}

		public JellyFishDbContext(DbContextOptions<JellyFishDbContext> options)
			: base(options)
		{
		}

		public virtual DbSet<Address> Addresses { get; set; } = null!;
		public virtual DbSet<Applicant> Applicants { get; set; } = null!;
		public virtual DbSet<AspNetRole> AspNetRoles { get; set; } = null!;
		public virtual DbSet<AspNetRoleClaim> AspNetRoleClaims { get; set; } = null!;
		public virtual DbSet<AspNetUser> AspNetUsers { get; set; } = null!;
		public virtual DbSet<AspNetUserClaim> AspNetUserClaims { get; set; } = null!;
		public virtual DbSet<AspNetUserLogin> AspNetUserLogins { get; set; } = null!;
		public virtual DbSet<AspNetUserToken> AspNetUserTokens { get; set; } = null!;
		public virtual DbSet<Category> Categories { get; set; } = null!;
		public virtual DbSet<Company> Companies { get; set; } = null!;
		public virtual DbSet<Employer> Employers { get; set; } = null!;
		public virtual DbSet<Job> Jobs { get; set; } = null!;
		public virtual DbSet<JobCategory> JobCategories { get; set; } = null!;
		public virtual DbSet<Skill> Skills { get; set; } = null!;
		public virtual DbSet<UserSkill> UserSkills { get; set; } = null!;

		/*protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			if (!optionsBuilder.IsConfigured)
			{
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
				optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS19;Database=JellyFishDB;Trusted_Connection=True;");
			}
		}
		*/
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Address>(entity =>
			{
				entity.ToTable("Address");

				entity.Property(e => e.AddressId).HasColumnName("address_id");

				entity.Property(e => e.City)
					.HasMaxLength(255)
					.HasColumnName("city");

				entity.Property(e => e.PostalCode)
					.HasMaxLength(255)
					.HasColumnName("postal_code");

				entity.Property(e => e.Province)
					.HasMaxLength(255)
					.HasColumnName("province");

				entity.Property(e => e.Street)
					.HasMaxLength(255)
					.HasColumnName("street");

				entity.Property(e => e.UserId)
					.HasMaxLength(450)
					.HasColumnName("user_id");

				entity.HasOne(d => d.User)
					.WithMany(p => p.Addresses)
					.HasForeignKey(d => d.UserId)
					.OnDelete(DeleteBehavior.ClientSetNull)
					.HasConstraintName("FKAddress726313");
			});

			modelBuilder.Entity<Applicant>(entity =>
			{
				entity.ToTable("Applicant");

				entity.Property(e => e.ApplicantId).HasColumnName("applicant_id");

				entity.Property(e => e.JobId).HasColumnName("job_id");

				entity.Property(e => e.UserId)
					.HasMaxLength(450)
					.HasColumnName("user_id");

				entity.HasOne(d => d.Job)
					.WithMany(p => p.Applicants)
					.HasForeignKey(d => d.JobId)
					.OnDelete(DeleteBehavior.ClientSetNull)
					.HasConstraintName("FKApplicant506596");

				entity.HasOne(d => d.User)
					.WithMany(p => p.Applicants)
					.HasForeignKey(d => d.UserId)
					.OnDelete(DeleteBehavior.ClientSetNull)
					.HasConstraintName("FKApplicant720822");
			});

			modelBuilder.Entity<AspNetRole>(entity =>
			{
				entity.HasIndex(e => e.NormalizedName, "RoleNameIndex")
					.IsUnique()
					.HasFilter("([NormalizedName] IS NOT NULL)");

				entity.Property(e => e.Name).HasMaxLength(256);

				entity.Property(e => e.NormalizedName).HasMaxLength(256);
			});

			modelBuilder.Entity<AspNetRoleClaim>(entity =>
			{
				entity.HasIndex(e => e.RoleId, "IX_AspNetRoleClaims_RoleId");

				entity.HasOne(d => d.Role)
					.WithMany(p => p.AspNetRoleClaims)
					.HasForeignKey(d => d.RoleId);
			});

			modelBuilder.Entity<AspNetUser>(entity =>
			{
				entity.HasIndex(e => e.NormalizedEmail, "EmailIndex");

				entity.HasIndex(e => e.NormalizedUserName, "UserNameIndex")
					.IsUnique()
					.HasFilter("([NormalizedUserName] IS NOT NULL)");

				entity.Property(e => e.DateOfBirth).HasMaxLength(256);

				entity.Property(e => e.Email).HasMaxLength(256);

				entity.Property(e => e.FirstName).HasMaxLength(256);

				entity.Property(e => e.LastName).HasMaxLength(256);

				entity.Property(e => e.NormalizedEmail).HasMaxLength(256);

				entity.Property(e => e.NormalizedUserName).HasMaxLength(256);

				entity.Property(e => e.UserName).HasMaxLength(256);

				entity.HasMany(d => d.Roles)
					.WithMany(p => p.Users)
					.UsingEntity<Dictionary<string, object>>(
						"AspNetUserRole",
						l => l.HasOne<AspNetRole>().WithMany().HasForeignKey("RoleId"),
						r => r.HasOne<AspNetUser>().WithMany().HasForeignKey("UserId"),
						j =>
						{
							j.HasKey("UserId", "RoleId");

							j.ToTable("AspNetUserRoles");

							j.HasIndex(new[] { "RoleId" }, "IX_AspNetUserRoles_RoleId");
						});
			});

			modelBuilder.Entity<AspNetUserClaim>(entity =>
			{
				entity.HasIndex(e => e.UserId, "IX_AspNetUserClaims_UserId");

				entity.HasOne(d => d.User)
					.WithMany(p => p.AspNetUserClaims)
					.HasForeignKey(d => d.UserId);
			});

			modelBuilder.Entity<AspNetUserLogin>(entity =>
			{
				entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });

				entity.HasIndex(e => e.UserId, "IX_AspNetUserLogins_UserId");

				entity.Property(e => e.LoginProvider).HasMaxLength(128);

				entity.Property(e => e.ProviderKey).HasMaxLength(128);

				entity.HasOne(d => d.User)
					.WithMany(p => p.AspNetUserLogins)
					.HasForeignKey(d => d.UserId);
			});

			modelBuilder.Entity<AspNetUserToken>(entity =>
			{
				entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name });

				entity.Property(e => e.LoginProvider).HasMaxLength(128);

				entity.Property(e => e.Name).HasMaxLength(128);

				entity.HasOne(d => d.User)
					.WithMany(p => p.AspNetUserTokens)
					.HasForeignKey(d => d.UserId);
			});

			modelBuilder.Entity<Category>(entity =>
			{
				entity.ToTable("Category");

				entity.Property(e => e.CategoryId).HasColumnName("category_id");

				entity.Property(e => e.Name)
					.HasMaxLength(255)
					.HasColumnName("name");
			});

			modelBuilder.Entity<Company>(entity =>
			{
				entity.ToTable("Company");

				entity.Property(e => e.CompanyId).HasColumnName("company_id");

				entity.Property(e => e.EmployerId)
					.HasMaxLength(450)
					.HasColumnName("employer_id");

				entity.Property(e => e.Name)
					.HasMaxLength(50)
					.HasColumnName("name");

				entity.Property(e => e.Url)
					.HasMaxLength(100)
					.HasColumnName("url");

				entity.HasOne(d => d.Employer)
					.WithMany(p => p.Companies)
					.HasForeignKey(d => d.EmployerId)
					.OnDelete(DeleteBehavior.ClientSetNull)
					.HasConstraintName("FKCompany237877");
			});

			modelBuilder.Entity<Employer>(entity =>
			{
				entity.ToTable("Employer");

				entity.Property(e => e.EmployerId).HasColumnName("employer_id");

				entity.Property(e => e.Title)
					.HasMaxLength(255)
					.HasColumnName("title");

				entity.HasOne(d => d.EmployerNavigation)
					.WithOne(p => p.Employer)
					.HasForeignKey<Employer>(d => d.EmployerId)
					.OnDelete(DeleteBehavior.ClientSetNull)
					.HasConstraintName("FKEmployer37240");
			});

			modelBuilder.Entity<Job>(entity =>
			{
				entity.ToTable("Job");

				entity.Property(e => e.JobId).HasColumnName("job_id");

				entity.Property(e => e.Description)
					.HasMaxLength(255)
					.HasColumnName("description");

				entity.Property(e => e.JobCategoryId).HasColumnName("job_category_id");

				entity.Property(e => e.Title)
					.HasMaxLength(255)
					.HasColumnName("title");
			});

			modelBuilder.Entity<JobCategory>(entity =>
			{
				entity.ToTable("JobCategory");

				entity.Property(e => e.JobCategoryId).HasColumnName("job_category_id");

				entity.Property(e => e.CategoryId).HasColumnName("category_id");

				entity.Property(e => e.JobId).HasColumnName("job_id");

				entity.HasOne(d => d.Category)
					.WithMany(p => p.JobCategories)
					.HasForeignKey(d => d.CategoryId)
					.OnDelete(DeleteBehavior.ClientSetNull)
					.HasConstraintName("FKJobCategor418821");

				entity.HasOne(d => d.Job)
					.WithMany(p => p.JobCategories)
					.HasForeignKey(d => d.JobId)
					.OnDelete(DeleteBehavior.ClientSetNull)
					.HasConstraintName("FKJobCategor238289");
			});

			modelBuilder.Entity<Skill>(entity =>
			{
				entity.ToTable("Skill");

				entity.Property(e => e.SkillId).HasColumnName("skill_id");

				entity.Property(e => e.Name)
					.HasMaxLength(255)
					.HasColumnName("name");
			});

			modelBuilder.Entity<UserSkill>(entity =>
			{
				entity.ToTable("UserSkill");

				entity.Property(e => e.UserSkillId).HasColumnName("user_skill_id");

				entity.Property(e => e.SkillId).HasColumnName("skill_id");

				entity.Property(e => e.UserId)
					.HasMaxLength(450)
					.HasColumnName("user_id");

				entity.HasOne(d => d.Skill)
					.WithMany(p => p.UserSkills)
					.HasForeignKey(d => d.SkillId)
					.OnDelete(DeleteBehavior.ClientSetNull)
					.HasConstraintName("FKUserSkill942971");

				entity.HasOne(d => d.User)
					.WithMany(p => p.UserSkills)
					.HasForeignKey(d => d.UserId)
					.OnDelete(DeleteBehavior.ClientSetNull)
					.HasConstraintName("FKUserSkill459199");
			});

			OnModelCreatingPartial(modelBuilder);
		}

		partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
	}
}
