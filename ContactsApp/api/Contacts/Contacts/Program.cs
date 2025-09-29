using Contacts.Data;
using Contacts.Models.Dtos;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(ContactsProfile).Assembly);
builder.Services.AddDbContext<ContactsDbContext>(options =>
{
   options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(tmp =>
{
    tmp.AllowAnyHeader();
    tmp.AllowAnyMethod();
    tmp.AllowAnyOrigin();
});

app.UseAuthorization();

app.MapControllers();

app.Run();
