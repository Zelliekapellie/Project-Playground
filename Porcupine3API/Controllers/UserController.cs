using Microsoft.AspNetCore.Mvc;
using Porcupine3API.Models;
using Porcupine3API.Repository;
using System.Transactions;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Porcupine3API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }


        // GET: api/<UserController>
        [HttpGet]
        public IActionResult Get()
        {
            var users = _userRepository.GetUsers();
            return new OkObjectResult(users);
        }

        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var user = _userRepository.GetUserByID(id);
            return new OkObjectResult(user);
        }

        // POST api/<UserController>
        [HttpPost]
        public IActionResult Post([FromBody] UserM user)
        {
            using(var scope = new TransactionScope())
            {
                _userRepository.CreateUser(user);
                scope.Complete();
                return CreatedAtAction(nameof(Get), new { id = user.ID }, user);
            }
        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public IActionResult Put( [FromBody] UserM user)
        {
            if(user != null)
            {
                using (var scope = new TransactionScope())
                {
                    _userRepository.UpdateUser(user);
                    scope.Complete();
                    return new OkResult();
                }
            }
            else
            {
                return BadRequest();
            }
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _userRepository.DeleteUser(id);
            return new OkResult();
        }
    }
}
