param(
    [string]$EnvPath,
    [string]$ProjectPath
)

if (Test-Path $EnvPath) {
    Write-Host "Loading secrets from $EnvPath into $ProjectPath..."
    Get-Content $EnvPath | ForEach-Object {
        if ($_ -match '^\s*([^#=]+)\s*=\s*(.*)\s*$') {
            $key = $matches[1].Trim()
            $value = $matches[2].Trim(" `"'")
            if (![string]::IsNullOrEmpty($key)) {
                # Suppress normal output to avoid noise on every build, but keep errors
                $null = dotnet user-secrets set "$key" "$value" --project "$ProjectPath"
            }
        }
    }
    Write-Host "Secrets loaded successfully."
} else {
    Write-Host "No .env file found at $EnvPath. Skipping secrets loading."
}
