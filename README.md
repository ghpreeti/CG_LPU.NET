# JWT Authentication Web API (ASP.NET Core)

This project demonstrates **JWT-based authentication and authorization** using **ASP.NET Core Web API** with **ASP.NET Identity** and **Entity Framework Core**. It allows users to **register, login, generate JWT tokens, and access protected APIs**.

---

## 🚀 Features

- User Registration
- User Login with password verification
- JWT Token Generation
- Secure API endpoints using `[Authorize]`
- ASP.NET Identity integration
- Entity Framework Core with SQL Server
- Swagger support with JWT Authorization

---

## 🏗️ Project Architecture

```text
WebAPIApplicationAuth
│
├── Controllers
│   ├── AuthController.cs        # Handles Register, Login, JWT generation
│   └── TestController.cs        # Protected API using [Authorize]
│
├── Models
│   ├── ApplicationUser.cs       # Identity user model
│   ├── Response.cs              # Standard API response model
│   └── UserRoles.cs             # Role definitions (Admin, User)
│
├── DTOs
│   ├── RegisterDTO.cs           # Registration request model
│   └── LoginDTO.cs              # Login request model
│
├── Data
│   └── ApplicationDbContext.cs  # EF Core database context
│
├── Migrations                   # EF Core migration files
│
├── Program.cs                   # Service configuration & middleware pipeline
├── appsettings.json             # Database connection & JWT configuration
└── WebAPIApplicationAuth.http   # API testing file
```

---

## ⚙️ Technologies Used

- ASP.NET Core Web API
- ASP.NET Identity
- Entity Framework Core
- SQL Server
- JWT (JSON Web Token)
- Swagger (API Testing)

---

## 🔐 Authentication Flow

1. User registers using `/api/auth/register`
2. User logs in using `/api/auth/login`
3. Server validates credentials
4. JWT Token is generated and returned
5. Client sends token in request header


---

## 🔑 Testing JWT in Swagger

1. Login using `/api/auth/login`
2. Copy the returned token
3. Click **Authorize 🔒** in Swagger
4. Enter: `Bearer <Your Token>`
5. Access protected endpoints.

---

## 📌 Key Concepts Implemented

- Stateless Authentication
- JWT Token Validation
- ASP.NET Identity User Management
- Secure API Authorization

---

## 📖 Learning Purpose

This project demonstrates how **authentication and authorization work in modern REST APIs using JWT and ASP.NET Core**.
