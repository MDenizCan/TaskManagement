# Task Management System
My third project that i developed during my Internship

A comprehensive Task Management System built with a robust N-Tier architecture and modern backend technologies. This project provides a scalable solution for managing projects, tasks, and users with secure authentication.

## 🚀 Technologies Used

The project leverages a modern tech stack to ensure performance, security, and maintainability:

*   **Backend Framework:** [.NET 8](https://dotnet.microsoft.com/) - High-performance core for modern web applications.
*   **Architecture:** **N-Tier (Layered) Architecture** - Separated into API, Business, Infrastructure, Entities, and Contracts for maximum decoupling.
*   **Database:** [SQLite](https://www.sqlite.org/) - Lightweight and efficient relational database.
*   **ORM:** [Entity Framework Core](https://learn.microsoft.com/en-us/ef/core/) - Powerful Object-Relational Mapper for database operations.
*   **Authentication & Security:**
    *   **JWT (JSON Web Token)** - Secure and stateless authentication.
    *   **ASP.NET Core Identity** - Robust membership system for users, passwords, and roles.
*   **Data Mapping:** [AutoMapper](https://automapper.org/) - Seamless object-to-object mapping between entities and DTOs.
*   **Documentation:** [Swagger (OpenAPI)](https://swagger.io/) - Interactive API documentation and testing interface.

## 🏗️ Project Structure

The solution is divided into specialized layers:

*   **Task.API:** The entry point. Contains controllers, custom middleware, and dependency injection configurations.
*   **Task.BUSINESS:** The core of the application. Contains business logic, service implementations, and validation rules.
*   **Task.CONTRACTS:** Defines the communication schema. Contains Data Transfer Objects (DTOs) and request/response models.
*   **Task.ENTITIES:** Defines the data structure. Contains core domain entities (User, Project, Task).
*   **Task.INFRASTRUCTURE:** Data access layer. Manages the Database Context and repository implementations.

## 🌟 Key Features

*   **Secure Authentication:** User registration and login using JWT and Identity.
*   **Project Management:** Create, update, and track multiple projects.
*   **Task Tracking:** Assignment and management of tasks within projects.
*   **User Management:** Role-based access and user-specific task assignments.
*   **Scalable Design:** Easy to extend and maintain thanks to the N-Tier structure.
*   **API versioning & Documentation:** Fully documented endpoints via Swagger.

## ⚙️ Getting Started

### Prerequisites

*   [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
*   Visual Studio or VS Code

### Installation

1.  **Clone the Repository:**
    ```bash
    git clone https://github.com/MDenizCan/TaskManagement.git
    cd TaskManagement
    ```

2.  **Restore Dependencies:**
    ```bash
    dotnet restore
    ```

3.  **Update Database:**
    Apply migrations to create the local SQLite database:
    ```bash
    dotnet ef database update --project Task.INFRASTRUCTURE --startup-project Task.API
    ```

4.  **Run the Application:**
    ```bash
    dotnet run --project Task.API
    ```
    The API will be available at `http://localhost:5000` (or as configured in `launchSettings.json`).

---
*Developed by Deniz Can as part of an Internship program.*
