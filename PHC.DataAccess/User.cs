//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PHC.DataAccess
{
    using System;
    using System.Collections.Generic;
    
    public partial class User
    {
        public User()
        {
            this.UserDetails = new HashSet<UserDetail>();
            this.UserMaps = new HashSet<UserMap>();
        }
    
        public string UserID { get; set; }
        public string LoginID { get; set; }
        public string Password { get; set; }
        public string LastModifiedBy { get; set; }
        public System.DateTime LastModifiedDate { get; set; }
        public string ObsInd { get; set; }
    
        public virtual ICollection<UserDetail> UserDetails { get; set; }
        public virtual ICollection<UserMap> UserMaps { get; set; }
    }
}
