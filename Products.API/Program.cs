using Microsoft.Extensions.Options;
using Products.API.Abstractions;
using Products.API.Infrastructure.Mongo;
using Products.API.Infrastructure.Repositories;
using Products.API.Mappers;
using Products.API.Services;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.Configure<MongoSettings>(builder.Configuration.GetRequiredSection(nameof(MongoSettings)));
builder.Services.AddSingleton<IMongoSettings>(sp => sp.GetRequiredService<IOptions<MongoSettings>>().Value);

builder.Services.AddScoped<IProductsMapper, ProductsMapper>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IProductService, ProductService>();

builder.Services.AddControllers();

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference(options =>
    {
        options.WithTheme(ScalarTheme.Mars);
        options.WithTitle("Products API");
        options.ShowSidebar = true;
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
