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
    
    public partial class PatientAddress
    {
        public string PatientAddressID { get; set; }
        public string PatientID { get; set; }
        public string Address { get; set; }
        public string PhoneNo { get; set; }
        public string ContactNo { get; set; }
        public string LastModifiedBy { get; set; }
        public System.DateTime LastModifiedDate { get; set; }
        public string ObsInd { get; set; }
        public string VillageID { get; set; }
    
        public virtual PatientDetail PatientDetail { get; set; }
        public virtual MVillage MVillage { get; set; }
    }
}
