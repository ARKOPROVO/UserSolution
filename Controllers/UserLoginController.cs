using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UserSolution.Data;
using UserSolution.Repository.Implementation;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace UserSolution.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserLoginController : ControllerBase
    {
        UserDBContext _userDBContext;
        UserLoginRepository _userLoginRepository;
        public UserLoginController(UserDBContext userDBContext)
        {
            _userDBContext = userDBContext;
            _userLoginRepository = new UserLoginRepository(_userDBContext);
        }
        // GET: api/<UserLoginController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        [HttpGet]
        [Route("login")]
        public IActionResult ConfirmLogin(string userid, string password)
        {
            //var user = _loanDBContext.Users.Find(userid);
            //var user = _userDBContext.Users.FirstOrDefault(p => p.UserId == userid);
            var user = _userLoginRepository.ConfirmLogin(userid, password);
            if (user == null)
            {
                return NotFound("User doesn't exist");
            }
            else if (user.Password != password)
            {
                return BadRequest("password doesn't match");
            }
            else
            {
                return Ok(user.Role);
            }
        }
    }
}
