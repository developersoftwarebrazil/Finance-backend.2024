using Finance.Domain.Entity.Entities.Users.Systems.Expenses;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Finance.Infra.Data.Date.Configurations.Users.Expenses
{
    public class UserSystemExpenseConfig : IEntityTypeConfiguration<UserSystemExpense>
    {
        public void Configure(EntityTypeBuilder<UserSystemExpense> builder)
        {
            builder.ToTable("UsuarioDespesaSistema");

            builder.HasKey(e => e.Id);

            //builder.Property(e => e.UserName)
            //    .HasColumnName("NomeUsuario")
            //    .HasDisplayValue("NOMEUSUARIO");

            builder.Property(e => e.UserEmail)
                .HasColumnName("EmailUsuario");

            builder.Property(e => e.Administrator)
                .HasColumnName("Administrador");

            builder.Property(e => e.ActualSystemMonth)
                .HasColumnName("MesAtual");

            //builder.HasOne(e => e.SystemExpense)
            //    .WithMany()
            //    .HasForeignKey(e => e.SystemExpenseId)
            //    .HasPrincipalKey(se => se.Id)
            //    .OnDelete(DeleteBehavior.Cascade); // Ajuste conforme sua necessidade de exclusão em cascata

        }
    }
}
