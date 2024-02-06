using System.ComponentModel.DataAnnotations.Schema;

namespace Finance.Domain.Entity.Entities.Categories
{
    [Table("Categoria")]
    public class Category : Base
    {

        [ForeignKey("SystemExpense")]
        [Column(Order = 1)]
        public int SystemExpenseId { get; set; }
        //public virtual SystemExpense SystemExpense { get; set; }


        [ForeignKey("SystemIncome")]
        [Column(Order = 0)]
        public int SystemIncomeId { get; set; }
        //public virtual SystemIncome SystemIncome { get; set; }


    }
}
