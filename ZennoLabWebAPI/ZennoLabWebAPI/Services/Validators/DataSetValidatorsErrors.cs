using System.Collections.Generic;

namespace ZennoLabWebAPI.Services.Validators
{
    public static class DataSetValidatorsErrors
    {
        private static Dictionary<DataSetValidatorErrorEnum, string> _errors = new();
        static DataSetValidatorsErrors()
        {
            _errors.Add(DataSetValidatorErrorEnum.Ok, "Ok");
            _errors.Add(DataSetValidatorErrorEnum.NameIsNull, "Ошибка в имени");
            _errors.Add(DataSetValidatorErrorEnum.NameIsSmallOrBig, "Длина имени меньше 4 или больше 8 символов");
            _errors.Add(DataSetValidatorErrorEnum.ContainsCaptcha, "Имя содержит слово 'captcha'");
            _errors.Add(
                DataSetValidatorErrorEnum.DataSetHasNotAnyOfTheSymbolsType,
                "Должно быть выбрано как минимум одно из: 'Содержит кириллицу','Содержит латиницу', 'Содержит цифры'");
        }

        public static string GetMessage(DataSetValidatorErrorEnum msg) => _errors[msg];
    }
}
