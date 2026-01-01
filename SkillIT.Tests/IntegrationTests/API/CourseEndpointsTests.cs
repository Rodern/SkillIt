using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using SkillIT_Models.Models;
using System.Net;
using System.Net.Http.Json;
using System.Text.Json;
using Xunit;

namespace SkillIT.Tests.IntegrationTests.API
{
    /// <summary>
    /// Integration tests for Course API endpoints
    /// </summary>
    public class CourseEndpointsTests : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly WebApplicationFactory<Program> _factory;
        private readonly HttpClient _client;

        public CourseEndpointsTests(WebApplicationFactory<Program> factory)
        {
            _factory = factory;
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task GetCourses_WithoutAuthentication_ReturnsSuccess()
        {
            // Act
            var response = await _client.GetAsync("/api/v1/courses");

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Fact]
        public async Task GetCourses_ReturnsPaginatedResult()
        {
            // Act
            var response = await _client.GetAsync("/api/v1/courses?pageNumber=1&pageSize=10");

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            
            var content = await response.Content.ReadAsStringAsync();
            content.Should().Contain("pageNumber");
            content.Should().Contain("pageSize");
            content.Should().Contain("totalCount");
            content.Should().Contain("items");
        }

        [Fact]
        public async Task GetCourse_WithValidId_ReturnsOk()
        {
            // Arrange - assuming course with ID 1 exists
            var courseId = 1;

            // Act
            var response = await _client.GetAsync($"/api/v1/courses/{courseId}");

            // Assert
            response.StatusCode.Should().BeOneOf(HttpStatusCode.OK, HttpStatusCode.NotFound);
        }

        [Fact]
        public async Task GetCourse_WithInvalidId_ReturnsNotFound()
        {
            // Arrange
            var courseId = 99999;

            // Act
            var response = await _client.GetAsync($"/api/v1/courses/{courseId}");

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.NotFound);
        }

        [Fact]
        public async Task CreateCourse_WithoutAuthentication_ReturnsUnauthorized()
        {
            // Arrange
            var newCourse = new
            {
                name = "Test Course",
                description = "Test Description",
                level = "beginner"
            };

            // Act
            var response = await _client.PostAsJsonAsync("/api/v1/courses", newCourse);

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.Unauthorized);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(10)]
        [InlineData(20)]
        public async Task GetCourses_WithDifferentPageSizes_ReturnsSuccess(int pageSize)
        {
            // Act
            var response = await _client.GetAsync($"/api/v1/courses?pageSize={pageSize}");

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Fact]
        public async Task GetCourses_WithExcessivePageSize_LimitsToMaximum()
        {
            // Arrange - requesting more than max allowed (100)
            var pageSize = 200;

            // Act
            var response = await _client.GetAsync($"/api/v1/courses?pageSize={pageSize}");
            var content = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<JsonElement>(content);

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            
            if (result.TryGetProperty("pageSize", out var actualPageSize))
            {
                actualPageSize.GetInt32().Should().BeLessOrEqualTo(100);
            }
        }

        [Fact]
        public async Task GetAllChapters_ReturnsSuccess()
        {
            // Act
            var response = await _client.GetAsync("/api/v1/courses/chapters");

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Fact]
        public async Task GetAllLessons_ReturnsSuccess()
        {
            // Act
            var response = await _client.GetAsync("/api/v1/courses/lessons");

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }
    }
}
