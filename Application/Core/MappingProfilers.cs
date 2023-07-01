using Application.Activities;
using Application.Comments;
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
            CreateMap<ActivityAttendee, AttendeeDto>()
                .ForMember(d => d.DisplayName, o=>o.MapFrom(S => S.AppUser.DispalyName))
                .ForMember(d => d.Username, o=>o.MapFrom(S => S.AppUser.UserName))
                .ForMember(d => d.Bio, o=>o.MapFrom(S => S.AppUser.Bio))
                .ForMember(d => d.Image, o => o.MapFrom(s => s.AppUser.Photos.FirstOrDefault(x => x.IsMain).Url));
            
            CreateMap<AppUser, Profiles.Profile>()
                .ForMember(d => d.Image, o => o.MapFrom(s => s.Photos.FirstOrDefault(x => x.IsMain).Url));

            CreateMap<Comment, CommentDto>()
                .ForMember(d => d.DisplayName, o=>o.MapFrom(S => S.Author.DispalyName))
                .ForMember(d => d.Username, o=>o.MapFrom(S => S.Author.UserName))
                .ForMember(d => d.Image, o => o.MapFrom(s => s.Author.Photos.FirstOrDefault(x => x.IsMain).Url));
        }
    }
}