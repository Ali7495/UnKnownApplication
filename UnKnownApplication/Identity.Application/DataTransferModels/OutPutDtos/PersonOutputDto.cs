using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Application.DataTransferModels.OutPutDtos
{
    public class PersonOutputDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string NationalCode { get; set; } = string.Empty;
        public DateTime? BirthDate { get; set; }
        public bool? IsMarried { get; set; }
        public string Gender { get; set; } = string.Empty;
    }
}
