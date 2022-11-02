/*using Microsoft.AspNetCore;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;
using Ocelot.Provider.Consul;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var ocelotBuilder = WebHost.CreateDefaultBuilder(args);

*//*ocelotBuilder.ConfigureServices(s =>
        s.AddSingleton(ocelotBuilder))
        .ConfigureAppConfiguration(c => 
        c.AddJsonFile("ocelot.json"));*//*

ocelotBuilder.UseUrls("http://*:9000")
             .ConfigureAppConfiguration((hostingContext, config) =>
             {
                 config
                     .SetBasePath(hostingContext.HostingEnvironment.ContentRootPath)
                     .AddJsonFile("ocelot.json")
                     .AddEnvironmentVariables();
             })
            .ConfigureServices(services =>
            {
                services.AddOcelot()
                    .AddConsul();
            })
            .Configure(app =>
            {
                app.UseMvc()
                .UseSwagger()
                .UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/a/swagger.json", "Catalog");
                    c.SwaggerEndpoint("/b/swagger.json", "Product");
                });
                app.UseOcelot().Wait();
            });

var app = builder.Build();

app.UseAuthorization();

app.MapControllers();

app.Run();

*/



namespace APIGateway
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
            .ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder.UseStartup<Startup>();
            })
            .ConfigureAppConfiguration((hostingContext, config) =>
            {
                config.AddJsonFile("ocelot.json");
            });
    }
}