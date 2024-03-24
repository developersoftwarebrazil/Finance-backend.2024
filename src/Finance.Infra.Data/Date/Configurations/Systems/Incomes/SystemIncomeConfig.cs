using Finance.Domain.Entity.Entities.Systems.Incomes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Finance.Infra.Data.Date.Configurations.Systems.Incomes
{
    public class SystemIncomeConfig : IEntityTypeConfiguration<SystemIncome>
    {
        public void Configure(EntityTypeBuilder<SystemIncome> builder)
        {
            builder.ToTable("SistemaInvestimento");

            builder.Property(e => e.DayMonthlyBookClose)
                .HasColumnName("DiaFechamentoMensal");

            builder.Property(e => e.Month)
                .HasColumnName("Mes");

            builder.Property(e => e.Year)
                .HasColumnName("Ano");
        }
    }
}
