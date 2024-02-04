namespace coderama_movies_server.Dto
{
    public class UserDto
    {
        public int Id { get; set; }

        public required string Username { get; set; }

        public required string Email { get; set; }

        public required string AvatarImage { get; set; }
    }
}
