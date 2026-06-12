param(
    [string]$ConnectionString = $env:ConnectionStrings__DefaultConnection
)

$ErrorActionPreference = "Stop"
$root = Split-Path -Parent $PSScriptRoot

if ([string]::IsNullOrWhiteSpace($ConnectionString)) {
    throw "Set ConnectionStrings__DefaultConnection or pass -ConnectionString."
}

$env:ConnectionStrings__DefaultConnection = $ConnectionString

Write-Host "Applying EF migrations..."
Push-Location $root
try {
    dotnet ef database update --project Models --startup-project WebApi
    if ($LASTEXITCODE -ne 0) { throw "dotnet ef database update failed." }
    Write-Host "Database update completed."
}
finally {
    Pop-Location
}
