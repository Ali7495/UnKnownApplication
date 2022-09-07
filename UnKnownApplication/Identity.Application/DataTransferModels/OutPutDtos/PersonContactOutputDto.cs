using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Application.DataTransferModels.OutPutDtos
{
    public class PersonContactOutputDto
    {
        public string ContactTypeName { get; set; } = String.Empty;

        public string Key { get; set; } = String.Empty;

        public string Value { get; set; } = String.Empty;
    }
}
