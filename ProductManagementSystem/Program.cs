﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ProductManagementSystem.Data;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<ProductManagementSystemContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ProductManagementSystemContext") ?? throw new InvalidOperationException("Connection string 'ProductManagementSystemContext' not found.")));

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors((p) => p.AddDefaultPolicy(
                                    policy => policy.WithOrigins("*").
                                               AllowAnyHeader()
                                                  .AllowAnyMethod()
                                                  )
                          );

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseCors();

app.Run();
