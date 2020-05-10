using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DTO.Request
{
    public class ActivationRequest
    {
        [Required]
        public string Login { get; set; }

        public string Code { get; set; }
    }
}
