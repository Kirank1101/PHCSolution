using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PHC.BAInterfaces.DataTransfer;


namespace PHC.BAInterfaces.Validations
{
   public interface IValidate
    {
       ResultDTO validateuserregistration(string Name, string EmailId, string Contactno, string loginid, string Password, string ConfirmPassword);

       ResultDTO validateLogin(string UserName, string Password);

       ResultDTO validatePatientInfo(string Name, string Age, string Contact, int ddlsex, int ddlbloodgroup);
    }
}
