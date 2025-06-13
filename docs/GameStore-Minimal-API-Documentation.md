# GameStore Minimal API Documentation

## Overview

The GameStore API is a RESTful web service built with **ASP.NET Core 9.0** using the **Minimal APIs** pattern. This API provides complete CRUD (Create, Read, Update, Delete) operations for managing games in a game store catalog.

## Project Architecture

### Technology Stack

- **.NET 9.0** - Latest .NET framework
- **ASP.NET Core Minimal APIs** - Lightweight API development pattern
- **C# 12** with nullable reference types enabled
- **MinimalApis.Extensions** - Enhanced functionality for minimal APIs

### Project Structure

```
src/GameStore.Api/
├── Models/
│   ├── Game.cs          # Game entity model
│   └── Genre.cs         # Genre entity model (planned)
├── Properties/
│   └── launchSettings.json
├── Program.cs           # Main application entry point
├── GameStore.Api.csproj # Project file
├── appsettings.json     # Configuration
└── gamestore.http       # HTTP test requests
```

## Data Models

### Game Model

```csharp
public class Game
{
    public Guid Id { get; set; }

    [Required]
    [StringLength(50, MinimumLength = 3)]
    public required string Name { get; set; }

    [Required]
    [StringLength(20, MinimumLength = 3)]
    public required string Genre { get; set; }

    [Range(1, 100)]
    public decimal Price { get; set; }

    public DateOnly ReleaseDate { get; set; }
}
```

#### Validation Rules

- **Name**: Required, 3-50 characters
- **Genre**: Required, 3-20 characters
- **Price**: Must be between $1.00 and $100.00
- **ReleaseDate**: Valid date format

### Genre Model

```csharp
public class Genre
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
}
```

## API Endpoints

### Root Endpoint

#### Welcome Message

```http
GET /
```

**Response:**

```json
{
  "message": "Welcome to the Games API",
  "requestId": "123e4567-e89b-12d3-a456-426614174000",
  "dateTime": "2025-06-13T10:30:45.123Z"
}
```

### Games Collection

#### Get All Games

```http
GET /games
```

**Response:** `200 OK`

```json
[
  {
    "id": "123e4567-e89b-12d3-a456-426614174000",
    "name": "Street Fighter II",
    "genre": "Fighting",
    "price": 19.99,
    "releaseDate": "1992-07-15"
  }
]
```

#### Get Game by ID

```http
GET /games/{id}
```

**Parameters:**

- `id` (GUID): Unique identifier of the game

**Responses:**

- `200 OK`: Game found
- `404 Not Found`: Game not found

**Example:**

```http
GET /games/123e4567-e89b-12d3-a456-426614174000
```

#### Create New Game

```http
POST /games
Content-Type: application/json
```

**Request Body:**

```json
{
  "name": "Test Game",
  "genre": "Action",
  "price": 19.99,
  "releaseDate": "1992-07-15"
}
```

**Responses:**

- `201 Created`: Game successfully created
- `400 Bad Request`: Validation errors

**Response Headers:**

- `Location`: URL to the created game resource

#### Update Game

```http
PUT /games/{id}
Content-Type: application/json
```

**Request Body:**

```json
{
  "name": "Updated Game Name",
  "genre": "Updated Genre",
  "price": 29.99,
  "releaseDate": "2023-01-01"
}
```

**Responses:**

- `204 No Content`: Game successfully updated
- `404 Not Found`: Game not found
- `400 Bad Request`: Validation errors

#### Delete Game

```http
DELETE /games/{id}
```

**Responses:**

- `204 No Content`: Game successfully deleted
- `404 Not Found`: Game not found

## Sample Data

The API comes pre-loaded with sample games:

| Name              | Genre       | Price  | Release Date       |
| ----------------- | ----------- | ------ | ------------------ |
| Street Fighter II | Fighting    | $19.99 | July 15, 1992      |
| Final Fantasy XIV | Roleplaying | $59.99 | September 30, 2010 |
| FIFA 23           | Sports      | $69.99 | September 27, 2022 |

## Configuration

### Development URLs

- **HTTPS**: `https://localhost:7202`
- **HTTP**: `http://localhost:5078`

### Environment Variables

- `ASPNETCORE_ENVIRONMENT`: Set to "Development" for local development

## Error Handling

### HTTP Status Codes

- `200 OK`: Successful GET request
- `201 Created`: Successful POST request
- `204 No Content`: Successful PUT/DELETE request
- `400 Bad Request`: Validation errors
- `404 Not Found`: Resource not found
- `500 Internal Server Error`: Server error

### Validation Error Response

```json
{
  "type": "https://tools.ietf.org/html/rfc7231#section-6.5.1",
  "title": "One or more validation errors occurred.",
  "status": 400,
  "traceId": "00-trace-id-here-00",
  "errors": {
    "Name": ["The name must be between 3 and 50 characters long."],
    "Price": ["The price must be between $1 and $100."]
  }
}
```

## API Features

### Endpoint Documentation

- Each endpoint is properly tagged for organization
- OpenAPI/Swagger integration
- Comprehensive HTTP status code documentation

### Validation

- Automatic model validation using Data Annotations
- Parameter validation with `WithParameterValidation()`
- Detailed validation error responses

### Routing

- RESTful URL patterns
- Strongly-typed route parameters
- GUID constraints for ID parameters

## Testing

### HTTP Test File

The project includes `gamestore.http` with sample requests for all endpoints:

```http
@GameAPIs_HostAddress=https://localhost:7202
@ContentType = application/json

### Get All Games
GET {{GameAPIs_HostAddress}}/games

### Create Game
POST {{GameAPIs_HostAddress}}/games
Content-Type: {{ContentType}}

{
    "name": "Test Game",
    "genre": "Action",
    "price": 19.99,
    "releaseDate": "1992-07-15"
}
```

## Current Limitations

### Data Storage

- **In-Memory Storage**: Data is stored in a `List<Game>` collection
- **No Persistence**: Data is lost when the application restarts
- **Thread Safety**: Current implementation is not thread-safe

### Security

- **No Authentication**: All endpoints are publicly accessible
- **No Authorization**: No role-based access control

### Planned Features

- Genre endpoints (model exists but endpoints not implemented)
- Database integration
- Authentication and authorization
- Logging and monitoring

## Development Guidelines

### Code Quality

- Warnings treated as errors
- Latest C# analysis rules enabled
- Nullable reference types enforced
- Centralized package management

### Best Practices Demonstrated

- **Minimal API Pattern**: Lightweight endpoint definition
- **Functional Programming**: Lambda expressions for handlers
- **Separation of Concerns**: Models in separate namespace
- **RESTful Design**: Standard HTTP methods and status codes
- **Validation**: Data annotations and automatic validation

## Getting Started

1. **Clone the repository**
2. **Navigate to the project directory**
   ```bash
   cd src/GameStore.Api
   ```
3. **Run the application**
   ```bash
   dotnet run
   ```
4. **Test the API**
   - Open browser to `https://localhost:7202`
   - Use the provided HTTP test file
   - Test with tools like Postman or curl

## Next Steps

This project serves as an excellent foundation for learning:

- Minimal API development patterns
- RESTful web service design
- Model validation techniques
- HTTP protocol best practices
- Modern .NET development approaches

Future enhancements could include database integration, authentication, caching, and more sophisticated business logic.
