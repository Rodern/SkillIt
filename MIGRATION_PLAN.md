# Database-First to Code-First EF Core Migration Plan

**Project:** SkillIt Learning Platform  
**Date:** January 1, 2026  
**Current Status:** 232 compilation errors blocking migration  
**Goal:** Complete migration to Code-First EF Core with improved database schema

---

## Executive Summary

This document outlines the comprehensive plan to migrate the SkillIt project from database-first Entity Framework to code-first EF Core 8.0. The migration involves updating 18 business logic services, 18 interfaces, and 10+ controllers to use the new entity model with improved patterns (soft delete, audit trails, proper indexing).

---

## Current State Analysis

### ✅ Completed Work
1. **Entity Models (23 files)**: All entities created in `SkillIT-Models/Entities/`
   - Core: User, Account, Role, Creator, Email, Phone, Country, Language, Skill, Social, Notification, Otp, Feedback, Testimonial, Project, SentMail
   - Junction: UserEmail, UserPhone, UserSkill, UserSocial
   - Courses: Course, CourseChapter, CourseLesson, CourseContent
   - Learning: Enrollment, CourseData, DataIndex, Catalog, Engagement, Achievement, UserAchievement, Certificate, UserCertificate
   - Quiz: Quiz, Question, QuestionAnswer, QuizQuestion, ChapterQuiz, EnrollmentQuiz, QuestionAnswerResponse
   - Analytics: CourseView

2. **ApplicationDbContext**: Fully configured with:
   - Soft delete global query filters
   - Audit interceptor for CreatedAt/By, UpdatedAt/By
   - 20+ indexes for performance
   - JSON column configurations
   - Fluent API relationship mappings

3. **Program.cs**: Updated to use ApplicationDbContext with Pomelo MySQL provider

4. **Package Dependencies**: Updated to EF Core 8.0.0

### ❌ Blocking Issues

**Primary Key Naming Convention Mismatch:**
- Old DatabaseModels: `UserId`, `CourseId`, `SkillId`, `AccountId`, etc.
- New Entities: `Id` (inherited from BaseEntity/AuditableEntity)

**Type Incompatibility:**
- Services return `SkillIT_Models.DatabaseModels.*` types
- New system uses `SkillIT_Models.Entities.*` types
- No implicit conversion between these types

**DbSet Property Name Mismatches:**
- Old: `CourseEnrollments` → New: `Enrollments`
- Old: `DataIndices` → New: `DataIndexes`
- Old: `Sentmails` → New: `SentMails`

**Helper Method Parameters:**
- Many services use helper methods that expect `skill_it_dbContext` parameter
- New system uses `ApplicationDbContext`

---

## Migration Strategy - Combined Approach (Option 2 + 3)

**Adopted Strategy:** Complete Full Refactoring with AutoMapper for DTO Mapping

This combined approach provides:
1. **Clean Entity Layer**: All services use new entity types internally (Option 2)
2. **Backward Compatibility**: AutoMapper handles conversion between entities and legacy DatabaseModels (Option 3)
3. **Gradual Migration**: Controllers and external interfaces can continue using DTOs during transition
4. **Separation of Concerns**: Clear boundaries between persistence layer and API layer

### AutoMapper Configuration

**Installed Packages:**
- AutoMapper 12.0.1
- AutoMapper.Extensions.Microsoft.DependencyInjection 12.0.1

**Mapping Profile Location:**
`BusinessLogic/Mapping/EntityMappingProfile.cs`

**Key Mappings:**
- All primary key mappings (Id ↔ EntityId pattern)
- Special property mappings (CoverImage ↔ ThumbnailImage)
- Navigation property handling for foreign keys
- Bidirectional mappings for full flexibility

### Phase 1: Interface Updates (18 files) - ✅ COMPLETED
Update all service interfaces in `BusinessLogic/Interfaces/` to return new entity types.

