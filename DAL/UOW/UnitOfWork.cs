using DAL.UOW.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.UOW
{
    class UnitOfWork : IDisposable, IUnitOfWork
    {
        private readonly IDBSession _dbSession;

        public UnitOfWork(IDBSession dBSession)
        {
            _dbSession = dBSession;
        }

        public void BeginTransaction()
        {
            _dbSession.Transaction = _dbSession.Connection.BeginTransaction();
        }

        public void Commit()
        {
            if (_dbSession.Transaction != null)
            {
                _dbSession.Transaction.Commit();
            }
            _dbSession.Transaction = null;
        }

        public void RollBack()
        {
            // Si la transaction n'est pas null alors rollback (le point ? remplace le if)
            _dbSession.Transaction?.Rollback();
            _dbSession.Transaction = null;
        }

        public void Dispose()
        {
            _dbSession.Dispose();
        }

        public IMemberRepository Members { get => new MemberRepository(_dbSession); }

        public ITopicRepository Topics { get => new TopicRepository(_dbSession); }

        public IResponseRepository Responses { get => new ResponseRepository(_dbSession); }

        public ICategoryRepository Categories { get => new CategoryRepository(_dbSession); }
    }
}
