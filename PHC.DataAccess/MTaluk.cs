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
    
    public partial class MTaluk
    {
        public MTaluk()
        {
            this.MPHCs = new HashSet<MPHC>();
            this.UserMaps = new HashSet<UserMap>();
        }
    
        public string TalukID { get; set; }
        public string DistrictID { get; set; }
        public string Name { get; set; }
        public string LastModifiedBy { get; set; }
        public System.DateTime LastModifiedDate { get; set; }
        public string ObsInd { get; set; }
    
        public virtual MDistrict MDistrict { get; set; }
        public virtual ICollection<MPHC> MPHCs { get; set; }
        public virtual ICollection<UserMap> UserMaps { get; set; }
    }
}
