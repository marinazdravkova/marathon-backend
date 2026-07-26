# Štip Marathon 2026 - Backend System (Phase 1)

Welcome to the backend architecture of the **Štip Marathon 2026** web application. 
This project is being developed using an iterative software engineering approach, 
starting from core OOP concepts and evolving into a full-scale enterprise Web API.


 🚀 Development Roadmap & Progress

- [Done] **Phase 1: Core Console Engine & JSON Database** — Object-oriented domain models, robust validation, LINQ filtering, and local JSON persistence.
- [Done] **Phase 2: ASP.NET Core Web API & CORS Integration** — RESTful controllers, HTTP status handling, Swagger documentation, and CORS configuration for React/Next.js frontend.
- [ ] **Phase 3: Frontend Integration** — Connecting the C# Web API endpoints with the React user interface.
- [ ] **Phase 4: Database & ORM Integration** — Migrating JSON storage to SQL Server / MySQL via Entity Framework Core (EF Core).
- [ ] **Phase 5: Security & Clean Architecture** — JWT Authentication, role-based access control, and refactoring into Layered/Clean Architecture.

 🛠️ Architecture & Features (Phase 1 & Phase 2)

 🔹 Domain Logic & Persistence (`StipMarathon.Backend`)
- Object-Oriented Design:Encapsulated domain models (`Runner`) with strict validations and null-safety.
- Type Safety:Strong enums (`Category`) mapped to race distances (`Km5`, `Km10`, `Km21`).
- LINQ Queries: High-performance filtering for runner registration lists and age restrictions.
- JSON File Storage: Automated serialization and deserialization via `System.Text.Json`.

 🔹 RESTful Web API (`StipMarathon.API`)
- Controllers & Endpoints: Full CRUD operations exposed via HTTP methods (`GET`, `POST`, `PUT`, `DELETE`).
- HTTP Standards: Implemented standard API responses (`200 OK`, `201 Created`, `400 Bad Request`, `404 Not Found`, `204 No Content`).
- CORS Policy: Configured Cross-Origin Resource Sharing allowing seamless communication with React / Vite / Next.js clients.
- OpenAPI / Swagger: Interactive API documentation for real-time testing.


 🌐 API Endpoints Reference

| HTTP Method	    |		Endpoint Path				         |			 Description				      |
|	`GET`       |		`/api/runners`					 | Retrieves all registered marathon runners.			      |
|	`GET`       |		`/api/runners/{id}`				 | Fetches detailed info for a specific runner by ID.		      |
|	`GET`       |		`/api/runners/underage`			         | Filters and retrieves runners under 18 years old.		      |
|	`GET`       |	`/api/runners/category/{category}`                       | Filters runners by category (`Km5`, `Km10`, `Km21`).		      |
|	`POST`      |		`/api/runners`					 | Registers a new runner (validates unique email & required fields). |
|	`PUT`       |		`/api/runners/{id}`				 | Updates existing runner profile details.			      |
|	`DELETE`    |		`/api/runners/{id}`				 | Cancels and removes a runner registration.			      |


 💻 How to Run This Phase

1. Clone this repository:
   ```bash
   git clone [https://github.com/marinazdravkova/marathon-backend.git](https://github.com/marinazdravkova/marathon-backend.git)