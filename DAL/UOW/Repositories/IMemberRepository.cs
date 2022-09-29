using Domain.Entities;
using System.Threading.Tasks;

namespace DAL.UOW.Repositories
{
    public interface IMemberRepository : IGenericRepository<Member>
    {
        Task<Member> GetByNicknameAndPasswordAsync(string nickname, string password);
    }
}