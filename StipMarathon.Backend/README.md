# Štip Marathon 2026 - Backend System (Phase 1)

Welcome to the backend architecture of the **Štip Marathon 2026** web application. 
This project is being developed using an iterative software engineering approach, 
starting from core OOP concepts and evolving into a full-scale enterprise Web API.

---

## 🚀 The Development Philosophy (The Roadmap)

Instead of building a complex system all at once, this project is designed to show the natural evolution of a software product. 
The backend is planned to progress through the following phases:

Phase 1: Core Console Engine & JSON Database (Current) - Focuses on establishing object-oriented design, robust validation, and local data persistence.
Phase 2: ASP.NET Core Web API - Migrating the business logic into RESTful endpoints to serve a frontend application (React/Next.js).
Phase 3: Database & ORM Integration - Connecting the system to a relational database (SQL Server/MySQL) using Entity Framework Core.
Phase 4: Security & Clean Architecture** - Implementing JWT Authentication, role-based access control, and refactoring into Layered/Clean Architecture.

---

## 🛠️ Phase 1: Core OOP & Memory Engine

In this initial phase, the project establishes a rock-solid domain model and business logic layer using C# and .NET.

### Key Technical Concepts Implemented:
1. Object-Oriented Programming (OOP): Encapsulation of domain models (`Runner` class) with explicit properties and constructors.
2. Type Safety & Enums: Used C# `Enum` (`Category`) with custom mappings to guarantee consistent category choices (`Km5`, `Km10`, `Km42`).
3. LINQ & Collections: Implemented `List<Runner>` and utilized LINQ queries (`.Where()`, `.Any()`) for high-performance filtering (e.g., retrieving runners by category or identifying underage runners).
4. Exception Handling (Robustness): Robust data validation throwing customized `ArgumentException` to prevent empty registrations or duplicate email entries.
5. Data Persistence (JSON Database): Created a lightweight JSON file database (`System.Text.Json` serialization/deserialization) ensuring data is preserved even after the application stops.
6. Null Safety: Handled nullable reference types cleanly using C# null-coalescing operators (`??`) to guarantee runtime stability.

---

## 📂 Project Structure

* `Runner.cs` - The core domain entity representing a marathon participant.
* `Category.cs` (Enum) - Strongly-typed representation of racing distances.
* `MarathonManager.cs` - The logic coordinator (Repository simulation) managing registrations, filtering, and JSON persistence.
* `Program.cs` - Interactive command-line interface simulating client-server interactions.

---

## 🔮 Future Roadmap (What's Next?)

The next steps for this repository include:
1. Transition to ASP.NET Core: Expose endpoints such as `GET /api/runners` and `POST /api/runners` to communicate with the frontend.
2. Entity Framework Core (EF Core): Map domain models to SQL tables and manage database schema migrations.
3. React Frontend Connection: Connect the existing [marathon-app frontend](https://github.com/marinazdravkova/marathon-app) to this backend.
4. Security: Secure admin routes using JWT Tokens so only authorized organizers can access participant information.

---

### 💻 How to Run This Phase

1. Clone this repository:
   ```bash
   git clone [https://github.com/marinazdravkova/marathon-backend.git](https://github.com/marinazdravkova/marathon-backend.git)