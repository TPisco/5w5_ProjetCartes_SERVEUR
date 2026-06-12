# Deployment guide — Super Cartes Infinies

## Prerequisites

- .NET 8 SDK
- Node.js 18+
- SQL Server (local or Azure SQL)
- Azure App Service (API) + Azure Static Web Apps or App Service (Angular), optional

---

## 1. Server environment variables (Azure App Service)

Set these in **Configuration → Application settings**:

| Setting | Example |
|---------|---------|
| `ConnectionStrings__DefaultConnection` | `Server=tcp:....database.windows.net,1433;Database=SuperCartesInfinies;User ID=...;Password=...;Encrypt=True;` |
| `JWT_SECRET` | long random string (32+ chars) |
| `JWT_ISSUER` | `https://your-api.azurewebsites.net` |
| `JWT_AUDIENCE` | `https://your-frontend.azurestaticapps.net` |
| `CORS_ORIGINS` | `https://your-frontend.azurestaticapps.net,http://localhost:4200` |

Local development uses `WebApi/appsettings.Development.json` instead.

---

## 2. Update cloud database

From `sci-depart-main`:

```powershell
$env:ConnectionStrings__DefaultConnection = "<your-azure-sql-connection-string>"
.\scripts\update-cloud-database.ps1
```

Or:

```powershell
dotnet ef database update --project Models --startup-project WebApi
```

---

## 3. Deploy API (single instance)

```powershell
cd sci-depart-main\WebApi
dotnet publish -c Release -o ./publish
# Deploy ./publish to Azure App Service (zip deploy, GitHub Actions, or VS Publish)
```

Enable **Web sockets** on App Service (required for SignalR).

Use **one instance** unless you add Azure SignalR Service.

---

## 4. Build Angular for production

Update `src/environments/environment.prod.ts` with your real API URL, then:

```powershell
cd ngsci-depart-main
npm ci
npm run build
```

Deploy `dist/supercartesinfinies/` to Static Web Apps or any static host.

---

## 5. Smoke test

With the API running locally or in the cloud:

```powershell
.\scripts\smoke-test-api.ps1 -BaseUrl "http://localhost:5276"
```

Checks: login, authenticated endpoints, public pack list.

---

## 6. JWT / CORS checklist

- `JWT_ISSUER` must match the URL clients use to reach the API
- `JWT_AUDIENCE` must match the frontend origin used in tokens
- `CORS_ORIGINS` must include the exact frontend URL (scheme + host + port)
- Angular `environment.prod.ts` `apiUrl` must point to the same API base URL
