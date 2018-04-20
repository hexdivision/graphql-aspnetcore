using GraphQL.Types;

namespace PathWays.Types
{
    public class UserType : ObjectGraphType<UserModel>
    {
        public UserType()
        {
            Name = "UserType";
            Description = "UserType";

            Field(x => x.User).Description("The Id of the SystemSettings.");
            Field(x => x.Password, nullable: true).Description("The key of the SystemSettings.");
        }
    }

    public class UserInputType : InputObjectGraphType
    {
        public UserInputType()
        {
            Name = "UserInputType";
            Field<NonNullGraphType<StringGraphType>>("user");
            Field<NonNullGraphType<StringGraphType>>("password");
        }
    }

    public class UserModel
    {
        public string User { get; set; }

        public string Password { get; set; }
    }
}