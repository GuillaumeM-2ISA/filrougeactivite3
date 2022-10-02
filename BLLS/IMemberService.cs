using Domain.Entities;
using System.Threading.Tasks;

namespace BLLS
{
    public interface IMemberService
    {
        Task<Member> RegisterAsync(Member newMember);

        Task<Member> UpdatePasswordAsync(Member modifiedMember);
    }
}