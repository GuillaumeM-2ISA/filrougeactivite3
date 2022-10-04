using Domain.Entities;
using System.Threading.Tasks;

namespace BLLS
{
    public interface IMemberService
    {
        /// <summary>
        /// Enregistre le nouveau membre
        /// </summary>
        /// <param name="newMember"></param>
        /// <returns></returns>
        Task<Member> RegisterAsync(Member newMember);

        /// <summary>
        /// Modifie le mot de passe du membre
        /// </summary>
        /// <param name="modifiedMember"></param>
        /// <returns></returns>
        Task<Member> UpdatePasswordAsync(Member modifiedMember);
    }
}