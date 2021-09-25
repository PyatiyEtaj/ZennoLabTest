using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZennoLabWebAPI.DTO;
using ZennoLabWebAPI.EntityContext;
using ZennoLabWebAPI.Mapper;
using ZennoLabWebAPI.Services;

namespace ZennoLabWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DataSetController : ControllerBase
    {
        private DataBaseContext _db;
        private readonly IDataSetValidator _dataSetValidator;
        private readonly IDataSetService _dataSetService;
        private readonly DataSetDTOMapper _dataSetDTOMapper;

        public DataSetController(IDataSetValidator dataSetValidator, IDataSetService dataSetService, DataSetDTOMapper dataSetDTOMapper)
        {
            _dataSetValidator = dataSetValidator;
            _dataSetService = dataSetService;
            _dataSetDTOMapper = dataSetDTOMapper;
        }

        /// <summary>
        /// Простой Get
        /// </summary>
        /// <response code="200">Все замечательно</response>
        [HttpGet]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<DataSet>>> Get()
        {
            return await _dataSetService.GetAllDataSetsAsync();
        }

        /// <summary>
        /// Загрузка данных для обучения ИИ на сервер
        /// </summary>
        /// <param name="dataSet">загружаемый набор данных с метаинформацией</param>
        /// <response code="200">Данные успешно загружены</response>
        /// <response code="400">загружаемые данные содержат ошибки</response>  
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<string>> UploadDataSet(DataSetDTO dataSet)
        {
            var result = _dataSetValidator.Validate(dataSet);
            if (!result.valid)
                return BadRequest(result.message);

            await _dataSetService.InsertDatasetAsync(_dataSetDTOMapper.Map(dataSet));

            return Ok();
        }


    }
}
