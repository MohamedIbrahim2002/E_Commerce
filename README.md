# 🛒 E-Commerce API

A scalable and production-ready **E-Commerce RESTful API** built with **ASP.NET Core** following **Clean Architecture** principles. The project demonstrates modern backend development practices including authentication, payment integration, caching, repository pattern, and specification pattern.

---

## 🚀 Features

- 🔐 JWT Authentication & Authorization
- 👤 ASP.NET Core Identity
- 🛍 Product Catalog
- 🛒 Shopping Basket
- ❤️ Wishlist Support
- 📦 Order Management
- 💳 Stripe Payment Integration
- 🚚 Delivery Methods
- 🔍 Product Filtering, Sorting & Pagination
- 🔎 Product Search
- ⚡ Redis Basket Caching
- 📄 Global Exception Handling
- ✅ Fluent Validation
- 🗂 Clean Architecture
- 📚 Swagger / OpenAPI Documentation

---

# 🏗 Architecture

The project follows **Clean Architecture** to ensure maintainability, scalability, and separation of concerns.

```
Presentation
      │
      ▼
Application
      │
      ▼
Domain
      │
      ▼
Infrastructure
```

### Layers

### API
- Controllers
- Middleware
- Dependency Injection
- Authentication
- Swagger

### Application
- DTOs
- Services
- Interfaces
- Validation
- Business Logic
- Mapping

### Domain
- Entities
- Interfaces
- Specifications
- Domain Models

### Infrastructure
- Entity Framework Core
- SQL Server
- Identity
- Redis
- Stripe
- Repository Pattern
- Unit Of Work

---

# 🛠 Technologies

- ASP.NET Core Web API
- C#
- .NET
- Entity Framework Core
- SQL Server
- ASP.NET Identity
- JWT Authentication
- AutoMapper
- Redis
- Stripe API
- Swagger
- FluentValidation
- Repository Pattern
- Unit of Work
- Specification Pattern
- Dependency Injection

---

# 📂 Project Structure

```
E_Commerce.API
│
├── Controllers
├── Middleware
├── Extensions
└── Program.cs

E_Commerce.Application
│
├── DTOs
├── Interfaces
├── Services
├── Mapping
└── Features

E_Commerce.Domain
│
├── Entities
├── Specifications
├── Interfaces
└── Common

E_Commerce.Infrastructure
│
├── Data
├── Identity
├── Repositories
├── Services
├── UnitOfWork
└── DependencyInjection
```

---

# 🔑 Authentication

The API uses:

- ASP.NET Core Identity
- JWT Access Tokens
- Role-Based Authorization

---

# 💳 Payments

Integrated with **Stripe** Payment Gateway.

Features include:

- Create Payment Intent
- Update Payment Intent
- Store Client Secret
- Secure Payment Workflow

---

# 🛒 Basket

Basket data is cached using **Redis**.

Supports:

- Create Basket
- Update Basket
- Delete Basket
- Retrieve Basket

---

# 📦 Orders

- Create Order
- Delivery Methods
- Order History
- Payment Validation

---

# 🔍 Product API

Supports

- Pagination
- Searching
- Sorting
- Filtering
- Specification Pattern

---

# 🗄 Database

- SQL Server
- Entity Framework Core
- Code First
- Migrations
- Data Seeding

# 📈 Design Patterns Used

- Repository Pattern
- Unit Of Work
- Specification Pattern
- Dependency Injection
- Clean Architecture

---

# 🔐 Security

- JWT Authentication
- Identity
- Authorization Policies
- Secure Password Hashing

---

# 📌 Future Improvements

- Email Confirmation
- Refresh Tokens
- Docker Support
- Unit Testing
- Integration Testing
- Background Jobs
- Notifications
- Azure Deployment

---

# 👨‍💻 Author

**Mohamed Ibrahim Ali**

Backend .NET Developer

- GitHub: https://github.com/MohamedIbrahim2002
- LinkedIn: https://www.linkedin.com/in/mohamedibrahim2002/

---

## ⭐ If you found this project useful, don't forget to give it a Star!
