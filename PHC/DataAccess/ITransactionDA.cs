using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PHC.DataAccess;


namespace PHC.DAInterfaces.DataAccess
{
    public interface ITransactionDA
    {
        
        bool AddPatientInfo(PatientDetail obj);
        bool SaveUserRegistration(User obj);
        User GetUsers(string UserId);
        User GetUsers(string UserName, string Password);

        List<MDisease> GetMDiseases();
        bool AddMDisease(MDisease Disease);

        bool UpdateMDisease(MDisease Disease);

        bool DeleteMDisease(String DiseaseID);

        MDisease GetMDiseases(string DiseaseName);

        List<MDrug> GetMDrugs();

        MDrug GetMdrug(string DrugName);

        bool AddMDrug(MDrug Drug);

        bool UpdateMDrug(MDrug Drug);

        bool DeleteMDrug(string DrugID);

        List<MLabTest> GetMLabTests();

        MLabTest GetMLabTests(string LabTestName);

        bool AddMLabTest(MLabTest LabTest);

        bool UpdateMLabTest(MLabTest LabTest);

        bool DeleteMLabTest(string LabTestID);

        List<MTaluk> GetMTaluks();

        string GetDistrictName(string DistrictID);

        MTaluk GetMTaluk(string TalukName);

        bool AddMTaluk(MTaluk MTaluk);

        bool UpdateMTaluk(MTaluk Taluk);

        bool DeleteMTaluk(string TalukID);

        List<MDistrict> GetMDistrict();

        List<MTaluk> GetMTaluks(string DistrictID);

        MPHC GetMPHC(string PHCName);

        bool AddMPHC(MPHC MPHC);

        List<MPHC> GetMPHCList();


        MTaluk GetMTalukOnID(string TalukID);

        bool DeleteMPHC(string PHCID);

        bool UpdateMPHC(MPHC PHC);

        List<DrugStockDetail> GetDrugPurchaseDetail(string PHCID);

        string GetDrugName(string DrugID);

        bool AddDrugStock(DrugStockDetail DrugStockDetail);

        bool UpdateDrugStock(DrugStockDetail DrugStockDetail);

        bool DeleteDrugStock(string DrugStockID);

        bool UpdatePatientDetail(PatientDetail PatientDetail);

        bool AddPatientDetails(PatientDetail PatientDetail);

        List<PatientDetail> GetPatientDetail(string PHCID);

        string GetVillageName(string VillageID);

        List<MVillage> getMVillage(string PHCID);
        PatientEC GetPatientEC(string PatientID);
        bool AddUser(User userObj);
        //to Check PatientName exist in DB 
        string CheeckPatientName(string PatientName, string ECNumber, string PHCID);

        string CheckPatientNameAndECNumberforUpdate(string PatientID, string ECNumber, string PatientName, string PHCID);

        List<MVillage> GetMVillage(string PHCID);

        bool DeleteVillage(string VillageID, string PHCID);

        bool AddMVillage(MVillage MVillage);

        MVillage CheckVillage(string PHCID, string VillageName);

        string CheckVillageforUpdate(string VillageID, string PHCID, string VillageName);

        bool UpdateVillageDetail(MVillage MVillage);

        MScheme checkSchemeName(string SchemeName);

        bool AddMScheme(MScheme MScheme);

        MReligion checkReligionName(string ReligionName);

        bool AddMReligion(MReligion MReligion);

        SubCenter checkSubCenterName(string PHCID, string SubCenterName);

        bool AddSubCenter(SubCenter SubCenter);

        MEducation checkEducationName(string EducationName);

        bool AddMEducation(MEducation MEducation);

        List<MScheme> GetMSchemes();

        List<MReligion> GetMReligions();

        List<MEducation> GetMEducations();

        List<SubCenter> GetSubCenter(string PHCID);

        string CheckSchemforUpdate(string SchemeID, string SchemeName);

        bool UpdateSchemeDetail(MScheme MScheme);

        string CheckReligionforUpdate(string ReligionID, string ReligionName);

        bool UpdateReligionDetail(MReligion MReligion);

        string CheckEducationforUpdate(string EducationID, string EducationName);

        bool UpdateEducationDetail(MEducation MEducation);

        bool UpdateSubCenterDetail(SubCenter SubCenter);

        string CheckSubCenterforUpdate(string SubCenterID, string PHCID, string SubCenterName);

        bool DeleteMScheme(string SchemeID);

        bool DeleteReligion(string ReligionID);

        bool DeleteEducation(string EducationID);

        bool DeleteSubCenter(string SubCenterID, string PHCID);

        bool AddPatientPrescription(PatientPrescription PP);


        PatientDetail GeTPatientInfo(string PatientName,string PHCID);

        List<PatientPrescription> GetPatientVistHistory(string PatientID, string PHCID);

        PHCTransaction checkPHCOpeningBalance(string PHCID, string Description);

        bool AddPHCTransaction(PHCTransaction PHCT);

        List<PHCTransaction> GetPHCTransaction(string PHCID);

        bool UpdatePHCTransaction(PHCTransaction PHCTransaction);

        List<PHCTransaction> GetPendingTransaction(string PHCID);

        List<PHCTransaction> GetPatientPendingTransaction(string PatientName, string PHCID);
    }
}
