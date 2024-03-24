using Finance.Domain.Entity.Entities.Categories.Expenses;
using Finance.Domain.Entity.Entities.Categories.Incomes;
using Finance.Domain.Entity.Entities.Expenses;
using Finance.Domain.Entity.Entities.Incomes;
using Finance.Domain.Entity.Entities.Systems.Expenses;
using Finance.Domain.Entity.Entities.Systems.Incomes;
using Finance.Domain.Entity.Entities.Users.Identity;
using Finance.Domain.Entity.Entities.Users.Systems.Expenses;
using Finance.Domain.Entity.Entities.Users.Systems.Incomes;
using Finance.Infra.Data.Date.Configurations.Categories.Expenses;
using Finance.Infra.Data.Date.Configurations.Categories.Incomes;
using Finance.Infra.Data.Date.Configurations.Expenses;
using Finance.Infra.Data.Date.Configurations.Incomes;
using Finance.Infra.Data.Date.Configurations.Systems.Expenses;
using Finance.Infra.Data.Date.Configurations.Systems.Incomes;
using Finance.Infra.Data.Date.Configurations.Users.Expenses;
using Finance.Infra.Data.Date.Configurations.Users.Incomes;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Finance.Infra.Data.Date.Contexts
{
    public class FinanceDbContext : IdentityDbContext<ApplicationUser>
    {

        public FinanceDbContext(DbContextOptions options) : base(options) { }

        public DbSet<ApplicationUser> ApplicationUsers { get; set; }

        public DbSet<UserSystemExpense> UserSystemExpenses { get; set; }
        public DbSet<UserSystemIncome> UserSystemIncomes { get; set; }
        public DbSet<SystemExpense> SystemExpenses { get; set; }
        public DbSet<SystemIncome> SystemIncomes { get; set; }

        public DbSet<CategoryExpense> CategoryExpenses { get; set; }
        public DbSet<CategoryIncome> CategoryIncomes { get; set; }
        public DbSet<Income> Incomes { get; set; }
        public DbSet<Expense> Expenses { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(GetConnetioString());
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<ApplicationUser>().ToTable("AspNetUsers").HasKey(t => t.Id);

            builder.ApplyConfiguration(new ExpenseConfig());
            builder.ApplyConfiguration(new IncomeConfig());

            builder.ApplyConfiguration(new CategoryExpenseConfig());
            builder.ApplyConfiguration(new CategoryIncomeConfig());

            builder.ApplyConfiguration(new SystemExpenseConfig());
            builder.ApplyConfiguration(new SystemIncomeConfig());

            builder.ApplyConfiguration(new UserSystemExpenseConfig());
            builder.ApplyConfiguration(new UserSystemIncomeConfig());


        }
        public string GetConnetioString()
        {
            return "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Finance_2024;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        }

    }
}
