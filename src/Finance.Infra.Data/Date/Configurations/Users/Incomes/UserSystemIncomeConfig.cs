using Finance.Domain.Entity.Entities.Users.Systems.Incomes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Finance.Infra.Data.Date.Configurations.Users.Incomes
{
    public class UserSystemIncomeConfig : IEntityTypeConfiguration<UserSystemIncome>
    {
        public void Configure(EntityTypeBuilder<UserSystemIncome> builder)
        {
            builder.ToTable("UsuarioInvestimentoSistema");

            builder.HasKey(i => i.Id);

            //builder.Property(e => e.UserName)
            //    .HasColumnName("NomeUsuario")
            //    .HasDisplayValue("NOMEUSUARIO");

            builder.Property(i => i.UserEmail)
                .HasColumnName("EmailUsuario");

            builder.Property(i => i.Administrator)
                .HasColumnName("Administrador");

            builder.Property(i => i.ActualSystemMonth)
                .HasColumnName("MesAtual");

            //builder.HasOne(i => i.SystemIncome)
            //    .WithMany()
            //    .HasForeignKey(i => i.SystemIncomeId)
            //    .HasPrincipalKey(si => si.Id)
            //    .OnDelete(DeleteBehavior.Cascade); // Ajuste conforme sua necessidade de exclusão em cascata

        }
    }
}
