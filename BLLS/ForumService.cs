using DAL.UOW;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLLS
{
    class ForumService : IForumService
    {
        private readonly IUnitOfWork _dbContext;

        public ForumService(IUnitOfWork dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Category>> GetCategoriesAsync()
        {
            return await _dbContext.Categories.GetAllAsync();
        }

        public async Task<IEnumerable<Topic>> GetTopicsAsync()
        {
            return await _dbContext.Topics.GetAllAsync();
        }

        public async Task<Topic> GetTopicByIdAsync(int id)
        {
            return await _dbContext.Topics.GetByIdAsync(id);
        }

        public async Task<Topic> AddTopicAsync(Topic newTopic)
        {
            return await _dbContext.Topics.AddAsync(newTopic);
        }

        public async Task<Topic> ModifyTopicAsync(Topic modifiedTopic)
        {
            return await _dbContext.Topics.UpdateAsync(modifiedTopic);
        }

        public async Task<bool> DeleteTopicAsync(int id)
        {
            return await _dbContext.Topics.DeleteAsync(id);
        }

        public async Task<IEnumerable<Response>> GetResponsesAsync()
        {
            return await _dbContext.Responses.GetAllAsync();
        }

        public async Task<Response> GetResponseByIdAsync(int id)
        {
            return await _dbContext.Responses.GetByIdAsync(id);
        }

        public async Task<Response> AddResponseAsync(Response newResponse)
        {
            return await _dbContext.Responses.AddAsync(newResponse);
        }

        public async Task<bool> DeleteResponseAsync(int id)
        {
            return await _dbContext.Responses.DeleteAsync(id);
        }
    }
}
