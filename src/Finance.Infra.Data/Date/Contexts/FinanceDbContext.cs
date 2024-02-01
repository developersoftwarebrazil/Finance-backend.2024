using Finance.Domain.Entity.Entities.Categories;
using Finance.Domain.Entity.Entities.Expenses;
using Finance.Domain.Entity.Entities.Incomes;
using Finance.Domain.Entity.Entities.Systems.SystemExpenses;
using Finance.Domain.Entity.Entities.Systems.SystemIncomes;
using Finance.Domain.Entity.Entities.Users.Identity;
using Finance.Domain.Entity.Entities.Users.Systems;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Finance.Infra.Data.Date.Contexts
{
    public class FinanceDbContext : IdentityDbContext<ApplicationUser>
    {

        public FinanceDbContext(DbContextOptions options) : base(options) { }

        public DbSet<ApplicationUser> ApplicationUsers { get; set; }

        public DbSet<UserSystem> UserSystems { get; set; }
        public DbSet<SystemExpense> SystemExpenses { get; set; }
        public DbSet<SystemIncome> SystemIncomes { get; set; }


        public DbSet<Category> Categories { get; set; }
        public DbSet<Income> Incomes { get; set; }
        public DbSet<Expense> Expenses { get; set; }



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(GetConnetioString());
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<ApplicationUser>().ToTable("AspNetUsers").HasKey(t => t.Id);
            base.OnModelCreating(builder);
        }
        public string GetConnetioString()
        {
            return "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Finance_2024;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        }

    }
}
