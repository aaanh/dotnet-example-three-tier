> [!NOTE]
> This README was generated with GPT-5 (Instant). Only covers getting up and running.

# Example Three-Tier Application

[![CI](https://github.com/aaanh/dotnet-example-three-tier/actions/workflows/ci.yaml/badge.svg)](https://github.com/aaanh/dotnet-example-three-tier/actions/workflows/ci.yaml)

[![.NET Build](https://github.com/aaanh/dotnet-example-three-tier/actions/workflows/dotnet-build.yaml/badge.svg)](https://github.com/aaanh/dotnet-example-three-tier/actions/workflows/dotnet-build.yaml)

[![Test](https://github.com/aaanh/dotnet-example-three-tier/actions/workflows/test.yaml/badge.svg)](https://github.com/<YOUR_USERNAME>/<YOUR_REPO>/actions/workflows/test.yaml)


This is a sample **3-tier .NET 8 application** using:

- **Data Layer** (`example-three-tier.Data`) — EF Core + PostgreSQL  
- **Business Layer** (`example-three-tier.Business`) — service logic  
- **Web Layer** (`example-three-tier.Web`) — ASP.NET Core Web API + Razor Pages + Swagger  

---

## 🚀 Quick Start

### 1. Start PostgreSQL (Docker)
Run Postgres in a container:

```bash
docker run --name example-postgres \
  -e POSTGRES_USER=myuser \
  -e POSTGRES_PASSWORD=mypassword \
  -e POSTGRES_DB=myappdb \
  -p 5432:5432 \
  -d postgres:16
```

Check logs:

```bash
docker logs example-postgres
```

---

### 2. Configure Connection String
The API expects this connection string (already set in `appsettings.json`):

```
Host=localhost;Port=5432;Database=myappdb;Username=myuser;Password=mypassword
```

---

### 3. Apply EF Core Migrations
From the solution root:

```bash
dotnet ef database update \
  --project example-three-tier.Data \
  --startup-project example-three-tier.Web
```

This will create the `Customers` table and seed sample data.

---

### 4. Run the Application
Start the Web project:

```bash
dotnet run --project example-three-tier.Web
```

---

### 5. Access the App
- **Razor UI Home** → [http://localhost:5000/](http://localhost:5000/)  
- **Swagger API Docs** → [http://localhost:5000/swagger](http://localhost:5000/swagger)  
- **Example Customers Page** → [http://localhost:5000/customers](http://localhost:5000/customers)  

---

## 🛑 Stop Postgres
When done, stop/remove the container:

```bash
docker stop example-postgres
docker rm example-postgres
```