**Pattern:**
```csharp
// OLD
public interface ICourseService
{
    Task<List<SkillIT_Models.DatabaseModels.Course>> GetAllCourses();
}

// NEW
public interface ICourseService
{
    Task<List<SkillIT_Models.Entities.Courses.Course>> GetAllCourses();
}
```

**Files to Update:**
1. IAccountService.cs
2. IAnalyticsService.cs
3. IAuthenticationService.cs
4. ICatalogService.cs
5. ICourseService.cs
6. IEngagementService.cs
7. IEnrollmentService.cs
8. IEntityService.cs
9. IMailingService.cs (likely no changes needed)
10. INotificationService.cs
11. IOTPService.cs
12. IQuizService.cs
13. ISkillService.cs
14. ISocialService.cs
15. IUserAchievementService.cs
16. IUserCertificateService.cs
17. IUserService.cs
18. IUserSkillService.cs
19. IUserSocialService.cs

### Phase 2: Service Implementation Updates (18 files)

For each service, update:

#### A. Using Statements
```csharp
// Add
using SkillIT_Models.Entities.Core;
using SkillIT_Models.Entities.Courses;
using SkillIT_Models.Entities.Learning;
using SkillIT_Models.Entities.Analytics;

// Remove or keep as needed
using SkillIT_Models.DatabaseModels;
```

#### B. Return Types
Change all method return types from DatabaseModels to Entities.

#### C. Property References
```csharp
// OLD
var user = Users.Find(u => u.UserId == id);
var course = Courses.Find(c => c.CourseId == id);
var skill = Skills.Find(s => s.SkillId == id);

// NEW
var user = Users.Find(u => u.Id == id);
var course = Courses.Find(c => c.Id == id);
var skill = Skills.Find(s => s.Id == id);
```

#### D. DbSet References
```csharp
// OLD
_databaseContext.CourseEnrollments
_databaseContext.DataIndices
_databaseContext.Sentmails

// NEW
_databaseContext.Enrollments
_databaseContext.DataIndexes
_databaseContext.SentMails
```

#### E. Helper Method Signatures
```csharp
// OLD
private static Course GetCourseDetails(int id, skill_it_dbContext context)

// NEW
private static Course GetCourseDetails(int id, ApplicationDbContext context)
```

#### F. Remove Static DatabaseContext References
All static `DatabaseContext.TableName` must be replaced with instance `_databaseContext.TableName`.

**Services to Update:**
1. AccountService.cs - Account, Creator, Role, User entities
2. AnalyticsService.cs - CourseView, Course entities
3. AuthenticationService.cs - User, Account, Otp, Role entities
4. CatalogService.cs - Catalog entity
5. CourseService.cs - Course, CourseChapter, CourseLesson, CourseContent, CourseData, DataIndex entities
6. EngagementService.cs - Engagement entity
7. EnrollmentService.cs - Enrollment entity
8. EntityService.cs - Generic entity operations
9. MailingService.cs - Email operations (likely minimal changes)
10. NotificationService.cs - Notification entity
11. OTPService.cs - Otp entity
12. QuizService.cs - Quiz, Question, QuestionAnswer, QuizQuestion, ChapterQuiz, EnrollmentQuiz, QuestionAnswerResponse entities
13. SkillService.cs - Skill entity
14. SocialService.cs - Social entity
15. UserAchievementService.cs - UserAchievement, Achievement entities
16. UserCertificateService.cs - UserCertificate, Certificate entities
17. UserService.cs - User, Account entities
18. UserSkillService.cs - UserSkill, Skill entities
19. UserSocialService.cs - UserSocial, Social entities

### Phase 3: Controller Updates (10+ files)

Update all API controllers in `SkillIT-API/Controllers/` that consume the updated services.

**Pattern:**
```csharp
// OLD
var courses = await _courseService.GetAllCourses();
// courses is List<SkillIT_Models.DatabaseModels.Course>

// NEW  
var courses = await _courseService.GetAllCourses();
// courses is List<SkillIT_Models.Entities.Courses.Course>
```

