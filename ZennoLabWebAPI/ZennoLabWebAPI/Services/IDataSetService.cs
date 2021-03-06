using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZennoLabWebAPI.EntityContext;

namespace ZennoLabWebAPI.Services
{
    public interface IDataSetService
    {
        Task<List<DataSet>> GetAllDataSetsAsync();
        Task<List<DataSet>> GetAllDataSetsFullAsync();
        Task InsertDatasetAsync(DataSet dataset);
    }
}
