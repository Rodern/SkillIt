# SkillIT - Learning Management System

[![.NET](https://img.shields.io/badge/.NET-8.0-512BD4)](https://dotnet.microsoft.com/)
[![License](https://img.shields.io/badge/license-MIT-blue.svg)](LICENSE)
[![Version](https://img.shields.io/badge/version-2.1.0-green)](CHANGELOG.md)

SkillIT is a comprehensive Learning Management System (LMS) designed to empower young Cameroonians with skills to fit the demands of the African tech system. The platform provides course management, skill tracking, achievements, certifications, interactive learning experiences, real-time notifications, and analytics.

## 🚀 Features

### Core Features
- **Course Management**: Hierarchical course structure (Courses → Chapters → Lessons → Content)
- **User Authentication**: JWT-based authentication with role-based access control
- **Enrollment System**: Track user progress and course completions
- **Assessment Engine**: Quizzes, questions, and automated grading
- **Gamification**: Achievements, certificates, and skill badges
- **Content Cataloging**: Organize learning materials by categories
- **Email Notifications**: Automated emails for registration, completion, and password reset

### Advanced Features (v2.1)
- **Real-Time Notifications**: SignalR-powered live updates and messaging
- **Analytics Dashboard**: Track course views, enrollments, and trending content
- **Health Monitoring**: Built-in health checks for production monitoring
- **Rate Limiting**: API protection against abuse (100 req/min)
- **Request Logging**: Comprehensive HTTP request/response logging (dev mode)
- **Pagination**: Efficient data loading for large datasets
- **Memory Caching**: Improved performance with intelligent caching
- **API Versioning**: Future-proof API design (v1)

## 📋 Prerequisites

- [.NET 8.0 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- [MySQL Server](https://dev.mysql.com/downloads/mysql/) 5.7 or later
- [Visual Studio 2022](https://visualstudio.microsoft.com/) or [VS Code](https://code.visualstudio.com/)

## 🏗️ Architecture

```
SkillIt/
├── SkillIT-API/          # RESTful API (ASP.NET Core 8.0)
│   ├── Controllers/      # API endpoints (v1)
│   ├── Middleware/       # Exception handling, logging
│   └── Hubs/            # SignalR hubs
├── SkillIT-UI/           # Blazor Server UI (8.0)
├── BusinessLogic/        # Business logic layer
│   ├── Services/        # Service implementations
│   └── Interfaces/      # Service interfaces
└── SkillIT-Models/       # Data models & database entities
    ├── DatabaseModels/  # EF Core entities
    ├── Models/          # DTOs and view models
    └── Constants/       # Application constants
```

### Technology Stack

- **Backend**: ASP.NET Core 8.0
- **Frontend**: Blazor Server 8.0
- **Database**: MySQL with Entity Framework Core 8.x
- **Authentication**: JWT Bearer tokens
- **Real-Time**: SignalR for WebSocket communication
- **Styling**: TailwindCSS
- **Email**: SendGrid
- **Caching**: IMemoryCache (extensible to Redis)
- **API Documentation**: Swagger/OpenAPI

## ⚙️ Quick Start

### Automated Setup (Recommended)

**Windows:**
```powershell
.\setup.ps1
```

**Linux/Mac:**
```bash
chmod +x setup.sh
./setup.sh
```

The setup script will:
- Generate secure JWT keys
- Configure database connections
- Set up user secrets for both projects
- Validate configuration

### Manual Setup

See [docs/secrets.md](docs/secrets.md) for detailed manual setup instructions.

## 📦 Installation

### 1. Clone the Repository

```bash
git clone https://github.com/Rodern/SkillIt.git
cd SkillIt
```

### 2. Configure Secrets

Run the automated setup script (see Quick Start above) or configure manually.

### 3. Database Setup

Create the MySQL database:

```sql
CREATE DATABASE skill_it_db;
```

Run Entity Framework migrations:

```bash
cd SkillIT-Models
dotnet ef migrations add InitialCreate
dotnet ef database update
```

### 4. Build and Run

```bash
# Build entire solution
dotnet build SkillIt.sln

# Run API
cd SkillIT-API
dotnet run

# In another terminal, run UI
cd SkillIT-UI
dotnet run
```
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
