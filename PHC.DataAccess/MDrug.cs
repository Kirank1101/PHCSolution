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
    
    public partial class MDrug
    {
        public MDrug()
        {
            this.DrugsIssueds = new HashSet<DrugsIssued>();
            this.DrugStockDetails = new HashSet<DrugStockDetail>();
        }
    
        public string DrugID { get; set; }
        public string Name { get; set; }
        public string LastModifiedBy { get; set; }
        public System.DateTime LastModifiedDate { get; set; }
        public string ObsInd { get; set; }
        public string StateID { get; set; }
    
        public virtual ICollection<DrugsIssued> DrugsIssueds { get; set; }
        public virtual ICollection<DrugStockDetail> DrugStockDetails { get; set; }
        public virtual MState MState { get; set; }
    }
}
