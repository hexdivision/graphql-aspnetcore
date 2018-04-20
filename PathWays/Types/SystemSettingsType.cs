using System;
using GraphQL.Authorization;
using GraphQL.Types;
using PathWays.Data.Model;

namespace PathWays.Types
{
    public class SystemSettingsType : ObjectGraphType<SystemSettings>
    {
        public SystemSettingsType()
        {
            Name = "SystemSettings";
            Description = "SystemSettings";

            Field(x => x.SystemSettingsId).Description("The Id of the SystemSettings.");
            Field(x => x.Key, nullable: true).Description("The key of the SystemSettings.");
            Field(d => d.Value, nullable: true).Description("The value function of the SystemSettings.");
            Field(d => d.Type).Description("The value function of the SystemSettings.");
        }
    }

    public class SystemSettingsInputType : InputObjectGraphType
    {
        public SystemSettingsInputType()
        {
            Name = "SystemSettingsInputType";
            Field<NonNullGraphType<StringGraphType>>("Key");
            Field<NonNullGraphType<StringGraphType>>("Type");
            Field<NonNullGraphType<StringGraphType>>("Value");
        }
    }
}