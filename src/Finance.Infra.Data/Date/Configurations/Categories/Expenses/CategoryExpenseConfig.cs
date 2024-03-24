using Finance.Domain.Entity.Entities.Categories.Expenses;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Finance.Infra.Data.Date.Configurations.Categories.Expenses
{
    public class CategoryExpenseConfig : IEntityTypeConfiguration<CategoryExpense>
    {
        public void Configure(EntityTypeBuilder<CategoryExpense> builder)
        {

            builder.ToTable("CategoriaDespesa");

            builder.HasKey(e => e.Id);

            //builder.HasOne(e => e.SystemExpense)
            //    .WithMany()
            //    .HasForeignKey(e => e.SystemExpenseId)
            //    .HasPrincipalKey(se => se.Id)
            //    .OnDelete(DeleteBehavior.Cascade); // Ajuste conforme sua necessidade de exclusão em cascata
        }
    }
}
