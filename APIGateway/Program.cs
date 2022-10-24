using Microsoft.AspNetCore;
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

/*ocelotBuilder.ConfigureServices(s =>
        s.AddSingleton(ocelotBuilder))
        .ConfigureAppConfiguration(c => 
        c.AddJsonFile("ocelot.json"));*/

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
                    .AddConsul()
                    // Store the configuration in consul
                    .AddConfigStoredInConsul();
            })
            .Configure(app =>
            {
                app.UseMvc().UseSwagger().UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/a/swagger.json", "Catalog");
                    c.SwaggerEndpoint("/b/swagger.json", "Catalog");
                });
                app.UseOcelot().Wait();
            })
            ;

/*builder.Services.AddOcelot()
    .AddConsul()
    .AddConfigStoredInConsul(); //Ocelot added*/

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();

//app.UseOcelot().Wait();
