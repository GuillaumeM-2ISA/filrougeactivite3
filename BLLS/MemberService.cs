using DAL.UOW;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BLLS
{
    class MemberService : IMemberService
    {
        private readonly IUnitOfWork _dbContext;

        public MemberService(IUnitOfWork dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Member>> GetMembersAsync()
        {
            return await _dbContext.Members.GetAllAsync();
        }

        public async Task<Member> GetMemberByIdAsync(int id)
        {
            return await _dbContext.Members.GetByIdAsync(id);
        }

        public async Task<Member> GetMemberByEmailAsync(string email)
        {
            return await _dbContext.Members.GetByEmailAsync(email);
        }

        public async Task<Member> RegisterAsync(Member newMember)
        {
            newMember.Password = Convert.ToBase64String(GenerateSaltedHash(Encoding.UTF8.GetBytes(newMember.Password), Encoding.UTF8.GetBytes("12356789")));
            return await _dbContext.Members.AddAsync(newMember);
        }

        public async Task<Member> UpdatePasswordAsync(Member modifiedMember)
        {
            modifiedMember.Password = Convert.ToBase64String(GenerateSaltedHash(Encoding.UTF8.GetBytes(modifiedMember.Password), Encoding.UTF8.GetBytes("12356789")));
            return await _dbContext.Members.UpdatePasswordAsync(modifiedMember);
        }

        // https://stackoverflow.com/questions/2138429/hash-and-salt-passwords-in-c-sharp
        /// <summary>
        /// Génère un hash à partir d'un texte et d'un grain de sel
        /// </summary>
        /// <param name="plainText"></param>
        /// <param name="salt"></param>
        /// <returns></returns>
        public static byte[] GenerateSaltedHash(byte[] plainText, byte[] salt)
        {
            HashAlgorithm algorithm = new SHA256Managed();

            byte[] plainTextWithSaltBytes =
              new byte[plainText.Length + salt.Length];

            for (int i = 0; i < plainText.Length; i++)
            {
                plainTextWithSaltBytes[i] = plainText[i];
            }
            for (int i = 0; i < salt.Length; i++)
            {
                plainTextWithSaltBytes[plainText.Length + i] = salt[i];
            }

            return algorithm.ComputeHash(plainTextWithSaltBytes);
        }
    }
}
