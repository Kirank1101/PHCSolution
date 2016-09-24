using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PHC.BAInterfaces.DataTransfer
{

    public class MStateDTO
    {
        public string StateID { get; set; }
        public string Name { get; set; }
    }
    public class MDistrictDTO
    {
        public string DistrictID { get; set; }
        public string Name { get; set; }

    }
    public class MTalukDTO
    {
        public string TalukID { get; set; }
        public string Name { get; set; }
    }
    public class MPHCDTO
    {
        public string PHCID { get; set; }
        public string Name { get; set; }
    }
    public class MVillageDTO
    {
        public string VillageID { get; set; }
        public string Name { get; set; }
    }
    public class UserDTO
    {
        public string UserID { get; set; }
        public string PHCID { get; set; }
        public string Name { get; set; }
        public string EmailID { get; set; }
        public string LoginID { get; set; }
        public string ContactNo { get; set; }
    }
    public class MDiseaseDTO
    {
        public string DiseaseID { get; set; }
        public string DiseaseName { get; set; }
    }
    public class MDrugsDTO
    {
        public string DrugID { get; set; }
        public string DrugName { get; set; }        
    }
    public class MLabTestDTO
    {
        public string LabTestID { get; set; }
        public string LabTestName { get; set; }
    }
    public class PatientDetailDTO
    {
        public string PatientID { get; set; }
        public string Name { get; set; }
        public Int16 Age { get; set; }
        public DateTime DOB { get; set; }
        public string Place { get; set; }
        public string Address { get; set; }
        public string PhoneNo { get; set; }
        public string ECNumber { get; set; }
        public string MCNumber { get; set; }
    }
}
