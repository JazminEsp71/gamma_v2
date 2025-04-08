using System.Data.Common;

namespace Gamma.System.Api.DataAccess.Interfaces;

public interface IDbContext
{
    DbConnection Connection { get; }
}