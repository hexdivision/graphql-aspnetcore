using System.Collections.Generic;
using System.Threading.Tasks;
using PathWays.Data.Repositories.Base;

namespace PathWays.Data.Repositories.UserExploration
{
    public interface IUserExplorationRepository : IRepository<Model.UserExploration>
    {
        Task<List<string>> GetAccessCodes(char firstLetter);

        Task<Model.UserExploration> GetByAccessCode(string accessCode);

        Task<List<Model.UserExploration>> GetAllWithTokens();
    }
}
