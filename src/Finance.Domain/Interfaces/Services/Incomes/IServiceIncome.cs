using Finance.Domain.Entity.Entities.Incomes;

namespace Finance.Domain.Interfaces.Services.Incomes
{
    public interface IServiceIncome : IServiceBase<Income>
    {
        Task AddIncome(Income income);
        Task UpdateExpense(Income income);
        Task<object> LoadGrafic(string userEmail);
    }
}
