using Finance.Domain.Entity.Entities.Users.Systems.Expenses;

namespace Finance.Domain.Interfaces.Services.Users.Systems.Expense
{
    public interface IServiceUserSystemExpense : IServiceBase<UserSystemExpense>
    {
        Task RegisterUserOnSystemExpense(UserSystemExpense userSystemExpense);
    }
}
