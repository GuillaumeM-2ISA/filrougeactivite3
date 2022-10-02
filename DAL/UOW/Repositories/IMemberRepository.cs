using Domain.Entities;
using System.Threading.Tasks;

namespace DAL.UOW.Repositories
{
    public interface IMemberRepository : IGenericRepository<Member>
    {
        Task<bool> IsGettableByNicknameAsync(string nickname);

        Task<bool> IsGettableByEmailAsync(string email);

        Task<Member> GetByNicknameAndPasswordAsync(string nickname, string password);
    }
}