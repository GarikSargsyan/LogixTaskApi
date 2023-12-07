using LogixTaskApi.Models;
using LogixTaskApi.Models.DataBase;
using LogixTaskApi.Models.RequestModels;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace LogixTaskApi.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDBContext dbContext;
        public UserRepository(ApplicationDBContext dBContext)
        {
            this.dbContext = dBContext;
        }

        public async Task<bool> DeleteUser(Guid id)
        {
            var user = await dbContext.UserProfileDBModels.FirstOrDefaultAsync(x => x.Id == id && x.IsActive);
            if (user == null)
                return false;
            user.IsActive = false;
            await dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<UserInfo> GetUserById(Guid id)
        {
            var user = await dbContext.UserProfileDBModels.AsNoTracking().SingleOrDefaultAsync(x => x.Id == id && x.IsActive);
            var userInfo = new UserInfo()
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Address = user.Address,
                DateOfBirth = DateTime.Parse(user.DateOfBirth),
                Email = user.Email,
                FullName = user.FullName,
                Id = user.Id,
                PhoneNumber = user.PhoneNumber,
                Role = user.Role,
            };
            return userInfo;
        }

        public async Task<List<UserInfo>> GetUsers()
        {
            var users = await dbContext.UserProfileDBModels.AsNoTracking().Where(x => x.IsActive).ToListAsync();
            var resUsers = new List<UserInfo>();
            foreach (var user in users)
            {
                resUsers.Add(new UserInfo()
                {
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Address = user.Address,
                    DateOfBirth = DateTime.Parse(user.DateOfBirth),
                    Email = user.Email,
                    FullName = user.FullName,
                    Id = user.Id,
                    PhoneNumber = user.PhoneNumber,
                    Role = user.Role,
                });
            }
            return resUsers;
        }

        public async Task<bool> UpdateUser(UpdateUserRequestModel user)
        {
            var userToUpdate = await dbContext.UserProfileDBModels.Include(u => u.ClassUsers).FirstOrDefaultAsync(x => x.Id == user.Id && x.IsActive);
            if (userToUpdate == null)
                return false;

            var address = InfoCorrectHelper.AddressCorrect(user.Address);
            userToUpdate.FirstName = user.FirstName;
            userToUpdate.LastName = user.LastName;
            userToUpdate.Address = address;
            userToUpdate.DateOfBirth = user.DateOfBirth.ToString("MM/dd/yyyy");
            userToUpdate.Email = user.Email;
            userToUpdate.FullName = $"{user.FirstName} {user.LastName}";
            userToUpdate.PhoneNumber = user.PhoneNumber;
            userToUpdate.IsActive = user.IsActive;

            dbContext.ClassUsers.RemoveRange(userToUpdate.ClassUsers);

            if (user.ClassIds.Count > 0)
            {
                var classUsers = user.ClassIds
                    .Select(classId => new ClassUser { UserId = user.Id, ClassId = classId })
                    .ToList();

                dbContext.ClassUsers.AddRange(classUsers);
            }

            // Save changes to the database
            dbContext.SaveChanges();



            await dbContext.SaveChangesAsync();
            return true;
        }
    }
}
