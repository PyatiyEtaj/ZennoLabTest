namespace ZennoLabWebAPI.Services.Validators
{
    public enum DataSetValidatorErrorEnum
    {
        Ok,
        NameIsNull,
        NameIsSmallOrBig,
        ContainsCaptcha,
        DataSetHasNotAnyOfTheSymbolsType
    }
}
