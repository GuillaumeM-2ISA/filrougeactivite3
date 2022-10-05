using Dapper;
using Domain.Entities;
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
    }
}
