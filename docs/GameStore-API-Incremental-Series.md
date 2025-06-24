# GameStore API: Incremental Development Series

## Overview

This document provides a comprehensive guide to building a GameStore API using ASP.NET Core Minimal APIs through incremental development. Each version builds upon the previous one, introducing new concepts, patterns, and technologies.

## Learning Path

This course is designed for developers who want to learn modern .NET API development through a practical, step-by-step approach. The incremental nature ensures that concepts are introduced gradually, making it easier to understand and apply each new technique.

## Version Roadmap

### v1.0: Basic In-Memory API

**Focus**: Core concepts and basics of Minimal API development

- ASP.NET Core Minimal API pattern
- Basic CRUD operations
- In-memory data storage
- Data validation
- RESTful design principles

[View Detailed Documentation](./v1.0-Basic-In-Memory-API.md)

### v1.1: Enhanced In-Memory API with Genres

**Focus**: Improved structure and relationship management

- Genre management
- Relationship between Games and Genres
- Enhanced error handling
- Query parameters and filtering
- Code organization improvements

[View Detailed Documentation](./v1.1-Enhanced-API-with-Genres.md)

### v2.0: Repository Pattern Implementation

**Focus**: Design patterns and dependency injection

- Repository pattern
- Interface-based design
- Dependency injection
- Separation of concerns
- Unit testing with mock repositories

[View Detailed Documentation](./v2.0-Repository-Pattern-Implementation.md)

### v3.0: Entity Framework Core Integration

**Focus**: Data persistence and ORM

- Entity Framework Core setup
- SQL Server database
- Code-first migrations
- Advanced querying with EF Core
- Repository pattern with EF Core

[View Detailed Documentation](./v3.0-EF-Core-Integration.md)

### v4.0: Authentication and Authorization (Planned)

**Focus**: Security and access control

- JWT authentication
- Role-based authorization
- Identity management
- Secured endpoints
- User registration and login

### v5.0: Advanced Features (Planned)

**Focus**: Production-ready enhancements

- Response caching
- Rate limiting
- API versioning
- Comprehensive logging
- Health checks

### v6.0: Deployment Ready (Planned)

**Focus**: DevOps and deployment

- Docker containerization
- CI/CD pipeline setup
- Environment configuration
- Performance optimization
- Documentation with OpenAPI/Swagger

## Development Approach

Each version introduces new concepts while maintaining backward compatibility. The development approach follows these principles:

1. **Incremental Development**: Build small, working components before adding complexity
2. **Best Practices**: Follow ASP.NET Core best practices and design patterns
3. **Test-Driven**: Include unit tests for new functionality
4. **Documentation**: Comprehensive documentation for each version
5. **Clean Code**: Maintain readable, maintainable code structure

## Skills Covered

By completing this series, you'll gain proficiency in:

- ASP.NET Core Minimal API development
- C# 12 features and patterns
- REST API design principles
- Entity Framework Core
- Repository pattern
- Dependency Injection
- Authentication and Authorization
- Testing ASP.NET Core applications
- Database migrations
- API documentation
- DevOps for .NET applications

## Getting Started

To begin working with this series:

1. Start with v1.0 to understand the basic structure
2. Follow each version in sequence
3. Complete the exercises at the end of each version
4. Implement the suggested enhancements before moving to the next version

## Technical Requirements

- .NET 9 SDK
- Visual Studio 2025 or Visual Studio Code
- SQL Server (LocalDB for development)
- Git for version control

## Recommended Learning Path

For optimal learning, follow this course in the given sequence. Each version builds on knowledge from previous versions, making it important to understand earlier concepts before moving on.

1. Complete v1.0 to understand Minimal API basics
2. Implement v1.1 to learn relationship management
3. Refactor to v2.0 to apply repository pattern
4. Integrate EF Core in v3.0 for persistence
5. Add security with v4.0
6. Enhance with advanced features in v5.0
7. Prepare for deployment with v6.0

## Additional Resources

- [ASP.NET Core Documentation](https://docs.microsoft.com/en-us/aspnet/core)
- [Entity Framework Core Documentation](https://docs.microsoft.com/en-us/ef/core)
- [Minimal API Tutorial](https://docs.microsoft.com/en-us/aspnet/core/tutorials/min-web-api)
- [C# Programming Guide](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide)
