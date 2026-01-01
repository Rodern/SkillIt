#!/bin/bash

# SkillIT Quick Setup Script for Linux/Mac
# Run this script to configure User Secrets for development

echo "=================================="
echo "  SkillIT Quick Setup Script"
echo "=================================="
echo ""

# Check if .NET is installed
if ! command -v dotnet &> /dev/null; then
    echo "✗ .NET SDK not found. Please install .NET 6.0 or later."
    exit 1
fi

DOTNET_VERSION=$(dotnet --version)
echo "✓ .NET SDK detected: $DOTNET_VERSION"
echo ""

echo "This script will help you configure User Secrets for the SkillIT application."
echo ""

# Collect configuration values
echo "Please provide the following information:"
echo ""

# Database Configuration
echo "[Database Configuration]"
read -p "MySQL Server (default: localhost): " DB_SERVER
DB_SERVER=${DB_SERVER:-localhost}

read -p "MySQL Port (default: 3306): " DB_PORT
DB_PORT=${DB_PORT:-3306}

read -p "Database Name (default: skill_it_db): " DB_NAME
DB_NAME=${DB_NAME:-skill_it_db}

read -p "Database User (default: root): " DB_USER
DB_USER=${DB_USER:-root}

read -sp "Database Password: " DB_PASSWORD
echo ""

CONNECTION_STRING="server=$DB_SERVER;port=$DB_PORT;database=$DB_NAME;user=$DB_USER;password=$DB_PASSWORD"

echo ""
echo "[JWT Configuration]"
echo "Generating secure JWT secret key..."
JWT_SECRET=$(LC_ALL=C tr -dc 'A-Za-z0-9' </dev/urandom | head -c 64)
echo "✓ JWT secret generated (64 characters)"

echo ""
echo "[Email Configuration (Optional)]"
read -p "SendGrid API Key (press Enter to skip): " SENDGRID_API_KEY
read -p "From Email Address (default: noreply@skillit.com): " FROM_EMAIL
FROM_EMAIL=${FROM_EMAIL:-noreply@skillit.com}

echo ""
echo "=================================="
echo "Configuring User Secrets..."
echo "=================================="
echo ""

# Configure SkillIT-API
echo "Configuring SkillIT-API..."
cd SkillIT-API || exit

# Initialize user secrets if not already done
dotnet user-secrets init > /dev/null 2>&1

# Set secrets
dotnet user-secrets set "ConnectionStrings:Default" "$CONNECTION_STRING"
dotnet user-secrets set "JwtSettings:SecretKey" "$JWT_SECRET"

if [ -n "$SENDGRID_API_KEY" ]; then
    dotnet user-secrets set "EmailSettings:SendGridApiKey" "$SENDGRID_API_KEY"
    dotnet user-secrets set "EmailSettings:FromEmail" "$FROM_EMAIL"
fi

echo "✓ SkillIT-API secrets configured"
cd ..

# Configure SkillIT-UI
echo "Configuring SkillIT-UI..."
cd SkillIT-UI || exit

# Initialize user secrets if not already done
dotnet user-secrets init > /dev/null 2>&1

# Set secrets (UI needs same connection string and JWT secret)
dotnet user-secrets set "ConnectionStrings:Default" "$CONNECTION_STRING"
dotnet user-secrets set "JwtSettings:SecretKey" "$JWT_SECRET"

echo "✓ SkillIT-UI secrets configured"
cd ..

echo ""
echo "=================================="
echo "  Configuration Complete! ✓"
echo "=================================="
echo ""
echo "Summary:"
echo "  - Database: $DB_SERVER:$DB_PORT/$DB_NAME"
echo "  - JWT Secret: *** (64 characters, securely stored)"
if [ -n "$SENDGRID_API_KEY" ]; then
    echo "  - SendGrid: Configured"
else
    echo "  - SendGrid: Skipped (configure later if needed)"
fi

echo ""
echo "Next Steps:"
echo "  1. Ensure MySQL server is running"
echo "  2. Run database migrations: cd SkillIT-Models && dotnet ef database update"
echo "  3. Build the solution: dotnet build SkillIt.sln"
echo "  4. Run the applications (API and UI)"
echo ""
echo "To view your configured secrets:"
echo "  cd SkillIT-API && dotnet user-secrets list"
echo "  cd SkillIT-UI && dotnet user-secrets list"
echo ""
echo "For more information, see SETUP_USER_SECRETS.md"
echo ""

# Clean up sensitive variables
unset DB_PASSWORD
unset JWT_SECRET
unset SENDGRID_API_KEY
