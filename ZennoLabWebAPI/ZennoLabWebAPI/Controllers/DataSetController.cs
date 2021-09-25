using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZennoLabWebAPI.EntityContext;

namespace ZennoLabWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DataSetController : ControllerBase
    {
        private DataBaseContext _db;

        public DataSetController(DataBaseContext context)
        {
            _db = context;
        }

        /// <summary>
        /// Простой Get
        /// </summary>
        /// <response code="200">Все замечательно</response>
        [HttpGet]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<List<DataSet>> Get()
        {
            var result = _db.DataSets.Select(x => x).ToList();
            return Ok(result);
        }

    }
}
