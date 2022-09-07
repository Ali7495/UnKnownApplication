using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Application.DataTransferModels.InputDtos
{
    public class PersonInputDto
    {
        public PersonInputDto()
        {
            PersonContacts = new List<PersonInputContactDto>();
        }

        public string Name { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string NationalCode { get; set; } = string.Empty;
        public DateTime? BirthDate { get; set; }
        public bool? IsMarried { get; set; }
        public string Gender { get; set; } = string.Empty;



        public virtual List<PersonInputContactDto> PersonContacts { get; set; }
    }
}
