using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PHC.Business.DataTransfer
{
    public class ResultDTO
    {
        public ResultDTO()
        {
            IsSuccess = true;
            Message = string.Empty;

        }
        public bool IsSuccess
        {
            get;
            set;
        }
        public string Message
        {
            get;
            set;
        }
        public string ID { get; set; }
    }
}
