using Microsoft.AspNetCore;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;
using Ocelot.Provider.Consul;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(
    p => p.AddPolicy("corsapp", builder =>
    {
        builder.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();
    })
);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddOcelot();

builder.Configuration.AddJsonFile("ocelot.json");

var app = builder.Build();

app.UseAuthorization();

app.UseSwagger();

app.UseSwaggerUI( c =>
    {
        c.SwaggerEndpoint("/catalog/swagger.json", "Catalog");
        c.SwaggerEndpoint("/product/swagger.json", "Product");
    }
);

app.UseOcelot();

app.UseCors();

app.MapControllers();

if (app.Environment.IsDevelopment())
{
    app.Run();
}
else
{
    app.Run("http://0.0.0.0:5000");
}


