using System;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using TaskManagementSystem.Api.Data;
using TaskManagementSystem.Api.Models;
using Xunit;

namespace TaskManagementSystem.Api.Tests.IntegrationTests
{
    public class AuthControllerTests : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly HttpClient _client;
        private readonly WebApplicationFactory<Program> _factory;
        private readonly string uniqueUsername;

        public AuthControllerTests(WebApplicationFactory<Program> factory)
        {
            _factory = factory.WithWebHostBuilder(builder =>
            {
                builder.ConfigureServices(services =>
                {
                    // Remove the existing DbContext registration
                    var descriptor = services.SingleOrDefault(
                        d => d.ServiceType ==
                            typeof(DbContextOptions<ApplicationDbContext>));

                    if (descriptor != null)
                    {
                        services.Remove(descriptor);
                    }

                    // Add ApplicationDbContext using an in-memory database for testing
                    services.AddDbContext<ApplicationDbContext>(options =>
                    {
                        options.UseInMemoryDatabase("InMemoryDbForTesting");
                    });

                    // Build the service provider
                    var serviceProvider = services.BuildServiceProvider();

                    // Create a scope to obtain a reference to the database contexts
                    using (var scope = serviceProvider.CreateScope())
                    {
                        var scopedServices = scope.ServiceProvider;
                        var db = scopedServices.GetRequiredService<ApplicationDbContext>();

                        // Ensure the database is created
                        db.Database.EnsureCreated();

                        // Seed the database with initial data
                        SeedDatabase(db);
                    }
                });
            });

            _client = _factory.CreateClient();
            uniqueUsername = "testuser" + DateTime.Now.Ticks;
        }

        private void SeedDatabase(ApplicationDbContext db)
        {
            // Seed the database with test data if needed
        }

        [Fact]
        public async System.Threading.Tasks.Task Register_ValidUser_ReturnsOk()
        {
            var registerModel = new RegisterModel
            {
                Username = uniqueUsername,
                Email = uniqueUsername + "@example.com",
                Password = "Password123!"
            };
            var content = new StringContent(JsonConvert.SerializeObject(registerModel), Encoding.UTF8, "application/json");

            var response = await _client.PostAsync("/api/auth/register", content);

            var responseContent = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
            {
                throw new HttpRequestException($"Registration failed with status code {response.StatusCode}. Response content: {responseContent}");
            }

            response.EnsureSuccessStatusCode();
        }

        [Fact]
        public async System.Threading.Tasks.Task Login_ValidUser_ReturnsOk()
        {
            await Register_ValidUser_ReturnsOk();

            var loginModel = new LoginModel
            {
                Username = uniqueUsername,
                Password = "Password123!"
            };
            var content = new StringContent(JsonConvert.SerializeObject(loginModel), Encoding.UTF8, "application/json");

            var response = await _client.PostAsync("/api/auth/login", content);

            var responseContent = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
            {
                throw new HttpRequestException($"Response status code does not indicate success: {response.StatusCode}. Response content: {responseContent}");
            }

            response.EnsureSuccessStatusCode();
            var responseString = await response.Content.ReadAsStringAsync();
            Assert.Contains("token", responseString);
        }
    }
}
