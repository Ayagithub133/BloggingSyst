using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BloggingSystem.ViewModels
{
    public class Response
    {

        public string Message { get; set; }
        public bool IsSuccess { set; get; }
        public DateTime? ExpireDate { set; get; }
        

    }
}
