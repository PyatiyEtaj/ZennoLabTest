using System;
using System.Collections.Generic;
using System.Linq;
using ZennoLabWebAPI.DTO;
using ZennoLabWebAPI.Services.Validators;

namespace ZennoLabWebAPI.Services
{
    public class DataSetValidator : IDataSetValidator
    {
        private List<IDataSetElementValidator> _validators = new ();

        public DataSetValidator()
        {
            var types = typeof(IDataSetElementValidator)
                .Assembly
                .DefinedTypes
                .Where(x => !x.IsAbstract && !x.IsInterface && typeof(IDataSetElementValidator).IsAssignableFrom(x))
                .ToList();

            foreach(var i in types)
            {
                var ctor = i.GetConstructors().FirstOrDefault();
                if (ctor is not null)
                    _validators.Add((IDataSetElementValidator)ctor.Invoke(null));
            }
        }

        public (bool valid, string message) Validate(DataSetDTO dataset)
        {
            foreach(var v in _validators)
            {
                var result = v.Validate(dataset);
                if (result != DataSetValidatorErrorEnum.Ok)
                    return (false, DataSetValidatorsErrors.GetMessage(result));
            }
            return (true, DataSetValidatorsErrors.GetMessage(DataSetValidatorErrorEnum.Ok));
        }
    }
}
