param(
    [string]$BaseUrl = "http://localhost:5276",
    [string]$Email = "admin@admin.com",
    [string]$Password = "Passw0rd!"
)

$ErrorActionPreference = "Stop"
$base = $BaseUrl.TrimEnd("/")

function Invoke-Api {
    param(
        [string]$Method,
        [string]$Path,
        [object]$Body = $null,
        [string]$Token = $null
    )

    $headers = @{ "Content-Type" = "application/json" }
    if ($Token) {
        $headers["Authorization"] = "Bearer $Token"
    }

    $params = @{
        Uri = "$base$Path"
        Method = $Method
        Headers = $headers
    }

    if ($null -ne $Body) {
        $params["Body"] = ($Body | ConvertTo-Json)
    }

    return Invoke-RestMethod @params
}

Write-Host "Smoke test against $base"

Write-Host "[1/5] Register test user (if needed)..."
$testEmail = "smoke-$([Guid]::NewGuid().ToString('N').Substring(0, 8))@test.local"
$testPassword = "Passw0rd!"
try {
    Invoke-Api -Method Post -Path "/api/Players/Register" -Body @{
        email = $testEmail
        password = $testPassword
        passwordConfirm = $testPassword
    } | Out-Null
    Write-Host "  OK - registered $testEmail"
} catch {
    Write-Host "  Register skipped or failed, trying login with provided credentials."
    $testEmail = $Email
    $testPassword = $Password
}

Write-Host "[2/5] Login..."
$login = Invoke-Api -Method Post -Path "/api/Players/Login" -Body @{
    username = $testEmail
    password = $testPassword
}

if (-not $login.token) {
    throw "Login failed: no token returned."
}
Write-Host "  OK - token received."

Write-Host "[3/5] Authenticated gold endpoint..."
$gold = Invoke-Api -Method Get -Path "/api/Players/GetGold" -Token $login.token
Write-Host "  OK - gold: $gold"

Write-Host "[4/5] Player stats..."
$stats = Invoke-Api -Method Get -Path "/api/Statistics/GetPlayerStats" -Token $login.token
Write-Host "  OK - wins: $($stats.wins), losses: $($stats.losses)"

Write-Host "[5/5] Public pack list..."
$packs = Invoke-Api -Method Get -Path "/api/Pack/GetAllPacks"
Write-Host "  OK - packs: $($packs.Count)"

Write-Host ""
Write-Host "Smoke test passed."
Write-Host "Manual checks still required: matchmaking, play card, end turn, surrender (SignalR)."
