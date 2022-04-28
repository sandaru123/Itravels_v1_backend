using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Itravels_v1.DAL;
using Itravels_v1.Model.TravelHistory;
using Itravels_v1.Service;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Itravels_v1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TravelHistoryController : ControllerBase
    {
        

        [Route("~/api/GetHistoryByUserIdAsync")]
        [HttpGet]
        public async Task<ActionResult<List<TravelHistory>>> GetHistoryByUserIdAsync(int id)
        {
            TravelHistoryRepository travelHistoryRepository = new TravelHistoryRepository();
            var bl = await travelHistoryRepository.GetHistoryByUserId(id);

            return bl;
        }

        [Route("~/api/AddNewTravelHistoryAsync")]
        [HttpPost]
        public async Task<ActionResult<string>> AddNewTravelHistoryAsync([FromBody] TravelHistoryModel travelHistory)
        {
            TravelHistoryRepository travelHistoryRepository = new TravelHistoryRepository();
            var bl = await travelHistoryRepository.AddNewTravelHistoryAsync(travelHistory);

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
