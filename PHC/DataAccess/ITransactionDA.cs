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
    }
}
