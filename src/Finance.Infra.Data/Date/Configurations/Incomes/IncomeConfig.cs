using Finance.Domain.Entity.Entities.Incomes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Finance.Infra.Data.Date.Configurations.Incomes
{
    public class IncomeConfig : IEntityTypeConfiguration<Income>
    {
        public void Configure(EntityTypeBuilder<Income> builder)
        {
            builder.ToTable("Investimento");

            builder.Property(e => e.Month)
                .HasColumnName("Mes");

            builder.Property(e => e.Year)
                .HasColumnName("Ano");

            builder.Property(e => e.Value)
                .HasColumnName("Valor")
                .HasPrecision(18, 2) // Definindo 18 dígitos no total, com 2 dígitos após o ponto decimal
                .HasColumnType("decimal(18, 2)"); // Especificando o tipo de coluna no banco de dados


            builder.Property(e => e.RegistrationDate)
                .HasColumnName("DataCadastro");


            builder.Property(e => e.RegistrationChangeDate)
                .HasColumnName("DataAlteracaoCadastro");

            builder.Property(e => e.IncomeDate)
                .HasColumnName("DataInvestimento");

            builder.Property(e => e.TransactionTypes)
                .HasColumnName("TipoTransacao");

            //builder.HasOne(e => e.CategoryIncome)
            //    .WithMany()
            //    .HasForeignKey(e => e.CategoryIncomeId)
            //    .HasPrincipalKey(ci => ci.Id)
            //    .OnDelete(DeleteBehavior.Restrict); // Se necessário, ajuste essa configuração de acordo com sua lógica de negócios.
        }
    }
}
