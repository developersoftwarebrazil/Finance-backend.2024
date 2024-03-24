using Finance.Domain.Entity.Entities.Systems.Incomes;

namespace Finance.Domain.Interfaces.Services.Systems.Incomes
{
    public interface IServiceSystemIncome : IServiceBase<SystemIncome>
    {
        Task AddSystemIncome(SystemIncome systemIncome);
        Task UpdateSystemIncome(SystemIncome systemIncome);
    }
}
