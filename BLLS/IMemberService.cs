using Domain.Entities;
using System.Threading.Tasks;

namespace BLLS
{
    public interface IMemberService
    {
        /// <summary>
        /// Obtenir un membre par son identifiant
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Member> GetMemberByIdAsync(int id);

        /// <summary>
        /// Obtenir un membre par son adresse email
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        Task<Member> GetMemberByEmailAsync(string email);

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