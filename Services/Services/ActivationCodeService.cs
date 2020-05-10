using Domain.Persons;
using Storage.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Services
{
    public class ActivationCodeService : BaseCrudService<ActivationCode>, IActivationCodeService
    {
        public ActivationCodeService(IRepository<ActivationCode> repository) : base(repository)
        {

        }
    }
}
