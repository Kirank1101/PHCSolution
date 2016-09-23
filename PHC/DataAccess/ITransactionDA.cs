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
    }
}
