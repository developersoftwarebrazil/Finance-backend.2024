using Finance.Domain.Entity.Entities.Users.Identity;
using Finance.Domain.Interfaces.Repositories;
using Finance.Domain.Interfaces.Repositories.Categories;
using Finance.Domain.Interfaces.Repositories.Expenses;
using Finance.Domain.Interfaces.Repositories.Incomes;
using Finance.Domain.Interfaces.Repositories.Systems.SystemExpenses;
using Finance.Domain.Interfaces.Repositories.Systems.SystemIncomes;
using Finance.Domain.Interfaces.Repositories.Users.Systems;
using Finance.Domain.Interfaces.Services;
using Finance.Domain.Interfaces.Services.Categories;
using Finance.Domain.Interfaces.Services.Expenses;
using Finance.Domain.Interfaces.Services.Incomes;
using Finance.Domain.Interfaces.Services.Systems.SystemExpenses;
using Finance.Domain.Interfaces.Services.Systems.SystemIncomes;
using Finance.Domain.Interfaces.Services.Users.Systems;
using Finance.Domain.Services;
using Finance.Domain.Services.Categories;
using Finance.Domain.Services.Expenses;
using Finance.Domain.Services.Incomes;
using Finance.Domain.Services.Systems.SystemExpenses;
using Finance.Domain.Services.Systems.SystemIncomes;
using Finance.Domain.Services.Users.Systems;
using Finance.Infra.Data.Date.Contexts;
using Finance.Infra.Data.Repositories;
using Finance.Infra.Data.Repositories.Categories;
using Finance.Infra.Data.Repositories.Expenses;
using Finance.Infra.Data.Repositories.Incomes;
using Finance.Infra.Data.Repositories.System.SystemExpenses;
using Finance.Infra.Data.Repositories.System.SystemIncomes;
using Finance.Infra.Data.Repositories.Users.Systems;
using Finance.Web.API.Tokens;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//builder.Services.AddControllers();
builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.PropertyNamingPolicy = null;
    });

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Add Contexts Base
builder.Services.AddDbContext<FinanceDbContext>(options =>
  options.UseSqlServer(builder.Configuration.GetConnectionString("ConnectionStrings")));
//Add configuration Identity
builder.Services.AddDefaultIdentity<ApplicationUser>(options =>
  options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<FinanceDbContext>();

// DOM�NIO PARA INFRAESTRUTURA

//// INTERFACE E REPOSIT�RIO

builder.Services.AddSingleton(typeof(IRepositoryBase<>), typeof(RepositoryBase<>));
builder.Services.AddSingleton<IRepositoryCategory, RepositoryCategory>();
builder.Services.AddSingleton<IRepositoryExpense, RepositoryExpense>();
builder.Services.AddSingleton<IRepositoryIncome, RepositoryIncome>();
builder.Services.AddSingleton<IRepositorySystemExpense, RepositorySystemExpense>();
builder.Services.AddSingleton<IRepositorySystemIncome, RepositorySystemIncome>();
builder.Services.AddSingleton<IRepositoryUserSystem, RepositoryUserSystem>();

//DOM�NIO
//// SERVI�O DOMINIO
builder.Services.AddSingleton(typeof(IServiceBase<>), typeof(ServiceBase<>));
builder.Services.AddSingleton<IServiceCategory, ServiceCategory>();
builder.Services.AddSingleton<IServiceExpense, ServiceExpense>();
builder.Services.AddSingleton<IServiceIncome, ServiceIncome>();
builder.Services.AddSingleton<IServiceSystemExpense, ServiceSystemExpense>();
builder.Services.AddSingleton<IServiceSystemIncome, ServiceSystemIncome>();
builder.Services.AddSingleton<IServiceUserSystem, ServiceUserSystem>();

// CONFIGURA��ES DO JWT
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
             .AddJwtBearer(option =>
             {
                 option.TokenValidationParameters = new TokenValidationParameters
                 {
                     ValidateIssuer = false,
                     ValidateAudience = false,
                     ValidateLifetime = true,
                     ValidateIssuerSigningKey = true,

                     ValidIssuer = "Code.Security.Bearer",
                     ValidAudience = "Teste.Security.Bearer",
                     IssuerSigningKey = JwtSecurityKey.Create("43443FDFDF34DF34343fdf344SDFSDFSDFSDFSDF4545354345SDFGDFGDFGDFGdffgfdGDFGDGR%")
                 };

                 option.Events = new JwtBearerEvents
                 {
                     OnAuthenticationFailed = context =>
                     {
                         Console.WriteLine("OnAuthenticationFailed: " + context.Exception.Message);
                         return Task.CompletedTask;
                     },
                     OnTokenValidated = context =>
                     {
                         Console.WriteLine("OnTokenValidated: " + context.SecurityToken);
                         return Task.CompletedTask;
                     }
                 };
             });


var app = builder.Build();

//// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


var devClient = "http://localhost:4200";

app.UseCors(x =>
x.AllowAnyOrigin()
.AllowAnyMethod()
.AllowAnyHeader()
.WithOrigins(devClient));

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
