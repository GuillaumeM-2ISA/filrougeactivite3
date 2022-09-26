using DAL.UOW.Repositories;

namespace DAL.UOW
{
    public interface IUnitOfWork
    {
        void BeginTransaction();
        void Commit();
        void RollBack();
    }
}