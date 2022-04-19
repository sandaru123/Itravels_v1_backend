using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Itravels_v1.DAL;
using Itravels_v1.Model.User;
using Itravels_v1.Service;
using Itravels_v1.Service.Interface;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Itravels_v1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        //private readonly IUser userRepository;

        //public UserController(IUser _userRepository)
        //{
        //    userRepository = _userRepository;
        //}


        [Route("~/api/GetUserByIdAsync")]
        [HttpGet]
        public async Task<ActionResult<User>> GetUserByIdAsync(int id)
        {
            UserRepository userRepository = new UserRepository();
            var bl = await userRepository.GetUserDetailsById(id);

            return bl;
        }

        [Route("~/api/GetAllUsersAsync")]
        [HttpGet]
        public async Task<ActionResult<List<User>>> GetAllUsersAsync()
        {
            UserRepository userRepository = new UserRepository();
            var bl = await userRepository.GetAllUsersAsync();

            return bl;
        }

        [Route("~/api/AddNewUserAsync")]
        [HttpPost]
        public async Task<ActionResult<string>> AddNewUserAsync([FromBody] UserModel user)
        {
            UserRepository userRepository = new UserRepository();
            var bl = await userRepository.CreateUserAsync(user);

            bool i = false;

            if (bl == "0")
            {
                i = true;
                return Ok(new { i, Message = "Success" });
            }

            return BadRequest(new { i, Message = bl });
        }

        [Route("~/api/UpdateUserAsync")]
        [HttpPut]
        public async Task<ActionResult<bool>> UpdateUserAsync([FromBody] UserUpdateModel user)
        {
            UserRepository userRepository = new UserRepository();
            var bl = await userRepository.UpdateUserDetails(user);

            if (bl)
            {
                return Ok(new { bl, Message = "Success" });
            }

            return BadRequest(new { bl, Message = "Unsuccessfull" });
        }

        [Route("~/api/LoginUserAsync")]
        [HttpPost]
        public async Task<ActionResult<int>> LoginUserAsync(string email, string password)
        {
            UserRepository userRepository = new UserRepository();
            var bl = await userRepository.ValidateLoginUserAsync(email, password);

           if(bl == 0)
            {
                return Ok(new { bl, Message = "Success" });
            }
           else if(bl == 1)
            {
                return BadRequest(new { bl, Message = "Email not valid" });
            }else if(bl == 2)
            {
                return BadRequest(new { bl, Message = "Incorrect Password" });
            }
            else
            {
                return BadRequest(new { bl, Message = "Unsuccessfull" });
            }
                

          //  return BadRequest(new { bl, Message = "Unsuccessfull" });
        }
    }
}
