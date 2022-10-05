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
    class ResponseRepository : IResponseRepository
    {
        private readonly IDBSession _db;

        public ResponseRepository(IDBSession db)
        {
            _db = db;
        }

        public async Task<IEnumerable<Response>> GetAllAsync()
        {
            string query = @"SELECT * FROM Response AS r INNER JOIN Member AS m ON r.MemberId = m.Id";

            IEnumerable<Response> responses = await _db.Connection.QueryAsync<Response>(query, transaction: _db.Transaction);

            return responses;
        }

        public async Task<IEnumerable<Response>> GetResponsesByTopicIdAsync(int topicId)
        {
            string query = @"SELECT * FROM Response AS r INNER JOIN Member AS m ON r.MemberId = m.Id WHERE r.TopicId = @TopicId";

            IEnumerable<Response> responses = await _db.Connection.QueryAsync<Response>(query, new { TopicId = topicId }, transaction: _db.Transaction);

            return responses;
        }

        public async Task<Response> GetByIdAsync(int id)
        {
            string query = @"SELECT * FROM Response AS r INNER JOIN Member AS m ON r.MemberId = m.Id WHERE r.Id = @Id";

            Response response = (await _db.Connection.QueryAsync<Response>(query, new { Id = id }, transaction: _db.Transaction)).FirstOrDefault();

            if (response == null)
                throw new NotFoundException();
            else
                return response;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            string query = @"DELETE FROM Response WHERE Id = @Id";

            int nbLigneAffected = await _db.Connection.ExecuteAsync(query, new { Id = id }, transaction: _db.Transaction);

            return nbLigneAffected == 1;

        }

        public async Task<Response> UpdateAsync(Response responseModified)
        {
            string query = @"UPDATE Response SET 
                            Content = @Content,
                            WHERE Id = @Id AND MemberId = @MemberId";

            int nbLigneAffected = await _db.Connection.ExecuteAsync(query,
                new
                {
                    Id = responseModified.Id,
                    MemberId = responseModified.MemberId,
                    Content = responseModified.Content
                }, transaction: _db.Transaction);

            if (nbLigneAffected == 1)
            {
                return await GetByIdAsync(responseModified.Id);
            }
            else
            {
                throw new UpdateSQLFailureException(responseModified);
            }
        }

        public async Task<Response> AddAsync(Response response)
        {
            string query = @"INSERT INTO Response (SentOn, Content, TopicId, MemberId)
                            OUTPUT INSERTED.Id
                            VALUES (@SentOn, @Content, @TopicId, @MemberId)";

            int? lastId = await _db.Connection.ExecuteScalarAsync<int?>(query,
                         new
                         {
                             SentOn = DateTime.Now,
                             Content = response.Content,
                             TopicId = response.TopicId,
                             MemberId = response.MemberId
                         }, transaction: _db.Transaction);

            if (lastId.HasValue)
            {
                return await GetByIdAsync(lastId.Value);
            }
            else
            {
                throw new InsertSQLFailureException(response);
            }
        }
    }
}
