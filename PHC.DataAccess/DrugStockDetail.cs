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
    
    public partial class DrugStockDetail
    {
        public string DrugStockID { get; set; }
        public string DrugID { get; set; }
        public string PHCID { get; set; }
        public short Quantity { get; set; }
        public string BatchNo { get; set; }
        public System.DateTime ManufactureDate { get; set; }
        public System.DateTime ExpiryDate { get; set; }
        public System.DateTime PurchaseDate { get; set; }
        public string LastModifiedBy { get; set; }
        public System.DateTime LastModifiedDate { get; set; }
        public string ObsInd { get; set; }
    
        public virtual MDrug MDrug { get; set; }
        public virtual MPHC MPHC { get; set; }
    }
}
