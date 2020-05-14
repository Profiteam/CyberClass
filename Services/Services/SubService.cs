using Domain.Orders;
using DTO.Request;
using DTO.Response;
using Storage.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utils;

namespace Services.Services
{
    public class SubService : BaseCrudService<Sub>, ISubService
    {
        public SubService(IRepository<Sub> repository) : base(repository)
        {

        }

        public bool CreateSub(CreateSubDTO request)
        {
            if (!SMTPHelper.EmailIsValid(request.Email))
                throw new ServiceErrorException(107);

            var sub = new Sub
            {
                Email = request.Email,
                Date = DateTime.UtcNow

            };
            Create(sub);
            return true;
        }

        public IList<SubDTO> GetSubs()
        {
            return GetAll().OrderByDescending(x => x.Date).Select(x => new SubDTO(x)).ToList();
        }
    }
}
