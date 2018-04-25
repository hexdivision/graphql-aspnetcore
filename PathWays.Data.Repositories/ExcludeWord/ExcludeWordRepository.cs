using System.Linq;
using PathWays.Data.Model;
using PathWays.Data.Repositories.Base;

namespace PathWays.Data.Repositories.ExcludeWord
{
    public class ExcludeWordRepository : PathWaysRepository<AccessCodeExcludeWord>, IExcludeWordRepository
    {
        public ExcludeWordRepository(PathWaysContext context)
            : base(context)
        {
        }

        public IQueryable<string> GetAllWords()
        {
            var excludedWords = Context.AccessCodeExcludeWords.Select(w => w.ExcludeWord);
            return excludedWords;
        }
    }
}
