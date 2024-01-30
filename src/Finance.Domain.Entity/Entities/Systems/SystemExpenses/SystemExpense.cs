using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Finance.Domain.Entity.Entities.Systems.SystemExpenses
{
    [Table("SistemaDespesa")]
    public class SystemExpense : Base
    {

        [Display(Name = "MES")]
        [Column("Mes")]
        public int Month { get; set; }

        [Display(Name = "MESCOPIA")]
        [Column("MesCopia")]
        public int MonthCopy { get; set; }

        [Display(Name = "DIAFECHAMENTOMENSAL")]
        [Column("DiaFechamentoMensal")]
        public int DayMonthlyBookClose { get; set; }

        [Display(Name = "ANO")]
        [Column("Ano")]
        public int Year { get; set; }

        [Display(Name = "ANOCOPIA")]
        [Column("AnoCopia")]
        public int YearCopy { get; set; }


        [Display(Name = "GERARCOPIADESPESA")]
        [Column("GerarCopiaDespesa")]
        public bool GenerateExpensesCopy
        {
            get; set;
        }
    }
}
