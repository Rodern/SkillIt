# Changelog

All notable changes to the SkillIT project will be documented in this file.

The format is based on [Keep a Changelog](https://keepachangelog.com/en/1.0.0/),
and this project adheres to [Semantic Versioning](https://semver.org/spec/v2.0.0.html).

## [Unreleased]

### Added
- Constants class for application-wide constants to eliminate magic strings
- Pagination support for all list endpoints with `PaginatedResult<T>` model
- Global exception handling middleware for consistent error responses
- Memory caching infrastructure for improved performance
- Comprehensive README.md with setup instructions
- User Secrets configuration guide (SETUP_USER_SECRETS.md)
- API documentation (API_DOCUMENTATION.md)
- Testing guide (TESTING.md)
- Extension methods for pagination and caching
- XML documentation comments on key classes and methods
- Logging infrastructure with structured logging support

### Changed
- **BREAKING**: Moved all secrets from appsettings.json to User Secrets
- **BREAKING**: Updated API routes to include version (v1) - e.g., `/api/v1/courses`
- **BREAKING**: Changed POST methods to GET where appropriate for RESTful compliance
- Updated AuthenticationHelper to use configuration-based secret key
- Improved error handling in services with try-catch blocks and logging
- Refactored CourseService to use AsNoTracking for read-only queries
- Updated CourseController with pagination, caching, and proper HTTP verbs
- Updated UserController with improved routing and HTTP methods
- Enhanced Swagger documentation with JWT bearer authentication
- Improved JWT token validation with lifetime checks

### Removed
- Hardcoded database connection strings from appsettings.json
- Hardcoded JWT authentication key from source code
- Duplicate service registrations in Program.cs
- Commented-out code in Program.cs files
- Hardcoded connection string warning from DbContext

### Fixed
- Inconsistent naming conventions (now using _privateField convention)
- Security vulnerabilities from exposed credentials
- Missing null checks in service methods
- Potential N+1 query issues with AsNoTracking usage

### Security
- Moved all sensitive configuration to User Secrets
- Added proper token expiration validation
- Removed exposed database credentials from source control
- Implemented secure password hashing with verification method

## [1.0.0] - Initial Release

### Added
- User management system with authentication
- Course hierarchy (Courses → Chapters → Lessons → Content)
- Enrollment and progress tracking
- Quiz and assessment engine
- Achievements and certification system
- Email notification system with SendGrid
- JWT-based authentication
- Role-based authorization (Admin, User, Creator, Author)
- Blazor Server UI
- RESTful API with Swagger documentation
- MySQL database with Entity Framework Core
- TailwindCSS styling

[Unreleased]: https://github.com/yourusername/SkillIt/compare/v1.0.0...HEAD
[1.0.0]: https://github.com/yourusername/SkillIt/releases/tag/v1.0.0
