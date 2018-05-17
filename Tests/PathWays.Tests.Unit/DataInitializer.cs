using PathWays.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PathWays.Tests.Unit
{
    public static class DataInitializer
    {
        public static IEnumerable<Organization> Organizations
        {
            get
            {
                var organizations = Enumerable.Range(1, 10)
                        .Select(i => new Organization { OrganizationId = i, FullName = $"Sample{i}", CreatedBy = i, CreatedDate = DateTime.UtcNow, OrganizationGuid = default(Guid) });

                return organizations;
            }
        }

        public static IEnumerable<Domain> Domains
        {
            get
            {
                var domains = Enumerable.Range(1, 10)
                        .Select(i => new Domain { DomainId = i, OrganizationId = i, CreatedBy = i, CreatedDate = DateTime.UtcNow });

                return domains;
            }
        }

        public static IEnumerable<UserExploration> UserExplorations
        {
            get
            {
                var userExplorations = Enumerable.Range(1, 10)
                        .Select(i => new UserExploration { UserExplorationId = i, OrganizationId = i, DomainId = i, CreatedBy = i, CreatedDate = DateTime.UtcNow, ExplorationCompletionDate = DateTime.UtcNow.AddMonths(2) });

                return userExplorations;
            }
        }

        public static IEnumerable<AccessCodeExcludeWord> BadWords
        {
            get
            {
                var badWords = Enumerable.Range(1, 10)
                        .Select(i => new AccessCodeExcludeWord { AccessCodeExcludeWordId = i, ExcludeWord = $"Fuck{i}" });

                return badWords;
            }
        }
    }
}
