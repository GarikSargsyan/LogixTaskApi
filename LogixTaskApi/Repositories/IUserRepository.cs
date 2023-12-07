using LogixTaskApi.Models;
using LogixTaskApi.Models.DataBase;
using LogixTaskApi.Models.RequestModels;

namespace LogixTaskApi.Repositories
{
    public interface IUserRepository
    {
        public Task<List<UserInfo>> GetUsers();
        public Task<UserInfo> GetUserById(Guid id);
        public Task<bool> DeleteUser(Guid id);
        //public Task<bool> CreateUser(CreateUserRequestModel user);
        public Task<bool> UpdateUser(UpdateUserRequestModel user);
    }
}
