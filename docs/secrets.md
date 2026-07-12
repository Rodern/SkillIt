# User Secrets Configuration Guide

This guide explains how to configure user secrets for the SkillIT application.

## Why User Secrets?

User Secrets keep sensitive data (passwords, API keys, connection strings) out of your source code and version control. They are stored locally on your development machine.

## Setup Instructions

### For SkillIT-API Project

1. **Initialize User Secrets**

```bash
cd SkillIT-API
dotnet user-secrets init
```

2. **Set Required Secrets**

```bash
# Database Connection String
dotnet user-secrets set "ConnectionStrings:Default" "server=localhost;port=3306;database=skill_it_db;user=root;password=YOUR_MYSQL_PASSWORD"

# JWT Settings
dotnet user-secrets set "JwtSettings:SecretKey" "YourSecureJwtSecretKeyMustBeAtLeast32CharactersLongForHS256Algorithm"

# Email Settings (SendGrid)
dotnet user-secrets set "EmailSettings:SendGridApiKey" "SG.your_sendgrid_api_key_here"
dotnet user-secrets set "EmailSettings:FromEmail" "noreply@skillit.com"
```

### For SkillIT-UI Project

1. **Initialize User Secrets**

```bash
cd ../SkillIT-UI
dotnet user-secrets init
```

2. **Set Required Secrets**

```bash
# Database Connection String (same as API)
dotnet user-secrets set "ConnectionStrings:Default" "server=localhost;port=3306;database=skill_it_db;user=root;password=YOUR_MYSQL_PASSWORD"

# JWT Settings (MUST match API settings)
dotnet user-secrets set "JwtSettings:SecretKey" "YourSecureJwtSecretKeyMustBeAtLeast32CharactersLongForHS256Algorithm"
```

## Important Notes

### JWT Secret Key

- **CRITICAL**: Use the SAME secret key for both API and UI projects
- Must be at least 32 characters long for HS256 algorithm
- Use a strong, randomly generated key
- Never commit this to source control

Generate a secure key using PowerShell:
```powershell
-join ((48..57) + (65..90) + (97..122) | Get-Random -Count 64 | % {[char]$_})
```

### Database Connection String

- Replace `YOUR_MYSQL_PASSWORD` with your actual MySQL root password
- For production, use a dedicated database user (not root)
- Ensure MySQL server is running on localhost:3306

### SendGrid API Key

1. Sign up for a free SendGrid account at https://sendgrid.com
2. Create an API key with "Mail Send" permissions
3. Use the generated API key in your configuration

## Viewing Your Secrets

To list all configured secrets:

```bash
dotnet user-secrets list
```

## Removing Secrets

To remove a specific secret:

```bash
dotnet user-secrets remove "SecretKeyName"
```

To clear all secrets:

```bash
dotnet user-secrets clear
```

## Production Configuration

For production deployments, use:
- **Azure**: Azure Key Vault
- **AWS**: AWS Secrets Manager
- **Environment Variables**: For containerized deployments

Never use User Secrets in production!

## Troubleshooting

### "JWT Secret Key not configured" Error

Make sure you've set the `JwtSettings:SecretKey` in both projects.

### "Database connection string not configured" Error

Verify you've set `ConnectionStrings:Default` and that it's not the placeholder value.

### Secrets Not Working

1. Ensure you ran `dotnet user-secrets init` in each project directory
2. Check that the secrets.json file exists:
   - Windows: `%APPDATA%\Microsoft\UserSecrets\<user_secrets_id>\secrets.json`
   - macOS/Linux: `~/.microsoft/usersecrets/<user_secrets_id>/secrets.json`

## Security Best Practices

1. ✅ Never commit user secrets to version control
2. ✅ Use different secrets for development and production
3. ✅ Rotate secrets regularly
4. ✅ Use strong, randomly generated keys
5. ✅ Keep SendGrid API keys restricted to minimum permissions
6. ❌ Don't share secrets via email or messaging
7. ❌ Don't hardcode secrets in your code

## Template secrets.json

For reference, your secrets.json should look like this:

```json
{
  "ConnectionStrings:Default": "server=localhost;port=3306;database=skill_it_db;user=root;password=YOUR_PASSWORD",
  "JwtSettings:SecretKey": "YOUR_SECURE_SECRET_KEY_HERE",
  "EmailSettings:SendGridApiKey": "SG.YOUR_API_KEY",
  "EmailSettings:FromEmail": "noreply@skillit.com"
}
```

This file is automatically created and managed by the `dotnet user-secrets` command.
