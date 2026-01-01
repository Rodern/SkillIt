using BusinessLogic;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;
using SkillIT_Models.DatabaseModels;
using SkillIT_Models.Models;
using Xunit;

namespace SkillIT.Tests.UnitTests.Services
{
    /// <summary>
    /// Unit tests for CourseService
    /// </summary>
    public class CourseServiceTests : IDisposable
    {
        private readonly skill_it_dbContext _context;
        private readonly Mock<ILogger<CourseService>> _loggerMock;
        private readonly CourseService _courseService;

        public CourseServiceTests()
        {
            // Setup in-memory database
            var options = new DbContextOptionsBuilder<skill_it_dbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            _context = new skill_it_dbContext(options);
            _loggerMock = new Mock<ILogger<CourseService>>();
            _courseService = new CourseService(_context, _loggerMock.Object);

            // Seed test data
            SeedTestData();
        }

        private void SeedTestData()
        {
            var courses = new List<Course>
            {
                new Course
                {
                    CourseId = 1,
                    Guid = "test-guid-1",
                    Name = "Introduction to Programming",
                    Description = "Learn the basics of programming",
                    Level = "beginner",
                    IsPublished = true,
                    DateCreated = DateTime.UtcNow
                },
                new Course
                {
                    CourseId = 2,
                    Guid = "test-guid-2",
                    Name = "Advanced Web Development",
                    Description = "Master modern web technologies",
                    Level = "advanced",
                    IsPublished = true,
                    DateCreated = DateTime.UtcNow
                }
            };

            _context.Courses.AddRange(courses);
            _context.SaveChanges();
        }

        [Fact]
        public void GetCourse_WithValidId_ReturnsCourse()
        {
            // Arrange
            var courseId = 1;

            // Act
            var result = _courseService.GetCourse(courseId);

            // Assert
            result.Should().NotBeNull();
            result.CourseId.Should().Be(courseId);
            result.Name.Should().Be("Introduction to Programming");
        }

        [Fact]
        public void GetCourse_WithInvalidId_ReturnsNull()
        {
            // Arrange
            var courseId = 999;

            // Act
            var result = _courseService.GetCourse(courseId);

            // Assert
            result.Should().BeNull();
        }

        [Fact]
        public void GetCourseByGuid_WithValidGuid_ReturnsCourse()
        {
            // Arrange
            var guid = "test-guid-1";

            // Act
            var result = _courseService.GetCourseByGuid(guid);

            // Assert
            result.Should().NotBeNull();
            result.Guid.Should().Be(guid);
            result.Name.Should().Be("Introduction to Programming");
        }

        [Fact]
        public void GetCourses_ReturnsAllCourses()
        {
            // Act
            var result = _courseService.GetCourses();

            // Assert
            result.Should().NotBeNull();
            result.Should().HaveCount(2);
            result.Should().Contain(c => c.Name == "Introduction to Programming");
            result.Should().Contain(c => c.Name == "Advanced Web Development");
        }

        [Fact]
        public void CreateCourse_WithValidCourse_ReturnsSuccess()
        {
            // Arrange
            var newCourse = new Course
            {
                CourseId = 3,
                Guid = "test-guid-3",
                Name = "Data Science Fundamentals",
                Description = "Introduction to data science",
                Level = "intermediate",
                IsPublished = false,
                DateCreated = DateTime.UtcNow
            };

            // Act
            var result = _courseService.CreateCourse(newCourse);

            // Assert
            result.Should().NotBeNull();
            result.Success.Should().BeTrue();
            _context.Courses.Should().Contain(c => c.CourseId == 3);
        }

        [Fact]
        public void UpdateCourse_WithValidCourse_ReturnsSuccess()
        {
            // Arrange
            var course = _context.Courses.Find(1);
            course.Name = "Updated Course Name";

            // Act
            var result = _courseService.UpdateCourse(course);

            // Assert
            result.Should().NotBeNull();
            result.Success.Should().BeTrue();
            
            var updatedCourse = _context.Courses.Find(1);
            updatedCourse.Name.Should().Be("Updated Course Name");
        }

        [Fact]
        public void DeleteCourse_WithValidId_ReturnsSuccess()
        {
            // Arrange
            var courseId = 1;

            // Act
            var result = _courseService.DeleteCourse(courseId);

            // Assert
            result.Should().NotBeNull();
            result.Success.Should().BeTrue();
            _context.Courses.Find(courseId).Should().BeNull();
        }

        [Fact]
        public void GetCourseByGuid_WithNullGuid_ReturnsNull()
        {
            // Act
            var result = _courseService.GetCourseByGuid(null);

            // Assert
            result.Should().BeNull();
        }

        [Theory]
        [InlineData("beginner")]
        [InlineData("intermediate")]
        [InlineData("advanced")]
        public void Course_Level_ShouldBeValid(string level)
        {
            // Arrange
            var course = new Course
            {
                CourseId = 99,
                Name = "Test Course",
                Level = level,
                DateCreated = DateTime.UtcNow
            };

            // Assert
            course.Level.Should().BeOneOf("beginner", "intermediate", "advanced");
        }

        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}
