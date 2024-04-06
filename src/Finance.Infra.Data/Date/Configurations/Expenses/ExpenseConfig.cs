using Finance.Domain.Entity.Entities.Expenses;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Finance.Infra.Data.Date.Configurations.Expenses
{
    public class ExpenseConfig : IEntityTypeConfiguration<Expense>
    {
        public void Configure(EntityTypeBuilder<Expense> builder)
        {
            // Define a tabela para a entidade Expense
            builder.ToTable("Despesa");

            // Mapeia a propriedade Month para a coluna Mes
            builder.Property(e => e.Month)
                .HasColumnName("Mes");

            // Mapeia a propriedade Year para a coluna Ano
            builder.Property(e => e.Year)
                .HasColumnName("Ano");


            // Mapeia a propriedade Value para a coluna Valor
            builder.Property(e => e.Value)
                .HasColumnName("Valor")
                .HasPrecision(18, 2) // Definindo 18 dígitos no total, com 2 dígitos após o ponto decimal
                .HasColumnType("decimal(18, 2)"); // Especificando o tipo de coluna no banco de dados


            // Mapeia a propriedade RegistrationDate para a coluna DataCadastro
            builder.Property(e => e.RegistrationDate)
                .HasColumnName("DataCadastro");


            // Mapeia a propriedade RegistrationChangeDate para a coluna DataAlteracaoCadastro
            builder.Property(e => e.RegistrationChangeDate)
                .HasColumnName("DataAlteracaoCadastro");


            // Mapeia a propriedade PaymentDate para a coluna DataPagamento
            builder.Property(e => e.PaymentDate)
                .HasColumnName("DataPagamento");


            // Mapeia a propriedade DueDate para a coluna DataVencimento
            builder.Property(e => e.DueDate)
                .HasColumnName("DataVencimento");

            // Mapeia a propriedade PayedOut para a coluna Pago
            builder.Property(e => e.PayedOut)
                .HasColumnName("Pago");

            // Mapeia a propriedade OverdueExpense para a coluna DespesaEmAtraso
            builder.Property(e => e.OverdueExpense)
                .HasColumnName("DespesaEmAtraso");

            // Mapeia a propriedade TransactionTypes para a coluna TipoTransacao
            builder.Property(e => e.TransactionTypes)
                .HasColumnName("TipoTransacao");

            // Define a chave estrangeira para a entidade CategoryExpense
            //builder.HasOne(e => e.CategoryExpense)
            //    .WithMany()
            //    .HasForeignKey(e => e.CategoryExpenseId)
            //    .OnDelete(DeleteBehavior.Restrict); // Se você não deseja exclusão em cascata

            // Mapeia a chave estrangeira para a coluna CategoryExpenseId
            builder.Property(e => e.CategoryExpenseId)
                .HasColumnName("CategoryExpenseId");

        }
    }
}
