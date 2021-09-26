using System;
using System.Collections.Generic;
using System.IO;
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
            using (var mem = new MemoryStream())
            {
                dataset.ZipArchiveImages.CopyTo(mem);
                return new DataSet
                {
                    AnswersLocation = dataset.AnswersLocation,
                    ArchiveImages = mem.ToArray(),
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
}
