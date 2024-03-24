using Finance.Domain.Entity.Entities.Users.Systems.Incomes;

namespace Finance.Domain.Interfaces.Services.Users.Systems.Incomes
{
    public interface IServiceUserSystemIncome : IServiceBase<UserSystemIncome>
    {
        Task RegisterUserOnSystemIncome(UserSystemIncome userSystemIncome);
    }
}
