using RentalCall;
using RentalCall.Managers;
using RentalCall.Managers.Interfaces;
using RentalCall.Repositories;
using RentalCall.Mapping;
using RentalCall.Repositories.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<RentalCallDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

// Register services

// Repositories
builder.Services.AddScoped<ICallRepository, CallRepository>();
builder.Services.AddScoped<IActionItemRepository, ActionItemRepository>();
builder.Services.AddScoped<ICallCategoryRepository, CallCategoryRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserRoleRepository, UserRoleRepository>();

// Managers
builder.Services.AddScoped<ICallManager, CallManager>();
builder.Services.AddScoped<IActionItemManager, ActionItemManager>();
builder.Services.AddScoped<IUserManager, UserManager>();
builder.Services.AddScoped<IUserRoleManager, UserRoleManager>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger(options => options.OpenApiVersion = Microsoft.OpenApi.OpenApiSpecVersion.OpenApi2_0);
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
