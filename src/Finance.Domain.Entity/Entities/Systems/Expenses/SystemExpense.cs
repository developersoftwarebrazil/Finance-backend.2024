using System.ComponentModel.DataAnnotations.Schema;

namespace Finance.Domain.Entity.Entities.Systems.Expenses
{
    [Table("SistemaDespesa")]
    public class SystemExpense : Base
    {
        public int Month { get; set; }

        public int MonthCopy { get; set; }

        public int DayMonthlyBookClose { get; set; }

        public int Year { get; set; }

        public int YearCopy { get; set; }

        public bool GenerateExpensesCopy
        {
            get; set;
        }
    }
}
