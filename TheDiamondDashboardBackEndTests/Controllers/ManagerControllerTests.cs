using TheDiamondDashboardBackEnd.Data;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net.Http.Json;
using TheDiamondDashboardBackEnd.Models;
using Newtonsoft.Json;
using System.Text;

namespace TheDiamondDashboardBackEnd.Controllers.Tests
{
    [TestClass()]
    public class ManagerControllerTests
    {
        private WebApplicationFactory<Program> _factory;
        public ManagerControllerTests()
        {
            _factory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder =>
            {
                builder.ConfigureTestServices(services =>
                {
                    services.RemoveAll(typeof(DbContextOptions<DataContext>));
                    services.AddDbContext<DataContext>(options =>
                    {
                        options.UseInMemoryDatabase("test");
                    });
                });
            });
        }

        [TestMethod()]
        public async Task GetAllManagersTest()
        {
            // Arrange
            using (var scope = _factory.Services.CreateScope())
            {
                var scopService = scope.ServiceProvider;
                var dbContext = scopService.GetRequiredService<DataContext>();

                dbContext.Database.EnsureDeleted();
                dbContext.Database.EnsureCreated();
                dbContext.manager.Add(new Manager()
                {
                    Id = 1,
                    Name = "Mark",
                    ClubName = "Yankees"
                });
                dbContext.SaveChanges();
            }
            var client = _factory.CreateClient();

            // Act
            var response = await client.GetAsync(HttpHelper.Urls.Manager);
            var result = await response.Content.ReadFromJsonAsync<List<Manager>>();

            // Assert
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);

