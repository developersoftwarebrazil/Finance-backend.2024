using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Finance.Domain.Entity.Entities.Systems.SystemIncomes
{
    [Table("SistemaInvestimento")]
    public class SystemIncome : Base
    {
        [Display(Name = "DIAFECHAMENTOMENSAL")]
        [Column("DiaFechamentoMensal")]
        public int DayMonthlyBookClose { get; set; }

        [Display(Name = "MES")]
        [Column("Mes")]
        public int Month { get; set; }

        [Display(Name = "ANO")]
        [Column("Ano")]
        public int Year { get; set; }


    }
}
