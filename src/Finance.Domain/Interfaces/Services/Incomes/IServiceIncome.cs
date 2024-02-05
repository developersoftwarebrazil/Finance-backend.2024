using Finance.Domain.Entity.Entities.Incomes;

namespace Finance.Domain.Interfaces.Services.Incomes
{
    public interface IServiceIncome : IServiceBase<Income>
    {
        Task AddIncome(Income income);
        Task UpdateIncome(Income income);
        Task<object> LoadGraph(string userEmail);
    }
}
