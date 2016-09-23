using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PHC.BAInterfaces.Business;
using PHC.DAInterfaces.DataAccess;
using PHC.DataAccess;
using PHC.BAInterfaces.DataTransfer;
namespace PHC.Business
{
    public class TransactionBusiness : ITransactionBusiness
    {
        ITransactionDA objDA;
        public TransactionBusiness(ITransactionDA iDA)
        {
            objDA = iDA;
        }

        //ResultDTO ITransactionBusiness.AddPatientInfo(string patientName, string age, string sex, string dob, string bloodgroup,string PHCID,string contactno)
        //{
        //    PatientInfo info = new PatientInfo();
        //    info.Age = Convert.ToInt16(age);
        //    info.BloodGroup = bloodgroup;
        //    info.ContactNo = contactno;
        //    info.DOB = DateTime.Now;
        //    info.LastModifiedBy = "system";
        //    info.LastModifiedDate = DateTime.Now;
        //    info.PHCID = PHCID;
        //    info.Name = patientName;
        //    info.ObsInd = "N";
        //    info.PatientID = AllInOne.Common.Library.Util.CommonUtil.CreateUniqueID("PT");
        //    info.Sex = sex;
        //    if(objDA.AddPatientInfo(info))
        //        return new ResultDTO() { IsSuccess = true, Message = "Successfully Saved." };
        //    else
        //        return new ResultDTO() { IsSuccess = false, Message = "Unsuccessfully Saved." };
        //}
        //bool ITransactionBusiness.AddUserRegistration(string Name, string EmailId, string Contactno, string loginid, string Password, string ConfirmPassword)
        //{

        //    User user = new User();
        //    //user.PHCID = "PHC1";
        //    user.UserID = AllInOne.Common.Library.Util.CommonUtil.CreateUniqueID("UI");
        //    //user.Name = Name;
        //    //user.EmailID = EmailId;
        //    //user.ContactNo = Contactno;
        //    user.LoginID = loginid;
        //    user.Password = Password;
        //    user.ObsInd = "N";
        //    user.LastModifiedBy = "system";
        //    user.LastModifiedDate = DateTime.Now;
        //    return objDA.SaveUserRegistration(user);
        //}
        ////UserDTO ITransactionBusiness.GetUsers(string UserId)
        //{
        //    User user = new User();
        //    UserDTO userDTO = null;
        //    user = objDA.GetUsers(UserId);
        //    if (user != null)
        //    {
        //        userDTO = new UserDTO();
        //        userDTO.UserID = user.UserID;
        //        userDTO.PHCID = user.;
        //        userDTO.EmailID = user.EmailID;
        //        userDTO.ContactNo = user.ContactNo;
        //        userDTO.LoginID = user.LoginID;
        //        userDTO.Name = user.Name;
        //    }
        //    return userDTO;
        //}
        //public ResultDTO AuthenticateUser(string UserName, string Password)
        //{
        //    User user = new User();
        //    user = objDA.GetUsers(UserName, Password);
        //    if (user != null)
        //        return new ResultDTO() {PHCID=user.PHCID, IsSuccess = true, Message = "Please enter UserName." };
        //    else
        //        return new ResultDTO() { IsSuccess = false, Message = "Invalid Username and Password." };
        //}