**Controllers to Update:**
1. AccountController.cs
2. AchievementController.cs
3. AuthenticationManagerController.cs
4. CatalogController.cs
5. CertificateController.cs
6. CourseController.cs
7. EngagementController.cs
8. OTPController.cs
9. UserController.cs
10. UserSkillController.cs
11. (Additional controllers as needed)

### Phase 4: Generate Migration

After all compilation errors are resolved:

```bash
dotnet build

dotnet ef migrations add InitialCreate \
  --project SkillIT-Models \
  --startup-project SkillIT-API

dotnet ef database update \
  --project SkillIT-Models \
  --startup-project SkillIT-API
```

---

## Detailed Property Mapping

### Common Property Changes

| Old DatabaseModel Property | New Entity Property | Entity Type |
|---------------------------|---------------------|-------------|
| `UserId` | `Id` | User |
| `AccountId` | `Id` | Account |
| `RoleId` | `Id` | Role |
| `CourseId` | `Id` | Course |
| `ChapterId` | `Id` | CourseChapter |
| `LessonId` | `Id` | CourseLesson |
| `ContentId` | `Id` | CourseContent |
| `SkillId` | `Id` | Skill |
| `SocialId` | `Id` | Social |
| `NotificationId` | `Id` | Notification |
| `OtpId` | `Id` | Otp |
| `EnrollmentId` | `Id` | Enrollment |
| `CatalogId` | `Id` | Catalog |
| `AchievementId` | `Id` | Achievement |
| `CertificateId` | `Id` | Certificate |
| `UserSkillId` | `Id` | UserSkill |
| `UserSocialId` | `Id` | UserSocial |
| `UserAchievementId` | `Id` | UserAchievement |
| `UserCertificateId` | `Id` | UserCertificate |
| `EnrollmentQuizId` | `Id` | EnrollmentQuiz |

### Special Property Changes

| Old Property | New Property | Notes |
|-------------|--------------|-------|
| `course.ThumbnailImage` | `course.CoverImage` | Property renamed in Course entity |
| `enrollment.CompletionPercentage` | Calculate from progress | May need to add property or compute |

---

## Critical DbContext Changes

### ApplicationDbContext DbSet Properties

Ensure services use correct DbSet property names:

```csharp
// Core
public DbSet<User> Users => Set<User>();
public DbSet<Account> Accounts => Set<Account>();
public DbSet<Role> Roles => Set<Role>();
public DbSet<Creator> Creators => Set<Creator>();
public DbSet<SentMail> SentMails => Set<SentMail>();  // NOT Sentmails

// Junction
public DbSet<UserSkill> UserSkills => Set<UserSkill>();
public DbSet<UserSocial> UserSocials => Set<UserSocial>();

// Courses
public DbSet<Course> Courses => Set<Course>();
public DbSet<CourseChapter> CourseChapters => Set<CourseChapter>();
public DbSet<CourseLesson> CourseLessons => Set<CourseLesson>();
public DbSet<CourseContent> CourseContents => Set<CourseContent>();

// Learning
public DbSet<Enrollment> Enrollments => Set<Enrollment>();  // NOT CourseEnrollments
public DbSet<CourseData> CourseData => Set<CourseData>();
public DbSet<DataIndex> DataIndexes => Set<DataIndex>();  // NOT DataIndices
public DbSet<Catalog> Catalogs => Set<Catalog>();

// Quiz
public DbSet<EnrollmentQuiz> EnrollmentQuizzes => Set<EnrollmentQuiz>();
public DbSet<ChapterQuiz> ChapterQuizzes => Set<ChapterQuiz>();

// Analytics
public DbSet<CourseView> CourseViews => Set<CourseView>();
```

---

## Risk Assessment & Mitigation

### High Risk Areas

