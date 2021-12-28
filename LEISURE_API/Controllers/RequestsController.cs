using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LEISURECore;

namespace LEISURE_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RequestsController : ControllerBase
    {

        [HttpDelete("{idRequest}")]
        public IActionResult Delete(int idrequest)
        {
            var result = DataAccess.GetRequest(idrequest);
            if (result == null)
                return NotFound();
            DataAccess.DeleteRequest(idrequest);
            return NoContent();
        }

        [HttpGet("{idRequest}")]
        public ActionResult<Request> Get(int idRequest)
        {
            var result = DataAccess.GetRequest(idRequest);
            if (result == null)
                return NotFound();

            return result;
        }
        [HttpGet]
        public IEnumerable<Request> Get()
        {
            return DataAccess.GetRequests();
        }
    }
}
