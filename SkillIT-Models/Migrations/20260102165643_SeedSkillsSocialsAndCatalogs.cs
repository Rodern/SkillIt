using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SkillIT_Models.Migrations
{
    /// <inheritdoc />
    public partial class SeedSkillsSocialsAndCatalogs : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Seed Social Platforms
            migrationBuilder.InsertData(
                table: "social",
                columns: new[] { "socialID", "name", "link" },
                values: new object[,]
                {
                    { 1L, "Twitter", "twitter.com" },
                    { 2L, "Facebook", "facebook.com" },
                    { 3L, "LinkedIn", "linkedin.com" },
                    { 4L, "GitHub", "github.com" },
                    { 5L, "Instagram", "instagram.com" },
                    { 6L, "YouTube", "youtube.com" }
                });

            // Seed Skills - Common tech skills (level: 0=Beginner, 1=Amateur, 2=Intermediate, 3=Professional, 4=GodLevel)
            migrationBuilder.InsertData(
                table: "skill",
                columns: new[] { "skillID", "name", "level" },
                values: new object[,]
                {
                    { 1L, "Web Development", 3 },        // Professional
                    { 2L, "Mobile Development", 2 },     // Intermediate
                    { 3L, "C# Programming", 2 },         // Intermediate
                    { 4L, "JavaScript", 3 },             // Professional
                    { 5L, "Python", 2 },                 // Intermediate
                    { 6L, "Java", 2 },                   // Intermediate
                    { 7L, "SQL", 3 },                    // Professional
                    { 8L, "Graphics Design", 2 },        // Intermediate
                    { 9L, "UI/UX Design", 3 },           // Professional
                    { 10L, "DevOps", 2 },                // Intermediate
                    { 11L, "Cloud Computing", 2 },       // Intermediate
                    { 12L, "Machine Learning", 0 }       // Beginner
                });

            // Seed Catalogs - Learning resources
            migrationBuilder.InsertData(
                table: "catalog",
                columns: new[] { "catalogID", "title", "image_url", "image_thumbnail_url", "data", "descriptions", "link", "date_created", "last_modified" },
                values: new object[,]
                {
                    { 1L, ".Net MAUI For Beginners", 
                      "https://i.ytimg.com/vi/Hh279ES_FNQ/maxresdefault.jpg",
                      "https://i.ytimg.com/vi/Hh279ES_FNQ/hqdefault.jpg",
                      "{\"title\":\"What is .NET MAUI? [1 of 8] | .NET MAUI for Beginners\",\"author_name\":\"dotnet\",\"type\":\"video\",\"provider_name\":\"YouTube\",\"thumbnail_url\":\"https://i.ytimg.com/vi/Hh279ES_FNQ/hqdefault.jpg\"}",
                      "Welcome to the .NET MAUI for Beginners series where you will learn the basics of building multi-platform apps with .NET MAUI for iOS, Android, macOS, and Windows from a shared C# codebase.",
                      "https://youtu.be/Hh279ES_FNQ?list=PLdo4fOcmZ0oUBAdL2NwBpDs32zwGqb9DY",
                      DateTime.UtcNow,
                      DateTime.UtcNow },
                    
                    { 2L, "Suggestion Site App", 
                      "https://i.ytimg.com/vi/eEyAKk4NeSg/maxresdefault.jpg",
                      "https://i.ytimg.com/vi/eEyAKk4NeSg/hqdefault.jpg",
                      "{\"title\":\"Suggestion Site App\",\"author_name\":\"IAmTimCorey\",\"type\":\"video\",\"provider_name\":\"YouTube\",\"thumbnail_url\":\"https://i.ytimg.com/vi/eEyAKk4NeSg/hqdefault.jpg\"}",
                      "Welcome to the course on building a Suggestion Site App. In this course, we are going to design, build, and test a production-ready application using C#. This course is sponsored by MongoDB.",
                      "https://www.youtube.com/playlist?list=PLLWMQd6PeGY0cZFMqx5ijmdaD87sJKCsU",
                      DateTime.UtcNow,
                      DateTime.UtcNow },
                    
                    { 3L, "Blazor on Desktop: PWA, Electron or .NET MAUI", 
                      "https://i.ytimg.com/vi/2MxfNrtx2l8/maxresdefault.jpg",
                      "https://i.ytimg.com/vi/2MxfNrtx2l8/hqdefault.jpg",
                      "{\"title\":\"Blazor on Desktop: PWA, Electron or .NET MAUI - Sam Basu\",\"author_name\":\"Dotnet Frontend Day\",\"type\":\"video\",\"provider_name\":\"YouTube\",\"thumbnail_url\":\"https://i.ytimg.com/vi/2MxfNrtx2l8/hqdefault.jpg\"}",
                      "The desire to see web technologies power experiences on mobile/desktop is nothing new. With Blazor, developers get to build modern web apps with C#/.NET, running on the server or fully client-side through WebAssembly.",
                      "https://www.youtube.com/watch?v=2MxfNrtx2l8",
                      DateTime.UtcNow,
                      DateTime.UtcNow },
                    
                    { 4L, "How to ACTUALLY learn to code... 7 Roadmaps for 2023", 
                      "https://i.ytimg.com/vi/66tfvFeALBQ/maxresdefault.jpg",
                      "https://i.ytimg.com/vi/66tfvFeALBQ/hqdefault.jpg",
                      "{\"title\":\"How to ACTUALLY learn to code... 7 Roadmaps for 2023\",\"author_name\":\"Fireship\",\"type\":\"video\",\"provider_name\":\"YouTube\",\"thumbnail_url\":\"https://i.ytimg.com/vi/66tfvFeALBQ/hqdefault.jpg\"}",
                      "Explore 7 roadmaps or learning paths for beginner developers. The goal of this video is to provide a starting point for aspiring software engineers looking to learn web development, mobile, desktop, IoT, data science, game dev, and low-level systems.",
                      "https://www.youtube.com/watch?v=66tfvFeALBQ",
                      DateTime.UtcNow,
                      DateTime.UtcNow },
                    
                    { 5L, "Entity Framework Core - Join Related Tables with LINQ", 
                      "https://i.ytimg.com/vi/KgmMFFojhiA/maxresdefault.jpg",
                      "https://i.ytimg.com/vi/KgmMFFojhiA/hqdefault.jpg",
                      "{\"title\":\"One Way to Join Related Tables with LINQ and Entity Framework Core\",\"author_name\":\"Coding Under Pressure\",\"type\":\"video\",\"provider_name\":\"YouTube\",\"thumbnail_url\":\"https://i.ytimg.com/vi/KgmMFFojhiA/hqdefault.jpg\"}",
                      "Today we are going to take a look at one way to join tables and their data with Entity Framework using LINQ.",
                      "https://www.youtube.com/watch?v=KgmMFFojhiA",
                      DateTime.UtcNow,
                      DateTime.UtcNow },
                    
                    { 6L, "What is gRPC - Remote Procedure Calls", 
                      "https://i.ytimg.com/vi/hVrwuMnCtok/maxresdefault.jpg",
                      "https://i.ytimg.com/vi/hVrwuMnCtok/hqdefault.jpg",
                      "{\"title\":\"What is gRPC? (Remote Procedure Calls)\",\"author_name\":\"IBM Technology\",\"type\":\"video\",\"provider_name\":\"YouTube\",\"thumbnail_url\":\"https://i.ytimg.com/vi/hVrwuMnCtok/hqdefault.jpg\"}",
                      "Are you using REST APIs for your microservice-to-microservice communication? There's a faster, more scalable solution: gRPC. It is a modern communication framework from the Cloud Native Computing Foundation.",
                      "https://www.youtube.com/watch?v=hVrwuMnCtok",
                      DateTime.UtcNow,
                      DateTime.UtcNow }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // Remove seeded catalogs
            migrationBuilder.DeleteData(
                table: "catalog",
                keyColumn: "catalogID",
                keyValues: new object[] { 1L, 2L, 3L, 4L, 5L, 6L });

            // Remove seeded skills
            migrationBuilder.DeleteData(
                table: "skill",
                keyColumn: "skillID",
                keyValues: new object[] { 1L, 2L, 3L, 4L, 5L, 6L, 7L, 8L, 9L, 10L, 11L, 12L });

            // Remove seeded social platforms
            migrationBuilder.DeleteData(
                table: "social",
                keyColumn: "socialID",
                keyValues: new object[] { 1L, 2L, 3L, 4L, 5L, 6L });
        }
    }
}
