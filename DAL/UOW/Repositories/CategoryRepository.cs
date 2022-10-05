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
    class CategoryRepository : ICategoryRepository
    {
        private readonly IDBSession _db;

        public CategoryRepository(IDBSession db)
        {
            _db = db;
        }

        public async Task<IEnumerable<Category>> GetAllAsync()
        {
            string query = @"SELECT * FROM Category";

            IEnumerable<Category> categories = await _db.Connection.QueryAsync<Category>(query, transaction: _db.Transaction);

            return categories;
        }

        public async Task<Category> GetByIdAsync(int id)
        {
            string query = @"SELECT * FROM Category WHERE Id = @Id";

            Category category = (await _db.Connection.QueryAsync<Category>(query, new { Id = id }, transaction: _db.Transaction)).FirstOrDefault();

            if (category == null)
                throw new NotFoundException();
            else
                return category;
        }
    }
}
