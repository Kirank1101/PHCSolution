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

        ResultDTO SaveMdisease(string DiseaseID, string DiseaseName);

        ResultDTO UpdateMdisease(string DiseaseID, string DiseaseName);

        ResultDTO DeleteMdisease(string DiseaseID);

        List<MDrugsDTO> GetMDrugs();

        ResultDTO SaveMDrug(string DrugName);

        ResultDTO UpdateMDrug(string DrugID, string DrugName);

        ResultDTO DeleteMDrug(string DrugID);
    }
}
