using Finance.Domain.Entity.Entities.Users.Identity;
using Finance.Infra.Data.Date.Contexts;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Add Contexts Base
builder.Services.AddDbContext<FinanceDbContext>(options =>
  options.UseSqlServer(builder.Configuration.GetConnectionString("ConnectionStrings")));
//Add configuration Identity
builder.Services.AddDefaultIdentity<ApplicationUser>(options =>
  options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<FinanceDbContext>();

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

app.Run();
