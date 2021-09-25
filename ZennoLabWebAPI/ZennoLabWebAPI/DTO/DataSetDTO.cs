using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZennoLabWebAPI.EntityContext;

namespace ZennoLabWebAPI.DTO
{
    public class DataSetDTO
    {      
        public string Name { get; set; }
        public bool HasCyrillic { get; set; }
        public bool HasLatin { get; set; }        
        public bool HasDigits { get; set; }        
        public bool HasSpecialSymbols { get; set; }        
        public bool CaseSensitivity { get; set; }        
        public DataSetAnswersLocationEnum AnswersLocation { get; set; }
        public IFormFile ZipArchiveImages { get; set; }

    }
}
