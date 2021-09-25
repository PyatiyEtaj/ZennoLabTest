using ZennoLabWebAPI.DTO;

namespace ZennoLabWebAPI.Services.Validators
{
    public class DataSetZipArchiveValidator : IDataSetElementValidator
    {
        public DataSetElementValidatorsEnum Type => DataSetElementValidatorsEnum.ZipArchive;

        public DataSetValidatorErrorEnum Validate(DataSetDTO dataset)
        {
            return DataSetValidatorErrorEnum.Ok;
        }
    }
}
