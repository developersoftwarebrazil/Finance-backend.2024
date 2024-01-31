using Finance.Domain.Entity.Entities.Systems.SystemIncomes;

namespace Finance.Domain.Interfaces.Repositories.Systems.SystemIncomes
{
    internal interface IRepositorySystemIncome : IRepositoryBase<SystemIncome>
    {
        Task<IList<SystemIncome>> SystemUserList(string userEmail);
    }
}
