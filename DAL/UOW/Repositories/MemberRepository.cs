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

        public async Task<bool> GetByNicknameAsync(string nickname)
        {
            string query = @"SELECT * FROM Member WHERE Nickname = @Nickname";

            Member member = (await _db.Connection.QueryAsync<Member>(query, new { Nickname = nickname }, transaction: _db.Transaction)).FirstOrDefault();

            if (member == null)
                return false;
            else
                return true;
        }

        public async Task<bool> GetByEmailAsync(string email)
        {
            string query = @"SELECT * FROM Member WHERE Email = @Email";

            Member member = (await _db.Connection.QueryAsync<Member>(query, new { Email = email }, transaction: _db.Transaction)).FirstOrDefault();

            if (member == null)
                return false;
            else
                return true;
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
                            Email = @Email,
                            Password = @Password,
                            UpdatedAt = @UpdatedAt 
                            WHERE Id = @Id";

            int nbLigneAffected = await _db.Connection.ExecuteAsync(query,
                new
                {
                    Id = memberModified.Id,
                    Nickname = memberModified.Nickname,
                    Email = memberModified.Email,
                    Password = memberModified.Password,
                    UpdatedAt = DateTime.Now
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
            if (await GetByNicknameAsync(member.Nickname) || await GetByEmailAsync(member.Email))
            {
                throw new InsertSQLFailureException(member);
            }

            string query = @"INSERT INTO Member (Nickname, Type, Email, Password, CreatedAt)
                            OUTPUT INSERTED.Id
                            VALUES (@Nickname, @Type, @Email, @Password, @CreatedAt)";

            int? lastId = await _db.Connection.ExecuteScalarAsync<int?>(query,
                         new
                         {
                             Nickname = member.Nickname,
                             Type = "Member",
                             Email = member.Email,
                             Password = member.Password,
                             CreatedAt = DateTime.Now
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
