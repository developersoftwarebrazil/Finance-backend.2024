using Finance.Domain.Entity.Entities.Users.Systems;

namespace Finance.Domain.Interfaces.Services.Users.Systems
{
    public interface IServiceUserSystem : IServiceBase<UserSystem>
    {
        Task RegisterUserSystem(UserSystem userSystem);
    }
}
