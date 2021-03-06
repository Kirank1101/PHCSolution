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
    
    public partial class MState
    {
        public MState()
        {
            this.MDiseases = new HashSet<MDisease>();
            this.MDistricts = new HashSet<MDistrict>();
            this.MLabTests = new HashSet<MLabTest>();
            this.UserMaps = new HashSet<UserMap>();
            this.MDrugs = new HashSet<MDrug>();
            this.MEducations = new HashSet<MEducation>();
            this.MReligions = new HashSet<MReligion>();
            this.MSchemes = new HashSet<MScheme>();
            this.MVaccinations = new HashSet<MVaccination>();
        }
    
        public string StateID { get; set; }
        public string Name { get; set; }
        public string LastModifiedBy { get; set; }
        public System.DateTime LastModifiedDate { get; set; }
        public string ObsInd { get; set; }
    
        public virtual ICollection<MDisease> MDiseases { get; set; }
        public virtual ICollection<MDistrict> MDistricts { get; set; }
        public virtual ICollection<MLabTest> MLabTests { get; set; }
        public virtual ICollection<UserMap> UserMaps { get; set; }
        public virtual ICollection<MDrug> MDrugs { get; set; }
        public virtual ICollection<MEducation> MEducations { get; set; }
        public virtual ICollection<MReligion> MReligions { get; set; }
        public virtual ICollection<MScheme> MSchemes { get; set; }
        public virtual ICollection<MVaccination> MVaccinations { get; set; }
    }
}
