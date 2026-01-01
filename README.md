# SkillIT - Learning Management System

[![.NET](https://img.shields.io/badge/.NET-6.0%20%7C%207.0-512BD4)](https://dotnet.microsoft.com/)
[![License](https://img.shields.io/badge/license-MIT-blue.svg)](LICENSE)

SkillIT is a comprehensive Learning Management System (LMS) designed to empower young Cameroonians with skills to fit the demands of the African tech system. The platform provides course management, skill tracking, achievements, certifications, and interactive learning experiences.

## 🚀 Features

- **Course Management**: Hierarchical course structure (Courses → Chapters → Lessons → Content)
- **User Authentication**: JWT-based authentication with role-based access control
- **Enrollment System**: Track user progress and course completions
- **Assessment Engine**: Quizzes, questions, and automated grading
- **Gamification**: Achievements, certificates, and skill badges
- **Content Cataloging**: Organize learning materials by categories
- **Email Notifications**: Automated emails for registration, completion, and password reset
- **RESTful API**: Well-documented API with Swagger/OpenAPI
- **Blazor UI**: Modern, interactive server-side Blazor web application

## 📋 Prerequisites

- [.NET 6.0 SDK](https://dotnet.microsoft.com/download/dotnet/6.0) or later
- [.NET 7.0 SDK](https://dotnet.microsoft.com/download/dotnet/7.0) (for UI project)
- [MySQL Server](https://dev.mysql.com/downloads/mysql/) 5.7 or later
- [Visual Studio 2022](https://visualstudio.microsoft.com/) or [VS Code](https://code.visualstudio.com/)

## 🏗️ Architecture

```
SkillIt/
├── SkillIT-API/          # RESTful API (ASP.NET Core)
├── SkillIT-UI/           # Blazor Server UI
├── BusinessLogic/        # Business logic layer
└── SkillIT-Models/       # Data models & database entities
```

### Technology Stack

- **Backend**: ASP.NET Core 6.0
- **Frontend**: Blazor Server (.NET 7.0)
- **Database**: MySQL with Entity Framework Core
- **Authentication**: JWT Bearer tokens
- **Styling**: TailwindCSS
- **Email**: SendGrid
- **Caching**: In-memory cache (production-ready for distributed cache)

## ⚙️ Installation & Setup

### 1. Clone the Repository

```bash
git clone https://github.com/yourusername/SkillIt.git
cd SkillIt
```

### 2. Configure User Secrets

For security, sensitive configuration is stored in User Secrets. Set them up for both projects:

#### For API Project:

```bash
cd SkillIT-API
dotnet user-secrets init
dotnet user-secrets set "ConnectionStrings:Default" "server=localhost;port=3306;database=skill_it_db;user=root;password=YOUR_PASSWORD"
dotnet user-secrets set "JwtSettings:SecretKey" "YOUR_SECURE_JWT_SECRET_KEY_AT_LEAST_32_CHARACTERS_LONG"
dotnet user-secrets set "EmailSettings:SendGridApiKey" "YOUR_SENDGRID_API_KEY"
dotnet user-secrets set "EmailSettings:FromEmail" "noreply@skillit.com"
```

#### For UI Project:

```bash
cd ../SkillIT-UI
dotnet user-secrets init
dotnet user-secrets set "ConnectionStrings:Default" "server=localhost;port=3306;database=skill_it_db;user=root;password=YOUR_PASSWORD"
dotnet user-secrets set "JwtSettings:SecretKey" "YOUR_SECURE_JWT_SECRET_KEY_AT_LEAST_32_CHARACTERS_LONG"
```

> **Note**: Use the same JWT secret key for both projects!

### 3. Database Setup

Create the MySQL database:

```sql
CREATE DATABASE skill_it_db;
```

Run Entity Framework migrations:

```bash
cd SkillIT-Models
dotnet ef database update --context skill_it_dbContext
```

### 4. Build the Solution

```bash
cd ..
dotnet build SkillIt.sln
```

### 5. Run the Applications

#### Option A: Run Both Projects Simultaneously (Recommended)

In Visual Studio:
1. Right-click the solution → Properties
2. Select "Multiple startup projects"
3. Set both `SkillIT-API` and `SkillIT-UI` to "Start"
4. Press F5

#### Option B: Run Separately

**Terminal 1 - API:**
```bash
cd SkillIT-API
dotnet run
```

**Terminal 2 - UI:**
```bash
cd SkillIT-UI
dotnet run
```

## 🔑 Default Access

After setup, access the application at:

- **UI**: https://localhost:5001 (or check console output)
- **API**: https://localhost:7001 (or check console output)
- **Swagger**: https://localhost:7001/swagger

## 📚 API Documentation

The API is documented using Swagger/OpenAPI. When running in development mode, access the interactive documentation at:

```
https://localhost:7001/swagger
```

### Key API Endpoints

#### Authentication
- `POST /api/Authenticate` - Login
- `POST /api/CreateOTP/{email}` - Generate password reset OTP
- `POST /api/Reset` - Reset password

#### Courses
- `GET /api/v1/courses` - Get all courses (paginated)
- `GET /api/v1/courses/{id}` - Get course by ID
- `POST /api/v1/courses` - Create course (admin/creator only)
- `PUT /api/v1/courses/{id}` - Update course
- `DELETE /api/v1/courses/{id}` - Delete course (admin only)

#### Users
- `GET /api/User/GetAllUsers` - Get all users
- `POST /api/User/AddUser` - Register new user
- `PUT /api/User/UpdateUser` - Update user profile

## 🔒 Security Best Practices

1. **Never commit secrets** to version control
2. **Use User Secrets** for local development
3. **Use Azure Key Vault** or similar for production
4. **Rotate JWT keys** regularly
5. **Enable HTTPS** in production
6. **Keep packages updated** for security patches

## 🧪 Testing

*(Test infrastructure to be added)*

```bash
# Run unit tests
dotnet test

# Run with coverage
dotnet test /p:CollectCoverage=true
```

## 📦 Deployment

### Prerequisites for Production

1. MySQL database (Azure Database for MySQL, AWS RDS, etc.)
2. Application hosting (Azure App Service, AWS, etc.)
3. Email service (SendGrid account)
4. SSL certificate

### Configuration

Update production `appsettings.Production.json`:

```json
{
  "Logging": {
    "LogLevel": {
      "Default": "Warning"
    }
  },
  "ConnectionStrings": {
    "Default": "USE_ENVIRONMENT_VARIABLE_OR_KEY_VAULT"
  }
}
```

## 🤝 Contributing

1. Fork the repository
2. Create a feature branch (`git checkout -b feature/AmazingFeature`)
3. Commit your changes (`git commit -m 'Add some AmazingFeature'`)
4. Push to the branch (`git push origin feature/AmazingFeature`)
5. Open a Pull Request

## 📝 License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

## 👥 Authors

- **Your Name** - *Initial work*

## 🙏 Acknowledgments

- Built for empowering young Cameroonians with tech skills
- Uses modern .NET technologies
- Designed for scalability and maintainability

## 📞 Support

For support, email support@skillit.com or open an issue in the GitHub repository.

## 🗺️ Roadmap

- [ ] Unit and integration tests
- [ ] Docker support
- [ ] CI/CD pipeline
- [ ] Mobile application
- [ ] Real-time notifications (SignalR)
- [ ] Advanced analytics and reporting
- [ ] Multi-language support
- [ ] Video content support
- [ ] Live streaming classes

---

**Made with ❤️ for African tech education**
