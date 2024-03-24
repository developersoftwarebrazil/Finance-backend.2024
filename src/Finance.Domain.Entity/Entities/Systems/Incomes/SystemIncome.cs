using System.ComponentModel.DataAnnotations.Schema;

namespace Finance.Domain.Entity.Entities.Systems.Incomes

{
    [Table("SistemaInvestimento")]
    public class SystemIncome : Base
    {
        public int DayMonthlyBookClose { get; set; }

        public int Month { get; set; }

        public int Year { get; set; }

    }
}
