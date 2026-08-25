# Employee API

A comprehensive REST API for managing employee data, built with .NET 9 and designed to handle employee records efficiently. This API provides endpoints for creating, reading, updating, and deleting employee information.

## Description

The Employee API is a backend service that provides a robust solution for managing employee records. It includes features such as:

- Create new employee records
- Retrieve employee information
- Update employee details
- Delete employee records
- Validation for required fields (Name, Email, Date of Birth)
- Email format validation
- CORS support for cross-origin requests

## Tech Stack

- **.NET 9**: Modern web framework
- **C#**: Primary programming language
- **REST API**: Standard HTTP methods for CRUD operations
- **CORS**: Cross-Origin Resource Sharing enabled for secure frontend communication

## Installation

### Prerequisites

- .NET 9 SDK or later
- Visual Studio 2026 (or any compatible IDE)
- Git

### Steps

1. Clone the repository:
   ```bash
   git clone https://github.com/abelawesso/Employee-Management.git
   cd Employee\ API
   ```

2. Restore dependencies:
   ```bash
   dotnet restore
   ```

3. Build the project:
   ```bash
   dotnet build
   ```

4. Run the application:
   ```bash
   dotnet run
   ```

The API will be available at `https://localhost:5183` by default.

## Usage

### Configuration

The API is configured to allow requests from `https://localhost:5001`. You can modify the CORS policy in `Program.cs` to allow requests from other origins as needed.

### Example Requests

#### Get All Employees
```http
GET http://localhost:5183/employees
Accept: application/json
```

#### Create a New Employee
```http
POST http://localhost:5183/employees
Content-Type: application/json

{
  "name": "John",
  "lastName": "Doe",
  "email": "john.doe@example.com",
  "dateOfBirth": "1990-01-15",
  "position": "Software Engineer"
}
```

#### Get Employee by ID
```http
GET http://localhost:5183/employees/{id}
Accept: application/json
```

#### Update an Employee
```http
PUT http://localhost:5183/employees/{id}
Content-Type: application/json

{
  "name": "John",
  "lastName": "Smith",
  "email": "john.smith@example.com",
  "dateOfBirth": "1990-01-15",
  "position": "Senior Engineer"
}
```

#### Delete an Employee
```http
DELETE http://localhost:5183/employees/{id}
```

## API Endpoints

### Employees

| Method | Endpoint | Description |
|--------|----------|-------------|
| GET | `/employees` | Retrieve all employees |
| GET | `/employees/{id}` | Retrieve a specific employee by ID |
| POST | `/employees` | Create a new employee |
| PUT | `/employees/{id}` | Update an existing employee |
| DELETE | `/employees/{id}` | Delete an employee |

### Request/Response Format

All requests and responses use JSON format.

#### Employee Object Model

```json
{
  "id": "550e8400-e29b-41d4-a716-446655440000",
  "name": "John",
  "lastName": "Doe",
  "email": "john.doe@example.com",
  "dateOfBirth": "1990-01-15T00:00:00Z",
  "position": "Software Engineer"
}
```

#### Validation Rules

- **Name** (Required): Must be provided
- **Email** (Required): Must be a valid email format
- **Date of Birth** (Required): Must be a valid date
- **Last Name** (Optional): Can be empty
- **Position** (Optional): Job title or role

## Error Handling

The API returns appropriate HTTP status codes:

- `200 OK`: Successful GET, PUT request
- `201 Created`: Successful POST request
- `204 No Content`: Successful DELETE request
- `400 Bad Request`: Invalid input or validation error
- `404 Not Found`: Employee not found
- `500 Internal Server Error`: Server-side error

## Contributing

Contributions are welcome! Please fork the repository and submit a pull request with your changes.

## License

This project is licensed under the MIT License - see the LICENSE.txt file for details.