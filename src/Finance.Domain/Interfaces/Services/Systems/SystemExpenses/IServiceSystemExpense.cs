using Finance.Domain.Entity.Entities.Systems.SystemExpenses;

namespace Finance.Domain.Interfaces.Services.Systems.SystemExpenses
{
    public interface IServiceSystemExpense : IServiceBase<SystemExpense>
    {
        Task AddSystemExpense(SystemExpense systemExpense);
        Task UpdateSystemExpense(SystemExpense systemExpense);
    }
}
