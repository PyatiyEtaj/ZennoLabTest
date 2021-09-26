using ZennoLabWebAPI.DTO;

namespace ZennoLabWebAPI.Services.Validators
{
    public class DataSetNameValidator : IDataSetElementValidator
    {
        public DataSetElementValidatorsEnum Type => DataSetElementValidatorsEnum.Name;

        public DataSetValidatorErrorEnum Validate(DataSetDTO dataset)
        {
            if (dataset.Name is null)
                return DataSetValidatorErrorEnum.NameIsNull;

            if (dataset.Name.Length < 4 || dataset.Name.Length > 8)
                return DataSetValidatorErrorEnum.NameIsSmallOrBig;

            if (dataset.Name.ToLower().Contains("captcha"))
                return DataSetValidatorErrorEnum.ContainsCaptcha;

            return DataSetValidatorErrorEnum.Ok;
        }
    }
}
