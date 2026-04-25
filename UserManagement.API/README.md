# 🚀 UserManagement API

[![.NET](https://img.shields.io/badge/.NET-8.0-512BD4?logo=dotnet)](https://dotnet.microsoft.com/)
[![Azure](https://img.shields.io/badge/Azure-Ready-0078D4?logo=microsoftazure)](https://azure.microsoft.com/)
[![License](https://img.shields.io/badge/License-MIT-green.svg)](LICENSE)
[![Swagger](https://img.shields.io/badge/Swagger-Documented-85EA2D?logo=swagger)](https://swagger.io/)

A **production-ready** User Management REST API built with ASP.NET Core 8, featuring JWT authentication, password hashing, structured logging, and database migrations.

## ✨ Features

| Feature | Status | Description |
|---------|--------|-------------|
| 🔐 JWT Authentication | ✅ | Secure token-based authentication |
| 🔑 Password Hashing | ✅ | BCrypt hashing for passwords |
| 📝 Structured Logging | ✅ | Serilog with file/console output |
| 🗄️ Entity Framework Core | ✅ | Code-first approach with migrations |
| 📚 Swagger/OpenAPI | ✅ | Auto-generated API documentation |
| 🔄 Retry Policies | ✅ | Polly for transient fault handling |
| ☁️ Azure Ready | ✅ | Key Vault + App Service compatible |

## 📋 API Endpoints

| Method | Endpoint | Description | Authentication |
|--------|----------|-------------|----------------|
| GET | `/api/Users` | Get all users | ✅ Required |
| GET | `/api/Users/{id}` | Get user by ID | ✅ Required |
| POST | `/api/Users` | Create new user | ❌ Public |
| POST | `/api/Users/login` | Authenticate user | ❌ Public |
| DELETE | `/api/Users/{id}` | Delete user | ✅ Required |

## 🛠️ Tech Stack

```
└── Backend Layer
    ├── ASP.NET Core 8 Web API
    ├── Entity Framework Core 8
    ├── SQL Server / Azure SQL
    ├── JWT Bearer Authentication
    └── Swagger / OpenAPI

└── Security Layer
    ├── BCrypt.Net-Next (Password Hashing)
    ├── Azure.Identity (Managed Identity)
    └── Azure.Security.KeyVault.Secrets

└── Observability Layer
    ├── Serilog (Structured Logging)
    └── Polly (Resilience Policies)
```

## 📦 Packages Used

```xml
<PackageReference Include="Microsoft.EntityFrameworkCore" Version="8.0.0" />
<PackageReference Include="Microsoft.EntityFrameworkCore.SqlServer" Version="8.0.0" />
<PackageReference Include="Microsoft.EntityFrameworkCore.Tools" Version="8.0.0" />
<PackageReference Include="Microsoft.AspNetCore.Authentication.JwtBearer" Version="8.0.0" />
<PackageReference Include="BCrypt.Net-Next" Version="4.1.0" />
<PackageReference Include="Serilog.AspNetCore" Version="10.0.0" />
<PackageReference Include="Polly" Version="8.6.6" />
<PackageReference Include="Swashbuckle.AspNetCore" Version="6.6.2" />
<PackageReference Include="Azure.Identity" Version="1.21.0" />
<PackageReference Include="Azure.Security.KeyVault.Secrets" Version="4.10.0" />