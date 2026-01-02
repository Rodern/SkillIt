using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using SkillIT_Models.Entities;
using SkillIT_Models.Entities.Analytics;
using SkillIT_Models.Entities.Core;
using SkillIT_Models.Entities.Courses;
using SkillIT_Models.Entities.Learning;

namespace SkillIT_Models.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    // Core Entities
    public DbSet<User> Users => Set<User>();
    public DbSet<Account> Accounts => Set<Account>();
    public DbSet<Role> Roles => Set<Role>();
    public DbSet<Creator> Creators => Set<Creator>();
    public DbSet<Email> Emails => Set<Email>();
    public DbSet<Phone> Phones => Set<Phone>();
    public DbSet<Country> Countries => Set<Country>();
    public DbSet<Language> Languages => Set<Language>();
    public DbSet<Skill> Skills => Set<Skill>();
    public DbSet<Social> Socials => Set<Social>();
    public DbSet<Notification> Notifications => Set<Notification>();
    public DbSet<Otp> Otps => Set<Otp>();
    public DbSet<Feedback> Feedbacks => Set<Feedback>();
    public DbSet<Testimonial> Testimonials => Set<Testimonial>();
    public DbSet<Project> Projects => Set<Project>();
    public DbSet<SentMail> SentMails => Set<SentMail>();

    // Location Entities
    public DbSet<City> Cities => Set<City>();
    public DbSet<Region> Regions => Set<Region>();

    // Junction Tables
    public DbSet<UserEmail> UserEmails => Set<UserEmail>();
    public DbSet<UserPhone> UserPhones => Set<UserPhone>();
    public DbSet<UserCity> UserCities => Set<UserCity>();
    public DbSet<UserCountry> UserCountries => Set<UserCountry>();
    public DbSet<UserRegion> UserRegions => Set<UserRegion>();
    public DbSet<UserToken> UserTokens => Set<UserToken>();
    public DbSet<UserSkill> UserSkills => Set<UserSkill>();
    public DbSet<UserSocial> UserSocials => Set<UserSocial>();

    // Communication Entities
    public DbSet<NewsLetter> NewsLetters => Set<NewsLetter>();
    public DbSet<NewsLetterSubscriber> NewsLetterSubscribers => Set<NewsLetterSubscriber>();

    // Location and Security Entities
    public DbSet<SimpleLocation> SimpleLocations => Set<SimpleLocation>();
    public DbSet<Password> Passwords => Set<Password>();

    // Course Entities
    public DbSet<Course> Courses => Set<Course>();
    public DbSet<CourseChapter> CourseChapters => Set<CourseChapter>();
    public DbSet<CourseLesson> CourseLessons => Set<CourseLesson>();
    public DbSet<CourseContent> CourseContents => Set<CourseContent>();

    // Learning Entities
    public DbSet<Enrollment> Enrollments => Set<Enrollment>();
    public DbSet<CourseData> CourseData => Set<CourseData>();
    public DbSet<DataIndex> DataIndexes => Set<DataIndex>();
    public DbSet<Catalog> Catalogs => Set<Catalog>();
    public DbSet<Engagement> Engagements => Set<Engagement>();
    public DbSet<Achievement> Achievements => Set<Achievement>();
    public DbSet<UserAchievement> UserAchievements => Set<UserAchievement>();
    public DbSet<Certificate> Certificates => Set<Certificate>();
    public DbSet<UserCertificate> UserCertificates => Set<UserCertificate>();

    // Quiz Entities
    public DbSet<Quiz> Quizzes => Set<Quiz>();
    public DbSet<Question> Questions => Set<Question>();
    public DbSet<QuestionAnswer> QuestionAnswers => Set<QuestionAnswer>();
    public DbSet<QuizQuestion> QuizQuestions => Set<QuizQuestion>();
    public DbSet<ChapterQuiz> ChapterQuizzes => Set<ChapterQuiz>();
    public DbSet<EnrollmentQuiz> EnrollmentQuizzes => Set<EnrollmentQuiz>();
    public DbSet<QuestionAnswerResponse> QuestionAnswerResponses => Set<QuestionAnswerResponse>();

    // Analytics Entities
    public DbSet<CourseView> CourseViews => Set<CourseView>();
    public DbSet<CourseEnrollmentAnalytics> CourseEnrollmentAnalytics => Set<CourseEnrollmentAnalytics>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Apply all configurations
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);

        // Global Query Filters for Soft Delete
        ConfigureSoftDeleteFilters(modelBuilder);

        // Configure JSON columns
        ConfigureJsonColumns(modelBuilder);

        // Configure Indexes
        ConfigureIndexes(modelBuilder);

        // Configure Unique Constraints
        ConfigureUniqueConstraints(modelBuilder);
    }

    public override int SaveChanges()
    {
        UpdateAuditFields();
        return base.SaveChanges();
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        UpdateAuditFields();
        return base.SaveChangesAsync(cancellationToken);
    }

    private void UpdateAuditFields()
    {
        var entries = ChangeTracker.Entries<AuditableEntity>();

        foreach (var entry in entries)
        {
            switch (entry.State)
            {
                case EntityState.Added:
                    entry.Entity.CreatedAt = DateTime.UtcNow;
                    // CreatedBy should be set by the calling code
                    break;

                case EntityState.Modified:
                    entry.Entity.UpdatedAt = DateTime.UtcNow;
                    // UpdatedBy should be set by the calling code
                    break;

                case EntityState.Deleted:
                    // Soft delete
                    entry.State = EntityState.Modified;
                    entry.Entity.IsDeleted = true;
                    entry.Entity.DeletedAt = DateTime.UtcNow;
                    // DeletedBy should be set by the calling code
                    break;
            }
        }
    }

    private void ConfigureSoftDeleteFilters(ModelBuilder modelBuilder)
    {
        // Apply soft delete query filter to all entities that implement ISoftDeletable
        foreach (var entityType in modelBuilder.Model.GetEntityTypes())
        {
            if (typeof(ISoftDeletable).IsAssignableFrom(entityType.ClrType))
            {
                var parameter = Expression.Parameter(entityType.ClrType, "e");
                var property = Expression.Property(parameter, nameof(ISoftDeletable.IsDeleted));
                var filterExpression = Expression.Lambda(
                    Expression.Equal(property, Expression.Constant(false)),
                    parameter
                );

                modelBuilder.Entity(entityType.ClrType).HasQueryFilter(filterExpression);
            }
        }
    }

    private void ConfigureJsonColumns(ModelBuilder modelBuilder)
    {
        // Account JSON columns
        modelBuilder.Entity<Account>()
            .Property(a => a.LoginInfo)
            .HasColumnType("json");

        modelBuilder.Entity<Account>()
            .Property(a => a.LoginAttempt)
            .HasColumnType("json");

        // Catalog JSON column
        modelBuilder.Entity<Catalog>()
            .Property(c => c.Data)
            .HasColumnType("json");

        // CourseData JSON column
        modelBuilder.Entity<CourseData>()
            .Property(cd => cd.StudyRecord)
            .HasColumnType("json");

        // DataIndex JSON column
        modelBuilder.Entity<DataIndex>()
            .Property(di => di.IndexData)
            .HasColumnType("json");

        // Notification JSON column
        modelBuilder.Entity<Notification>()
            .Property(n => n.Actions)
            .HasColumnType("json");

        // Feedback JSON columns
        modelBuilder.Entity<Feedback>()
            .Property(f => f.IncludedImages)
            .HasColumnType("json");

        modelBuilder.Entity<Feedback>()
            .Property(f => f.ReadBy)
            .HasColumnType("json");

        modelBuilder.Entity<Feedback>()
            .Property(f => f.TagIds)
            .HasColumnType("json");

        modelBuilder.Entity<Feedback>()
            .Property(f => f.TopicIds)
            .HasColumnType("json");

        modelBuilder.Entity<Feedback>()
            .Property(f => f.SubjectIds)
            .HasColumnType("json");

        modelBuilder.Entity<Feedback>()
            .Property(f => f.CategoryIds)
            .HasColumnType("json");

        // Project JSON column
        modelBuilder.Entity<Project>()
            .Property(p => p.SkillSet)
            .HasColumnType("json");

        // Password JSON column
        modelBuilder.Entity<Password>()
            .Property(p => p.PastPasswords)
            .HasColumnType("json");
    }

    private void ConfigureIndexes(ModelBuilder modelBuilder)
    {
        // User indexes
        modelBuilder.Entity<User>()
            .HasIndex(u => u.Email)
            .IsUnique()
            .HasDatabaseName("idx_user_email_unique");

        modelBuilder.Entity<User>()
            .HasIndex(u => u.Username)
            .IsUnique()
            .HasDatabaseName("idx_user_username_unique");

        modelBuilder.Entity<User>()
            .HasIndex(u => u.IsDeleted)
            .HasDatabaseName("idx_user_deleted");

        // Course indexes
        modelBuilder.Entity<Course>()
            .HasIndex(c => c.Guid)
            .IsUnique()
            .HasDatabaseName("idx_course_guid_unique");

        modelBuilder.Entity<Course>()
            .HasIndex(c => new { c.IsPublished, c.Level, c.DatePublish })
            .HasDatabaseName("idx_course_published_level");

        modelBuilder.Entity<Course>()
            .HasIndex(c => c.AuthorId)
            .HasDatabaseName("idx_course_author");

        modelBuilder.Entity<Course>()
            .HasIndex(c => c.IsDeleted)
            .HasDatabaseName("idx_course_deleted");

        // Enrollment indexes
        modelBuilder.Entity<Enrollment>()
            .HasIndex(e => new { e.UserId, e.CourseId })
            .IsUnique()
            .HasDatabaseName("idx_enrollment_user_course");

        modelBuilder.Entity<Enrollment>()
            .HasIndex(e => new { e.UserId, e.IsCompleted, e.DateEnrolled })
            .HasDatabaseName("idx_enrollment_user_completed");

        modelBuilder.Entity<Enrollment>()
            .HasIndex(e => e.IsDeleted)
            .HasDatabaseName("idx_enrollment_deleted");

        // Engagement indexes
        modelBuilder.Entity<Engagement>()
            .HasIndex(e => new { e.UserId, e.CatalogId })
            .IsUnique()
            .HasDatabaseName("idx_engagement_user_catalog");

        modelBuilder.Entity<Engagement>()
            .HasIndex(e => new { e.UserId, e.Completed, e.EngagedDate })
            .HasDatabaseName("idx_engagement_user_completed");

        // Notification indexes
        modelBuilder.Entity<Notification>()
            .HasIndex(n => new { n.AccountId, n.MarkedAsRead, n.DateCreated })
            .HasDatabaseName("idx_notification_account_read_date");

        // OTP indexes
        modelBuilder.Entity<Otp>()
            .HasIndex(o => o.Guid)
            .IsUnique()
            .HasDatabaseName("idx_otp_guid");

        modelBuilder.Entity<Otp>()
            .HasIndex(o => new { o.Code, o.UserId })
            .IsUnique()
            .HasDatabaseName("idx_otp_code_user");

        modelBuilder.Entity<Otp>()
            .HasIndex(o => new { o.UserId, o.Code, o.ExpiryDate })
            .HasDatabaseName("idx_otp_user_code_expiry");

        // Course structure indexes
        modelBuilder.Entity<CourseChapter>()
            .HasIndex(c => new { c.CourseId, c.ChapterNumber })
            .HasDatabaseName("idx_chapter_course_number");

        modelBuilder.Entity<CourseLesson>()
            .HasIndex(l => new { l.ChapterId, l.LessonNumber })
            .HasDatabaseName("idx_lesson_chapter_number");

        modelBuilder.Entity<CourseContent>()
            .HasIndex(c => new { c.LessonId, c.ContentNumber })
            .HasDatabaseName("idx_content_lesson_number");

        // Analytics indexes
        modelBuilder.Entity<CourseView>()
            .HasIndex(cv => new { cv.CourseId, cv.ViewedAt })
            .HasDatabaseName("idx_courseview_course_date");

        modelBuilder.Entity<CourseView>()
            .HasIndex(cv => new { cv.UserId, cv.ViewedAt })
            .HasDatabaseName("idx_courseview_user_date");

        modelBuilder.Entity<CourseEnrollmentAnalytics>()
            .HasIndex(cea => new { cea.CourseId, cea.EnrolledAt })
            .HasDatabaseName("idx_courseenrollment_course_date");

        modelBuilder.Entity<CourseEnrollmentAnalytics>()
            .HasIndex(cea => new { cea.UserId, cea.IsCompleted })
            .HasDatabaseName("idx_courseenrollment_user_completed");

        // City indexes
        modelBuilder.Entity<City>()
            .HasIndex(c => c.Guid)
            .IsUnique()
            .HasDatabaseName("idx_city_guid_unique");

        modelBuilder.Entity<City>()
            .HasIndex(c => c.CountryId)
            .HasDatabaseName("idx_city_country");

        // Region indexes
        modelBuilder.Entity<Region>()
            .HasIndex(r => r.Guid)
            .IsUnique()
            .HasDatabaseName("idx_region_guid_unique");

        modelBuilder.Entity<Region>()
            .HasIndex(r => r.CountryId)
            .HasDatabaseName("idx_region_country");

        // UserCity indexes
        modelBuilder.Entity<UserCity>()
            .HasIndex(uc => new { uc.UserId, uc.CityId })
            .IsUnique()
            .HasDatabaseName("idx_usercity_user_city_unique");

        // UserCountry indexes
        modelBuilder.Entity<UserCountry>()
            .HasIndex(uc => new { uc.UserId, uc.CountryId })
            .IsUnique()
            .HasDatabaseName("idx_usercountry_user_country_unique");

        // UserRegion indexes
        modelBuilder.Entity<UserRegion>()
            .HasIndex(ur => new { ur.UserId, ur.RegionId })
            .IsUnique()
            .HasDatabaseName("idx_userregion_user_region_unique");

        // UserToken indexes
        modelBuilder.Entity<UserToken>()
            .HasIndex(ut => ut.UserId)
            .IsUnique()
            .HasDatabaseName("idx_usertoken_user_unique");

        // NewsLetter indexes
        modelBuilder.Entity<NewsLetter>()
            .HasIndex(nl => nl.Guid)
            .IsUnique()
            .HasDatabaseName("idx_newsletter_guid_unique");

        modelBuilder.Entity<NewsLetter>()
            .HasIndex(nl => new { nl.Status, nl.ScheduleDate })
            .HasDatabaseName("idx_newsletter_status_schedule");

        // NewsLetterSubscriber indexes
        modelBuilder.Entity<NewsLetterSubscriber>()
            .HasIndex(nls => nls.SubscriberCode)
            .IsUnique()
            .HasDatabaseName("idx_newslettersubscriber_code_unique");

        modelBuilder.Entity<NewsLetterSubscriber>()
            .HasIndex(nls => nls.EmailId)
            .HasDatabaseName("idx_newslettersubscriber_email");

        // Password indexes
        modelBuilder.Entity<Password>()
            .HasIndex(p => p.UserId)
            .HasDatabaseName("idx_password_user");

        modelBuilder.Entity<Password>()
            .HasIndex(p => p.LastChanged)
            .HasDatabaseName("idx_password_lastchanged");
    }

    private void ConfigureUniqueConstraints(ModelBuilder modelBuilder)
    {
        // Email unique constraint
        modelBuilder.Entity<Email>()
            .HasIndex(e => e.Address)
            .IsUnique()
            .HasDatabaseName("idx_email_address_unique");

        // Testimonial - one per user
        modelBuilder.Entity<Testimonial>()
            .HasIndex(t => t.UserId)
            .IsUnique()
            .HasDatabaseName("idx_testimonial_user_unique");
    }
}
