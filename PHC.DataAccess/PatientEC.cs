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
    
    public partial class PatientEC
    {
        public PatientEC()
        {
            this.PatientMCs = new HashSet<PatientMC>();
        }
    
        public string PatientECID { get; set; }
        public string ECNumber { get; set; }
        public string PatientID { get; set; }
        public string LastModifiedBy { get; set; }
        public System.DateTime LastModifiedDate { get; set; }
        public string ObsInd { get; set; }
        public string PHCID { get; set; }
    
        public virtual PatientDetail PatientDetail { get; set; }
        public virtual ICollection<PatientMC> PatientMCs { get; set; }
        public virtual MPHC MPHC { get; set; }
    }
}
