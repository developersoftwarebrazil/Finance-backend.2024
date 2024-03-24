using Finance.Domain.Entity.Entities.Categories.Incomes;
using Finance.Domain.Entity.Enums.Systems;

namespace Finance.Domain.Entity.Entities.Incomes
{

    public class Income : Base
    {
        public int Month { get; set; }

        public int Year { get; set; }

        public decimal Value { get; set; }

        public DateTime RegistrationDate { get; set; }

        public DateTime RegistrationChangeDate { get; set; }

        public DateTime IncomeDate { get; set; }

        public TransactionTypeEnum TransactionTypes { get; set; }

        public int CategoryIncomeId { get; set; }
        public virtual CategoryIncome CategoryIncome { get; set; }
    }
}

