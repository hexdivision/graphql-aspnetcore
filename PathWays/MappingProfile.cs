using AutoMapper;
using PathWays.Data.Model;
using PathWays.Types;

namespace PathWays
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // SystemSettings
            CreateMap<SystemSettings, SystemSettingsType>(MemberList.Destination);

            // UserExploration
            CreateMap<UserExploration, UserExplorationType>(MemberList.Destination);

            CreateMap<UserStep, UserStepType>(MemberList.Destination);
        }
    }
}
