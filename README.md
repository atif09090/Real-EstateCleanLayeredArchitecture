# 🏡 Real Estate API - Clean Layered Architecture (.NET 8)

This is a **Real Estate Management API** built with **.NET 8**, **Entity Framework Core**, **JWT Authentication**, **AutoMapper**, and **Clean Architecture principles** (Controllers, Services, Repositories, DTOs, AutoMapper, etc.).

---

## 📂 Project Structure

```
/RealEstateAPI
├── Controllers # API endpoints
├── Services # Business logic layer
├── Repositories # Data access logic
├── Models # Entity models
├── DTOs # Data Transfer Objects
├── Mappings # AutoMapper profiles
├── Data # DbContext and seeders
├── Middleware # (optional) JWT middleware
├── Program.cs # Entry point & DI setup
├── appsettings.json # Configuration

```

---

## 🛠️ Tech Stack

| Component         | Technology                            |
|------------------|----------------------------------------|
| Framework        | .NET 8                                 |
| ORM              | Entity Framework Core (EF Core)        |
| Database         | SQL Server                             |
| Auth             | JWT Authentication                     |
| Mapping          | AutoMapper                             |
| API Docs         | Swagger (Swashbuckle)                  |

---

## 🚀 Getting Started

### 🔧 Prerequisites

- [.NET 8 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/8.0)
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads)
- [Visual Studio 2022+](https://visualstudio.microsoft.com/) or VS Code

### ⚙️ Configuration

Edit your `appsettings.json` file:

```
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=YOUR_SQL_SERVER;Database=RealEstateDB;Trusted_Connection=True;TrustServerCertificate=True"
  },
  "Jwt": {
    "Key": "YourSuperSecretKeyHere",
    "Issuer": "https://localhost:7233",
    "Audience": "https://localhost:7233"
  },
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*"

dotnet ef migrations add InitialCreate
dotnet ef database update

```
---



🔐 JWT Authentication
Secure endpoints using [Authorize]

Get a JWT token from /api/Auth/login or registration endpoint

Add token to Swagger or Postman:

---
Authorization: Bearer {your_jwt_token}

---

🔎 Property Search Endpoint
POST /api/Properties/search
Filter properties by criteria like city, price, bedrooms, etc.

✅ Request Body:

{
  "city": "Dubai",
  "minPrice": 100000,
  "maxPrice": 500000,
  "minBedrooms": 2,
  "maxBedrooms": 4,
  "propertyType": "Apartment"
}


✅ Implemented Features

```
 User Registration/Login (JWT)

 CRUD for Properties

 Add/Remove Favorites

 AutoMapper for DTO ↔ Entity

 EF Core with SQL Server

 Seed sample data

 Search properties with filters

```
---

 Swagger UI for API testing

🧪 API Documentation
Swagger is available at:


https://localhost:{port}/swagger
Use the Authorize button to enter JWT token for testing protected routes.

🧱 Sample Layers

```
Entity Model (e.g. Property.cs)

[Key]
public Guid Id { get; set; }

[Required]
public string Title { get; set; }

public string City { get; set; }
public decimal Price { get; set; }

DTO (e.g. PropertyDto.cs)
public Guid Id { get; set; }
public string Title { get; set; }
public decimal Price { get; set; }
```

---

Controller (e.g. PropertiesController.cs)

```
[HttpPost("search")]
public async Task<IActionResult> SearchProperties([FromBody] PropertySearchDto filters)
{
    var results = await _propertyService.SearchPropertiesAsync(filters);
    return Ok(results);
}
```
---

📦 NuGet Packages
```
dotnet add package AutoMapper --version 13.0.1
dotnet add package AutoMapper.Extensions.Microsoft.DependencyInjection --version 13.0.1
dotnet add package Microsoft.EntityFrameworkCore.SqlServer
dotnet add package Microsoft.EntityFrameworkCore.Tools
dotnet add package Microsoft.AspNetCore.Authentication.JwtBearer
dotnet add package Swashbuckle.AspNetCore

```


📄 License
This project is open-source and available under the MIT License.

---
🤝 Contributing
Feel free to fork this repo and open a pull request with improvements or bug fixes. Happy coding!


