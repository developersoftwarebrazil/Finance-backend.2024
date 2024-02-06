using Finance.Domain.Entity.Enums.Systems;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Finance.Domain.Entity.Entities.Expenses
{
    [Table("Despesa")]
    public class Expense : Base
    {
        [Display(Name = "MES")]
        [Column("Mes")]
        public int Month { get; set; }

        [Display(Name = "ANO")]
        [Column("Ano")]
        public int Year { get; set; }


        [Display(Name = "VALOR")]
        [Column("Valor")]
        public decimal Value { get; set; }


        [Display(Name = "DATACADASTRO")]
        [Column("DataCadastro")]
        public DateTime RegistrationDate { get; set; }

        [Display(Name = "DATAALTERACAOCADASTRO")]
        [Column("DataAlteracaoCadastro")]
        public DateTime RegistrationChangeDate { get; set; }

        [Display(Name = "DATAPAGAMENTO")]
        [Column("DataPagamento")]
        public DateTime paymentDate { get; set; }

        [Display(Name = "DATAVENCIMENTO")]
        [Column("DataVencimencimento")]
        public DateTime DueDate { get; set; }

        [Display(Name = "PAGO")]
        [Column("Pago")]
        public bool PayedOut { get; set; }

        [Display(Name = "DESPESAEMATRASO")]
        [Column("DespesaEmAtraso")]
        public DateTime OverdueExpense { get; set; }

        [Display(Name = "TIPOTRANSACAO")]
        [Column("TipoTransacao")]
        public TransactionTypeEnum TransactionTypes { get; set; }

        [ForeignKey("Category")]
        [Column(Order = 1)]
        public int CategoryId { get; set; }
        //public virtual Category Category { get; set; }

    }
}