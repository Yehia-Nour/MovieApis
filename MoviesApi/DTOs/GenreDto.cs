namespace MoviesApi.DTOs
{
    public class GenreDto
    {
        [MaxLength(length: 100)]
        public string Name { get; set; }
    }
}
