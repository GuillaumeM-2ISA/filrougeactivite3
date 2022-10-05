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
    class TopicRepository : ITopicRepository
    {
        private readonly IDBSession _db;

        public TopicRepository(IDBSession db)
        {
            _db = db;
        }

        public async Task<IEnumerable<Topic>> GetAllAsync()
        {
            string query = @"SELECT * FROM Topic";

            IEnumerable<Topic> topics = await _db.Connection.QueryAsync<Topic>(query, transaction: _db.Transaction);

            return topics;
        }

        public async Task<IEnumerable<Topic>> GetTopicsByCategoryIdAsync(int categoryId)
        {
            string query = @"SELECT * FROM Topic WHERE CategoryId = @CategoryId";

            IEnumerable<Topic> topics = await _db.Connection.QueryAsync<Topic>(query, new { CategoryId = categoryId }, transaction: _db.Transaction);

            return topics;
        }

        public async Task<Topic> GetByIdAsync(int id)
        {
            string query = @"SELECT * FROM Topic WHERE Id = @Id";

            Topic topic = (await _db.Connection.QueryAsync<Topic>(query, new { Id = id }, transaction: _db.Transaction)).FirstOrDefault();

            if (topic == null)
                throw new NotFoundException();
            else
                return topic;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            string query = @"DELETE FROM Topic WHERE Id = @Id";

            int nbLigneAffected = await _db.Connection.ExecuteAsync(query, new { Id = id }, transaction: _db.Transaction);

            return nbLigneAffected == 1;

        }

        public async Task<Topic> UpdateAsync(Topic topicModified)
        {
            string query = @"UPDATE Topic SET 
                            Title = @Title,
                            Description = @Description,
                            CategoryId = @CategoryId,
                            UpdatedAt = @UpdatedAt 
                            WHERE Id = @Id";

            int nbLigneAffected = await _db.Connection.ExecuteAsync(query,
                new
                {
                    Id = topicModified.Id,
                    Title = topicModified.Title,
                    Description = topicModified.Description,
                    CategoryId = topicModified.CategoryId,
                    UpdatedAt = DateTime.Now
                }, transaction: _db.Transaction);

            if (nbLigneAffected == 1)
            {
                return await GetByIdAsync(topicModified.Id);
            }
            else
            {
                throw new UpdateSQLFailureException(topicModified);
            }
        }

        public async Task<Topic> AddAsync(Topic topic)
        {
            string query = @"INSERT INTO Topic (CreatedAt, Title, Description, CategoryId, MemberId)
                            OUTPUT INSERTED.Id
                            VALUES (@CreatedAt, @Title, @Description, @CategoryId, @MemberId)";

            int? lastId = await _db.Connection.ExecuteScalarAsync<int?>(query,
                         new
                         {
                             CreatedAt = DateTime.Now,
                             Title = topic.Title,
                             Description = topic.Description,
                             CategoryId = topic.CategoryId,
                             MemberId = topic.MemberId
                         }, transaction: _db.Transaction);

            if (lastId.HasValue)
            {
                return await GetByIdAsync(lastId.Value);
            }
            else
            {
                throw new InsertSQLFailureException(topic);
            }
        }
    }
}
