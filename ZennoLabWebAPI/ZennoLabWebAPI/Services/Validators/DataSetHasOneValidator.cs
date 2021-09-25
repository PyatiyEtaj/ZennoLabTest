using ZennoLabWebAPI.DTO;

namespace ZennoLabWebAPI.Services.Validators
{
    public class DataSetHasOneValidator : IDataSetElementValidator
    {
        public DataSetElementValidatorsEnum Type => DataSetElementValidatorsEnum.DataSetHasOneOfTheTypeSymbols;
        public DataSetValidatorErrorEnum Validate(DataSetDTO dataset)
        {
            if (dataset.HasCyrillic == false && dataset.HasDigits == false && dataset.HasLatin == false)
                return DataSetValidatorErrorEnum.DataSetHasNotAnyOfTheSymbolsType;

            return DataSetValidatorErrorEnum.Ok;
        }
    }
}
