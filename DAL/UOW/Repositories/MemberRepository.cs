using Dapper;
using Domain.Entities;
using Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.UOW.Repositories
{
    class MemberRepository : IMemberRepository
    {
        private readonly IDBSession _db;

        public MemberRepository(IDBSession db)
        {
            _db = db;
        }

        public async Task<IEnumerable<Member>> GetAllAsync()
        {
            string query = @"SELECT * FROM Member";

            IEnumerable<Member> members = await _db.Connection.QueryAsync<Member>(query, transaction: _db.Transaction);

            return members;
        }

        public async Task<Member> GetByIdAsync(int id)
        {
            string query = @"SELECT * FROM Member WHERE Id = @Id";

            Member member = (await _db.Connection.QueryAsync<Member>(query, new { Id = id }, transaction: _db.Transaction)).FirstOrDefault();

            if (member == null)
                throw new NotFoundException();
            else
                return member;
        }

        public async Task<Member> GetByNicknameAndPasswordAsync(string nickname, string password)
        {
            string query = @"SELECT * FROM Member WHERE Nickname = @Nickname AND Password = @Password";

            Member member = (await _db.Connection.QueryAsync<Member>(query,
                new
                {
                    Nickname = nickname,
                    Password = password
                }, transaction: _db.Transaction)).FirstOrDefault();

            if (member == null)
                throw new AuthentificationFailException();
            else
                return member;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            string query = @"DELETE FROM Member WHERE Id = @Id";

            int nbLigneAffected = await _db.Connection.ExecuteAsync(query, new { Id = id }, transaction: _db.Transaction);

            return nbLigneAffected == 1;

        }

        public async Task<Member> UpdateAsync(Member memberModified)
        {
            string query = @"UPDATE Member SET 
                            Nickname = @Nickname,
                            Type = @Type, 
                            Email = @Email,
                            Password = @Password,
                            WHERE Id = @Id";

            int nbLigneAffected = await _db.Connection.ExecuteAsync(query,
                new
                {
                    Id = memberModified.Id,
                    Nickname = memberModified.Nickname,
                    Type = memberModified.Type,
                    Email = memberModified.Email,
                    Password = memberModified.Password
                }, transaction: _db.Transaction);

            if (nbLigneAffected == 1)
            {
                return await GetByIdAsync(memberModified.Id);
            }
            else
            {
                throw new UpdateSQLFailureException(memberModified);
            }
        }

        public async Task<Member> AddAsync(Member member)
        {
            string query = @"INSERT INTO Member (Nickname, Type, Email, Password)
                            OUTPUT INSERTED.Id
                            VALUES (@Nickname, @Type, @Email, @Password)";

            int? lastId = await _db.Connection.ExecuteScalarAsync<int?>(query,
                         new
                         {
                             Nickname = member.Nickname,
                             Type = member.Type,
                             Email = member.Email,
                             Password = member.Password
                         }, transaction: _db.Transaction);

            if (lastId.HasValue)
            {
                return await GetByIdAsync(lastId.Value);
            }
            else
            {
                throw new InsertSQLFailureException(member);
            }
        }
    }
}
