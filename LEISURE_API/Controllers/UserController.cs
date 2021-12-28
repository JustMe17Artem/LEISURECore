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
    public class UserController : ControllerBase
    {
        [HttpGet("{idUser}")]
        public ActionResult<Users> Get(int idUser)
        {
            var result = DataAccess.GetUser(idUser);
            if (result == null)
                return NotFound();

            return result;
        }
        [HttpGet]
        public IEnumerable<Users> Get()
        {
            return DataAccess.GetUsers();
        }


        [HttpDelete("{idUser}")]
        public IActionResult Delete(int idUser)
        {
            var result = DataAccess.GetUser(idUser);
            if (result == null)
                return NotFound();

            DataAccess.DeleteUser(idUser);
            return NoContent();
        }

        [HttpPut("{idUser}")]
        public IActionResult Update(int idUser, Users user)
        {
            var result = DataAccess.GetUser(idUser);
            if (result == null)
                return NotFound();

            DataAccess.UpdateUser(user);

            return NoContent();
        }
    }
}
