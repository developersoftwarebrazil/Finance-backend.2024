using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Finance.Domain.Entity.Entities.Systems.SystemIncomes
{
    public class SystemIncome : Base
    {
        [Display(Name = "MES")]
        [Column("Mes")]
        public int Month { get; set; }



        [Display(Name = "ANO")]
        [Column("Ano")]
        public int Year { get; set; }

    }
}
