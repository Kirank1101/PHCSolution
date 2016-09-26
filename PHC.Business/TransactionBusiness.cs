using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PHC.BAInterfaces.Business;
using PHC.DAInterfaces.DataAccess;
using PHC.DataAccess;
using PHC.BAInterfaces.DataTransfer;
using AllInOne.Common.Library.Util;
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
            if (objDA.DeleteMDisease(DiseaseID))
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
                    lstDrugDTO.Add(DrugDTO);
                }
            return lstDrugDTO;
        }
        public ResultDTO SaveMDrug(string DrugName)
        {
            MDrug Drug = new MDrug();
            Drug.DrugID = "DrugID1";
            Drug.Name = DrugName;
            Drug.LastModifiedBy = "System";
            Drug.LastModifiedDate = DateTime.Now;
            Drug.ObsInd = "N";
            MDrug checkdrug = objDA.GetMdrug(DrugName);
            if (checkdrug == null)
            {
                if (objDA.AddMDrug(Drug))
                    return new ResultDTO() { IsSuccess = true, Message = "Successfully Saved." };
                else
                    return new ResultDTO() { IsSuccess = false, Message = "Unsuccessfully Saved." };
            }
            else
                return new ResultDTO() { IsSuccess = false, Message = "Drug already exist." };
        }
        public ResultDTO UpdateMDrug(string DrugID, string DrugName)
        {
            MDrug Drug = new MDrug();
            Drug.DrugID = DrugID;
            Drug.Name = DrugName;
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
            if (objDA.DeleteMDrug(DrugID))
                return new ResultDTO() { IsSuccess = true, Message = "Successfully Deleted." };
            else
                return new ResultDTO() { IsSuccess = false, Message = "Unsuccessfully Deleted." };
        }
        public List<MLabTestDTO> GetMLabTest()
        {
            List<MLabTest> lstLabTest = objDA.GetMLabTests();
            List<MLabTestDTO> lstLabTestDTO = new List<MLabTestDTO>();
            if (lstLabTest != null)
                foreach (MLabTest labtest in lstLabTest)
                {
                    MLabTestDTO LabTestDTO = new MLabTestDTO();
                    LabTestDTO.LabTestID = labtest.LabTestID;
                    LabTestDTO.LabTestName = labtest.Name;
                    lstLabTestDTO.Add(LabTestDTO);
                }
            return lstLabTestDTO;
        }
        public ResultDTO SaveMLabTest(string LabTestName)
        {
            MLabTest LabTest = new MLabTest();
            LabTest.LabTestID = "LabTestID1";
            LabTest.StateID = "Karnataka";
            LabTest.Name = LabTestName;
            LabTest.LastModifiedBy = "System";
            LabTest.LastModifiedDate = DateTime.Now;
            LabTest.ObsInd = "N";
            MLabTest checkLabTest = objDA.GetMLabTests(LabTestName);
            if (checkLabTest == null)
            {
                if (objDA.AddMLabTest(LabTest))
                    return new ResultDTO() { IsSuccess = true, Message = "Successfully Saved." };
                else
                    return new ResultDTO() { IsSuccess = false, Message = "Unsuccessfully Saved." };
            }
            else
                return new ResultDTO() { IsSuccess = false, Message = "LabTest already exist." };
        }
        public ResultDTO UpdateMLabTest(string LabTestID, string LabTestName)
        {
            MLabTest LabTest = new MLabTest();
            LabTest.LabTestID = LabTestID;
            LabTest.Name = LabTestName;
            LabTest.LastModifiedBy = "System";
            LabTest.LastModifiedDate = DateTime.Now;
            LabTest.ObsInd = "N";
            if (objDA.UpdateMLabTest(LabTest))
                return new ResultDTO() { IsSuccess = true, Message = "Successfully Updated." };
            else
                return new ResultDTO() { IsSuccess = false, Message = "Unsuccessfully Updated." };
        }
        public ResultDTO DeleteMLabTest(string LabTestID)
        {
            if (objDA.DeleteMLabTest(LabTestID))
                return new ResultDTO() { IsSuccess = true, Message = "Successfully Deleted." };
            else
                return new ResultDTO() { IsSuccess = false, Message = "Unsuccessfully Deleted." };
        }
        public List<MTalukDTO> GetMTaluk()
        {
            List<MTaluk> lstTaluk = objDA.GetMTaluks();
            List<MTalukDTO> lstTalukDTO = new List<MTalukDTO>();
            if (lstTaluk != null)
                foreach (MTaluk Taluk in lstTaluk)
                {
                    MTalukDTO TalukDTO = new MTalukDTO();
                    TalukDTO.TalukID = Taluk.TalukID;
                    TalukDTO.TalukName = Taluk.Name;
                    TalukDTO.DistrictID = Taluk.DistrictID;
                    string DistrictName = objDA.GetDistrictName(TalukDTO.DistrictID);
                    TalukDTO.DistrictName = DistrictName;
                    lstTalukDTO.Add(TalukDTO);
                }
            return lstTalukDTO;
        }
        public ResultDTO SaveMTaluk(string DistrictID, string TalukName)
        {
            MTaluk MTaluk = new MTaluk();
            MTaluk.TalukID = "LabTestID1";
            MTaluk.DistrictID = DistrictID;
            MTaluk.Name = TalukName;
            MTaluk.LastModifiedBy = "System";
            MTaluk.LastModifiedDate = DateTime.Now;
            MTaluk.ObsInd = "N";
            MTaluk checkTaluk = objDA.GetMTaluk(TalukName);
            if (checkTaluk == null)
            {
                if (objDA.AddMTaluk(MTaluk))
                    return new ResultDTO() { IsSuccess = true, Message = "Successfully Saved." };
                else
                    return new ResultDTO() { IsSuccess = false, Message = "Unsuccessfully Saved." };
            }
            else
                return new ResultDTO() { IsSuccess = false, Message = "Taluk already exist." };
        }
        public ResultDTO UpdateMTaluk(string TalukID, string DistrictID, string TalukName)
        {
            MTaluk Taluk = new MTaluk();
            Taluk.TalukID = TalukID;
            Taluk.Name = TalukName;
            Taluk.DistrictID = DistrictID;
            Taluk.LastModifiedBy = "System";
            Taluk.LastModifiedDate = DateTime.Now;
            Taluk.ObsInd = "N";
            if (objDA.UpdateMTaluk(Taluk))
                return new ResultDTO() { IsSuccess = true, Message = "Successfully Updated." };
            else
                return new ResultDTO() { IsSuccess = false, Message = "Unsuccessfully Updated." };
        }
        public ResultDTO DeleteMTaluk(string TalukID)
        {
            if (objDA.DeleteMTaluk(TalukID))
                return new ResultDTO() { IsSuccess = true, Message = "Successfully Deleted." };
            else
                return new ResultDTO() { IsSuccess = false, Message = "Unsuccessfully Deleted." };
        }
        public List<MDistrictDTO> GetMDistricts()
        {
            List<MDistrict> lstDistrict = objDA.GetMDistrict();
            List<MDistrictDTO> lstDistrictDTO = new List<MDistrictDTO>();
            if (lstDistrict != null)
                foreach (MDistrict District in lstDistrict)
                {
                    MDistrictDTO DistrictDTO = new MDistrictDTO();
                    DistrictDTO.DistrictID = District.DistrictID;
                    DistrictDTO.DistrictName = District.Name;
                    lstDistrictDTO.Add(DistrictDTO);
                }
            return lstDistrictDTO;
        }


        public List<MPHCDTO> GetMPHC()
        {
            List<MPHC> lstPHC = objDA.GetMPHCList();
            List<MPHCDTO> lstPHCDTO = new List<MPHCDTO>();
            if (lstPHC != null)
                foreach (MPHC PHC in lstPHC)
                {
                    MPHCDTO PHCDTO = new MPHCDTO();
                    PHCDTO.PHCID = PHC.PHCID;
                    PHCDTO.PHCName = PHC.Name;
                    PHCDTO.TalukID = PHC.TalukID;
                    MTaluk mtaluk =objDA.GetMTalukOnID(PHCDTO.TalukID);
                    PHCDTO.TalukName = mtaluk.Name;
                    PHCDTO.DistrictID = mtaluk.DistrictID;
                    PHCDTO.DistrictName = objDA.GetDistrictName(mtaluk.DistrictID);
                    
                    lstPHCDTO.Add(PHCDTO);
                }
            return lstPHCDTO;
        }

        public ResultDTO SaveMPHC(string TalukID, string PHCName)
        {
            MPHC MPHC = new MPHC();
            MPHC.PHCID = CommonUtil.CreateUniqueID(PHCName);
            MPHC.TalukID = TalukID;
            MPHC.Name = PHCName;
            MPHC.LastModifiedBy = "System";
            MPHC.LastModifiedDate = DateTime.Now;
            MPHC.ObsInd = "N";
            MPHC checkPHC = objDA.GetMPHC(PHCName);
            if (checkPHC == null)
            {
                if (objDA.AddMPHC(MPHC))
                    return new ResultDTO() { IsSuccess = true, Message = "Successfully Saved." };
                else
                    return new ResultDTO() { IsSuccess = false, Message = "Unsuccessfully Saved." };
            }
            else
                return new ResultDTO() { IsSuccess = false, Message = "PHC already exist." };
        }

        public ResultDTO DeleteMPHC(string PHCID)
        {
            throw new NotImplementedException();
        }


        public List<MTalukDTO> GetMTalukNames(string DistrictID)
        {
            List<MTaluk> lstTaluk = objDA.GetMTaluks(DistrictID);
            List<MTalukDTO> lstTalukDTO = new List<MTalukDTO>();
            if (lstTaluk != null)
                foreach (MTaluk Taluk in lstTaluk)
                {
                    MTalukDTO TalukDTO = new MTalukDTO();
                    TalukDTO.TalukID = Taluk.TalukID;
                    TalukDTO.TalukName = Taluk.Name;
                    TalukDTO.DistrictID = Taluk.DistrictID;
                    lstTalukDTO.Add(TalukDTO);
                }
            return lstTalukDTO;
        }
    }
}
