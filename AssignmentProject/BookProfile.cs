using AssignmentDataLayer.Models;
using AssignmentProject.Model;
using AutoMapper;

namespace AssignmentProject
{
    public class BookProfile: Profile
    {
        public BookProfile()
        {
            CreateMap<Book, BookModel>()
                .ForMember(
                    dest => dest.Id,
                    opt => opt.MapFrom(src => src.Id)
                )
                .ForMember(
                    dest => dest.Name,
                    opt => opt.MapFrom(src => src.Name)
                )
                .ForMember(
                    dest => dest.AuthorName,
                    opt => opt.MapFrom(src => src.AuthorName)
                ).ReverseMap();
        }
    }
}
