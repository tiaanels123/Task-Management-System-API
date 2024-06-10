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

### Following can be imported to test:

```json

{
	"info": {
		"_postman_id": "f2740507-9106-43aa-8eb9-1d12821536fd",
		"name": "Task Management API",
		"description": "Collection for Task Management API",
		"schema": "https://schema.getpostman.com/json/collection/v2.0.0/collection.json",
		"_exporter_id": "33830508"
	},
	"item": [
		{
			"name": "Register User",
			"request": {
				"method": "POST",
				"header": [
					{
						"key": "Content-Type",
						"value": "application/json"
					}
				],
				"body": {
					"mode": "raw",
					"raw": "{\"username\": \"testuser2\",\"email\": \"testuser@example.com\",\"password\": \"Password123!\"}"
				},
				"url": "http://localhost:5249/api/auth/register"
			},
			"response": []
		},
		{
			"name": "Log In",
			"request": {
				"method": "POST",
				"header": [
					{
						"key": "Content-Type",
						"value": "application/json"
					}
				],
				"body": {
					"mode": "raw",
					"raw": "{\"username\": \"testuser2\",\"password\": \"Password123!\"}"
				},
				"url": "http://localhost:5249/api/auth/login"
			},
			"response": []
		},
		{
			"name": "Create Task",
			"request": {
				"method": "POST",
				"header": [
					{
						"key": "Content-Type",
						"value": "application/json"
					},
					{
						"key": "Authorization",
						"value": "Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiI2MzYwNmU3OC03NjBiLTQ4ZTgtOGFiNy0wYjg3ZWM4NzRmMmIiLCJqdGkiOiJlODYzMGZhNy0wMzRkLTRlYWUtODU2My04ZjYzZmVjMWIzOGEiLCJlbWFpbCI6InRlc3R1c2VyQGV4YW1wbGUuY29tIiwidW5pcXVlX25hbWUiOiJ0ZXN0dXNlcjIiLCJleHAiOjE3MTc1ODI5ODMsImlzcyI6InlvdXJkb21haW4uY29tIiwiYXVkIjoieW91cmRvbWFpbi5jb20ifQ.TwuEWXxfdLmAURJvEqWyVbBhPTLx59weQ5_TlXQYoBk"
					}
				],
				"body": {
					"mode": "raw",
					"raw": "{\"title\": \"New Task2\",\"description\": \"This is a new task2.\",\"status\": \"To-Do\",\"userId\": \"36c99a3f-4d21-4393-bf48-9965751b0b0e\"}"
				},
				"url": "http://localhost:5249/api/tasks"
			},
			"response": []
		},
		{
			"name": "Get All Tasks",
			"request": {
				"method": "GET",
				"header": [
					{
						"key": "Authorization",
						"value": "Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiI2MzYwNmU3OC03NjBiLTQ4ZTgtOGFiNy0wYjg3ZWM4NzRmMmIiLCJqdGkiOiJlODYzMGZhNy0wMzRkLTRlYWUtODU2My04ZjYzZmVjMWIzOGEiLCJlbWFpbCI6InRlc3R1c2VyQGV4YW1wbGUuY29tIiwidW5pcXVlX25hbWUiOiJ0ZXN0dXNlcjIiLCJleHAiOjE3MTc1ODI5ODMsImlzcyI6InlvdXJkb21haW4uY29tIiwiYXVkIjoieW91cmRvbWFpbi5jb20ifQ.TwuEWXxfdLmAURJvEqWyVbBhPTLx59weQ5_TlXQYoBk"
					}
				],
				"url": "http://localhost:5249/api/tasks"
			},
			"response": []
		},
		{
			"name": "Get Task by ID",
			"request": {
				"method": "GET",
				"header": [
					{
						"key": "Authorization",
						"value": "Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiI2MzYwNmU3OC03NjBiLTQ4ZTgtOGFiNy0wYjg3ZWM4NzRmMmIiLCJqdGkiOiJlODYzMGZhNy0wMzRkLTRlYWUtODU2My04ZjYzZmVjMWIzOGEiLCJlbWFpbCI6InRlc3R1c2VyQGV4YW1wbGUuY29tIiwidW5pcXVlX25hbWUiOiJ0ZXN0dXNlcjIiLCJleHAiOjE3MTc1ODI5ODMsImlzcyI6InlvdXJkb21haW4uY29tIiwiYXVkIjoieW91cmRvbWFpbi5jb20ifQ.TwuEWXxfdLmAURJvEqWyVbBhPTLx59weQ5_TlXQYoBk"
					}
				],
				"url": "http://localhost:5249/api/tasks/7"
			},
			"response": []
		},
		{
			"name": "Update Task",
			"request": {
				"method": "PUT",
				"header": [
					{
						"key": "Content-Type",
						"value": "application/json"
					},
					{
						"key": "Authorization",
						"value": "Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiI2MzYwNmU3OC03NjBiLTQ4ZTgtOGFiNy0wYjg3ZWM4NzRmMmIiLCJqdGkiOiJlODYzMGZhNy0wMzRkLTRlYWUtODU2My04ZjYzZmVjMWIzOGEiLCJlbWFpbCI6InRlc3R1c2VyQGV4YW1wbGUuY29tIiwidW5pcXVlX25hbWUiOiJ0ZXN0dXNlcjIiLCJleHAiOjE3MTc1ODI5ODMsImlzcyI6InlvdXJkb21haW4uY29tIiwiYXVkIjoieW91cmRvbWFpbi5jb20ifQ.TwuEWXxfdLmAURJvEqWyVbBhPTLx59weQ5_TlXQYoBk"
					}
				],
				"body": {
					"mode": "raw",
					"raw": "{\"title\": \"Updated Task2\",\"description\": \"This is an updated task2.\",\"status\": \"In Progress\",\"userId\": \"36c99a3f-4d21-4393-bf48-9965751b0b0e\"}"
				},
				"url": "http://localhost:5249/api/tasks/7"
			},
			"response": []
		},
		{
			"name": "Delete Task",
			"request": {
				"method": "DELETE",
				"header": [
					{
						"key": "Authorization",
						"value": "Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiI2MzYwNmU3OC03NjBiLTQ4ZTgtOGFiNy0wYjg3ZWM4NzRmMmIiLCJqdGkiOiJlODYzMGZhNy0wMzRkLTRlYWUtODU2My04ZjYzZmVjMWIzOGEiLCJlbWFpbCI6InRlc3R1c2VyQGV4YW1wbGUuY29tIiwidW5pcXVlX25hbWUiOiJ0ZXN0dXNlcjIiLCJleHAiOjE3MTc1ODI5ODMsImlzcyI6InlvdXJkb21haW4uY29tIiwiYXVkIjoieW91cmRvbWFpbi5jb20ifQ.TwuEWXxfdLmAURJvEqWyVbBhPTLx59weQ5_TlXQYoBk"
					}
				],
				"url": "http://localhost:5249/api/tasks/7"
			},
			"response": []
		},
		{
			"name": "Get User Info",
			"request": {
				"method": "GET",
				"header": [
					{
						"key": "Authorization",
						"value": "Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiI2MzYwNmU3OC03NjBiLTQ4ZTgtOGFiNy0wYjg3ZWM4NzRmMmIiLCJqdGkiOiJlODYzMGZhNy0wMzRkLTRlYWUtODU2My04ZjYzZmVjMWIzOGEiLCJlbWFpbCI6InRlc3R1c2VyQGV4YW1wbGUuY29tIiwidW5pcXVlX25hbWUiOiJ0ZXN0dXNlcjIiLCJleHAiOjE3MTc1ODI5ODMsImlzcyI6InlvdXJkb21haW4uY29tIiwiYXVkIjoieW91cmRvbWFpbi5jb20ifQ.TwuEWXxfdLmAURJvEqWyVbBhPTLx59weQ5_TlXQYoBk"
					}
				],
				"url": "http://localhost:5249/api/users/me"
			},
			"response": []
		},
		{
			"name": "Update User Info",
			"request": {
				"method": "PUT",
				"header": [
					{
						"key": "Content-Type",
						"value": "application/json"
					},
					{
						"key": "Authorization",
						"value": "Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiI2MzYwNmU3OC03NjBiLTQ4ZTgtOGFiNy0wYjg3ZWM4NzRmMmIiLCJqdGkiOiJlODYzMGZhNy0wMzRkLTRlYWUtODU2My04ZjYzZmVjMWIzOGEiLCJlbWFpbCI6InRlc3R1c2VyQGV4YW1wbGUuY29tIiwidW5pcXVlX25hbWUiOiJ0ZXN0dXNlcjIiLCJleHAiOjE3MTc1ODI5ODMsImlzcyI6InlvdXJkb21haW4uY29tIiwiYXVkIjoieW91cmRvbWFpbi5jb20ifQ.TwuEWXxfdLmAURJvEqWyVbBhPTLx59weQ5_TlXQYoBk"
					}
				],
				"body": {
					"mode": "raw",
					"raw": "{\"userName\": \"updateduser2\",\"email\": \"updateduser2@example.com\"}"
				},
				"url": "http://localhost:5249/api/users/me"
			},
			"response": []
		}
	],
	"variable": [
		{
			"key": "token",
			"value": ""
		},
		{
			"key": "userId",
			"value": ""
		},
		{
			"key": "taskId",
			"value": ""
		}
	]
}
```
