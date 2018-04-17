using AutoMapper;
using PathWays.Data.Model;
using PathWays.Models;

namespace PathWays
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // SystemSettings
            CreateMap<SystemSettings, SystemSettingsType>(MemberList.Destination);
        }
    }
}
