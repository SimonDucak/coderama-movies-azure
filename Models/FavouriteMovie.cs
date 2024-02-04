using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace coderama_movies_server.Models
{
    public class FavouriteMovie
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public required int? Id { get; set; }

        public required string ImdbID { get; set; }

        public required string Title { get; set; }

        public required string Poster { get; set; }

        public int? Year { get; set; }

        public string? Type { get; set; }

        [ForeignKey("User")]
        public required int User { get; set; }
    }
}
