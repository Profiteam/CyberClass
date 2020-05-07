using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DTO.Request
{
        public class PagingModel
        {
            [Required]
            public int PageSize { get; set; } = 10;
            [Required]
            public int PageNumber { get; set; } = 1;
        }

        public class SearchPagingModel : PagingModel
        {
            public string Search { get; set; }
        }
}
