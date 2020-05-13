using System;
using System.Collections.Generic;
using System.Text;

namespace DTO.Request
{
    public class EditProfileDTO
    {
        public string NickName { get; set; }
        public string Email { get; set; }
        public string Vk { get; set; }
        public string Facebook { get; set; }
        public string Instagram { get; set; }
        public string Twitch { get; set; }
    }
}
