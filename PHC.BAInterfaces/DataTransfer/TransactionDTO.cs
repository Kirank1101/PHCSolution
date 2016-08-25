using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PHC.BAInterfaces.DataTransfer
{
    public class UserDTO
    {
        public string UserID { get; set; }
        public string PHCID { get; set; }
        public string Name { get; set; }
        public string EmailID { get; set; }
        public string LoginID { get; set; }
        public string ContactNo { get; set; }
    }
}
