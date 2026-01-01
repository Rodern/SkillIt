# Migration Guide: Version 1.x to 2.0

This guide helps you migrate from the previous version of SkillIT to version 2.0 with all the improvements.

## ⚠️ Breaking Changes

### 1. API Versioning
- **Old:** `/api/course/getCourses`
- **New:** `/api/v1/courses`

All API endpoints now include `/v1/` in the path. Update any API clients.

### 2. User Secrets Required
- **Old:** Credentials in `appsettings.json`
- **New:** Must configure User Secrets

You **cannot** run the application without configuring User Secrets first.

### 3. HTTP Methods Changed
Some endpoints now use proper HTTP verbs:

| Endpoint | Old Method | New Method |
|----------|------------|------------|
| Get User | POST | GET |
| Check Email | POST | GET |
| Get Course Chapters | POST | GET |

### 4. Response Format Changes
List endpoints now return paginated results:

**Old Response:**
```json
[
  { "courseId": 1, "name": "..." },
  { "courseId": 2, "name": "..." }
]
```

**New Response:**
```json
{
  "pageNumber": 1,
  "pageSize": 20,
  "totalCount": 50,
  "totalPages": 3,
  "hasPreviousPage": false,
  "hasNextPage": true,
  "items": [
    { "courseId": 1, "name": "..." },
    { "courseId": 2, "name": "..." }
  ]
}
```

## 📋 Migration Checklist

### Step 1: Backup
- [ ] Backup your database
- [ ] Backup `appsettings.json` files (for reference)
- [ ] Commit any uncommitted changes

### Step 2: Pull Latest Changes
```bash
git pull origin main
```

### Step 3: Configure User Secrets

**Option A: Use Setup Script (Recommended)**

Windows:
```powershell
.\setup.ps1
```

Linux/Mac:
```bash
chmod +x setup.sh
./setup.sh
```

**Option B: Manual Configuration**

Follow the instructions in [SETUP_USER_SECRETS.md](SETUP_USER_SECRETS.md).

### Step 4: Update Dependencies
```bash
dotnet restore SkillIt.sln
```

### Step 5: Database Migrations
```bash
cd SkillIT-Models
dotnet ef database update
```

### Step 6: Build Solution
```bash
cd ..
dotnet build SkillIt.sln
```

### Step 7: Update API Clients

If you have external API clients (mobile apps, SPAs, etc.), update them:

1. **Update Base URLs:**
   - Change `/api/course/` to `/api/v1/courses/`
   - Change `/api/User/` to `/api/v1/users/`

2. **Update HTTP Methods:**
   - `CheckEmailExistence`: POST → GET with query parameter
   - `GetUser`: POST → GET with route parameter
   - `GetCourseChapters`: POST → GET

3. **Handle Paginated Responses:**
   - Parse `items` array from response
   - Handle `pageNumber`, `totalPages`, etc.

### Step 8: Test Application

Start both applications and verify:

- [ ] API starts successfully
- [ ] UI starts successfully
- [ ] Can login
- [ ] Can view courses
- [ ] Can create course (if admin)
- [ ] Pagination works
- [ ] Caching works

## 🔧 Code Updates Required

### If You Extended Controllers

Update your controller routes:

**Before:**
```csharp
[Route("api/[controller]")]
```

**After:**
```csharp
[Route("api/v1/[controller]s")]
```

### If You Used Services Directly

Update to use ILogger:

**Before:**
```csharp
public MyService(skill_it_dbContext context)
{
    _context = context;
}
```

**After:**
```csharp
public MyService(skill_it_dbContext context, ILogger<MyService> logger = null)
{
    _context = context;
    _logger = logger;
}
```

### If You Called APIs

**Before:**
```javascript
fetch('/api/course/getCourses')
  .then(response => response.json())
  .then(courses => {
    // courses is an array
    courses.forEach(course => console.log(course.name));
  });
```

**After:**
```javascript
fetch('/api/v1/courses?pageNumber=1&pageSize=20')
  .then(response => response.json())
  .then(result => {
    // result is a paginated object
    const courses = result.items;
    courses.forEach(course => console.log(course.name));
    
    // Handle pagination
    console.log(`Page ${result.pageNumber} of ${result.totalPages}`);
  });
```

## 🔑 Environment Variables for Production

When deploying to production, set these environment variables instead of User Secrets:

```bash
ConnectionStrings__Default="server=...;database=...;user=...;password=..."
JwtSettings__SecretKey="your-production-secret-key"
EmailSettings__SendGridApiKey="SG.your-api-key"
EmailSettings__FromEmail="noreply@yourdomain.com"
```

## 📊 Performance Improvements

You should notice:

- **Faster API responses** (due to caching)
- **Lower memory usage** (due to AsNoTracking)
- **Reduced data transfer** (due to pagination)
- **Better error messages** (due to improved error handling)

## 🐛 Troubleshooting

### "JWT Secret Key not configured"

**Solution:** Configure User Secrets (see Step 3)

```bash
cd SkillIT-API
dotnet user-secrets set "JwtSettings:SecretKey" "YOUR_KEY_HERE"
```

### "Database connection string not configured"

**Solution:** Configure database connection in User Secrets

```bash
dotnet user-secrets set "ConnectionStrings:Default" "YOUR_CONNECTION_STRING"
```

### API Returns 404 for Old Routes

**Solution:** Update API calls to use new routes with `/v1/`

### Pagination Not Working

**Solution:** Ensure you're parsing the `items` property from responses

### Caching Issues

**Solution:** Restart the application to clear memory cache

## 🔄 Rollback Procedure

If you need to rollback:

1. Stop both applications
2. Checkout previous version:
   ```bash
   git checkout v1.0.0
   ```
3. Restore previous database backup
4. Restore old appsettings.json files
5. Rebuild and run

## 📞 Support

If you encounter issues during migration:

1. Check this guide thoroughly
2. Review [IMPROVEMENTS_SUMMARY.md](IMPROVEMENTS_SUMMARY.md)
3. Check [CHANGELOG.md](CHANGELOG.md) for all changes
4. Open an issue on GitHub

## ✅ Post-Migration Verification

Run this checklist to ensure everything works:

### API Verification
- [ ] `GET /api/v1/courses` returns paginated results
- [ ] `GET /api/v1/courses/{id}` returns single course
- [ ] `GET /api/v1/users/check-email?email=test@test.com` works
- [ ] Authentication with JWT works
- [ ] Swagger UI accessible at `/swagger`

### UI Verification
- [ ] Home page loads
- [ ] Login works
- [ ] Course listing shows
- [ ] Course detail page works
- [ ] User dashboard loads
- [ ] Profile picture upload works

### Performance Verification
- [ ] Second request for courses is faster (cache hit)
- [ ] Large course lists are paginated
- [ ] No N+1 query issues in logs

### Security Verification
- [ ] No secrets visible in appsettings.json
- [ ] User secrets configured correctly
- [ ] HTTPS enforced
- [ ] JWT tokens expire correctly

## 🎉 Migration Complete!

Once you've completed all steps and verifications, you're running version 2.0 with all improvements!

Welcome to the new and improved SkillIT! 🚀

---

**Migration Guide Version:** 2.0.0  
**Last Updated:** January 1, 2026
