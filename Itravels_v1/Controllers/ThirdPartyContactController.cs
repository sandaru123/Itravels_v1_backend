using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Itravels_v1.DAL;
using Itravels_v1.Model.ThirdPartyContact;
using Itravels_v1.Service;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Itravels_v1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ThirdPartyContactController : ControllerBase
    {
        [Route("~/api/GetContactByIdAsync")]
        [HttpGet]
        public async Task<ActionResult<ThirdPartyContact>> GetContactByIdAsync(int id)
        {
            ThirdPartyContactRepository contactrepo = new ThirdPartyContactRepository();
            var bl = await contactrepo.GetThirdpartyContactById(id);

            return bl;
        }

        [Route("~/api/GetAllThirdPartyContactsByUserIdAsync")]
        [HttpGet]
        public async Task<ActionResult<List<ThirdPartyContact>>> GetAllThirdPartyContactsByUserIdAsync(int id)
        {
            ThirdPartyContactRepository contactrepo = new ThirdPartyContactRepository();
            var bl = await contactrepo.GetAllContactsbyUserIdAsync(id);

            return bl;
        }

        [Route("~/api/AddThridPartyContactAsync")]
        [HttpPost]
        public async Task<ActionResult<string>> AddThridPartyContactAsync([FromBody] ThirdPartyContactModel contact)
        {
            ThirdPartyContactRepository contactrepo = new ThirdPartyContactRepository();
            var bl = await contactrepo.AddNewThirdpartyContactAsync(contact);

            bool i = false;

            if (bl == "0")
            {
                i = true;
                return Ok(new { i, Message = "Success" });
            }

            return BadRequest(new { i, Message = bl });
        }

        [Route("~/api/UpdateThirdPartyContactAsync")]
        [HttpPut]
        public async Task<ActionResult<bool>> UpdateThirdPartyContactAsync([FromBody] ThirdPartyContactUpdateModel contact)
        {
            ThirdPartyContactRepository contactrepo = new ThirdPartyContactRepository();
            var bl = await contactrepo.UpdateContactAsync(contact);

            if (bl=="0")
            {
                return Ok(new { bl, Message = "Success" });
            }

            return BadRequest(new { bl, Message = "Unsuccessfull" });
        }
    }
}
