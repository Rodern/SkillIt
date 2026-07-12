# SkillIT - Deployment Guide

This guide covers deploying the SkillIT application to various environments.

## Prerequisites

- MySQL database (cloud or on-premises)
- .NET 6.0+ runtime
- HTTPS certificate (production)
- SendGrid account for emails
- (Optional) Azure App Service or similar hosting

## Environment Configuration

### 1. Database Setup

#### Production Database

Create your production database:

```sql
CREATE DATABASE skill_it_db CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci;
CREATE USER 'skillit_user'@'%' IDENTIFIED BY 'STRONG_PASSWORD';
GRANT ALL PRIVILEGES ON skill_it_db.* TO 'skillit_user'@'%';
FLUSH PRIVILEGES;
```

#### Run Migrations

```bash
cd SkillIT-Models
dotnet ef database update --context skill_it_dbContext --connection "server=YOUR_SERVER;database=skill_it_db;user=skillit_user;password=YOUR_PASSWORD"
```

### 2. Application Configuration

#### Using Environment Variables

Set these environment variables on your hosting platform:

```bash
# Database
ConnectionStrings__Default="server=YOUR_SERVER;port=3306;database=skill_it_db;user=skillit_user;password=YOUR_PASSWORD"

# JWT
JwtSettings__SecretKey="YOUR_PRODUCTION_JWT_SECRET_KEY_MINIMUM_32_CHARACTERS"
JwtSettings__Issuer="SkillIT-API"
JwtSettings__Audience="SkillIT-Client"
JwtSettings__ExpirationMinutes="60"

# Email
EmailSettings__SendGridApiKey="SG.YOUR_SENDGRID_API_KEY"
EmailSettings__FromEmail="noreply@skillit.com"
EmailSettings__FromName="SkillIT Educate"

# Logging
Logging__LogLevel__Default="Warning"
Logging__LogLevel__Microsoft="Warning"

# CORS (adjust for your domain)
CORS__AllowedOrigins="https://www.skillit.com,https://skillit.com"
```

#### Using Azure Key Vault

For Azure deployments, use Key Vault:

```csharp
// In Program.cs
if (builder.Environment.IsProduction())
{
    var keyVaultEndpoint = new Uri(builder.Configuration["KeyVault:Endpoint"]);
    builder.Configuration.AddAzureKeyVault(keyVaultEndpoint, new DefaultAzureCredential());
}
```

Store secrets in Key Vault:
- `ConnectionStrings--Default`
- `JwtSettings--SecretKey`
- `EmailSettings--SendGridApiKey`

## Deployment Options

### Option 1: Azure App Service

#### Using Azure CLI

```bash
# Login to Azure
az login

# Create resource group
az group create --name SkillIT-RG --location eastus

# Create App Service plan
az appservice plan create --name SkillIT-Plan --resource-group SkillIT-RG --sku B1 --is-linux

# Create web app for API
az webapp create --name skillit-api --resource-group SkillIT-RG --plan SkillIT-Plan --runtime "DOTNETCORE:6.0"

# Create web app for UI
az webapp create --name skillit-ui --resource-group SkillIT-RG --plan SkillIT-Plan --runtime "DOTNETCORE:7.0"

# Configure app settings
az webapp config appsettings set --name skillit-api --resource-group SkillIT-RG --settings \
    ConnectionStrings__Default="YOUR_CONNECTION_STRING" \
    JwtSettings__SecretKey="YOUR_SECRET_KEY"

# Deploy
cd SkillIT-API
dotnet publish -c Release -o ./publish
az webapp deployment source config-zip --name skillit-api --resource-group SkillIT-RG --src publish.zip
```

#### Using Visual Studio

1. Right-click SkillIT-API project → Publish
2. Choose Azure → Azure App Service (Linux)
3. Create new or select existing App Service
4. Configure settings
5. Publish

### Option 2: Docker Container

#### Create Dockerfiles

**SkillIT-API/Dockerfile:**

```dockerfile
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["SkillIT-API/SkillIT-API.csproj", "SkillIT-API/"]
COPY ["BusinessLogic/BusinessLogic.csproj", "BusinessLogic/"]
COPY ["SkillIT-Models/SkillIT-Models.csproj", "SkillIT-Models/"]
RUN dotnet restore "SkillIT-API/SkillIT-API.csproj"
COPY . .
WORKDIR "/src/SkillIT-API"
RUN dotnet build "SkillIT-API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SkillIT-API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SkillIT-API.dll"]
```

**docker-compose.yml:**

