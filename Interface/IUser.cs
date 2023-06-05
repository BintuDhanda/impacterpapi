using ERP.Models;
using ERP.SearchFilters;

namespace ERP.Interface
{
    public interface IUser
    {
        Task<IEnumerable<Users>> GetAllAsync();
        Task<Users> GetByIdAsync(int Id);
        Task <Users> AddAsync(Users user);
        Task <Users> UpdateAsync(Users user);
        Task <Users> DeleteAsync(int Id);
        Task<UserSignUpResponse> SignUpAsync(Users user);
        Task<UserSignUpResponse> LogInAsync(Users user);
        Task<IEnumerable<Users>> SearchAsync(UserSearch userSearch);
    }
}
