using Domain.Persons;
using DTO.Response;
using Microsoft.AspNetCore.Http;
using Storage.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Utils;

namespace Services.Services
{
    public class PersonService : BaseCrudService<Person>, IPersonService
    {
        public PersonService(IRepository<Person> repository) : base(repository)
        {

        }

        public async Task<ProfileDTO> SetAvatar(IFormFile file, User user)
        {
            if (file == null)
                throw new ServiceErrorException(502);
            var fileName = $"{CryptHelper.CreateMD5(DateTime.Now.ToString())}{Path.GetExtension(file.FileName)}";
            var path = $"{System.IO.Directory.GetCurrentDirectory()}/Files/";
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);

            using (var fileStream = new FileStream(path + fileName, FileMode.Create))
            {
                await file.CopyToAsync(fileStream);
            }

            user.Person.Avatar = fileName == string.Empty ? user.Person.Avatar : fileName;
            Update(user.Person);

            return new ProfileDTO(user);

        }
    }
}

