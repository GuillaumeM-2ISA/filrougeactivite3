using DAL.UOW.Repositories;

namespace DAL.UOW
{
    public interface IUnitOfWork
    {
        IMemberRepository Members { get; }

        void BeginTransaction();
        void Commit();
        void RollBack();
    }
}