using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace SkillItModels.DatabaseModels
{
    public partial class skill_it_dbContext : DbContext
    {
        public skill_it_dbContext()
        {
        }

        public skill_it_dbContext(DbContextOptions<skill_it_dbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AccountDetail> AccountDetails { get; set; }
        public virtual DbSet<Acheivement> Acheivements { get; set; }
        public virtual DbSet<Catalog> Catalogs { get; set; }
        public virtual DbSet<CatalogOld> CatalogOlds { get; set; }
        public virtual DbSet<Certificate> Certificates { get; set; }
        public virtual DbSet<Otp> Otps { get; set; }
        public virtual DbSet<Project> Projects { get; set; }
        public virtual DbSet<Skill> Skills { get; set; }
        public virtual DbSet<Social> Socials { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserAchievement> UserAchievements { get; set; }
        public virtual DbSet<UserCertificate> UserCertificates { get; set; }
        public virtual DbSet<UserSkill> UserSkills { get; set; }
        public virtual DbSet<UserSocial> UserSocials { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
/*#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseMySQL("server=localhost;port=3306;database=skill_it_db;user=root;password=");*/
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AccountDetail>(entity =>
            {
                entity.HasKey(e => new { e.AcId, e.UserId })
                    .HasName("PRIMARY");

                entity.ToTable("account_detail");

                entity.HasIndex(e => e.UserId, "detail_of");

                entity.Property(e => e.AcId)
                    .HasColumnType("int(11)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("acID");

                entity.Property(e => e.UserId)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("userID");

                entity.Property(e => e.AccountStatus)
                    .IsRequired()
                    .HasColumnType("enum('suspended','not_verified','verified','banned')")
                    .HasColumnName("account_status");

                entity.Property(e => e.AccountType)
                    .IsRequired()
                    .HasColumnType("enum('user','admin')")
                    .HasColumnName("accountType");

                entity.Property(e => e.LastLogin).HasColumnName("last_login");

                entity.Property(e => e.LoginAttemp)
                    .IsRequired()
                    .HasColumnType("longtext")
                    .HasColumnName("login_attemp");

                entity.Property(e => e.LoginInfo)
                    .IsRequired()
                    .HasColumnType("longtext")
                    .HasColumnName("login_info");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AccountDetails)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("user");
            });

            modelBuilder.Entity<Acheivement>(entity =>
            {
                entity.HasKey(e => e.AchId)
                    .HasName("PRIMARY");

                entity.ToTable("acheivement");

                entity.Property(e => e.AchId)
                    .HasColumnType("int(11)")
                    .HasColumnName("achID");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(250)
                    .HasColumnName("name");

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasColumnType("enum('Badge','Milestone')")
                    .HasColumnName("type");
            });

            modelBuilder.Entity<Catalog>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("catalog");

                entity.Property(e => e.Caption)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("caption");

                entity.Property(e => e.CatalogId)
                    .HasColumnType("int(11)")
                    .HasColumnName("catalogID");

                entity.Property(e => e.CatalogLink)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("catalog_link");

                entity.Property(e => e.Data)
                    .IsRequired()
                    .HasColumnType("longtext")
                    .HasColumnName("data");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnType("longtext")
                    .HasColumnName("description");

                entity.Property(e => e.Image)
                    .IsRequired()
                    .HasColumnType("longblob")
                    .HasColumnName("image");
            });

            modelBuilder.Entity<CatalogOld>(entity =>
            {
                entity.HasKey(e => e.CatalogId)
                    .HasName("PRIMARY");

                entity.ToTable("catalog_old");

                entity.Property(e => e.CatalogId)
                    .HasColumnType("int(11)")
                    .HasColumnName("catalogID");

                entity.Property(e => e.Caption)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("caption");

                entity.Property(e => e.CatalogLink)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("catalog_link");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(250)
                    .HasColumnName("description");

                entity.Property(e => e.Image)
                    .HasColumnType("longblob")
                    .HasColumnName("image")
                    .HasDefaultValueSql("'NULL'");
            });

            modelBuilder.Entity<Certificate>(entity =>
            {
                entity.HasKey(e => e.CertId)
                    .HasName("PRIMARY");

                entity.ToTable("certificate");

                entity.Property(e => e.CertId)
                    .HasColumnType("int(11)")
                    .HasColumnName("certID");

                entity.Property(e => e.EndDate)
                    .HasColumnType("date")
                    .HasColumnName("endDate");

                entity.Property(e => e.Link)
                    .IsRequired()
                    .HasMaxLength(500)
                    .HasColumnName("link");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(500)
                    .HasColumnName("name");

                entity.Property(e => e.Platform)
                    .IsRequired()
                    .HasMaxLength(300)
                    .HasColumnName("platform");

                entity.Property(e => e.SignedDate)
                    .HasColumnType("date")
                    .HasColumnName("signedDate");

                entity.Property(e => e.StartDate)
                    .HasColumnType("date")
                    .HasColumnName("startDate");

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasColumnType("enum('Degree','Nano-Degree','Bachelor','Master','HND')")
                    .HasColumnName("type");
            });

            modelBuilder.Entity<Otp>(entity =>
            {
                entity.ToTable("otp");

                entity.HasIndex(e => e.UserId, "reset_code");

                entity.Property(e => e.OtpId)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("otpID");

                entity.Property(e => e.Code)
                    .HasColumnType("int(6)")
                    .HasColumnName("code");

                entity.Property(e => e.ExpiryDate)
                    .HasColumnType("date")
                    .HasColumnName("expiryDate");

                entity.Property(e => e.UserId)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("userId");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Otps)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("reset_code");
            });

            modelBuilder.Entity<Project>(entity =>
            {
                entity.ToTable("project");

                entity.Property(e => e.ProjectId)
                    .HasColumnType("int(11)")
                    .HasColumnName("projectID");

                entity.Property(e => e.Link)
                    .IsRequired()
                    .HasMaxLength(500)
                    .HasColumnName("link");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(500)
                    .HasColumnName("name");

                entity.Property(e => e.SkillSet)
                    .IsRequired()
                    .HasColumnType("longtext")
                    .HasColumnName("skillSet");

                entity.Property(e => e.SoureLink)
                    .IsRequired()
                    .HasMaxLength(500)
                    .HasColumnName("soureLink");

                entity.Property(e => e.UserId)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("userID");
            });

            modelBuilder.Entity<Skill>(entity =>
            {
                entity.ToTable("skill");

                entity.Property(e => e.SkillId)
                    .HasColumnType("int(11)")
                    .HasColumnName("skillID");

                entity.Property(e => e.Level)
                    .IsRequired()
                    .HasColumnType("enum('Beginner','Amateur','Intermediate','Professional','GodLevel')")
                    .HasColumnName("level");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<Social>(entity =>
            {
                entity.ToTable("social");

                entity.Property(e => e.SocialId)
                    .HasColumnType("int(11)")
                    .HasColumnName("socialID");

                entity.Property(e => e.Link)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("link");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("user");

                entity.Property(e => e.UserId)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("userID");

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("address");

                entity.Property(e => e.DateCreated).HasColumnName("date_created");

                entity.Property(e => e.Dob)
                    .HasColumnType("date")
                    .HasColumnName("dob");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("email");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(15)
                    .HasColumnName("first_name");

                entity.Property(e => e.Gender)
                    .IsRequired()
                    .HasColumnType("enum('M','F')")
                    .HasColumnName("gender");

                entity.Property(e => e.Image)
                    .HasColumnType("longblob")
                    .HasColumnName("image")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(15)
                    .HasColumnName("last_name");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(250)
                    .HasColumnName("password");

                entity.Property(e => e.Phone)
                    .IsRequired()
                    .HasMaxLength(9)
                    .HasColumnName("phone");
            });

            modelBuilder.Entity<UserAchievement>(entity =>
            {
                entity.HasKey(e => e.UaId)
                    .HasName("PRIMARY");

                entity.ToTable("user_achievement");

                entity.HasIndex(e => e.AchId, "acheived");

                entity.HasIndex(e => e.UserId, "acheived_by");

                entity.HasIndex(e => e.CatalogId, "involve_catalog");

                entity.HasIndex(e => e.UserSkillId, "involve_sklill");

                entity.Property(e => e.UaId)
                    .HasColumnType("int(11)")
                    .HasColumnName("uaID");

                entity.Property(e => e.AchId)
                    .HasColumnType("int(11)")
                    .HasColumnName("achID");

                entity.Property(e => e.CatalogId)
                    .HasColumnType("int(11)")
                    .HasColumnName("catalogID")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.CourseId)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("courseID")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.LanguageId)
                    .HasColumnType("int(11)")
                    .HasColumnName("languageID")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.UserId)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("userID");

                entity.Property(e => e.UserSkillId)
                    .HasColumnType("int(11)")
                    .HasColumnName("user_skillID")
                    .HasDefaultValueSql("'NULL'");

                entity.HasOne(d => d.Ach)
                    .WithMany(p => p.UserAchievements)
                    .HasForeignKey(d => d.AchId)
                    .HasConstraintName("acheived");

                entity.HasOne(d => d.Catalog)
                    .WithMany(p => p.UserAchievements)
                    .HasForeignKey(d => d.CatalogId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("involve_catalog");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserAchievements)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("acheived_by");

                entity.HasOne(d => d.UserSkill)
                    .WithMany(p => p.UserAchievements)
                    .HasForeignKey(d => d.UserSkillId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("involve_sklill");
            });

            modelBuilder.Entity<UserCertificate>(entity =>
            {
                entity.HasKey(e => e.UcId)
                    .HasName("PRIMARY");

                entity.ToTable("user_certificate");

                entity.HasIndex(e => e.CertId, "has_certifcate");

                entity.HasIndex(e => e.UserId, "owned_by");

                entity.Property(e => e.UcId)
                    .HasColumnType("int(11)")
                    .HasColumnName("ucID");

                entity.Property(e => e.CertId)
                    .HasColumnType("int(11)")
                    .HasColumnName("certID");

                entity.Property(e => e.UserId)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("userID");

                entity.HasOne(d => d.Cert)
                    .WithMany(p => p.UserCertificates)
                    .HasForeignKey(d => d.CertId)
                    .HasConstraintName("has_certifcate");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserCertificates)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("owned_by");
            });

            modelBuilder.Entity<UserSkill>(entity =>
            {
                entity.ToTable("user_skill");

                entity.HasIndex(e => e.SkillId, "skill");

                entity.HasIndex(e => e.UserId, "user_has_skill");

                entity.Property(e => e.UserSkillId)
                    .HasColumnType("int(11)")
                    .HasColumnName("user_skillID");

                entity.Property(e => e.SkillId)
                    .HasColumnType("int(11)")
                    .HasColumnName("skillID");

                entity.Property(e => e.UserId)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("userID");

                entity.HasOne(d => d.Skill)
                    .WithMany(p => p.UserSkills)
                    .HasForeignKey(d => d.SkillId)
                    .HasConstraintName("skill");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserSkills)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("user_has_skill");
            });

            modelBuilder.Entity<UserSocial>(entity =>
            {
                entity.ToTable("user_social");

                entity.HasIndex(e => e.SocialId, "social");

                entity.HasIndex(e => e.UserId, "user_has_social");

                entity.Property(e => e.UserSocialId)
                    .HasColumnType("int(11)")
                    .HasColumnName("user_socialID");

                entity.Property(e => e.SocialId)
                    .HasColumnType("int(11)")
                    .HasColumnName("socialID");

                entity.Property(e => e.UserId)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("userID");

                entity.HasOne(d => d.Social)
                    .WithMany(p => p.UserSocials)
                    .HasForeignKey(d => d.SocialId)
                    .HasConstraintName("social");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserSocials)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("user_has_social");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