1. **Service Method Return Types**
   - Risk: Breaking changes to API contracts
   - Mitigation: Update interfaces first, then implementations, then controllers in sequence

2. **Property Name Changes**
   - Risk: Runtime null reference exceptions
   - Mitigation: Comprehensive grep search for all old property names before building

3. **Missing DbSet Properties**
   - Risk: Compilation errors for tables not in ApplicationDbContext
   - Mitigation: Add any missing DbSet properties to ApplicationDbContext

4. **Helper Method Signatures**
   - Risk: Parameter type mismatches
   - Mitigation: Search for all methods accepting skill_it_dbContext and update

### Medium Risk Areas

1. **LINQ Query Changes**
   - May need to update complex queries due to property name changes
   - Test queries with new entity structure

2. **Null Handling**
   - New entities may have different nullability
   - Review and update null checks

3. **Business Logic**
   - Some business logic may be tightly coupled to old model structure
   - May need refactoring beyond simple type changes

---

## Testing Strategy

### Unit Testing
- Test each service method after refactoring
- Verify entity mapping works correctly
- Test CRUD operations

### Integration Testing
- Test API endpoints after controller updates
- Verify database operations work
- Test entity relationships (navigation properties)

### Migration Testing
- Test migration on development database
- Verify all tables created correctly
- Check indexes and constraints
- Validate soft delete filters work

---

## Rollback Plan

If migration fails:

1. **Code Rollback**: Git reset to commit before migration started
2. **Database Rollback**: 
   ```bash
   dotnet ef database update 0  # Remove all migrations
   ```
3. **Restore DatabaseModels**: Keep old DatabaseModels folder as backup

---

## Success Criteria

- ✅ Zero compilation errors in BusinessLogic project
- ✅ Zero compilation errors in SkillIT-API project
- ✅ All unit tests pass
- ✅ EF Core migration generates successfully
- ✅ Migration applies to database without errors
- ✅ All API endpoints functional
- ✅ Soft delete filters working
- ✅ Audit trail (CreatedAt/By, UpdatedAt/By) populating correctly
- ✅ Database indexes created as configured

---

## Estimated Effort

| Phase | Tasks | Estimated Time |
|-------|-------|----------------|
| Phase 1: Interfaces | 18 files | 2-3 hours |
| Phase 2: Services | 18 files | 8-12 hours |
| Phase 3: Controllers | 10+ files | 4-6 hours |
| Phase 4: Migration | Testing & fixes | 2-4 hours |
| **Total** | **46+ files** | **16-25 hours** |

---

## Implementation Order

### Priority 1: Foundation Services
1. EntityService (base operations)
2. AccountService (authentication dependency)
3. AuthenticationService (core functionality)
4. UserService (widely used)

### Priority 2: Core Services
5. CourseService (largest, most complex)
6. EnrollmentService (course dependency)
7. QuizService (course dependency)

### Priority 3: Supporting Services
8. CatalogService
9. SkillService
10. SocialService
11. NotificationService
12. OTPService

### Priority 4: Feature Services
13. EngagementService
14. AnalyticsService
15. UserAchievementService
16. UserCertificateService
17. UserSkillService
18. UserSocialService

### Priority 5: Controllers
Update all controllers after services are complete

---

## Notes

- Keep old DatabaseModels folder until migration is fully validated
- Create feature branch for migration work: `feature/code-first-migration`
- Commit after each completed service for easier debugging
- Update API documentation after migration completes
- Consider adding AutoMapper for DTO mapping in future iterations

---

## Next Steps

1. ✅ Review and approve this migration plan
2. Create feature branch: `git checkout -b feature/code-first-migration`
3. Start Phase 1: Update service interfaces
4. Start Phase 2: Update service implementations (Priority 1 first)
5. Start Phase 3: Update controllers
6. Generate and test migration
7. Merge to master after validation

---

**Document Status:** Draft  
**Last Updated:** January 1, 2026  
**Author:** GitHub Copilot
