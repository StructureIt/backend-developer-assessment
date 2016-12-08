using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SearchApiService.Models
{
    public class ErrorActionResult
    {
        public string Message { get; set; }

        public ICollection<string> Reasons { get; set; }

        public ErrorActionResult(string message, ICollection<string> reasons)
        {
            this.Message = message;
            Reasons = reasons;
        }
    }
}