using Application.Activities;
using AutoMapper;
using Domain;

namespace Application.Core
{
    public class MappingProfilers : Profile
    {
        public MappingProfilers()
        {
            CreateMap<Activity,Activity> ();
            CreateMap<Activity,ActivityDto> ()
                .ForMember(d => d.HostUsername, o => o.MapFrom(s => s.Attendees
                    .FirstOrDefault(x => x.IsHost).AppUser.UserName));
            CreateMap<ActivityAttendee, Profiles.Profile>()
                .ForMember(d => d.DisplayName, o=>o.MapFrom(S => S.AppUser.DispalyName))
                .ForMember(d => d.Username, o=>o.MapFrom(S => S.AppUser.UserName))
                .ForMember(d => d.Bio, o=>o.MapFrom(S => S.AppUser.Bio));
        }
    }
}