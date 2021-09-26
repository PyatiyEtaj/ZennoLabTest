using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ZennoLabWebAPI.EntityContext
{
    public class DataSet
    {
        public int DataSetId { get; set; }
        [Required]
        [StringLength(8, MinimumLength = 4)]
        public string Name { get; set; }

        [Required]
        public DateTime Date{ get; set; }

        [Required]
        public bool HasCyrillic { get; set; }

        [Required]
        public bool HasLatin { get; set; }

        [Required]
        public bool HasDigits { get; set; }

        [Required]
        public bool HasSpecialSymbols { get; set; }

        [Required]
        public bool CaseSensitivity { get; set; }

        [Required]
        public DataSetAnswersLocationEnum AnswersLocation { get; set; }

        [Required]
        public byte[] ArchiveImages { get; set; }

    }
}
