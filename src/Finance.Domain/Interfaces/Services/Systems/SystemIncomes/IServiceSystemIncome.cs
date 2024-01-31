using Finance.Domain.Entity.Entities.Systems.SystemIncomes;

namespace Finance.Domain.Interfaces.Services.Systems.SystemIncomes
{
    public interface IServiceSystemIncome : IServiceBase<SystemIncome>
    {
        Task AddSystemIncome(SystemIncome systemIncome);
        Task UpdateSystemIncome(SystemIncome systemIncome);
    }
}
