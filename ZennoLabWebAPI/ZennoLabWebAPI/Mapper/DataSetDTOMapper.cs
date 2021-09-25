using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZennoLabWebAPI.DTO;
using ZennoLabWebAPI.EntityContext;

namespace ZennoLabWebAPI.Mapper
{
    public class DataSetDTOMapper
    {
        public DataSet Map(DataSetDTO dataset)
        {
            return new DataSet
            {
                AnswersLocation = dataset.AnswersLocation,
                ArchiveImages = new byte[1024],
                HasCyrillic = dataset.HasCyrillic,
                HasDigits = dataset.HasDigits,
                HasLatin = dataset.HasLatin,
                HasSpecialSymbols = dataset.HasSpecialSymbols,
                Name = dataset.Name,
                CaseSensitivity = dataset.CaseSensitivity,
            };
        }
    }
}
