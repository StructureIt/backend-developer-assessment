using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SearchApiService.Models
{
    public class SearchRequest
    {
        [Required]
        public string Query { get; set; }

        [Range(0,100)]
        public int Index { get; set; }

        [Range(1,100)]
        public int Size { get; set; }
    }
}