using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQL.Types;
using PathWays.Data.Model;

namespace PathWays.Types
{
    public class PathwayType : ObjectGraphType<Pathway>
    {
        public PathwayType()
        {
            Name = "Pathway";
            Description = "Pathway";

            Field(x => x.PathwayId).Description("The Id of the Pathway.");
            Field(x => x.DomainId).Description("The associated domain of the pathway.");
            Field(d => d.PathName).Description("The pathway title.");
            Field(d => d.PathDescription).Description("The full description of the pathway.");
            Field(d => d.PathAbbreviation).Description("The unique abbreviation for the pathway.");
            Field(d => d.FirstObjectType, nullable: true).Description("The type of the first object.");
            Field(d => d.FirstObjectId, nullable: true).Description("The Id of the first object.");
            Field(d => d.IsDeleted, nullable: true).Description("Whether pathway is marked as deleted.");
            Field(d => d.IsActive).Description("Whether pathway is marked as active.");
            Field(d => d.CreatedDate).Description("The creation date for the pathway.");
            Field(d => d.ModifiedDate, nullable: true).Description("The last modified date of the pathway.");
        }
    }

    public class PathwayInputType : InputObjectGraphType
    {
        public PathwayInputType()
        {
            Name = "PathwayInputType";
            Field<NonNullGraphType<IntGraphType>>("DomainId");
            Field<NonNullGraphType<StringGraphType>>("PathName");
            Field<NonNullGraphType<StringGraphType>>("PathDescription");
            Field<NonNullGraphType<StringGraphType>>("PathAbbreviation");
        }
    }

    public class PathwayUpdateType : InputObjectGraphType
    {
        public PathwayUpdateType()
        {
            Name = "PathwayUpdateType";
            Field<NonNullGraphType<IntGraphType>>("PathwayId");
            Field<IntGraphType>("DomainId");
            Field<StringGraphType>("PathName");
            Field<StringGraphType>("PathDescription");
            Field<StringGraphType>("PathAbbreviation");
            Field<BooleanGraphType>("IsActive");
        }
    }
}
