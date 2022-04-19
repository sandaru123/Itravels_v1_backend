using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Itravels_v1.DAL;
using Itravels_v1.Model.Inquiry;
using Itravels_v1.Service;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Itravels_v1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InquiryController : ControllerBase
    {

        [Route("~/api/GetInquiryByIdAsync")]
        [HttpGet]
        public async Task<ActionResult<Inquiry>> GetInquiryByIdAsync(int id)
        {
            InquiryRepository inquiryRepository = new InquiryRepository();
            var bl = await inquiryRepository.GetInquiryAsync(id);

            return bl;
        }

        [Route("~/api/GetAllInquiriesByBaggageId")]
        [HttpGet]
        public async Task<ActionResult<List<Inquiry>>> GetAllInquiriesByBaggageId(int id)
        {
            InquiryRepository inquiryRepository = new InquiryRepository();
            var bl = await inquiryRepository.GetAllInquiriesbyBaggageIdAsync(id);

            return bl;
        }


        [Route("~/api/AddnewInquiryAsync")]
        [HttpPost]
        public async Task<ActionResult<string>> AddnewInquiryAsync([FromBody] InquiryModel inquiry)
        {
            InquiryRepository inquiryRepository = new InquiryRepository();
            var bl = await inquiryRepository.AddNewInquiryAsync(inquiry);

            bool i = false;

            if (bl == "0")
            {
                i = true;
                return Ok(new { i, Message = "Success" });
            }

            return BadRequest(new { i, Message = bl });
        }


        // DELETE api/<InquiryController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
