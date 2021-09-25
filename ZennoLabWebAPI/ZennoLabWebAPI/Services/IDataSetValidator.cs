using ZennoLabWebAPI.DTO;

namespace ZennoLabWebAPI.Services
{
    public interface IDataSetValidator
    {
        (bool valid, string message) Validate(DataSetDTO dataset);
    }
}
