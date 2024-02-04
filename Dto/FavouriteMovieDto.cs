namespace coderama_movies_server.Dto
{
    public class FavouriteMovieDto
    {
        public required int? Id { get; set; }

        public required string ImdbID { get; set; }

        public required string Title { get; set; }

        public required string Poster { get; set; }

        public int? Year { get; set; }

        public string? Type { get; set; }
    }
}

