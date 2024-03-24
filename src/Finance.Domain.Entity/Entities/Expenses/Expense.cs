using Finance.Domain.Entity.Entities.Categories.Expenses;
using Finance.Domain.Entity.Enums.Systems;

namespace Finance.Domain.Entity.Entities.Expenses
{

    public class Expense : Base
    {

        public int Month { get; set; }

        public int Year { get; set; }

        public decimal Value { get; set; }

        public DateTime RegistrationDate { get; set; }

        public DateTime RegistrationChangeDate { get; set; }


        public DateTime PaymentDate { get; set; }

        public DateTime DueDate { get; set; }

        public bool PayedOut { get; set; }

        public DateTime OverdueExpense { get; set; }

        public TransactionTypeEnum TransactionTypes { get; set; }

        public int CategoryExpenseId { get; set; }
        public virtual CategoryExpense CategoryExpense { get; set; }

    }
}