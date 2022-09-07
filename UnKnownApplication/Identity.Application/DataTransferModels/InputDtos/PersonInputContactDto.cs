using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Application.DataTransferModels.InputDtos
{
    public class PersonInputContactDto
    {
        public Guid ContactTypeId { get; set; }

        public string Key { get; set; } = String.Empty;

        public string Value { get; set; } = String.Empty;
    }
}
