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
    public class VisitingController : ControllerBase
    {
        [HttpGet("{idUser}")]
        public ActionResult<Visiting> Get(int idUser)
        {
            var result = DataAccess.GetVisiting(idUser);
            if (result == null)
                return NotFound();

            return result;
        }
        [HttpGet]
        public IEnumerable<Visiting> Get()
        {
            return DataAccess.GetVisitings();
        }
        

        [HttpDelete("{idUser}")]
        public IActionResult Delete(int idUser)
        {
            var result = DataAccess.GetVisiting(idUser);
            if (result == null)
                return NotFound();

            DataAccess.DeleteUser(idUser);
            return NoContent();
        }

    }

}
