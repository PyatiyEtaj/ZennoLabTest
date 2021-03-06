using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZennoLabWebAPI.EntityContext;

namespace ZennoLabWebAPI.Services
{
    public class DataSetService : IDataSetService
    {
        private readonly DataBaseContext _db;

        public DataSetService(DataBaseContext dbContext)
        {
            _db = dbContext;
        }
        public async Task<List<DataSet>> GetAllDataSetsAsync()
        {
            return await Task.Run(() => _db.DataSets.Select(x => new DataSet{
                DataSetId = x.DataSetId,
                Date = x.Date,
                Name = x.Name
            }).OrderByDescending(x => x.Date).ToList());
        }

        public async Task<List<DataSet>> GetAllDataSetsFullAsync()
        {
            return await Task.Run(() => _db.DataSets.Select(x => x).OrderByDescending(x => x.Date).ToList());
        }

        public async Task InsertDatasetAsync(DataSet dataset)
        {
            // так и не смог заставить MS SQL самостоятельно заполнять это значение
            // любое значение в атрибут DefaultValue приводит к ошибкам (SYSDATETIME, GETTIME ...)
            dataset.Date = DateTime.Now;

            await _db.DataSets.AddAsync(dataset);

            await _db.SaveChangesAsync();
        }
    }
}
