using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using ZennoLabWebAPI.DTO;

namespace ZennoLabWebAPI.Services.Validators
{
    public class DataSetZipArchiveValidator : IDataSetElementValidator
    {
        public DataSetElementValidatorsEnum Type => DataSetElementValidatorsEnum.ZipArchive;

        // проверка ответов в файле
        private bool CheckAnswersInFile(List<string> files, ZipArchiveEntry answers)
        {
            if (answers is null) return false;

            using (var str = new StreamReader(answers.Open()))
            {
                while (!str.EndOfStream)
                {
                    var name = str.ReadLine().Split(':')[0];
                    var item = files.IndexOf(name);
                    if (item != -1)
                    {
                        files.RemoveAt(item);
                    }                    
                }
            }

            return files.Count <= 1;
        }
        public DataSetValidatorErrorEnum CheckAnswers(ZipArchive zip)
        {
            List<string> files = new List<string>();
            ZipArchiveEntry answers = default;
            foreach (var item in zip.Entries)
            {
                if (item.Name.Length > 0) 
                { 
                    files.Add(item.Name);
                    if (item.Name == "answers.txt")
                    {
                        answers = item;
                    }
                }
                
            }
            return CheckAnswersInFile(files, answers)
                ? DataSetValidatorErrorEnum.Ok
                : DataSetValidatorErrorEnum.ZipAnswersFileError;
        }
        //------------------------------------------------


        // проверка количества файлов
        private int Mul(DataSetDTO dataset)
        {
            int mul = 1;
            mul += dataset.HasCyrillic ? 1 : 0;
            mul += dataset.HasSpecialSymbols ? 1 : 0;
            mul += dataset.CaseSensitivity ? 1 : 0;
            mul += dataset.HasDigits ? 1 : 0;
            return mul;
        }

        private bool CheckFilesCount(ZipArchive zip, int mul)
        {
            return zip.Entries.Count >= (2000 * mul - 1) && zip.Entries.Count <= (3000 * mul + 1);
        }
        //---------------------------

        public DataSetValidatorErrorEnum Validate(DataSetDTO dataset)
        {
            if (dataset.ZipArchiveImages is null)
                return DataSetValidatorErrorEnum.ZipFileError;

            try
            {
                using (var zip = new ZipArchive(dataset.ZipArchiveImages.OpenReadStream(), ZipArchiveMode.Read))
                {
                    if (!CheckFilesCount(zip, Mul(dataset)))
                        return DataSetValidatorErrorEnum.ZipFilesCount;

                    switch (dataset.AnswersLocation)
                    {
                        case EntityContext.DataSetAnswersLocationEnum.InName:
                            break;
                        case EntityContext.DataSetAnswersLocationEnum.InFile:
                            return CheckAnswers(zip);
                        case EntityContext.DataSetAnswersLocationEnum.None:
                        default:
                            break;
                    }
                }
            }
            catch (Exception)
            {
                return DataSetValidatorErrorEnum.ZipFileError;
            }            

            return DataSetValidatorErrorEnum.Ok;
        }
    }
}
