using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ZennoLabWebAPI.Entity
{
    public class DataSet
    {
        public string Name { get; set; }
        public bool HasCyrillic { get; set; }
        public bool HasLatin { get; set; }
        public bool HasDigits { get; set; }
        public bool HasSpecialSymbols { get; set; }
        public bool CaseSensitivity { get; set; }
        public DataSetAnswersLocationEnum AnswersLocation { get; set; }

        //byte[] Archive

    }
}
