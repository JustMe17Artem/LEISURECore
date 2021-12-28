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
    public class Event_TypeController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<Type_Event> Get()
        {
            return DataAccess.GetTypeEvents();
        }

        [HttpGet("{idType_Event}")]
        public ActionResult<Type_Event> Get(int idType_Event)
        {
            var result = DataAccess.GetTypeEvent(idType_Event);
            if (result == null)
                return NotFound();

            return result;
        }

        [HttpPost]
        public IActionResult Create(Type_Event type)
        {
            DataAccess.AddNewTypeEvent(type);
            return NoContent();
        }

        [HttpDelete("{idType_Event}")]
        public IActionResult Delete(int idType_Event)
        {
            var result = DataAccess.GetTypeEvent(idType_Event);
            if (result == null)
                return NotFound();

            DataAccess.DeleteTypeEvent(idType_Event);
            return NoContent();
        }
        public IActionResult Update(int idEvent_Type, Type_Event type)
        {
            var result = DataAccess.GetTypeEvent(idEvent_Type);
            if (result == null)
                return NotFound();

            DataAccess.UpdateEventType(idEvent_Type, type);

            return NoContent();
        }
    }
}
