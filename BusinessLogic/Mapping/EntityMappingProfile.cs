using AutoMapper;
using SkillIT_Models.DatabaseModels;
using SkillIT_Models.Entities.Analytics;
using SkillIT_Models.Entities.Core;
using SkillIT_Models.Entities.Courses;
using SkillIT_Models.Entities.Learning;

namespace BusinessLogic.Mapping
{
    /// <summary>
    /// AutoMapper profile for mapping between new Entity models and legacy DatabaseModels
    /// This enables gradual migration while maintaining backward compatibility
    /// </summary>
    public class EntityMappingProfile : Profile
    {
        public EntityMappingProfile()
        {
            // ===================
            // Core Entity Mappings
            // ===================
            
            // User mappings
            CreateMap<SkillIT_Models.Entities.Core.User, SkillIT_Models.DatabaseModels.User>()
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.Id))
                .ReverseMap()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.UserId));

            // Account mappings
            CreateMap<SkillIT_Models.Entities.Core.Account, SkillIT_Models.DatabaseModels.Account>()
                .ForMember(dest => dest.AccountId, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.User != null ? src.User.Id : 0))
                .ReverseMap()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.AccountId));

            // Role mappings
            CreateMap<SkillIT_Models.Entities.Core.Role, SkillIT_Models.DatabaseModels.Role>()
                .ForMember(dest => dest.RoleId, opt => opt.MapFrom(src => src.Id))
                .ReverseMap()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.RoleId));

            // Creator mappings
            CreateMap<SkillIT_Models.Entities.Core.Creator, SkillIT_Models.DatabaseModels.Creator>()
                .ForMember(dest => dest.AuthorId, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.AccountId, opt => opt.MapFrom(src => src.Account != null ? src.Account.Id : 0))
                .ReverseMap()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.AuthorId));

            // Skill mappings
            CreateMap<SkillIT_Models.Entities.Core.Skill, SkillIT_Models.DatabaseModels.Skill>()
                .ForMember(dest => dest.SkillId, opt => opt.MapFrom(src => src.Id))
                .ReverseMap()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.SkillId));

            // Social mappings
            CreateMap<SkillIT_Models.Entities.Core.Social, SkillIT_Models.DatabaseModels.Social>()
                .ForMember(dest => dest.SocialId, opt => opt.MapFrom(src => src.Id))
                .ReverseMap()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.SocialId));

            // Notification mappings
            CreateMap<SkillIT_Models.Entities.Core.Notification, SkillIT_Models.DatabaseModels.Notification>()
                .ForMember(dest => dest.NotificationId, opt => opt.MapFrom(src => src.Id))
                .ReverseMap()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.NotificationId));

            // OTP mappings
            CreateMap<SkillIT_Models.Entities.Core.Otp, SkillIT_Models.DatabaseModels.Otp>()
                .ForMember(dest => dest.OtpId, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.User != null ? src.User.Id : 0))
                .ReverseMap()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.OtpId));

            // SentMail mappings (note the naming difference: Sentmail vs SentMail)
            CreateMap<SkillIT_Models.Entities.Core.SentMail, SkillIT_Models.DatabaseModels.Sentmail>()
                .ForMember(dest => dest.MailId, opt => opt.MapFrom(src => src.Id))
                .ReverseMap()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.MailId));

            // UserSkill mappings
            CreateMap<SkillIT_Models.Entities.Core.UserSkill, SkillIT_Models.DatabaseModels.UserSkill>()
                .ForMember(dest => dest.UserSkillId, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.User != null ? src.User.Id : 0))
                .ForMember(dest => dest.SkillId, opt => opt.MapFrom(src => src.Skill != null ? src.Skill.Id : 0))
                .ReverseMap()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.UserSkillId));

            // UserSocial mappings
            CreateMap<SkillIT_Models.Entities.Core.UserSocial, SkillIT_Models.DatabaseModels.UserSocial>()
                .ForMember(dest => dest.UserSocialId, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.User != null ? src.User.Id : 0))
                .ForMember(dest => dest.SocialId, opt => opt.MapFrom(src => src.Social != null ? src.Social.Id : 0))
                .ReverseMap()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.UserSocialId));

            // ===================
            // Course Entity Mappings
            // ===================
            
            // Course mappings
            CreateMap<SkillIT_Models.Entities.Courses.Course, SkillIT_Models.DatabaseModels.Course>()
                .ForMember(dest => dest.CourseId, opt => opt.MapFrom(src => src.Id))
                .ReverseMap()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.CourseId));

            // CourseChapter mappings
            CreateMap<SkillIT_Models.Entities.Courses.CourseChapter, SkillIT_Models.DatabaseModels.CourseChapter>()
                .ForMember(dest => dest.ChapterId, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.CourseId, opt => opt.MapFrom(src => src.Course != null ? src.Course.Id : 0))
                .ReverseMap()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.ChapterId));

            // CourseLesson mappings
            CreateMap<SkillIT_Models.Entities.Courses.CourseLesson, SkillIT_Models.DatabaseModels.CourseLesson>()
                .ForMember(dest => dest.LessonId, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.ChapterId, opt => opt.MapFrom(src => src.Chapter != null ? src.Chapter.Id : 0))
                .ReverseMap()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.LessonId));

            // CourseContent mappings
            CreateMap<SkillIT_Models.Entities.Courses.CourseContent, SkillIT_Models.DatabaseModels.CourseContent>()
                .ForMember(dest => dest.ContentId, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.LessonId, opt => opt.MapFrom(src => src.Lesson != null ? src.Lesson.Id : 0))
                .ReverseMap()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.ContentId));

            // ===================
            // Learning Entity Mappings
            // ===================
            
            // Enrollment mappings
            CreateMap<SkillIT_Models.Entities.Learning.Enrollment, SkillIT_Models.DatabaseModels.Enrollment>()
                .ForMember(dest => dest.EnrollmentId, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.User != null ? src.User.Id : 0))
                .ForMember(dest => dest.CourseId, opt => opt.MapFrom(src => src.Course != null ? src.Course.Id : 0))
                .ReverseMap()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.EnrollmentId));

            // CourseData mappings (CourseDatum in old model)
            CreateMap<SkillIT_Models.Entities.Learning.CourseData, SkillIT_Models.DatabaseModels.CourseDatum>()
                .ForMember(dest => dest.DataId, opt => opt.MapFrom(src => src.Id))
                .ReverseMap()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.DataId));

            // DataIndex mappings
            CreateMap<SkillIT_Models.Entities.Learning.DataIndex, SkillIT_Models.DatabaseModels.DataIndex>()
                .ForMember(dest => dest.IndexId, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.CourseId, opt => opt.MapFrom(src => src.Course != null ? src.Course.Id : 0))
                .ReverseMap()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.IndexId));

            // Catalog mappings
            CreateMap<SkillIT_Models.Entities.Learning.Catalog, SkillIT_Models.DatabaseModels.Catalog>()
                .ForMember(dest => dest.CatalogId, opt => opt.MapFrom(src => src.Id))
                .ReverseMap()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.CatalogId));

            // Engagement mappings
            CreateMap<SkillIT_Models.Entities.Learning.Engagement, SkillIT_Models.DatabaseModels.Engagement>()
                .ForMember(dest => dest.EngagementId, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.User != null ? src.User.Id : 0))
                .ForMember(dest => dest.CatalogId, opt => opt.MapFrom(src => src.Catalog != null ? src.Catalog.Id : 0))
                .ReverseMap()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.EngagementId));

            // Achievement mappings
            CreateMap<SkillIT_Models.Entities.Learning.Achievement, SkillIT_Models.DatabaseModels.Achievement>()
                .ForMember(dest => dest.AchievementId, opt => opt.MapFrom(src => src.Id))
                .ReverseMap()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.AchievementId));

            // UserAchievement mappings
            CreateMap<SkillIT_Models.Entities.Learning.UserAchievement, SkillIT_Models.DatabaseModels.UserAchievement>()
                .ForMember(dest => dest.UserAchievementId, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.User != null ? src.User.Id : 0))
                .ForMember(dest => dest.AchievementId, opt => opt.MapFrom(src => src.Achievement != null ? src.Achievement.Id : 0))
                .ReverseMap()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.UserAchievementId));

            // Certificate mappings
            CreateMap<SkillIT_Models.Entities.Learning.Certificate, SkillIT_Models.DatabaseModels.Certificate>()
                .ForMember(dest => dest.CertificateId, opt => opt.MapFrom(src => src.Id))
                .ReverseMap()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.CertificateId));

            // UserCertificate mappings
            CreateMap<SkillIT_Models.Entities.Learning.UserCertificate, SkillIT_Models.DatabaseModels.UserCertificate>()
                .ForMember(dest => dest.UserCertificateId, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.User != null ? src.User.Id : 0))
                .ForMember(dest => dest.CertificateId, opt => opt.MapFrom(src => src.Certificate != null ? src.Certificate.Id : 0))
                .ReverseMap()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.UserCertificateId));

            // Quiz mappings
            CreateMap<SkillIT_Models.Entities.Learning.Quiz, SkillIT_Models.DatabaseModels.Quiz>()
                .ForMember(dest => dest.QuizId, opt => opt.MapFrom(src => src.Id))
                .ReverseMap()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.QuizId));

            // Question mappings
            CreateMap<SkillIT_Models.Entities.Learning.Question, SkillIT_Models.DatabaseModels.Question>()
                .ForMember(dest => dest.QuestionId, opt => opt.MapFrom(src => src.Id))
                .ReverseMap()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.QuestionId));

            // QuestionAnswer mappings
            CreateMap<SkillIT_Models.Entities.Learning.QuestionAnswer, SkillIT_Models.DatabaseModels.QuestionAnswer>()
                .ForMember(dest => dest.QuestionAnswerId, opt => opt.MapFrom(src => src.Id))
                .ReverseMap()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.QuestionAnswerId));

            // QuizQuestion mappings
            CreateMap<SkillIT_Models.Entities.Learning.QuizQuestion, SkillIT_Models.DatabaseModels.QuizQuestion>()
                .ForMember(dest => dest.QuizQuestionId, opt => opt.MapFrom(src => src.Id))
                .ReverseMap()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.QuizQuestionId));

            // ChapterQuiz mappings
            CreateMap<SkillIT_Models.Entities.Learning.ChapterQuiz, SkillIT_Models.DatabaseModels.ChapterQuiz>()
                .ForMember(dest => dest.ChapterQuizId, opt => opt.MapFrom(src => src.Id))
                .ReverseMap()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.ChapterQuizId));

            // EnrollmentQuiz mappings
            CreateMap<SkillIT_Models.Entities.Learning.EnrollmentQuiz, SkillIT_Models.DatabaseModels.EnrollmentQuiz>()
                .ForMember(dest => dest.EnrollmentQuizId, opt => opt.MapFrom(src => src.Id))
                .ReverseMap()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.EnrollmentQuizId));

            // QuestionAnswerResponse mappings
            CreateMap<SkillIT_Models.Entities.Learning.QuestionAnswerResponse, SkillIT_Models.DatabaseModels.QuestionAnswerResponse>()
                .ForMember(dest => dest.QuestionAnswerResponseId, opt => opt.MapFrom(src => src.Id))
                .ReverseMap()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.QuestionAnswerResponseId));

            // ===================
            // Analytics Entity Mappings
            // ===================
            
            // CourseView mappings
            CreateMap<SkillIT_Models.Entities.Analytics.CourseView, SkillIT_Models.DatabaseModels.CourseView>()
                .ForMember(dest => dest.ViewId, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.User != null ? src.User.Id : 0))
                .ForMember(dest => dest.CourseId, opt => opt.MapFrom(src => src.Course != null ? src.Course.Id : 0))
                .ReverseMap()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.ViewId));
        }
    }
}
