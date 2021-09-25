using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ZennoLabWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DataSetController : ControllerBase
    {
        /// <summary>
        /// Простой Get
        /// </summary>
        /// <response code="200">Все замечательно</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<string> Get()
        {
            return Ok("hello");
        }
    }
}