        public List<MDiseaseDTO> GetMDiseases()
        {
            List<MDisease> lstdisease = objDA.GetMDiseases();
            List<MDiseaseDTO> lstDiseaseDTO = new List<MDiseaseDTO>();
            if (lstdisease != null)
                foreach (MDisease Disease in lstdisease)
                {
                    MDiseaseDTO DiseaseDTO = new MDiseaseDTO();
                    DiseaseDTO.DiseaseID = Disease.DiseaseID;
                    DiseaseDTO.DiseaseName = Disease.Name;
                    lstDiseaseDTO.Add(DiseaseDTO);
                }
            return lstDiseaseDTO;
        }
        public ResultDTO SaveMdisease(string DiseaseID, string DiseaseName)
        {
            MDisease Disease = new MDisease();
            Disease.DiseaseID = DiseaseID;
            Disease.Name = DiseaseName;
            Disease.StateID = "Karnataka";
            Disease.LastModifiedBy = "System";
            Disease.LastModifiedDate = DateTime.Now;
            Disease.ObsInd = "N";
            MDisease checkdisease = objDA.GetMDiseases(DiseaseName);
            if (checkdisease != null)
            {
                if (objDA.AddMDisease(Disease))
                    return new ResultDTO() { IsSuccess = true, Message = "Successfully Saved." };
                else
                    return new ResultDTO() { IsSuccess = false, Message = "Unsuccessfully Saved." };
            }
            else
                return new ResultDTO() { IsSuccess = false, Message = "DiseaseName already exist." };
        }
        public ResultDTO UpdateMdisease(string DiseaseID, string DiseaseName)
        {
            MDisease Disease = new MDisease();
            Disease.DiseaseID = DiseaseID;
            Disease.Name = DiseaseName;
            if (objDA.UpdateMDisease(Disease))
                return new ResultDTO() { IsSuccess = true, Message = "Successfully Updated." };
            else
                return new ResultDTO() { IsSuccess = false, Message = "Unsuccessfully Updated." };
        }
        public ResultDTO DeleteMdisease(string DiseaseID)
        {
            MDisease Disease = new MDisease();
            Disease.DiseaseID = DiseaseID;
            if (objDA.DeleteMDisease(Disease))
                return new ResultDTO() { IsSuccess = true, Message = "Successfully Deleted." };
            else
                return new ResultDTO() { IsSuccess = false, Message = "Unsuccessfully Deleted." };
        }
        public List<MDrugsDTO> GetMDrugs()
        {
            List<MDrug> lstDrug = objDA.GetMDrugs();
            List<MDrugsDTO> lstDrugDTO = new List<MDrugsDTO>();
            if (lstDrug != null)
                foreach (MDrug Drug in lstDrug)
                {
                    MDrugsDTO DrugDTO = new MDrugsDTO();
                    DrugDTO.DrugID = Drug.DrugID;
                    DrugDTO.DrugName = Drug.Name;
                    DrugDTO.Quantity = Drug.Quantity;
                    DrugDTO.MfDate = Drug.manufactureDate;
                    DrugDTO.ExpDate = Drug.ExpiryDate;
                    DrugDTO.PurchaseDate = Drug.PurchaseDate;
                    lstDrugDTO.Add(DrugDTO);
                }
            return lstDrugDTO;
        }
        public ResultDTO SaveMDrug(string DrugName, int Quantity, string BatchNo, DateTime MfDate, DateTime ExpDate, DateTime PurchaseDate)
        {

            MDrug Drug = new MDrug();
            Drug.DrugID = "DrugID";
            Drug.Name = DrugName;
            Drug.Quantity = Quantity;
            Drug.BatchNo = BatchNo;
            Drug.manufactureDate = MfDate;
            Drug.ExpiryDate = ExpDate;
            Drug.PurchaseDate = PurchaseDate;
            Drug.LastModifiedBy = "System";
            Drug.LastModifiedDate = DateTime.Now;
            Drug.ObsInd = "N";
            MDrug checkdrug = objDA.GetMdrug(DrugName);
            if (checkdrug != null)
            {
                if (objDA.AddMDrug(Drug))
                    return new ResultDTO() { IsSuccess = true, Message = "Successfully Saved." };
                else
                    return new ResultDTO() { IsSuccess = false, Message = "Unsuccessfully Saved." };
            }
            else
                return new ResultDTO() { IsSuccess = false, Message = "DiseaseName already exist." };
        }
        public ResultDTO UpdateMDrug(string DrugID, string DrugName, int Quantity, string BatchNo, DateTime MfDate, DateTime ExpDate, DateTime PurchaseDate)
        {
            MDrug Drug = new MDrug();
            Drug.DrugID = DrugID;
            Drug.Name = DrugName;
            Drug.BatchNo = BatchNo;
            Drug.Quantity = Quantity;
            Drug.manufactureDate = MfDate;
            Drug.ExpiryDate = ExpDate;
            Drug.PurchaseDate = PurchaseDate;
            Drug.LastModifiedBy = "System";
            Drug.LastModifiedDate = DateTime.Now;
            Drug.ObsInd = "N";
            if (objDA.UpdateMDrug(Drug))
                return new ResultDTO() { IsSuccess = true, Message = "Successfully Updated." };
            else
                return new ResultDTO() { IsSuccess = false, Message = "Unsuccessfully Updated." };
        }
        public ResultDTO DeleteMDrug(string DrugID)
        {
            MDrug Drug = new MDrug();
            Drug.DrugID = DrugID;
            if (objDA.DeleteMDrug(Drug))
                return new ResultDTO() { IsSuccess = true, Message = "Successfully Deleted." };
            else
                return new ResultDTO() { IsSuccess = false, Message = "Unsuccessfully Deleted." };
        }
    }
}
