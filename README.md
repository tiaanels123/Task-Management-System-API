# Task Management System API

## Overview

The Task Management System API is a robust backend service designed for managing tasks and user authentication. It utilizes modern .NET technologies and adheres to best practices in software design.

## Technologies Used

- **.NET 6.0**
- **Entity Framework Core**
- **SQLite (for testing)**
- **JWT Authentication**
- **ASP.NET Core Identity**
- **Swagger/OpenAPI**
- **Moq (for unit testing)**
- **XUnit (for testing framework)**
- **Microsoft.AspNetCore.Mvc.Testing (for integration testing)**

## Design Patterns

- **Repository Pattern**: Abstracts data access logic and provides a clean separation of concerns.
- **Service Pattern**: Encapsulates business logic and interacts with repositories.
- **Dependency Injection**: Facilitates loose coupling and enhances testability.
- **Middleware**: Handles cross-cutting concerns such as error handling and authentication.

## Project Structure

```plaintext
Task-Management-System-API/
├── TaskManagementSystem.Api/
│   ├── Controllers/
│   ├── Data/
│   ├── DTOs/
│   ├── Middleware/
│   ├── Models/
│   ├── Repositories/
│   ├── Services/
│   └── Program.cs
├── TaskManagementSystem.Api.Tests/
│   ├── IntegrationTests/
│   ├── Services/
└── TaskManagementSystem.sln
```


## Setting Up the Project

1. **Clone the repository:**
   ```sh
   git clone https://github.com/tiaanels123/Task-Management-System-API.git
   cd Task-Management-System-API
   ```

2. **Build the project:**
   ```sh
   dotnet build
   ```

3. **Run the API:**
   ```sh
   dotnet run --project TaskManagementSystem.Api
   ```

### Access Swagger UI
   
Open your browser and navigate to http://localhost:5249/swagger to explore the API endpoints.

## Testing

### Unit Tests

Run unit tests with the following command:

   ```sh
   dotnet test --filter "FullyQualifiedName~TaskManagementSystem.Api.Tests.Services"
   ```

### Integration Tests

Run integration tests with the following command:

   ```sh
   dotnet test --filter "FullyQualifiedName~TaskManagementSystem.Api.Tests.IntegrationTests"
   ```

## API Endpoints

The API exposes various endpoints for managing tasks and users. Refer to the Swagger UI at http://localhost:5249/swagger for detailed documentation and testing of endpoints.



