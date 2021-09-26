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
            _errors.Add(DataSetValidatorErrorEnum.ZipAnswersFileError, "Файл с ответами содержит не корректные данные");
            _errors.Add(
                DataSetValidatorErrorEnum.ZipFilesCount, 
                "Количество картинок, находящихся в архиве, начинается c диапазона 2000-3000 с увеличением обеих границ " +
                "на 3000 за каждую настройку из: 'Содержит кириллицу', 'Содержит латиницу', 'Содержитцифры', 'Содержит " +
                "специальные символы', 'Чувствительность к регистру'");
            _errors.Add(DataSetValidatorErrorEnum.ZipFileError, "Критическая ошибка при обработке отправляемого файла, убедитесь, что файл является zip архивом");
        }

        public static string GetMessage(DataSetValidatorErrorEnum msg) => _errors[msg];
    }
}
