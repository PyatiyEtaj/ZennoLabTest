using ZennoLabWebAPI.DTO;

namespace ZennoLabWebAPI.Services.Validators
{
    public interface IDataSetElementValidator
    {
        DataSetElementValidatorsEnum Type { get; }
        DataSetValidatorErrorEnum Validate(DataSetDTO dataset);
    }
}
