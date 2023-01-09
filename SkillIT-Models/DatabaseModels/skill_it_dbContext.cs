using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace SkillIT_Models.DatabaseModels
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
        public virtual DbSet<Achievement> Achievements { get; set; }
        public virtual DbSet<Catalog> Catalogs { get; set; }
        public virtual DbSet<CatalogOld> CatalogOlds { get; set; }
        public virtual DbSet<Certificate> Certificates { get; set; }
        public virtual DbSet<ChapterQuiz> ChapterQuizzes { get; set; }
        public virtual DbSet<Course> Courses { get; set; }
        public virtual DbSet<CourseChapter> CourseChapters { get; set; }
        public virtual DbSet<CourseContent> CourseContents { get; set; }
        public virtual DbSet<CourseDatum> CourseData { get; set; }
        public virtual DbSet<CourseLesson> CourseLessons { get; set; }
        public virtual DbSet<Creator> Creators { get; set; }
        public virtual DbSet<Engagement> Engagements { get; set; }
        public virtual DbSet<Enrollment> Enrollments { get; set; }
        public virtual DbSet<EnrollmentQuiz> EnrollmentQuizzes { get; set; }
        public virtual DbSet<Otp> Otps { get; set; }
        public virtual DbSet<Project> Projects { get; set; }
        public virtual DbSet<Question> Questions { get; set; }
        public virtual DbSet<QuestionAnswer> QuestionAnswers { get; set; }
        public virtual DbSet<QuestionAnswerResponse> QuestionAnswerResponses { get; set; }
        public virtual DbSet<Quiz> Quizzes { get; set; }
        public virtual DbSet<QuizQuestion> QuizQuestions { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
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
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseMySQL("server=localhost;port=3306;database=skill_it_db;user=root;password=");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AccountDetail>(entity =>
            {
                entity.HasKey(e => e.AccountId)
                    .HasName("PRIMARY");

                entity.ToTable("account_detail");

                entity.HasIndex(e => e.UserId, "detail_of");

                entity.HasIndex(e => e.RoleId, "user_role");

                entity.Property(e => e.AccountId)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("accountID");

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

                entity.Property(e => e.RoleId)
                    .HasColumnType("int(11)")
                    .HasColumnName("roleID")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.UserId)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("userID");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AccountDetails)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("user_role");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AccountDetails)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("user");
            });

            modelBuilder.Entity<Achievement>(entity =>
            {
                entity.ToTable("achievement");

                entity.Property(e => e.AchievementId)
                    .HasColumnType("int(11)")
                    .HasColumnName("achievementID");

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
                entity.ToTable("catalog");

                entity.Property(e => e.CatalogId)
                    .HasColumnType("int(11)")
                    .HasColumnName("catalogID");

                entity.Property(e => e.Caption)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("caption");

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
                entity.ToTable("certificate");

                entity.Property(e => e.CertificateId)
                    .HasColumnType("int(11)")
                    .HasColumnName("certificateID");

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

            modelBuilder.Entity<ChapterQuiz>(entity =>
            {
                entity.ToTable("chapter_quiz");

                entity.HasIndex(e => e.AuthorId, "authorID");

                entity.HasIndex(e => e.ChapterId, "chapterID");

                entity.HasIndex(e => e.QuizId, "quizID");

                entity.Property(e => e.ChapterQuizId)
                    .HasColumnType("int(11)")
                    .HasColumnName("chapter_quizID");

                entity.Property(e => e.AuthorId)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("authorID");

                entity.Property(e => e.ChapterId)
                    .HasColumnType("int(11)")
                    .HasColumnName("chapterID");

                entity.Property(e => e.DateCreated).HasColumnName("date_created");

                entity.Property(e => e.QuizId)
                    .HasColumnType("int(11)")
                    .HasColumnName("quizID");

                entity.HasOne(d => d.Author)
                    .WithMany(p => p.ChapterQuizzes)
                    .HasForeignKey(d => d.AuthorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("chapter_quiz_ibfk_1");

                entity.HasOne(d => d.Chapter)
                    .WithMany(p => p.ChapterQuizzes)
                    .HasForeignKey(d => d.ChapterId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("chapter_quiz_ibfk_2");

                entity.HasOne(d => d.Quiz)
                    .WithMany(p => p.ChapterQuizzes)
                    .HasForeignKey(d => d.QuizId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("chapter_quiz_ibfk_3");
            });

            modelBuilder.Entity<Course>(entity =>
            {
                entity.ToTable("course");

                entity.HasIndex(e => e.AuthorId, "authorID");

                entity.Property(e => e.CourseId)
                    .HasColumnType("int(11)")
                    .HasColumnName("courseID");

                entity.Property(e => e.AuthorId)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("authorID");

                entity.Property(e => e.DateCreated)
                    .HasColumnType("int(11)")
                    .HasColumnName("date_created");

                entity.Property(e => e.DatePublish)
                    .HasColumnType("int(11)")
                    .HasColumnName("date_publish");

                entity.Property(e => e.IsOpen)
                    .IsRequired()
                    .HasColumnName("is_open")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.IsPublished).HasColumnName("is_published");

                entity.Property(e => e.Level)
                    .IsRequired()
                    .HasColumnType("enum('general','beginner','intermediate','advance')")
                    .HasColumnName("level")
                    .HasDefaultValueSql("'''general'''");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(250)
                    .HasColumnName("name");

                entity.HasOne(d => d.Author)
                    .WithMany(p => p.Courses)
                    .HasForeignKey(d => d.AuthorId)
                    .HasConstraintName("course_ibfk_1");
            });

            modelBuilder.Entity<CourseChapter>(entity =>
            {
                entity.HasKey(e => e.ChapterId)
                    .HasName("PRIMARY");

                entity.ToTable("course_chapter");

                entity.HasIndex(e => e.AuthorId, "authorID");

                entity.HasIndex(e => e.CourseId, "courseID");

                entity.Property(e => e.ChapterId)
                    .HasColumnType("int(11)")
                    .HasColumnName("chapterID");

                entity.Property(e => e.AuthorId)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("authorID");

                entity.Property(e => e.ChapterNumber)
                    .HasColumnType("int(11)")
                    .HasColumnName("chapter_number");

                entity.Property(e => e.CourseId)
                    .HasColumnType("int(11)")
                    .HasColumnName("courseID");

                entity.Property(e => e.DateCreated).HasColumnName("date_created");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(250)
                    .HasColumnName("title");

                entity.HasOne(d => d.Author)
                    .WithMany(p => p.CourseChapters)
                    .HasForeignKey(d => d.AuthorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("course_chapter_ibfk_1");

                entity.HasOne(d => d.Course)
                    .WithMany(p => p.CourseChapters)
                    .HasForeignKey(d => d.CourseId)
                    .HasConstraintName("course_chapter_ibfk_2");
            });

            modelBuilder.Entity<CourseContent>(entity =>
            {
                entity.HasKey(e => e.ContentId)
                    .HasName("PRIMARY");

                entity.ToTable("course_content");

                entity.HasIndex(e => e.AuthorId, "authorID");

                entity.HasIndex(e => e.LessonId, "lessonID");

                entity.Property(e => e.ContentId)
                    .HasColumnType("int(11)")
                    .HasColumnName("contentID");

                entity.Property(e => e.AuthorId)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("authorID");

                entity.Property(e => e.Content)
                    .IsRequired()
                    .HasColumnType("longtext")
                    .HasColumnName("content");

                entity.Property(e => e.ContentNumber)
                    .HasColumnType("int(11)")
                    .HasColumnName("content_number");

                entity.Property(e => e.DateCreated).HasColumnName("date_created");

                entity.Property(e => e.LessonId)
                    .HasColumnType("int(11)")
                    .HasColumnName("lessonID");

                entity.Property(e => e.Note)
                    .IsRequired()
                    .HasMaxLength(250)
                    .HasColumnName("note");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(250)
                    .HasColumnName("title");

                entity.Property(e => e.VideoLink)
                    .IsRequired()
                    .HasMaxLength(500)
                    .HasColumnName("video_link");

                entity.HasOne(d => d.Author)
                    .WithMany(p => p.CourseContents)
                    .HasForeignKey(d => d.AuthorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("course_content_ibfk_1");

                entity.HasOne(d => d.Lesson)
                    .WithMany(p => p.CourseContents)
                    .HasForeignKey(d => d.LessonId)
                    .HasConstraintName("course_content_ibfk_2");
            });

            modelBuilder.Entity<CourseDatum>(entity =>
            {
                entity.HasKey(e => e.DataId)
                    .HasName("PRIMARY");

                entity.ToTable("course_data");

                entity.HasIndex(e => e.EnrollmentId, "enrollmentID");

                entity.Property(e => e.DataId)
                    .HasColumnType("int(11)")
                    .HasColumnName("dataID");

                entity.Property(e => e.EnrollmentId)
                    .HasColumnType("int(11)")
                    .HasColumnName("enrollmentID");

                entity.Property(e => e.LastModified).HasColumnName("last_modified");

                entity.Property(e => e.StartDate).HasColumnName("start_date");

                entity.Property(e => e.StudyRecord)
                    .IsRequired()
                    .HasColumnType("longtext")
                    .HasColumnName("study_record");

                entity.HasOne(d => d.Enrollment)
                    .WithMany(p => p.CourseData)
                    .HasForeignKey(d => d.EnrollmentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("course_data_ibfk_1");
            });

            modelBuilder.Entity<CourseLesson>(entity =>
            {
                entity.HasKey(e => e.LessonId)
                    .HasName("PRIMARY");

                entity.ToTable("course_lesson");

                entity.HasIndex(e => e.AuthorId, "authorID");

                entity.HasIndex(e => e.ChapterId, "chapterID");

                entity.Property(e => e.LessonId)
                    .HasColumnType("int(11)")
                    .HasColumnName("lessonID");

                entity.Property(e => e.AuthorId)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("authorID");

                entity.Property(e => e.ChapterId)
                    .HasColumnType("int(11)")
                    .HasColumnName("chapterID");

                entity.Property(e => e.DateCreated).HasColumnName("date_created");

                entity.Property(e => e.LessonNumber)
                    .HasColumnType("int(11)")
                    .HasColumnName("lesson_number");

                entity.Property(e => e.Topic)
                    .IsRequired()
                    .HasMaxLength(250)
                    .HasColumnName("topic");

                entity.HasOne(d => d.Author)
                    .WithMany(p => p.CourseLessons)
                    .HasForeignKey(d => d.AuthorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("course_lesson_ibfk_1");

                entity.HasOne(d => d.Chapter)
                    .WithMany(p => p.CourseLessons)
                    .HasForeignKey(d => d.ChapterId)
                    .HasConstraintName("course_lesson_ibfk_2");
            });

            modelBuilder.Entity<Creator>(entity =>
            {
                entity.HasKey(e => e.AuthorId)
                    .HasName("PRIMARY");

                entity.ToTable("creator");

                entity.HasIndex(e => e.AccountId, "accountID");

                entity.HasIndex(e => e.RoleId, "roleID");

                entity.Property(e => e.AuthorId)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("authorID");

                entity.Property(e => e.AccountId)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("accountID");

                entity.Property(e => e.RoleId)
                    .HasColumnType("int(11)")
                    .HasColumnName("roleID");

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasColumnType("enum('active','passive')")
                    .HasColumnName("status")
                    .HasDefaultValueSql("'''active'''");

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.Creators)
                    .HasForeignKey(d => d.AccountId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("creator_ibfk_1");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Creators)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("creator_ibfk_2");
            });

            modelBuilder.Entity<Engagement>(entity =>
            {
                entity.ToTable("engagement");

                entity.HasIndex(e => e.CatalogId, "engaged");

                entity.HasIndex(e => e.UserId, "who_enganged");

                entity.Property(e => e.EngagementId)
                    .HasColumnType("int(11)")
                    .HasColumnName("engagementID");

                entity.Property(e => e.CatalogId)
                    .HasColumnType("int(11)")
                    .HasColumnName("catalogID");

                entity.Property(e => e.Completed).HasColumnName("completed");

                entity.Property(e => e.EngagedDate)
                    .HasColumnType("date")
                    .HasColumnName("engagedDate");

                entity.Property(e => e.UserId)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("userID");

                entity.HasOne(d => d.Catalog)
                    .WithMany(p => p.Engagements)
                    .HasForeignKey(d => d.CatalogId)
                    .HasConstraintName("engaged");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Engagements)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("who_enganged");
            });

            modelBuilder.Entity<Enrollment>(entity =>
            {
                entity.ToTable("enrollment");

                entity.HasIndex(e => e.CourseId, "courseID");

                entity.HasIndex(e => e.UserId, "userID");

                entity.Property(e => e.EnrollmentId)
                    .HasColumnType("int(11)")
                    .HasColumnName("enrollmentID");

                entity.Property(e => e.CourseId)
                    .HasColumnType("int(11)")
                    .HasColumnName("courseID");

                entity.Property(e => e.DateCompleted).HasColumnName("date_completed");

                entity.Property(e => e.DateEnrolled).HasColumnName("date_enrolled");

                entity.Property(e => e.IsCompleted).HasColumnName("is_completed");

                entity.Property(e => e.UserId)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("userID");

                entity.HasOne(d => d.Course)
                    .WithMany(p => p.Enrollments)
                    .HasForeignKey(d => d.CourseId)
                    .HasConstraintName("enrollment_ibfk_2");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Enrollments)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("enrollment_ibfk_1");
            });

            modelBuilder.Entity<EnrollmentQuiz>(entity =>
            {
                entity.ToTable("enrollment_quiz");

                entity.HasIndex(e => e.EnrollmentId, "enrollmentID");

                entity.HasIndex(e => e.QuizId, "quizID");

                entity.Property(e => e.EnrollmentQuizId)
                    .HasColumnType("int(11)")
                    .HasColumnName("enrollment_quizID");

                entity.Property(e => e.DateTaken).HasColumnName("date_taken");

                entity.Property(e => e.EnrollmentId)
                    .HasColumnType("int(11)")
                    .HasColumnName("enrollmentID");

                entity.Property(e => e.Passed).HasColumnName("passed");

                entity.Property(e => e.Points)
                    .HasColumnType("int(11)")
                    .HasColumnName("points");

                entity.Property(e => e.QuizId)
                    .HasColumnType("int(11)")
                    .HasColumnName("quizID");

                entity.Property(e => e.TimeTaken).HasColumnName("time_taken");

                entity.HasOne(d => d.Enrollment)
                    .WithMany(p => p.EnrollmentQuizzes)
                    .HasForeignKey(d => d.EnrollmentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("enrollment_quiz_ibfk_1");

                entity.HasOne(d => d.Quiz)
                    .WithMany(p => p.EnrollmentQuizzes)
                    .HasForeignKey(d => d.QuizId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("enrollment_quiz_ibfk_2");
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

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(2000)
                    .HasColumnName("description");

                entity.Property(e => e.Link)
                    .IsRequired()
                    .HasMaxLength(500)
                    .HasColumnName("link");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(500)
                    .HasColumnName("name");

                entity.Property(e => e.Owner)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("owner");

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

            modelBuilder.Entity<Question>(entity =>
            {
                entity.ToTable("question");

                entity.HasIndex(e => e.AuthorId, "authorID");

                entity.Property(e => e.QuestionId)
                    .HasColumnType("int(11)")
                    .HasColumnName("questionID");

                entity.Property(e => e.AuthorId)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("authorID");

                entity.Property(e => e.Question1)
                    .IsRequired()
                    .HasColumnType("longtext")
                    .HasColumnName("question");

                entity.HasOne(d => d.Author)
                    .WithMany(p => p.Questions)
                    .HasForeignKey(d => d.AuthorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("question_ibfk_1");
            });

            modelBuilder.Entity<QuestionAnswer>(entity =>
            {
                entity.ToTable("question_answer");

                entity.HasIndex(e => e.QuestionId, "questionID");

                entity.Property(e => e.QuestionAnswerId)
                    .HasColumnType("int(11)")
                    .HasColumnName("question_answerID");

                entity.Property(e => e.Answer)
                    .IsRequired()
                    .HasColumnType("longtext")
                    .HasColumnName("answer");

                entity.Property(e => e.IsCorrect).HasColumnName("is_correct");

                entity.Property(e => e.QuestionId)
                    .HasColumnType("int(11)")
                    .HasColumnName("questionID");

                entity.HasOne(d => d.Question)
                    .WithMany(p => p.QuestionAnswers)
                    .HasForeignKey(d => d.QuestionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("question_answer_ibfk_1");
            });

            modelBuilder.Entity<QuestionAnswerResponse>(entity =>
            {
                entity.ToTable("question_answer_response");

                entity.HasIndex(e => e.EnrollmentId, "enrollmentID");

                entity.HasIndex(e => e.QuestionId, "questionID");

                entity.HasIndex(e => e.QuestionAnswerId, "question_answerID");

                entity.Property(e => e.QuestionAnswerResponseId)
                    .HasColumnType("int(11)")
                    .HasColumnName("question_answer_responseID");

                entity.Property(e => e.EnrollmentId)
                    .HasColumnType("int(11)")
                    .HasColumnName("enrollmentID");

                entity.Property(e => e.QuestionAnswerId)
                    .HasColumnType("int(11)")
                    .HasColumnName("question_answerID");

                entity.Property(e => e.QuestionId)
                    .HasColumnType("int(11)")
                    .HasColumnName("questionID");

                entity.Property(e => e.TimeAnswer).HasColumnName("time_answer");

                entity.HasOne(d => d.Enrollment)
                    .WithMany(p => p.QuestionAnswerResponses)
                    .HasForeignKey(d => d.EnrollmentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("question_answer_response_ibfk_1");

                entity.HasOne(d => d.QuestionAnswer)
                    .WithMany(p => p.QuestionAnswerResponses)
                    .HasForeignKey(d => d.QuestionAnswerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("question_answer_response_ibfk_2");

                entity.HasOne(d => d.Question)
                    .WithMany(p => p.QuestionAnswerResponses)
                    .HasForeignKey(d => d.QuestionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("question_answer_response_ibfk_3");
            });

            modelBuilder.Entity<Quiz>(entity =>
            {
                entity.ToTable("quiz");

                entity.HasIndex(e => e.QuizCode, "quiz_code")
                    .IsUnique();

                entity.Property(e => e.QuizId)
                    .HasColumnType("int(11)")
                    .HasColumnName("quizID");

                entity.Property(e => e.AuthorId)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("authorID");

                entity.Property(e => e.DateCreated).HasColumnName("date_created");

                entity.Property(e => e.QuizCode)
                    .HasColumnType("int(11)")
                    .HasColumnName("quiz_code")
                    .HasDefaultValueSql("'NULL'");
            });

            modelBuilder.Entity<QuizQuestion>(entity =>
            {
                entity.ToTable("quiz_question");

                entity.HasIndex(e => e.QuestionId, "questionID");

                entity.HasIndex(e => e.QuizId, "quizID");

                entity.Property(e => e.QuizQuestionId)
                    .HasColumnType("int(11)")
                    .HasColumnName("quiz_questionID");

                entity.Property(e => e.QuestionId)
                    .HasColumnType("int(11)")
                    .HasColumnName("questionID");

                entity.Property(e => e.QuizId)
                    .HasColumnType("int(11)")
                    .HasColumnName("quizID");

                entity.HasOne(d => d.Question)
                    .WithMany(p => p.QuizQuestions)
                    .HasForeignKey(d => d.QuestionId)
                    .HasConstraintName("quiz_question_ibfk_2");

                entity.HasOne(d => d.Quiz)
                    .WithMany(p => p.QuizQuestions)
                    .HasForeignKey(d => d.QuizId)
                    .HasConstraintName("quiz_question_ibfk_1");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("role");

                entity.Property(e => e.RoleId)
                    .HasColumnType("int(11)")
                    .HasColumnName("roleID");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(500)
                    .HasColumnName("description");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("name");
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
                entity.ToTable("user_achievement");

                entity.HasIndex(e => e.AchievementId, "acheived");

                entity.HasIndex(e => e.UserId, "acheived_by");

                entity.HasIndex(e => e.CatalogId, "involve_catalog");

                entity.HasIndex(e => e.UserSkillId, "involve_sklill");

                entity.HasIndex(e => e.EnrollmentId, "user_achievement_ibfk_1");

                entity.Property(e => e.UserAchievementId)
                    .HasColumnType("int(11)")
                    .HasColumnName("user_achievementID");

                entity.Property(e => e.AchievementId)
                    .HasColumnType("int(11)")
                    .HasColumnName("achievementID");

                entity.Property(e => e.CatalogId)
                    .HasColumnType("int(11)")
                    .HasColumnName("catalogID")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.EnrollmentId)
                    .HasColumnType("int(11)")
                    .HasColumnName("enrollmentID")
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

                entity.HasOne(d => d.Achievement)
                    .WithMany(p => p.UserAchievements)
                    .HasForeignKey(d => d.AchievementId)
                    .HasConstraintName("acheived");

                entity.HasOne(d => d.Catalog)
                    .WithMany(p => p.UserAchievements)
                    .HasForeignKey(d => d.CatalogId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("involve_catalog");

                entity.HasOne(d => d.Enrollment)
                    .WithMany(p => p.UserAchievements)
                    .HasForeignKey(d => d.EnrollmentId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("user_achievement_ibfk_1");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserAchievements)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("acheived_by");

                entity.HasOne(d => d.UserSkill)
                    .WithMany(p => p.UserAchievements)
                    .HasForeignKey(d => d.UserSkillId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("involve_sklill");
            });

            modelBuilder.Entity<UserCertificate>(entity =>
            {
                entity.ToTable("user_certificate");

                entity.HasIndex(e => e.CourseId, "courseID");

                entity.HasIndex(e => e.CertificateId, "has_certifcate");

                entity.HasIndex(e => e.UserId, "owned_by");

                entity.Property(e => e.UserCertificateId)
                    .HasColumnType("int(11)")
                    .HasColumnName("user_certificateID");

                entity.Property(e => e.CertificateId)
                    .HasColumnType("int(11)")
                    .HasColumnName("certificateID");

                entity.Property(e => e.CourseId)
                    .HasColumnType("int(11)")
                    .HasColumnName("courseID")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.UserId)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("userID");

                entity.HasOne(d => d.Certificate)
                    .WithMany(p => p.UserCertificates)
                    .HasForeignKey(d => d.CertificateId)
                    .HasConstraintName("has_certifcate");

                entity.HasOne(d => d.Course)
                    .WithMany(p => p.UserCertificates)
                    .HasForeignKey(d => d.CourseId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("user_certificate_ibfk_1");

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
