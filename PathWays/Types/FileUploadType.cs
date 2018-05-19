using GraphQL.Types;
using PathWays.Data.Model;

namespace PathWays.Types
{
    public class FileUploadType : ObjectGraphType<SystemSettings>
    {
        public FileUploadType()
        {
            Name = "FileUpload";
            Description = "FileUpload";

            Field(x => x.SystemSettingsId).Description("The Id of the SystemSettings.");
            Field(x => x.Key, nullable: true).Description("The key of the SystemSettings.");
            Field(d => d.Value, nullable: true).Description("The value function of the SystemSettings.");
            Field(d => d.Type).Description("The value function of the SystemSettings.");
        }
    }

    public class FileUploadInputType : InputObjectGraphType<SystemSettingsType>
    {
        public FileUploadInputType()
        {
            Name = "FileUploadInputType";

            Field<NonNullGraphType<StringGraphType>>("Key");
            Field<NonNullGraphType<StringGraphType>>("Type");
            Field<NonNullGraphType<StringGraphType>>("Value");
        }
    }
}