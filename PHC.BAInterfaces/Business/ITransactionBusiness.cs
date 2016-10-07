using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PHC.DataAccess;
using PHC.BAInterfaces.DataTransfer;

namespace PHC.BAInterfaces.Business
{
   public  interface ITransactionBusiness
    {
        
       // ResultDTO AddPatientInfo(string patientName, string age, string sex, string dob, string bloodgroup,string PHCID,string contactno);

        //bool AddUserRegistration(string Name, string EmailId, string Contactno, string loginid, string Password, string ConfirmPassword);

        //UserDTO GetUsers(string UserId);

        //ResultDTO AuthenticateUser(string UserName, string Password);
        List<MDiseaseDTO> GetMDiseases();
        ResultDTO SaveMdisease(string DiseaseName);
        ResultDTO UpdateMdisease(string DiseaseID, string DiseaseName);
        ResultDTO DeleteMdisease(string DiseaseID);
        List<MDrugsDTO> GetMDrugs();
        ResultDTO SaveMDrug(string DrugName);
        ResultDTO UpdateMDrug(string DrugID, string DrugName);
        ResultDTO DeleteMDrug(string DrugID);
        List<MLabTestDTO> GetMLabTest();
        ResultDTO SaveMLabTest(string LabTestName);       
        ResultDTO UpdateMLabTest(string LabTestID, string LabTestName);
        ResultDTO DeleteMLabTest(string LabTestID);
        List<MTalukDTO> GetMTaluk();
        ResultDTO UpdateMTaluk(string TalukID, string p1, string p2);
        ResultDTO DeleteMTaluk(string TalukID);
        List<MDistrictDTO> GetMDistricts();
        ResultDTO SaveMTaluk(string DistrictID, string TalukName);
        List<MPHCDTO> GetMPHC();
        ResultDTO SaveMPHC(string TalukID, string PHCName);
        ResultDTO DeleteMPHC(string PHCID);
        List<MTalukDTO> GetMTalukNames(string DistrictID);
        ResultDTO UpdateMPHC(string PHCID, string PHCName);
        List<DrugStockDTO> GetDrugPurchaseDetail(string PHCID);
        ResultDTO SaveDrugStock(string DrugID, string PHCID, Int16 Quantity, string BatchNo, string MfDate, string ExpDate, string PurchaseDate);
        ResultDTO UpdateDrugStock(string DrugStockID, string DrugID, string PHCID, Int16 Quantity, string BatchNo, string MfDate, string ExpDate, string PurchaseDate);
        ResultDTO DeleteDrugStock(string DrugStockID);
        ResultDTO SavePatientDetails(string PHCID,string PatientName, string ECNumber, short Age, string DOB, string Gender, string BloodGroup, string VillageID, string Address, string ContactNo, string PhoneNo);
        ResultDTO UpdatePatientDetail(string PHCID, string PatientID, string PatientName, string ECNumber, short Age, string DOB, string Gender, string BloodGroup, string VillageID, string Address, string ContactNo, string PhoneNo);
        ResultDTO DeletePatientDetail(string PatientID);
        List<PatientDetailDTO> GetPatientDetail(string PHCID);
        List<MVillageDTO> GetMVillages(string PHCID);
        List<BloodGroupDTO> GetBloodGroup();
        ResultDTO AddUser(string PHCID, string stateId, string districtId, string talukId, string villageId, string password,
            string userId, string emailId,string userName);
        List<MVillageDTO> GetMVillage(string PHCID);
        ResultDTO DeleteMVillage(string VillageID,string PHCID);
        ResultDTO SaveMVillage(string VillageName, string PHCID);
        ResultDTO UpdateMVillage(string VillageID, string PHCID, string VillageName);

        ResultDTO SaveMScheme(string SchemeName);
        List<MSchemeDTO> GetMScheme();
        ResultDTO UpdateMScheme(string SchemeID, string SchemeName); 
        ResultDTO DeleteMScheme(string SchemeID);

        ResultDTO SaveMReligion(string ReligionName);
        List<MReligionDTO> GetMReligion();
        ResultDTO UpdateMReligion(string ReligionID, string ReligionName);
        ResultDTO DeleteMReligion(string ReligionID);

        ResultDTO SaveSubCenter(string PHCID, string SubCenterName);
        List<SubCenterDTO> GetSubCenter(string PHCID);
        ResultDTO UpdateSubCenter(string PHCID, string SubCenterID, string SubCenterName);
        ResultDTO DeleteSubCenter(string PHCID, string SubCenterID);

        ResultDTO SaveMEducation(string EducationName); 
        List<MEducationDTO> GetMEducation();
        ResultDTO UpdateMEducation(string EducationID, string EducationName);
        ResultDTO DeleteMEducation(string EducationID);



        PatientDetailDTO GeTPatientInfo(string PatientName,string PHCID);

        ResultDTO SavePatientPrescription(string PatientID, string PHCID, string DiseaseID, string Description, List<TempDrugsDTO> lTD, List<TempLabTestDTO> lLT);


        List<PatientVistiHistoryDTO> GetPatientVistHistory(string PatientID, string PHCID);

        bool CheckPHCOpeningBalanceExist(string PHCID);

        ResultDTO SavePHCOpeningBalance(string PHCID,decimal Amount);

        List<PHCTransactionDTO> GetPHCTransactionDetails(string PHCID);

        ResultDTO SavePHCTransaction(string PHCID, string TransactionType, string ReceiverorGiverName, string ChequeuNo, decimal Amount, string Description);

        ResultDTO UpdateTransaction(string TransactionID, string PHCID);

        List<PHCTransactionDTO> GetPendingTransactionDetails(string PHCID);

        List<PHCTransactionDTO> GetPatientPendingTransaction(string PatientName, string PHCID);
    }
}
