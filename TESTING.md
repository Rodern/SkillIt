# SkillIT Testing Guide

## Test Project Structure

```
SkillIt.Tests/
├── UnitTests/
│   ├── Services/
│   │   ├── CourseServiceTests.cs
│   │   ├── UserServiceTests.cs
│   │   └── AuthenticationServiceTests.cs
│   ├── Controllers/
│   │   ├── CourseControllerTests.cs
│   │   └── UserControllerTests.cs
│   └── Models/
│       └── PaginationTests.cs
├── IntegrationTests/
│   ├── API/
│   │   ├── CourseEndpointsTests.cs
│   │   └── AuthenticationEndpointsTests.cs
│   └── Database/
│       └── DbContextTests.cs
└── TestHelpers/
    ├── TestDbContext.cs
    └── MockData.cs
```

## Running Tests

### All Tests
```bash
dotnet test
```

### Specific Test Project
```bash
dotnet test SkillIt.Tests/SkillIt.Tests.csproj
```

### With Coverage
```bash
dotnet test /p:CollectCoverage=true /p:CoverletOutputFormat=opencover
```

### Specific Test Category
```bash
dotnet test --filter Category=Unit
dotnet test --filter Category=Integration
```

## Writing Tests

### Unit Test Example

```csharp
using Xunit;
using Moq;
using FluentAssertions;
using BusinessLogic;

public class CourseServiceTests
{
    [Fact]
    public void GetCourse_WithValidId_ReturnsCourse()
    {
        // Arrange
        var mockContext = new Mock<skill_it_dbContext>();
        var service = new CourseService(mockContext.Object);
        
        // Act
        var result = service.GetCourse(1);
        
        // Assert
        result.Should().NotBeNull();
    }
}
```

### Integration Test Example

```csharp
using Xunit;
using Microsoft.AspNetCore.Mvc.Testing;

public class CourseEndpointsTests : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly WebApplicationFactory<Program> _factory;

    public CourseEndpointsTests(WebApplicationFactory<Program> factory)
    {
        _factory = factory;
    }

    [Fact]
    public async Task GetCourses_ReturnsSuccessStatusCode()
    {
        // Arrange
        var client = _factory.CreateClient();

        // Act
        var response = await client.GetAsync("/api/v1/courses");

        // Assert
        response.EnsureSuccessStatusCode();
    }
}
```

## Test Coverage Goals

- **Unit Tests**: > 80% code coverage
- **Integration Tests**: All API endpoints
- **E2E Tests**: Critical user journeys

## Continuous Integration

Tests run automatically on:
- Pull requests
- Commits to main branch
- Before deployments

## Mocking Strategy

- Use **Moq** for mocking dependencies
- Use **InMemory database** for EF Core tests
- Use **WebApplicationFactory** for integration tests

## Best Practices

1. Follow AAA pattern (Arrange, Act, Assert)
2. One assertion per test (when possible)
3. Use descriptive test names
4. Keep tests isolated and independent
5. Use test fixtures for shared setup
6. Mock external dependencies
7. Test both success and failure paths

## Test Categories

Use attributes to categorize tests:

```csharp
[Trait("Category", "Unit")]
[Trait("Category", "Integration")]
[Trait("Category", "Slow")]
```
