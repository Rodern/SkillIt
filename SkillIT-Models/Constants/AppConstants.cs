namespace SkillIT_Models.Constants
{
    /// <summary>
    /// Application-wide constants
    /// </summary>
    public static class AppConstants
    {
        /// <summary>
        /// Authentication and security constants
        /// </summary>
        public static class Authentication
        {
            public const string LocalStorageUserIdKey = "skillit_userId";
            public const string LocalStorageTokenKey = "skillit_user-token";
            public const string AuthenticationScheme = "SkillItBearer";
        }

        /// <summary>
        /// Account status enumeration
        /// </summary>
        public static class AccountStatus
        {
            public const string Suspended = "suspended";
            public const string NotVerified = "not_verified";
            public const string Verified = "verified";
            public const string Banned = "banned";
        }

        /// <summary>
        /// Account type enumeration
        /// </summary>
        public static class AccountType
        {
            public const string User = "user";
            public const string Admin = "admin";
        }

        /// <summary>
        /// User roles
        /// </summary>
        public static class Roles
        {
            public const string Admin = "admin";
            public const string User = "user";
            public const string Creator = "creator";
            public const string Author = "author";
        }

        /// <summary>
        /// Response messages
        /// </summary>
        public static class Messages
        {
            public const string Success = "Success";
            public const string Failed = "Failed";
            public const string UserNotFound = "UserNotFound";
            public const string EmailExists = "EmailExists";
            public const string EmailNotExisting = "EmailNotExisting";
            public const string InvalidCredentials = "InvalidCredentials";
            public const string OTPIncorrect = "OTPIncorrect";
            public const string ResetSuccess = "ResetSuccess";
            public const string TokenExpired = "TokenExpired";
            public const string TokenInvalid = "TokenInvalid";
        }

        /// <summary>
        /// Course level constants
        /// </summary>
        public static class CourseLevel
        {
            public const string Beginner = "beginner";
            public const string Intermediate = "intermediate";
            public const string Advanced = "advanced";
        }

        /// <summary>
        /// Email template types
        /// </summary>
        public static class EmailTemplates
        {
            public const string Welcome = "Welcome to Skill-IT Educate";
            public const string ConfirmEmail = "Please confirm email";
            public const string PasswordReset = "Password reset request";
            public const string CourseRegistered = "Course registered!";
            public const string CourseCompleted = "Course completed!";
        }

        /// <summary>
        /// Cache keys
        /// </summary>
        public static class CacheKeys
        {
            public const string AllCourses = "courses_all";
            public const string AllCatalogs = "catalogs_all";
            public const string CoursePrefix = "course_";
            public const string CatalogPrefix = "catalog_";
            public const string UserPrefix = "user_";
        }

        /// <summary>
        /// Pagination defaults
        /// </summary>
        public static class Pagination
        {
            public const int DefaultPageSize = 20;
            public const int MaxPageSize = 100;
            public const int DefaultPageNumber = 1;
        }
    }
}
