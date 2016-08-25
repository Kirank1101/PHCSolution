using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PHC.BAInterfaces.Validations;
using PHC.BAInterfaces.DataTransfer;
using System.Text.RegularExpressions;


namespace PHC.Business
{
    public class UIValidation : IValidate
    {
        public ResultDTO validateuserregistration(string Name, string EmailId, string Contactno, string loginid, string Password, string ConfirmPassword)
        {

            if (string.IsNullOrEmpty(Name))
                return new ResultDTO() { IsSuccess = false, Message = "Please enter Name." };
            else if (string.IsNullOrEmpty(EmailId))
                return new ResultDTO() { IsSuccess = false, Message = "Please enter EmailID." };
            else if (!validateemailid(EmailId))
                return new ResultDTO() { IsSuccess = false, Message = "Please enter valid EmailID." };
            else if (string.IsNullOrEmpty(Contactno))
                return new ResultDTO() { IsSuccess = false, Message = "Please enter Contact NO." };
            else if (Contactno.Length != 10)
                return new ResultDTO() { IsSuccess = false, Message = "Please enter Valid Contact NO." };
            else if (string.IsNullOrEmpty(loginid))
                return new ResultDTO() { IsSuccess = false, Message = "Please enter LogIn ID." };
            else if (string.IsNullOrEmpty(Password))
                return new ResultDTO() { IsSuccess = false, Message = "Please enter Password." };
            else if (string.IsNullOrEmpty(ConfirmPassword))
                return new ResultDTO() { IsSuccess = false, Message = "Please enter Confirm Password." };
            else if (Password != ConfirmPassword)
                return new ResultDTO() { IsSuccess = false, Message = "Password and Confirm Password is not matched!" };
            else
                return new ResultDTO();
        }
        private bool validateemailid(string EmailId)
        {
            Regex mRegxExpression = new Regex(@"^([a-zA-Z0-9_\-])([a-zA-Z0-9_\-\.]*)@(\[((25[0-5]|2[0-4][0-9]|1[0-9][0-9]|[1-9][0-9]|[0-9])\.){3}|((([a-zA-Z0-9\-]+)\.)+))([a-zA-Z]{2,}|(25[0-5]|2[0-4][0-9]|1[0-9][0-9]|[1-9][0-9]|[0-9])\])$");
            if (!mRegxExpression.IsMatch(EmailId))
                return false;
            else
                return true;
        }
        public ResultDTO validateLogin(string UserName, string Password)
        {
            if (string.IsNullOrEmpty(UserName))
                return new ResultDTO() { IsSuccess = false, Message = "Please enter UserName." };
            else if (string.IsNullOrEmpty(Password))
                return new ResultDTO() { IsSuccess = false, Message = "Please enter Password." };
            else
                return new ResultDTO();
        }


        public ResultDTO validatePatientInfo(string Name, string Age, string Contact, int ddlsex, int ddlbloodgroup)
        {
            if (string.IsNullOrEmpty(Name))
                return new ResultDTO() { IsSuccess = false, Message = "Please enter Name." };
            else if (string.IsNullOrEmpty(Age))
                return new ResultDTO() { IsSuccess = false, Message = "Please enter Age." };
            else if (!string.IsNullOrEmpty(Age) && (Convert.ToInt16(Age) == 0 || Convert.ToInt16(Age) > 110))
                return new ResultDTO() { IsSuccess = false, Message = "Please enter Correct Age." };
            else if (!string.IsNullOrEmpty(Contact) && Contact.Length != 10)
                return new ResultDTO() { IsSuccess = false, Message = "Please Correct Contact No." };
            else if (ddlsex == 0)
                return new ResultDTO() { IsSuccess = false, Message = "Please Select Sex" };
            else if (ddlbloodgroup == 0)
                return new ResultDTO() { IsSuccess = false, Message = "Please Select BloodGroup" };
            else
                return new ResultDTO();
        }
    }
}
