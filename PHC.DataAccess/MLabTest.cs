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
    
    public partial class MLabTest
    {
        public MLabTest()
        {
            this.LabTestDetails = new HashSet<LabTestDetail>();
        }
    
        public string LabTestID { get; set; }
        public string StateID { get; set; }
        public string Name { get; set; }
        public string LastModifiedBy { get; set; }
        public System.DateTime LastModifiedDate { get; set; }
        public string ObsInd { get; set; }
    
        public virtual ICollection<LabTestDetail> LabTestDetails { get; set; }
        public virtual MState MState { get; set; }
    }
}
