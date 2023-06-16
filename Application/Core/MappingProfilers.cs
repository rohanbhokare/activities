using AutoMapper;
using Domain;

namespace Application.Core
{
    public class MappingProfilers : Profile
    {
        public MappingProfilers()
        {
            CreateMap<Activity,Activity> ();
        }
    }
}