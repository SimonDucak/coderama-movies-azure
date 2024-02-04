using AutoMapper;
using coderama_movies_server.Interfaces;
using coderama_movies_server.Models;
using Microsoft.AspNetCore.Mvc;

namespace coach_of_people_azure_server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly IUserRepository _userRepository;

        private readonly IMapper _mapper;

        public UserController(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            this._mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<User>))]
        public IActionResult Get(int pageSize = 10, int pageNumber = 1)
        {
            var users = _userRepository.Get(pageSize, pageNumber);
            return Ok(users);
        }

        [HttpPut]
        public IActionResult Update([FromBody] User user)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var exists = _userRepository.UserExists(user.Id);

            if (!exists)
                return NotFound("User not found");

            _userRepository.Update(user);

            return Ok("User updated successfully");
        }
    }
}