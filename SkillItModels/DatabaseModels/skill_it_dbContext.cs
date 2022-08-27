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
        public virtual DbSet<Catalog> Catalogs { get; set; }
        public virtual DbSet<Skill> Skills { get; set; }
        public virtual DbSet<Social> Socials { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserSkill> UserSkills { get; set; }
        public virtual DbSet<UserSocial> UserSocials { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                //optionsBuilder.UseMySQL("server=localhost;port=3306;database=skill_it_db;user=root;password=");
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
                    .HasColumnType("int(11)")
                    .HasColumnName("userID");

                entity.Property(e => e.AccountStatus)
                    .IsRequired()
                    .HasColumnType("enum('suspended','not_verified','verified','banned')")
                    .HasColumnName("account_status");

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
                    .HasConstraintName("detail_of");
            });

            modelBuilder.Entity<Catalog>(entity =>
            {
                //entity.HasKey(e.cata);

                entity.ToTable("catalog");

                entity.Property(e => e.Caption)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("caption");

                entity.Property(e => e.CatalogId)
                    .HasColumnType("int(11)")
                    .HasColumnName("catalogID");

                entity.Property(e => e.CatalogLink)
                    .IsRequired()
                    .HasMaxLength(10000000)
                    .HasColumnName("catalog_link");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(250)
                    .HasColumnName("description");

                entity.Property(e => e.ImgLink)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("img_link");
            });

            modelBuilder.Entity<Skill>(entity =>
            {
                entity.ToTable("skill");

                entity.Property(e => e.SkillId)
                    .HasColumnType("int(11)")
                    .HasColumnName("skillID");

                entity.Property(e => e.Level)
                    .IsRequired()
                    .HasColumnType("enum('Beginner','Amateur','Intermediate','Professional','GodLevel')");

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
                    .HasColumnType("int(11)")
                    .HasColumnName("userID");

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("address");

                entity.Property(e => e.DateCreated)
                    .HasColumnName("date_created")
                    .HasDefaultValueSql("'current_timestamp()'");

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

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(15)
                    .HasColumnName("last_name");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(15)
                    .HasColumnName("password");

                entity.Property(e => e.Phone)
                    .IsRequired()
                    .HasMaxLength(9)
                    .HasColumnName("phone");

                entity.Property(e => e.UserSkillId)
                    .HasColumnType("int(11)")
                    .HasColumnName("user_skillID")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.UserSocialId)
                    .HasColumnType("int(11)")
                    .HasColumnName("user_socialID")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Username)
					.IsRequired()
					.HasMaxLength(10000000)
					.HasColumnName("username");
            });

            modelBuilder.Entity<UserSkill>(entity =>
            {
                entity.ToTable("user_skill");

                entity.HasIndex(e => e.SkillId, "has_skill");

                entity.HasIndex(e => e.UserId, "user_has");

                entity.Property(e => e.UserSkillId)
                    .HasColumnType("int(11)")
                    .HasColumnName("user_skillID");

                entity.Property(e => e.SkillId)
                    .HasColumnType("int(11)")
                    .HasColumnName("skillID");

                entity.Property(e => e.UserId)
                    .HasColumnType("int(11)")
                    .HasColumnName("userID");

                entity.HasOne(d => d.Skill)
                    .WithMany(p => p.UserSkills)
                    .HasForeignKey(d => d.SkillId)
                    .HasConstraintName("has_skill");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserSkills)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("user_has");
            });

            modelBuilder.Entity<UserSocial>(entity =>
            {
                entity.ToTable("user_social");

                entity.HasIndex(e => e.UserId, "has_social");

                entity.HasIndex(e => e.SocialId, "user_is_on");

                entity.Property(e => e.UserSocialId)
                    .HasColumnType("int(11)")
                    .HasColumnName("user_socialID");

                entity.Property(e => e.SocialId)
                    .HasColumnType("int(11)")
                    .HasColumnName("socialID");

                entity.Property(e => e.UserId)
                    .HasColumnType("int(11)")
                    .HasColumnName("userID");

                entity.HasOne(d => d.Social)
                    .WithMany(p => p.UserSocials)
                    .HasForeignKey(d => d.SocialId)
                    .HasConstraintName("user_is_on");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserSocials)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("has_social");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
