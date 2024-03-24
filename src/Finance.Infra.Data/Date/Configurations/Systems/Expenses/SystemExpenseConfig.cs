using Finance.Domain.Entity.Entities.Systems.Expenses;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Finance.Infra.Data.Date.Configurations.Systems.Expenses
{
    public class SystemExpenseConfig : IEntityTypeConfiguration<SystemExpense>
    {
        public void Configure(EntityTypeBuilder<SystemExpense> builder)
        {

            builder.ToTable("SistemaDespesa");

            builder.Property(e => e.Month)
                .HasColumnName("Mes");

            builder.Property(e => e.MonthCopy)
                .HasColumnName("MesCopia");

            builder.Property(e => e.DayMonthlyBookClose)
                .HasColumnName("DiaFechamentoMensal");

            builder.Property(e => e.Year)
                .HasColumnName("Ano");

            builder.Property(e => e.YearCopy)
                .HasColumnName("AnoCopia");

            builder.Property(e => e.GenerateExpensesCopy)
                .HasColumnName("GerarCopiaDespesa");
        }

    }
}

