using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Itravels_v1.DAL;
using Itravels_v1.Model.Baggage;
using Itravels_v1.Model.User;
using Itravels_v1.Service;
using Itravels_v1.Service.Interface;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Itravels_v1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaggageController : ControllerBase
    {

        //private readonly IUser userRepository;

        //public UserController(IUser _userRepository)
        //{
        //    userRepository = _userRepository;
        //}


        [Route("~/api/GetBaggageByIdAsync")]
        [HttpGet]
        public async Task<ActionResult<Baggage>> GetBaggageByIdAsync(int id)
        {
            BaggageRepository baggageRepository = new BaggageRepository();
            var bl = await baggageRepository.GetBaggageById(id);

            return bl;
        }

        [Route("~/api/GetAllBaggagesByUserId")]
        [HttpGet]
        public async Task<ActionResult<List<Baggage>>> GetAllBaggagesByUserId(int id)
        {
            BaggageRepository baggageRepository = new BaggageRepository();
            var bl = await baggageRepository.GetBaggagesByUserId(id);

            return bl;
        }

        [Route("~/api/AddNewBaggageAsync")]
        [HttpPost]
        public async Task<ActionResult<string>> AddNewBaggageAsync([FromBody] BaggageModel baggage)
        {
            BaggageRepository baggageRepository = new BaggageRepository();
            var bl = await baggageRepository.CreateBaggageAsync(baggage);

            bool i = false;

            if (bl == "0")
            {
                i = true;
                return Ok(new { i, Message = "Success" });
            }

            return BadRequest(new { i, Message = bl });
        }

       
    }
}
