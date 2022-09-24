using System.Data;

namespace DAL.UOW
{
    interface IDBSession
    {
        IDbConnection Connection { get; }
        IDbTransaction Transaction { get; set; }
    }
}