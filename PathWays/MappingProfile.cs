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
            CreateMap<UserExploration, UserExplorationType>(MemberList.Destination);
        }
    }
}
