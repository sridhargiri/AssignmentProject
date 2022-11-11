using AssignmentDataLayer.DataContext;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestPlatform.TestHost;

namespace AssignmentProject.IntegrationTests
{
    public class TestingWebAppFactory<TEntryPoint> : WebApplicationFactory<Program> where TEntryPoint : Program
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureServices(services =>
            {
                var descriptor = services.SingleOrDefault(
                    d => d.ServiceType ==
                        typeof(DbContextOptions<AssignmentDbContext>));

                if (descriptor != null)
                    services.Remove(descriptor);

                services.AddDbContext<AssignmentDbContext>(options =>
                {
                    options.UseInMemoryDatabase("AssignmentDb");
                });

                var sp = services.BuildServiceProvider();
                using (var scope = sp.CreateScope())
                using (var appContext = scope.ServiceProvider.GetRequiredService<AssignmentDbContext>())
                {
                    try
                    {
                        if (appContext.Database.ProviderName != "Microsoft.EntityFrameworkCore.InMemory")
                            appContext.Database.Migrate();
                    }
                    catch (Exception ex)
                    {
                        //Log errors or do anything you think it's needed
                        throw;
                    }
                }
            });
        }
    }

    public class BooksControllerIntegrationTests : IClassFixture<TestingWebAppFactory<Program>>
    {
        private readonly HttpClient _client;

        public BooksControllerIntegrationTests(TestingWebAppFactory<Program> factory)
            => _client = factory.CreateClient();
        [Fact]
        public async Task GetAll_WhenCalled_ReturnsOk()
        {
            var response = await _client.GetAsync("/Books/GetAllBooks");

            response.EnsureSuccessStatusCode();

            var responseString = await response.Content.ReadAsStringAsync();

            Assert.True(responseString.Length > 0);
        }
        [Fact]
        public async Task GetById_WhenCalled_ReturnsOk()
        {
            var response = await _client.GetAsync("/Books/GetById/58D9B665-26F0-4B0C-B27A-58B29CF766ED");
            response.EnsureSuccessStatusCode();
            Assert.NotNull(response);
        }
        [Fact]
        public async Task GetById_WhenCalled_ReturnsNull()
        {
            var response = await _client.GetAsync("/Books/GetById/5AC9B665-26F0-4B0C-B27A-58B29CF766ED");
            response.EnsureSuccessStatusCode();
            Assert.Null(response);
        }
        [Fact]
        public async Task Delete_WhenCalled_ReturnsOk()
        {
            var response = await _client.GetAsync("/Books/Delete/97D9B665-26F0-4B0C-C27A-58B29CF766ED");
            response.EnsureSuccessStatusCode();
            Assert.NotNull(response);
        }
    }
}