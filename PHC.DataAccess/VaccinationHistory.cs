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
    
    public partial class VaccinationHistory
    {
        public string VaccinationIssuedID { get; set; }
        public string VaccinationID { get; set; }
        public string PHCID { get; set; }
        public System.DateTime VaccinatedDate { get; set; }
        public string LastModifiedBy { get; set; }
        public System.DateTime LastModifiedDate { get; set; }
        public string ObsInd { get; set; }
    
        public virtual MPHC MPHC { get; set; }
        public virtual MVaccination MVaccination { get; set; }
    }
}
