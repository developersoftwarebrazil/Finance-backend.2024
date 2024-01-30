using Finance.Domain.Entity.Entities.Systems.SystemExpenses;
using Finance.Domain.Entity.Entities.Systems.SystemIncomes;
using System.ComponentModel.DataAnnotations.Schema;

namespace Finance.Domain.Entity.Entities.Categories
{
    public class Category : Base
    {

        [ForeignKey("SystemExpense")]
        [Column(Order = 1)]
        public int SystemExpenseId { get; set; }
        public virtual SystemExpense SystemExpense { get; set; }


        [ForeignKey("SystemIncome")]
        [Column(Order = 1)]
        public int SystemIncomeId { get; set; }
        public virtual SystemIncome SystemIncome { get; set; }


    }
}
