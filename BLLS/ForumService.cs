using DAL.UOW;
using Domain.Entities;
using Domain.Exceptions;
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

        public async Task<Category> GetCategoryByIdAsync(int id)
        {
            return await _dbContext.Categories.GetByIdAsync(id);
        }

        public async Task<IEnumerable<Topic>> GetTopicsAsync()
        {
            return await _dbContext.Topics.GetAllAsync();
        }

        public async Task<IEnumerable<Topic>> GetTopicsByCategoryIdAsync(int categoryId)
        {
            return await _dbContext.Topics.GetTopicsByCategoryIdAsync(categoryId);
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
            _dbContext.BeginTransaction();
            var isResponsesDeleted = await _dbContext.Responses.DeleteByTopicIdAsync(id);
            var isTopicDeleted = await _dbContext.Topics.DeleteAsync(id);
            if (isResponsesDeleted && isTopicDeleted)
            {
                _dbContext.Commit();
                return true;
            }
            _dbContext.RollBack();
            throw new DeleteTopicFailureException();
        }

        public async Task<IEnumerable<Response>> GetResponsesAsync()
        {
            return await _dbContext.Responses.GetAllAsync();
        }

        public async Task<IEnumerable<Response>> GetResponsesByTopicIdAsync(int topicId)
        {
            return await _dbContext.Responses.GetResponsesByTopicIdAsync(topicId);
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
