using DAL.UOW.Repositories;

namespace DAL.UOW
{
    public interface IUnitOfWork
    {
        IMemberRepository Members { get; }

        ITopicRepository Topics { get; }

        IResponseRepository Responses { get; }

        ICategoryRepository Categories { get; }

        void BeginTransaction();
        void Commit();
        void RollBack();
    }
}