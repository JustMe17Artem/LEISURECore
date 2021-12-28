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
    public class Object_TypeController : ControllerBase
    {
        [HttpPut]
        public IActionResult Update(int idObject_type, Type_Object type)
        {
            var result = DataAccess.GetTypeEvent(idObject_type);
            if (result == null)
                return NotFound();

            DataAccess.UpdateObjecttype(idObject_type, type);

            return NoContent();
        }
        [HttpGet("{idObject_type}")]
        public ActionResult<Type_Object> Get(int idObject_type)
        {
            var result = DataAccess.GetTypeObject(idObject_type);
            if (result == null)
                return NotFound();

            return result;
        }
        [HttpGet]
        public IEnumerable<Type_Object> Get()
        {
            return DataAccess.GetTypeObjects();
        }
    }
}
