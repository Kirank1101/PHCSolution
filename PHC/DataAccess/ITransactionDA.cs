using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PHC.DataAccess;


namespace PHC.DAInterfaces.DataAccess
{
    public interface ITransactionDA
    {
        
        bool AddPatientInfo(PatientInfo obj);
        bool SaveUserRegistration(User obj);
        User GetUsers(string UserId);
        User GetUsers(string UserName, string Password);
    }
}
