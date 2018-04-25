using System.Linq;

namespace PathWays.Data.Repositories.ExcludeWord
{
    public interface IExcludeWordRepository
    {
        IQueryable<string> GetAllWords();
    }
}
