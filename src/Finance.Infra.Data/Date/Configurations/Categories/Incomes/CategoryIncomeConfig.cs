using Finance.Domain.Entity.Entities.Categories.Incomes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Finance.Infra.Data.Date.Configurations.Categories.Incomes
{
    public class CategoryIncomeConfig : IEntityTypeConfiguration<CategoryIncome>
    {
        public void Configure(EntityTypeBuilder<CategoryIncome> builder)
        {
            builder.ToTable("CategoriaInvestimento");

            builder.HasKey(e => e.Id);

            //builder.HasOne(e => e.SystemIncome)
            //    .WithMany()
            //    .HasForeignKey(e => e.SystemIncomeId)
            //    .HasPrincipalKey(si => si.Id)
            //    .OnDelete(DeleteBehavior.Cascade); // Ajuste conforme sua necessidade de exclusão em cascata

        }
    }
}