```yaml
version: '3.8'

services:
  mysql:
    image: mysql:8.0
    environment:
      MYSQL_ROOT_PASSWORD: rootpassword
      MYSQL_DATABASE: skill_it_db
      MYSQL_USER: skillit_user
      MYSQL_PASSWORD: skillit_password
    ports:
      - "3306:3306"
    volumes:
      - mysql_data:/var/lib/mysql

  api:
    build:
      context: .
      dockerfile: SkillIT-API/Dockerfile
    environment:
      - ConnectionStrings__Default=server=mysql;port=3306;database=skill_it_db;user=skillit_user;password=skillit_password
      - JwtSettings__SecretKey=${JWT_SECRET_KEY}
      - EmailSettings__SendGridApiKey=${SENDGRID_API_KEY}
    ports:
      - "5000:80"
      - "5001:443"
    depends_on:
      - mysql

  ui:
    build:
      context: .
      dockerfile: SkillIT-UI/Dockerfile
    environment:
      - ConnectionStrings__Default=server=mysql;port=3306;database=skill_it_db;user=skillit_user;password=skillit_password
      - JwtSettings__SecretKey=${JWT_SECRET_KEY}
    ports:
      - "5002:80"
      - "5003:443"
    depends_on:
      - mysql
      - api

volumes:
  mysql_data:
```

#### Deploy with Docker

```bash
# Build and run
docker-compose up -d

# View logs
docker-compose logs -f

# Stop
docker-compose down
```

### Option 3: Traditional Server (IIS)

1. **Install Prerequisites**
   - .NET 6.0+ Runtime
   - .NET 7.0 Runtime (for UI)
   - ASP.NET Core Hosting Bundle

2. **Publish Applications**

```bash
dotnet publish SkillIT-API/SkillIT-API.csproj -c Release -o C:\inetpub\skillit-api
dotnet publish SkillIT-UI/SkillIT-UI.csproj -c Release -o C:\inetpub\skillit-ui
```

3. **Configure IIS**
   - Create Application Pool (.NET CLR Version: No Managed Code)
   - Create Website pointing to publish directory
   - Configure bindings (HTTP/HTTPS)
   - Set environment variables in web.config

4. **Configure web.config**

```xml
<?xml version="1.0" encoding="utf-8"?>
<configuration>
  <system.webServer>
    <handlers>
      <add name="aspNetCore" path="*" verb="*" modules="AspNetCoreModuleV2" resourceType="Unspecified" />
    </handlers>
    <aspNetCore processPath="dotnet" 
                arguments=".\SkillIT-API.dll" 
                stdoutLogEnabled="false" 
                stdoutLogFile=".\logs\stdout" 
                hostingModel="inprocess">
      <environmentVariables>
        <environmentVariable name="ConnectionStrings__Default" value="YOUR_CONNECTION_STRING" />
        <environmentVariable name="JwtSettings__SecretKey" value="YOUR_SECRET_KEY" />
      </environmentVariables>
    </aspNetCore>
  </system.webServer>
</configuration>
```

## Post-Deployment

### 1. Health Check

Create a health check endpoint:

```bash
curl https://your-api-domain/health
```

### 2. Database Migration

Ensure migrations are applied:

```bash
dotnet ef database update --context skill_it_dbContext
```

### 3. Verify Configuration

- Test user registration
- Test login
- Test course creation
- Check email delivery
- Verify HTTPS is working
- Test API endpoints

### 4. Monitoring Setup

- Configure application insights (Azure)
- Set up error tracking
- Configure performance monitoring
- Set up uptime monitoring

### 5. Backup Strategy

- Daily database backups
- Application configuration backups
- User-uploaded files backup
- Retention policy (30 days minimum)

## SSL/TLS Certificate

### Using Let's Encrypt (Free)

```bash
# Install Certbot
sudo apt-get install certbot

# Get certificate
sudo certbot certonly --standalone -d api.skillit.com

# Auto-renewal
sudo certbot renew --dry-run
```

### Using Azure App Service

SSL certificates are managed automatically in Azure App Service when using custom domains.

## Performance Optimization

### 1. Enable Response Compression

Already configured in the application.

### 2. Use CDN for Static Assets

Configure CDN for wwwroot files in production.

### 3. Connection Pooling

Ensure connection string has pooling enabled:

```
server=...;Pooling=true;MinPoolSize=5;MaxPoolSize=100;
```

### 4. Response Caching

Already implemented via MemoryCache. For production, consider Redis:

```bash
dotnet add package Microsoft.Extensions.Caching.StackExchangeRedis
```

## Troubleshooting

### Application Won't Start

- Check logs in `/logs` directory
- Verify environment variables
- Check database connectivity
- Ensure .NET runtime is installed

### Database Connection Fails

- Verify connection string
- Check firewall rules
- Confirm database server is running
- Test with MySQL client

### JWT Errors

- Ensure secret keys match between API and UI
- Verify token expiration settings
- Check clock synchronization

## Rollback Procedure

1. Stop the application
2. Restore previous application files
3. Rollback database if needed
4. Restart application
5. Verify functionality

## Security Checklist

- [ ] HTTPS enabled and enforced
- [ ] Secrets stored securely (not in code)
- [ ] Database uses non-root user
- [ ] Firewall configured
- [ ] Regular security updates applied
- [ ] Error messages don't expose sensitive info
- [ ] CORS properly configured
- [ ] SQL injection protection verified
- [ ] XSS protection enabled
- [ ] Rate limiting configured

## Support

For deployment issues:
- Check logs first
- Review this guide
- Contact: devops@skillit.com