            result.Count.Should().Be(1);
            result[0].Id.Should().Be(1);
            result[0].Name.Should().Be("Mark");
            result[0].ClubName.Should().Be("Yankees");
        }

        [TestMethod()]
        public async Task GetSingleManagerTestCorrectInput()
        {
            // Arrange
            using (var scope = _factory.Services.CreateScope())
            {
                var scopService = scope.ServiceProvider;
                var dbContext = scopService.GetRequiredService<DataContext>();

                dbContext.Database.EnsureDeleted();
                dbContext.Database.EnsureCreated();
                dbContext.manager.Add(new Manager()
                {
                    Id = 1,
                    Name = "Mark",
                    ClubName = "Yankees"
                });
                dbContext.SaveChanges();
            }
            var client = _factory.CreateClient();

            // Act
            var response = await client.GetAsync(HttpHelper.Urls.ManagerId1);
            var result = await response.Content.ReadFromJsonAsync<Manager>();

            // Assert
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);

            result.Id.Should().Be(1);
            result.Name.Should().Be("Mark");
            result.ClubName.Should().Be("Yankees");
        }

        [TestMethod()]
        public async Task GetSingleManagerTestWrongInput()
        {
            // Arrange
            using (var scope = _factory.Services.CreateScope())
            {
                var scopService = scope.ServiceProvider;
                var dbContext = scopService.GetRequiredService<DataContext>();

                dbContext.Database.EnsureDeleted();
                dbContext.Database.EnsureCreated();
                dbContext.manager.Add(new Manager()
                {
                    Id = 1,
                    Name = "Mark",
                    ClubName = "Yankees"
                });
                dbContext.SaveChanges();
            }
            var client = _factory.CreateClient();

            // Act
            var response = await client.GetAsync(HttpHelper.Urls.ManagerId2);

            // Assert
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.NoContent);

        }

        [TestMethod()]
        public async Task AddManagerTest()
        {
            // Arrange
            using (var scope = _factory.Services.CreateScope())
            {
                var scopService = scope.ServiceProvider;
                var dbContext = scopService.GetRequiredService<DataContext>();

                dbContext.Database.EnsureDeleted();
                dbContext.Database.EnsureCreated();
                dbContext.SaveChanges();
            }
            var client = _factory.CreateClient();
            var manager = new Manager()
            {
                Id = 1,
                Name = "Mark",
                ClubName = "Yankees"
            };
            var httpContent = new StringContent(JsonConvert.SerializeObject(manager), Encoding.UTF8, "application/json");

            // Act
            var request = await client.PostAsync(HttpHelper.Urls.Manager, httpContent);
            var response = await client.GetAsync(HttpHelper.Urls.Manager);
            var result = await response.Content.ReadFromJsonAsync<List<Manager>>();

            // Assert
            request.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);

            result.Count.Should().Be(1);
            result[0].Id.Should().Be(1);
            result[0].Name.Should().Be("Mark");
            result[0].ClubName.Should().Be("Yankees");
        }

        [TestMethod()]
        public async Task UpdateManagerTest()
        {
            // Arrange
            using (var scope = _factory.Services.CreateScope())
            {
                var scopService = scope.ServiceProvider;
                var dbContext = scopService.GetRequiredService<DataContext>();

                dbContext.Database.EnsureDeleted();
                dbContext.Database.EnsureCreated();
                dbContext.manager.Add(new Manager()
                {
                    Id = 1,
                    Name = "Mark",
                    ClubName = "Yankees"
                });
                dbContext.SaveChanges();
            }
            var client = _factory.CreateClient();
            var manager = new Manager()
            {
                Id = 1,
                Name = "Jaap",
                ClubName = "Cubs"
            };
            var httpContent = new StringContent(JsonConvert.SerializeObject(manager), Encoding.UTF8, "application/json");

            // Act
            var request = await client.PutAsync(HttpHelper.Urls.Manager, httpContent);
            var response = await client.GetAsync(HttpHelper.Urls.Manager);
            var result = await response.Content.ReadFromJsonAsync<List<Manager>>();

            // Assert
            request.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);

            result.Count.Should().Be(1);
            result[0].Id.Should().Be(1);
            result[0].Name.Should().Be("Jaap");
            result[0].ClubName.Should().Be("Cubs");
        }

        [TestMethod()]
        public async Task DeleteManagersTestCorrectInput()
        {
            // Arrange
            using (var scope = _factory.Services.CreateScope())
            {
                var scopService = scope.ServiceProvider;
                var dbContext = scopService.GetRequiredService<DataContext>();

                dbContext.Database.EnsureDeleted();
                dbContext.Database.EnsureCreated();
                dbContext.manager.Add(new Manager()
                {
                    Id = 1,
                    Name = "Mark",
                    ClubName = "Yankees"
                });
                dbContext.SaveChanges();
            }
            var client = _factory.CreateClient();

            // Act
            var request = await client.DeleteAsync(HttpHelper.Urls.ManagerId1);
            var response = await client.GetAsync(HttpHelper.Urls.Manager);
            var result = await response.Content.ReadFromJsonAsync<List<Manager>>();

            // Assert
            request.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);

            result.Count.Should().Be(0);
        }

        [TestMethod()]
        public async Task DeleteManagersTestWrongInput()
        {
            // Arrange
            using (var scope = _factory.Services.CreateScope())
            {
                var scopService = scope.ServiceProvider;
                var dbContext = scopService.GetRequiredService<DataContext>();

                dbContext.Database.EnsureDeleted();
                dbContext.Database.EnsureCreated();
                dbContext.manager.Add(new Manager()
                {
                    Id = 1,
                    Name = "Mark",
                    ClubName = "Yankees"
                });
                dbContext.SaveChanges();
            }
            var client = _factory.CreateClient();

            // Act
            var request = await client.DeleteAsync(HttpHelper.Urls.ManagerId2);
            var response = await client.GetAsync(HttpHelper.Urls.Manager);
            var result = await response.Content.ReadFromJsonAsync<List<Manager>>();

            // Assert
            request.StatusCode.Should().Be(System.Net.HttpStatusCode.NotFound);
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);

            result.Count.Should().Be(1);
        }
    }
}