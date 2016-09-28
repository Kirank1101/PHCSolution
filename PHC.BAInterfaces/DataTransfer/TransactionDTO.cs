﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PHC.BAInterfaces.DataTransfer
{
    [Serializable]
    public class MStateDTO
    {
        public string StateID { get; set; }
        public string Name { get; set; }
    }
    [Serializable]
    public class MDistrictDTO
    {
        public string DistrictID { get; set; }
        public string DistrictName { get; set; }

    }
    public class MTalukDTO
    {
        public string TalukID { get; set; }
        public string DistrictID { get; set; }
        public string TalukName { get; set; }
        public string DistrictName { get; set; }
    }
    public class MPHCDTO
    {
        public string PHCID { get; set; }
        public string PHCName { get; set; }
        public string TalukID { get; set; }
        public string TalukName { get; set; }
        public string DistrictID { get; set; }
        public string DistrictName { get; set; }
    }
    [Serializable]
    public class MVillageDTO
    {
        public string VillageID { get; set; }
        public string VillageName { get; set; }
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
    [Serializable]
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
        public string PHCID { get; set; }
        public string PatientName { get; set; }
        public Int16 Age { get; set; }
        public DateTime? DOB { get; set; }
        public string Gender { get; set; }
        public string BloodGroup { get; set; }
        public string Place { get; set; }
        public string VillageID { get; set; }
        public string Address { get; set; }
        public string RefPhoneNo { get; set; }
        public string ContactNo { get; set; }
        public string ECNumber { get; set; }
    }
    public class DrugStockDTO
    {
        public string DrugStockID { get; set; }
        public string PHCID { get; set; }
        public string DrugID { get; set; }
        public string DrugName { get; set; }
        public Int32 Quantity { get; set; }
        public string BatchNo { get; set; }
        public DateTime MfDate { get; set; }
        public DateTime ExpDate { get; set; }
        public DateTime PurchaseDate { get; set; }
    }
    public class BloodGroupDTO
    {
        public string BloodGroupID { get; set; }
        public string BloodGroupName { get; set; }
    }
}
