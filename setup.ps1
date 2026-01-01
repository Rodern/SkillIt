# SkillIT Quick Setup Script
# Run this script to configure User Secrets for development

Write-Host "==================================" -ForegroundColor Cyan
Write-Host "  SkillIT Quick Setup Script" -ForegroundColor Cyan
Write-Host "==================================" -ForegroundColor Cyan
Write-Host ""

# Check if .NET is installed
try {
    $dotnetVersion = dotnet --version
    Write-Host "✓ .NET SDK detected: $dotnetVersion" -ForegroundColor Green
} catch {
    Write-Host "✗ .NET SDK not found. Please install .NET 6.0 or later." -ForegroundColor Red
    exit 1
}

Write-Host ""
Write-Host "This script will help you configure User Secrets for the SkillIT application." -ForegroundColor Yellow
Write-Host ""

# Collect configuration values
Write-Host "Please provide the following information:" -ForegroundColor Cyan
Write-Host ""

# Database Configuration
Write-Host "[Database Configuration]" -ForegroundColor Yellow
$dbServer = Read-Host "MySQL Server (default: localhost)"
if ([string]::IsNullOrWhiteSpace($dbServer)) { $dbServer = "localhost" }

$dbPort = Read-Host "MySQL Port (default: 3306)"
if ([string]::IsNullOrWhiteSpace($dbPort)) { $dbPort = "3306" }

$dbName = Read-Host "Database Name (default: skill_it_db)"
if ([string]::IsNullOrWhiteSpace($dbName)) { $dbName = "skill_it_db" }

$dbUser = Read-Host "Database User (default: root)"
if ([string]::IsNullOrWhiteSpace($dbUser)) { $dbUser = "root" }

$dbPassword = Read-Host "Database Password" -AsSecureString
$dbPasswordPlain = [Runtime.InteropServices.Marshal]::PtrToStringAuto([Runtime.InteropServices.Marshal]::SecureStringToBSTR($dbPassword))

$connectionString = "server=$dbServer;port=$dbPort;database=$dbName;user=$dbUser;password=$dbPasswordPlain"

Write-Host ""
Write-Host "[JWT Configuration]" -ForegroundColor Yellow
Write-Host "Generating secure JWT secret key..." -ForegroundColor Gray
$jwtSecret = -join ((48..57) + (65..90) + (97..122) | Get-Random -Count 64 | ForEach-Object {[char]$_})
Write-Host "✓ JWT secret generated (64 characters)" -ForegroundColor Green

Write-Host ""
Write-Host "[Email Configuration (Optional)]" -ForegroundColor Yellow
$sendGridApiKey = Read-Host "SendGrid API Key (press Enter to skip)"
$fromEmail = Read-Host "From Email Address (default: noreply@skillit.com)"
if ([string]::IsNullOrWhiteSpace($fromEmail)) { $fromEmail = "noreply@skillit.com" }

Write-Host ""
Write-Host "==================================" -ForegroundColor Cyan
Write-Host "Configuring User Secrets..." -ForegroundColor Cyan
Write-Host "==================================" -ForegroundColor Cyan
Write-Host ""

# Configure SkillIT-API
Write-Host "Configuring SkillIT-API..." -ForegroundColor Yellow
Push-Location SkillIT-API

# Initialize user secrets if not already done
$null = dotnet user-secrets init 2>&1

# Set secrets
dotnet user-secrets set "ConnectionStrings:Default" $connectionString
dotnet user-secrets set "JwtSettings:SecretKey" $jwtSecret

if (![string]::IsNullOrWhiteSpace($sendGridApiKey)) {
    dotnet user-secrets set "EmailSettings:SendGridApiKey" $sendGridApiKey
    dotnet user-secrets set "EmailSettings:FromEmail" $fromEmail
}

Write-Host "✓ SkillIT-API secrets configured" -ForegroundColor Green
Pop-Location

# Configure SkillIT-UI
Write-Host "Configuring SkillIT-UI..." -ForegroundColor Yellow
Push-Location SkillIT-UI

# Initialize user secrets if not already done
$null = dotnet user-secrets init 2>&1

# Set secrets (UI needs same connection string and JWT secret)
dotnet user-secrets set "ConnectionStrings:Default" $connectionString
dotnet user-secrets set "JwtSettings:SecretKey" $jwtSecret

Write-Host "✓ SkillIT-UI secrets configured" -ForegroundColor Green
Pop-Location

Write-Host ""
Write-Host "==================================" -ForegroundColor Cyan
Write-Host "  Configuration Complete! ✓" -ForegroundColor Green
Write-Host "==================================" -ForegroundColor Cyan
Write-Host ""
Write-Host "Summary:" -ForegroundColor Yellow
Write-Host "  - Database: $dbServer:$dbPort/$dbName" -ForegroundColor White
Write-Host "  - JWT Secret: *** (64 characters, securely stored)" -ForegroundColor White
if (![string]::IsNullOrWhiteSpace($sendGridApiKey)) {
    Write-Host "  - SendGrid: Configured" -ForegroundColor White
} else {
    Write-Host "  - SendGrid: Skipped (configure later if needed)" -ForegroundColor Gray
}

Write-Host ""
Write-Host "Next Steps:" -ForegroundColor Yellow
Write-Host "  1. Ensure MySQL server is running" -ForegroundColor White
Write-Host "  2. Run database migrations: cd SkillIT-Models && dotnet ef database update" -ForegroundColor White
Write-Host "  3. Build the solution: dotnet build SkillIt.sln" -ForegroundColor White
Write-Host "  4. Run the applications (API and UI)" -ForegroundColor White
Write-Host ""
Write-Host "To view your configured secrets:" -ForegroundColor Yellow
Write-Host "  cd SkillIT-API && dotnet user-secrets list" -ForegroundColor Gray
Write-Host "  cd SkillIT-UI && dotnet user-secrets list" -ForegroundColor Gray
Write-Host ""
Write-Host "For more information, see SETUP_USER_SECRETS.md" -ForegroundColor Cyan
Write-Host ""

# Clean up
$dbPasswordPlain = $null
[System.GC]::Collect()
