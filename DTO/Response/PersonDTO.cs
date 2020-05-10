using Domain.Persons;
using System;
using System.Collections.Generic;
using System.Text;

namespace DTO.Response
{
    public class PersonDTO
    {
        public string PhoneNumber { get; set; }

        public PersonDTO()
        { }

        public PersonDTO(Person person)
        {
            if (person == null)
                return;
            PhoneNumber = person.PhoneNumber;
        }
    }
}
