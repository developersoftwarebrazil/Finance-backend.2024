using Finance.Domain.Entity.Entities.Systems.Expenses;

namespace Finance.Domain.Interfaces.Services.Systems.Expenses
{
    public interface IServiceSystemExpense : IServiceBase<SystemExpense>
    {
        Task AddSystemExpense(SystemExpense systemExpense);
        Task UpdateSystemExpense(SystemExpense systemExpense);
    }
}
