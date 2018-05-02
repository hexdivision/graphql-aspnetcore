using System;
using GraphQL.Types;
using PathWays.Data.Model;

namespace PathWays.Types
{
    public class UserExplorationTokenType : ObjectGraphType<UserExplorationToken>
    {
        public UserExplorationTokenType()
        {
            Name = "UserExplorationToken";
            Description = "UserExplorationToken";

            Field(x => x.AccessCode).Description("The Id of the UserExploration.");
            Field(x => x.AuthToken).Description("The associated organization of the exploration.");
            Field(d => d.ExpiresOn).Description("The associated domain of the exploration.");
            Field(d => d.ExplorationId, nullable: true).Description("The associated domain of the exploration.");
            Field(d => d.IssuedOn).Description("The associated domain of the exploration.");
            ////Field(d => d.RoleId).Description("The associated domain of the exploration.");
            Field(d => d.SystemUserId, nullable: true).Description("The associated domain of the exploration.");
            Field(d => d.UserExplorationTokenId, nullable: true).Description("The associated domain of the exploration.");
        }
    }
}
