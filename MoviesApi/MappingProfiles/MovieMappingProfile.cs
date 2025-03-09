
namespace MoviesApi.MappingProfiles
{
    public class MovieMappingProfile : Profile
    {
        public MovieMappingProfile()
        {
            CreateMap<Movie, MovieDetailsDto>()
                .ForMember(dest => dest.GenreName, opt => opt.MapFrom(src => src.Genre.Name));

            CreateMap<MovieDto, Movie>()
                .ForMember(dest => dest.Poster, opt => opt.Ignore());

        }
    }
}