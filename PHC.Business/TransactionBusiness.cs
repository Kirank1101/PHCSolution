﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PHC.BAInterfaces.Business;
using PHC.DAInterfaces.DataAccess;
using PHC.DataAccess;
using PHC.BAInterfaces.DataTransfer;
using AllInOne.Common.Library.Util;
using System.Globalization;
namespace PHC.Business
{
    public class TransactionBusiness : ITransactionBusiness
    {
        const string StateIDConstant = "KARNATAKA";
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
        public ResultDTO SaveMdisease(string DiseaseName)
        {
            MDisease Disease = new MDisease();
            Disease.DiseaseID = CommonUtil.CreateUniqueID("MD");
            Disease.Name = DiseaseName;
            Disease.StateID = "Karnataka";
            Disease.LastModifiedBy = "System";
            Disease.LastModifiedDate = DateTime.Now;
            Disease.ObsInd = "N";
            MDisease checkdisease = objDA.GetMDiseases(DiseaseName);
            if (checkdisease == null)
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
            Drug.DrugID = CommonUtil.CreateUniqueID("MD");
            Drug.StateID = StateIDConstant;
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
            LabTest.LabTestID = CommonUtil.CreateUniqueID("LT");
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
            MTaluk.TalukID = CommonUtil.CreateUniqueID("TN");
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
                    MTaluk mtaluk = objDA.GetMTalukOnID(PHCDTO.TalukID);
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
            if (objDA.DeleteMPHC(PHCID))
                return new ResultDTO() { IsSuccess = true, Message = "Successfully Deleted." };
            else
                return new ResultDTO() { IsSuccess = false, Message = "Unsuccessfully Deleted." };
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
        public ResultDTO UpdateMPHC(string PHCID, string PHCName)
        {
            MPHC PHC = new MPHC();
            PHC.PHCID = PHCID;
            PHC.Name = PHCName;
            PHC.LastModifiedBy = "System";
            PHC.LastModifiedDate = DateTime.Now;
            PHC.ObsInd = "N";
            if (objDA.UpdateMPHC(PHC))
                return new ResultDTO() { IsSuccess = true, Message = "Successfully Updated." };
            else
                return new ResultDTO() { IsSuccess = false, Message = "Unsuccessfully Updated." };
        }
        public List<DrugStockDTO> GetDrugPurchaseDetail(string PHCID)
        {
            List<DrugStockDetail> lstDrugStockDetail = objDA.GetDrugPurchaseDetail(PHCID);
            List<DrugStockDTO> lstDrugStockDTO = new List<DrugStockDTO>();
            if (lstDrugStockDetail != null)
                foreach (DrugStockDetail DrugStock in lstDrugStockDetail)
                {
                    DrugStockDTO DrugStockDTO = new DrugStockDTO();
                    DrugStockDTO.DrugStockID = DrugStock.DrugStockID;
                    DrugStockDTO.PHCID = DrugStock.PHCID;
                    DrugStockDTO.DrugID = DrugStock.DrugID;
                    string DrugName = objDA.GetDrugName(DrugStockDTO.DrugID);
                    DrugStockDTO.DrugName = DrugName;
                    DrugStockDTO.Quantity = DrugStock.Quantity;
                    DrugStockDTO.BatchNo = DrugStock.BatchNo;
                    DrugStockDTO.MfDate = DrugStock.ManufactureDate;
                    DrugStockDTO.ExpDate = DrugStock.ExpiryDate;
                    DrugStockDTO.PurchaseDate = DrugStock.PurchaseDate;

                    lstDrugStockDTO.Add(DrugStockDTO);
                }
            return lstDrugStockDTO;
        }
        public ResultDTO SaveDrugStock(string DrugID, string PHCID, Int16 Quantity, string BatchNo, string MfDate, string ExpDate, string PurchaseDate)
        {
            DrugStockDetail DrugStockDetail = new DrugStockDetail();
            DrugStockDetail.DrugStockID = CommonUtil.CreateUniqueID("D");
            DrugStockDetail.PHCID = PHCID;
            DrugStockDetail.DrugID = DrugID;
            DrugStockDetail.Quantity = Quantity;
            DrugStockDetail.BatchNo = BatchNo;
            DrugStockDetail.ManufactureDate = MfDate.ConvertToDate();
            DrugStockDetail.ExpiryDate = ExpDate.ConvertToDate();
            DrugStockDetail.PurchaseDate = PurchaseDate.ConvertToDate();
            DrugStockDetail.LastModifiedBy = "System";
            DrugStockDetail.LastModifiedDate = DateTime.Now;
            DrugStockDetail.ObsInd = "N";
            if (objDA.AddDrugStock(DrugStockDetail))
                return new ResultDTO() { IsSuccess = true, Message = "Successfully Saved." };
            else
                return new ResultDTO() { IsSuccess = false, Message = "Unsuccessfully Saved." };
        }
        public ResultDTO UpdateDrugStock(string DrugStockID, string DrugID, string PHCID, Int16 Quantity, string BatchNo, string MfDate, string ExpDate, string PurchaseDate)
        {
            DrugStockDetail DrugStockDetail = new DrugStockDetail();
            DrugStockDetail.DrugStockID = DrugStockID;
            DrugStockDetail.PHCID = PHCID;
            DrugStockDetail.DrugID = DrugID;
            DrugStockDetail.Quantity = Quantity;
            DrugStockDetail.BatchNo = BatchNo;
            DrugStockDetail.ManufactureDate = MfDate.ConvertToDate();
            DrugStockDetail.ExpiryDate = ExpDate.ConvertToDate();
            DrugStockDetail.PurchaseDate = PurchaseDate.ConvertToDate();
            DrugStockDetail.LastModifiedBy = "System";
            if (objDA.UpdateDrugStock(DrugStockDetail))
                return new ResultDTO() { IsSuccess = true, Message = "Successfully Updated." };
            else
                return new ResultDTO() { IsSuccess = false, Message = "Unsuccessfully Updated." };
        }
        public ResultDTO DeleteDrugStock(string DrugStockID)
        {
            if (objDA.DeleteDrugStock(DrugStockID))
                return new ResultDTO() { IsSuccess = true, Message = "Successfully Deleted." };
            else
                return new ResultDTO() { IsSuccess = false, Message = "Unsuccessfully Deleted." };
        }
        public ResultDTO SavePatientDetails(string PHCID, string PatientName, string ECNumber, short Age, string DOB, string Gender, string BloodGroup, string VillageID, string Address, string ContactNo, string PhoneNo, string EducationID, string ReligionID, string MarritalStatus, string FatherName, string HusbandName)
        {
            PatientDetail PatientDetail = new PatientDetail();
            PatientDetail.PatientID = CommonUtil.CreateUniqueID("P");
            PatientDetail.PHCID = PHCID;
            PatientDetail.Name = PatientName;
            PatientDetail.age = Age;
            PatientDetail.DOB = DOB.ConvertToDate();
            PatientDetail.Sex = Gender;
            PatientDetail.BloodGroup = BloodGroup;
            PatientDetail.EducationID = EducationID;
            PatientDetail.ReligionID = ReligionID;
            PatientDetail.IsMarried = MarritalStatus;
            PatientDetail.HusbandName = HusbandName;
            PatientDetail.FatherName = FatherName;
            PatientDetail.LastModifiedBy = "System";
            PatientDetail.LastModifiedDate = DateTime.Now;
            PatientDetail.ObsInd = "N";

            PatientAddress PatientAddres = new DataAccess.PatientAddress();
            PatientAddres.PatientAddressID = CommonUtil.CreateUniqueID("PADRS");
            PatientAddres.PatientID = PatientDetail.PatientID;
            PatientAddres.VillageID = VillageID;
            PatientAddres.Address = Address;
            PatientAddres.ContactNo = ContactNo;
            PatientAddres.PhoneNo = PhoneNo;
            PatientAddres.LastModifiedBy = "System";
            PatientAddres.LastModifiedDate = DateTime.Now;
            PatientAddres.ObsInd = "N";
            PatientDetail.PatientAddresses.Add(PatientAddres);
            if (!string.IsNullOrEmpty(ECNumber))
            {
                PatientEC patientec = new PatientEC();
                patientec.PatientECID = CommonUtil.CreateUniqueID("PEC");
                patientec.PatientID = PatientDetail.PatientID;
                patientec.PHCID = PatientDetail.PHCID;
                patientec.ECNumber = ECNumber;
                patientec.LastModifiedBy = "System";
                patientec.LastModifiedDate = DateTime.Now;
                patientec.ObsInd = "N";
                PatientDetail.PatientECs.Add(patientec);
            }

            String checkPatientExist = objDA.CheeckPatientName(PatientName, ECNumber, PatientDetail.PHCID);
            if (string.IsNullOrEmpty(checkPatientExist))
            {
                if (objDA.AddPatientDetails(PatientDetail))
                    return new ResultDTO() { IsSuccess = true, Message = "Successfully Saved." };
                else
                    return new ResultDTO() { IsSuccess = false, Message = "Unsuccessfully Saved." };
            }
            else
                return new ResultDTO() { IsSuccess = false, Message = checkPatientExist };
        }
        public ResultDTO UpdatePatientDetail(string PHCID, string PatientID, string PatientName, string ECNumber, short Age, string DOB, string Gender, string BloodGroup, string VillageID, string Address, string ContactNo, string PhoneNo, string EducationID, string ReligionID, string MarritalStatus, string FatherName, string HusbandName)
        {
            PatientDetail PatientDetail = new PatientDetail();
            PatientDetail.PatientID = PatientID;
            PatientDetail.PHCID = PHCID;
            PatientDetail.Name = PatientName;
            PatientDetail.age = Age;
            PatientDetail.DOB = DOB.ConvertToDate();
            PatientDetail.Sex = Gender;
            PatientDetail.BloodGroup = BloodGroup;
            PatientDetail.LastModifiedBy = "System";
            PatientDetail.EducationID = EducationID;
            PatientDetail.ReligionID = ReligionID;
            PatientDetail.IsMarried = MarritalStatus;
            PatientDetail.HusbandName = HusbandName;
            PatientDetail.FatherName = FatherName;
            PatientAddress PatientAddres = new DataAccess.PatientAddress();
            PatientAddres.PatientID = PatientID;
            PatientAddres.VillageID = VillageID;
            PatientAddres.Address = Address;
            PatientAddres.ContactNo = ContactNo;
            PatientAddres.PhoneNo = PhoneNo;
            PatientAddres.LastModifiedBy = "System";
            PatientDetail.PatientAddresses.Add(PatientAddres);
            PatientEC pec = objDA.GetPatientEC(PatientID);
            if (pec != null && !string.IsNullOrEmpty(ECNumber))
            {
                PatientEC patientec = new PatientEC();
                patientec.PatientID = PatientID;
                patientec.ECNumber = ECNumber;
                patientec.LastModifiedBy = "System";
                PatientDetail.PatientECs.Add(patientec);
            }
            else if (pec == null && !string.IsNullOrEmpty(ECNumber))
            {
                PatientEC patientec = new PatientEC();
                patientec.PatientECID = CommonUtil.CreateUniqueID("PEC");
                patientec.PatientID = PatientDetail.PatientID;
                patientec.PHCID = PatientDetail.PHCID;
                patientec.ECNumber = ECNumber;
                patientec.LastModifiedBy = "System";
                patientec.LastModifiedDate = DateTime.Now;
                patientec.ObsInd = "N";
                PatientDetail.PatientECs.Add(patientec);
            }
            string checkPatientExist = objDA.CheckPatientNameAndECNumberforUpdate(PatientDetail.PatientID, ECNumber, PatientName, PatientDetail.PHCID);
            if (string.IsNullOrEmpty(checkPatientExist))
            {
                if (objDA.UpdatePatientDetail(PatientDetail))
                    return new ResultDTO() { IsSuccess = true, Message = "Successfully Updated." };
                else
                    return new ResultDTO() { IsSuccess = false, Message = "Unsuccessfully Updated." };
            }
            else
            {
                return new ResultDTO() { IsSuccess = false, Message = checkPatientExist };
            }
        }
        public ResultDTO DeletePatientDetail(string PatientID)
        {
            if (objDA.DeleteDrugStock(PatientID))
                return new ResultDTO() { IsSuccess = true, Message = "Successfully Deleted." };
            else
                return new ResultDTO() { IsSuccess = false, Message = "Unsuccessfully Deleted." };
        }
        public List<PatientDetailDTO> GetPatientDetail(string PHCID)
        {

            List<PatientDetail> lstPatientDetail = objDA.GetPatientDetail(PHCID);
            List<PatientDetailDTO> lstPatientDetailDTO = new List<PatientDetailDTO>();
            if (lstPatientDetail != null)
                foreach (PatientDetail PatientDetail in lstPatientDetail)
                {
                    PatientDetailDTO patientDetailDTO = new PatientDetailDTO();
                    patientDetailDTO.PatientID = PatientDetail.PatientID;
                    patientDetailDTO.PHCID = PatientDetail.PHCID;
                    patientDetailDTO.PatientName = PatientDetail.Name;
                    patientDetailDTO.Age = PatientDetail.age;
                    patientDetailDTO.DOB = PatientDetail.DOB;
                    patientDetailDTO.Gender = PatientDetail.Sex;
                    patientDetailDTO.BloodGroup = PatientDetail.BloodGroup;
                    patientDetailDTO.EducationID = PatientDetail.EducationID;
                    patientDetailDTO.EducationName = PatientDetail.MEducation.Name;
                    patientDetailDTO.ReligionID = PatientDetail.ReligionID;
                    patientDetailDTO.ReligionName = PatientDetail.MReligion.ReligionName;
                    patientDetailDTO.IsMarried = PatientDetail.IsMarried;
                    patientDetailDTO.FatherName = PatientDetail.FatherName;
                    patientDetailDTO.HusbandName = PatientDetail.HusbandName;
                    PatientAddress PA = new PatientAddress();
                    PA = PatientDetail.PatientAddresses.FirstOrDefault();
                    patientDetailDTO.Address = PA.Address;
                    patientDetailDTO.RefPhoneNo = PA.PhoneNo;
                    patientDetailDTO.ContactNo = PA.ContactNo;
                    patientDetailDTO.VillageID = PA.VillageID;
                    
                    patientDetailDTO.Place = objDA.GetVillageName(patientDetailDTO.VillageID);

                    if (PatientDetail.PatientECs != null && PatientDetail.PatientECs.Count > 0)
                    {
                        PatientEC PEC = new PatientEC();
                        PEC = PatientDetail.PatientECs.FirstOrDefault();
                        patientDetailDTO.ECNumber = PEC.ECNumber;
                    }
                    lstPatientDetailDTO.Add(patientDetailDTO);
                }
            return lstPatientDetailDTO;
        }
        public List<MVillageDTO> GetMVillages(string PHCID)
        {
            List<MVillage> lstMVillage = objDA.getMVillage(PHCID);
            List<MVillageDTO> lstMVillageDTO = new List<MVillageDTO>();
            if (lstMVillage != null)
                foreach (MVillage Village in lstMVillage)
                {
                    MVillageDTO MVillageDTO = new MVillageDTO();
                    MVillageDTO.VillageID = Village.VillageID;
                    MVillageDTO.VillageName = Village.Name;
                    lstMVillageDTO.Add(MVillageDTO);
                }
            return lstMVillageDTO;
        }
        public List<BloodGroupDTO> GetBloodGroup()
        {
            List<BloodGroupDTO> lstBloodGroup = new List<BloodGroupDTO>();
            BloodGroupDTO bg = new BloodGroupDTO();
            bg.BloodGroupID = "A+";
            bg.BloodGroupName = "A+";
            lstBloodGroup.Add(bg);
            BloodGroupDTO bg1 = new BloodGroupDTO();
            bg1.BloodGroupID = "A-";
            bg1.BloodGroupName = "A-";
            lstBloodGroup.Add(bg1);
            BloodGroupDTO bg2 = new BloodGroupDTO();
            bg2.BloodGroupID = "B+";
            bg2.BloodGroupName = "B+";
            lstBloodGroup.Add(bg2);
            BloodGroupDTO bg3 = new BloodGroupDTO();
            bg3.BloodGroupID = "B-";
            bg3.BloodGroupName = "B-";
            lstBloodGroup.Add(bg3);
            BloodGroupDTO bg4 = new BloodGroupDTO();
            bg4.BloodGroupID = "AB+";
            bg4.BloodGroupName = "AB+";
            lstBloodGroup.Add(bg4);
            BloodGroupDTO bg5 = new BloodGroupDTO();
            bg5.BloodGroupID = "AB-";
            bg5.BloodGroupName = "AB+";
            lstBloodGroup.Add(bg5);
            BloodGroupDTO bg6 = new BloodGroupDTO();
            bg6.BloodGroupID = "O+";
            bg6.BloodGroupName = "O+";
            lstBloodGroup.Add(bg6);
            BloodGroupDTO bg7 = new BloodGroupDTO();
            bg7.BloodGroupID = "O-";
            bg7.BloodGroupName = "O-";
            lstBloodGroup.Add(bg7);
            return lstBloodGroup;
        }
        public ResultDTO AddUser(string PHCID, string stateId, string districtId, string talukId, string villageId, string password, string userId, string emailId, string userName)
        {
            User userObj = new User();
            userObj.UserID = CommonUtil.CreateUniqueID("U");
            userObj.Password = password;
            userObj.LoginID = PHCID;
            userObj.LastModifiedDate = DateTime.Now;
            userObj.LastModifiedBy = "System";
            userObj.ObsInd = "N";
            UserMap userMapObj = new DataAccess.UserMap();
            userMapObj.UserMapID = CommonUtil.CreateUniqueID("UM");
            userMapObj.UserID = userObj.UserID;
            userMapObj.PHCID = PHCID;
            userMapObj.StateID = StateIDConstant;
            userMapObj.DistrictID = districtId;
            userMapObj.TalukID = talukId;
            userMapObj.VillageID = villageId;
            userMapObj.DisplayName = userName;
            userMapObj.LastModifiedBy = "System";
            userMapObj.LastModifiedDate = DateTime.Now;
            userMapObj.ObsInd = "N";

            MPHC objMPHC = new MPHC();
            objMPHC.PHCID = PHCID;
            objMPHC.TalukID = talukId ;
            objMPHC.Name = PHCID;
            objMPHC.LastModifiedBy = "System";
            objMPHC.LastModifiedDate = DateTime.Now;
            objMPHC.ObsInd = "N";

           // userObj.UserMaps.Add(userMapObj);
            if (objDA.AddUser(userObj, userMapObj, objMPHC))
                return new ResultDTO() { IsSuccess = true, Message = "Successfully Saved." };
            else
                return new ResultDTO() { IsSuccess = false, Message = "Unsuccessfully Saved." };
        }
        public List<MVillageDTO> GetMVillage(string PHCID)
        {
            List<MVillage> lstMVillage = objDA.GetMVillage(PHCID);
            List<MVillageDTO> lstMVillageDTO = new List<MVillageDTO>();
            if (lstMVillage != null)
                foreach (MVillage MVillage in lstMVillage)
                {
                    MVillageDTO MVillageDTO = new MVillageDTO();
                    MVillageDTO.VillageID = MVillage.VillageID;
                    MVillageDTO.VillageName = MVillage.Name;
                    MVillageDTO.PHCID = MVillage.PHCID;
                    lstMVillageDTO.Add(MVillageDTO);
                }
            return lstMVillageDTO;
        }
        public ResultDTO DeleteMVillage(string VillageID, string PHCID)
        {
            if (objDA.DeleteVillage(VillageID, PHCID))
                return new ResultDTO() { IsSuccess = true, Message = "Successfully Deleted." };
            else
                return new ResultDTO() { IsSuccess = false, Message = "Unsuccessfully Deleted." };
        }
        public ResultDTO SaveMVillage(string VillageName, string PHCID)
        {

            MVillage MVillage = new MVillage();
            MVillage.VillageID = CommonUtil.CreateUniqueID("V");
            MVillage.PHCID = PHCID;
            MVillage.Name = VillageName;
            MVillage.LastModifiedBy = "System";
            MVillage.LastModifiedDate = DateTime.Now;
            MVillage.ObsInd = "N";
            MVillage checkVillage = objDA.CheckVillage(PHCID, VillageName);
            if (checkVillage == null)
            {
                if (objDA.AddMVillage(MVillage))
                    return new ResultDTO() { IsSuccess = true, Message = "Successfully Saved." };
                else
                    return new ResultDTO() { IsSuccess = false, Message = "Unsuccessfully Saved." };
            }
            else
                return new ResultDTO() { IsSuccess = false, Message = "Village already exist." };
        }
        public ResultDTO UpdateMVillage(string VillageID, string PHCID, string VillageName)
        {
            MVillage MVillage = new MVillage();
            MVillage.VillageID = VillageID;
            MVillage.PHCID = PHCID;
            MVillage.Name = VillageName;
            string checkVillageExist = objDA.CheckVillageforUpdate(VillageID, PHCID, VillageName);
            if (string.IsNullOrEmpty(checkVillageExist))
            {
                if (objDA.UpdateVillageDetail(MVillage))
                    return new ResultDTO() { IsSuccess = true, Message = "Successfully Updated." };
                else
                    return new ResultDTO() { IsSuccess = false, Message = "Unsuccessfully Updated." };
            }
            else
            {
                return new ResultDTO() { IsSuccess = false, Message = checkVillageExist };
            }
        }

        public ResultDTO SaveMScheme(string SchemeName)
        {
            MScheme MScheme = new MScheme();
            MScheme.SchemeID = CommonUtil.CreateUniqueID("SCHM");
            MScheme.StateID = "Karnataka";
            MScheme.Name = SchemeName;
            MScheme.LastModifiedBy = "System";
            MScheme.LastModifiedDate = DateTime.Now;
            MScheme.ObsInd = "N";
            MScheme checkSchemeName = objDA.checkSchemeName(SchemeName);
            if (checkSchemeName == null)
            {
                if (objDA.AddMScheme(MScheme))
                    return new ResultDTO() { IsSuccess = true, Message = "Successfully Saved." };
                else
                    return new ResultDTO() { IsSuccess = false, Message = "Unsuccessfully Saved." };
            }
            else
                return new ResultDTO() { IsSuccess = false, Message = "Scheme already exist." };
        }
        public List<MSchemeDTO> GetMScheme()
        {
            List<MScheme> lstScheme = objDA.GetMSchemes();
            List<MSchemeDTO> lstSchemeDTO = new List<MSchemeDTO>();
            if (lstScheme != null)
                foreach (MScheme Scheme in lstScheme)
                {
                    MSchemeDTO SchemeDTO = new MSchemeDTO();
                    SchemeDTO.SchemeID = Scheme.SchemeID;
                    SchemeDTO.SchemeName = Scheme.Name;
                    SchemeDTO.StateID = StateIDConstant;
                    lstSchemeDTO.Add(SchemeDTO);
                }
            return lstSchemeDTO;
        }
        public ResultDTO DeleteMScheme(string SchemeID)
        {
            if (objDA.DeleteMScheme(SchemeID))
                return new ResultDTO() { IsSuccess = true, Message = "Successfully Deleted." };
            else
                return new ResultDTO() { IsSuccess = false, Message = "Unsuccessfully Deleted." };
        }
        public ResultDTO UpdateMScheme(string SchemeID, string SchemeName)
        {
            MScheme MScheme = new MScheme();
            MScheme.SchemeID = SchemeID;
            MScheme.Name = SchemeName;
            string checkSchemeExist = objDA.CheckSchemforUpdate(SchemeID, SchemeName);
            if (string.IsNullOrEmpty(checkSchemeExist))
            {
                if (objDA.UpdateSchemeDetail(MScheme))
                    return new ResultDTO() { IsSuccess = true, Message = "Successfully Updated." };
                else
                    return new ResultDTO() { IsSuccess = false, Message = "Unsuccessfully Updated." };
            }
            else
            {
                return new ResultDTO() { IsSuccess = false, Message = checkSchemeExist };
            }
        }

        public ResultDTO SaveMReligion(string ReligionName)
        {
            MReligion MReligion = new MReligion();
            MReligion.ReligionID = CommonUtil.CreateUniqueID("Relg");
            MReligion.StateID = "Karnataka";
            MReligion.ReligionName = ReligionName;
            MReligion.LastModifiedBy = "System";
            MReligion.LastModifiedDate = DateTime.Now;
            MReligion.ObsInd = "N";
            MReligion checkReligionName = objDA.checkReligionName(ReligionName);
            if (checkReligionName == null)
            {
                if (objDA.AddMReligion(MReligion))
                    return new ResultDTO() { IsSuccess = true, Message = "Successfully Saved." };
                else
                    return new ResultDTO() { IsSuccess = false, Message = "Unsuccessfully Saved." };
            }
            else
                return new ResultDTO() { IsSuccess = false, Message = "Religion already exist." };
        }
        public List<MReligionDTO> GetMReligion()
        {
            List<MReligion> lstReligion = objDA.GetMReligions();
            List<MReligionDTO> lstReligionDTO = new List<MReligionDTO>();
            if (lstReligion != null)
                foreach (MReligion Religion in lstReligion)
                {
                    MReligionDTO ReligionDTO = new MReligionDTO();
                    ReligionDTO.ReligionID = Religion.ReligionID;
                    ReligionDTO.ReligionName = Religion.ReligionName;
                    ReligionDTO.StateID = StateIDConstant;
                    lstReligionDTO.Add(ReligionDTO);
                }
            return lstReligionDTO;
        }
        public ResultDTO UpdateMReligion(string ReligionID, string ReligionName)
        {
            MReligion MReligion = new MReligion();
            MReligion.ReligionID = ReligionID;
            MReligion.ReligionName = ReligionName;
            string checkReligionExist = objDA.CheckReligionforUpdate(ReligionID, ReligionName);
            if (string.IsNullOrEmpty(checkReligionExist))
            {
                if (objDA.UpdateReligionDetail(MReligion))
                    return new ResultDTO() { IsSuccess = true, Message = "Successfully Updated." };
                else
                    return new ResultDTO() { IsSuccess = false, Message = "Unsuccessfully Updated." };
            }
            else
            {
                return new ResultDTO() { IsSuccess = false, Message = checkReligionExist };
            }
        }
        public ResultDTO DeleteMReligion(string ReligionID)
        {
            if (objDA.DeleteReligion(ReligionID))
                return new ResultDTO() { IsSuccess = true, Message = "Successfully Deleted." };
            else
                return new ResultDTO() { IsSuccess = false, Message = "Unsuccessfully Deleted." };
        }

        public ResultDTO SaveMEducation(string EducationName)
        {
            MEducation MEducation = new MEducation();
            MEducation.EducationID = CommonUtil.CreateUniqueID("EDUC");
            MEducation.StateID = "Karnataka";
            MEducation.Name = EducationName;
            MEducation.LastModifiedBy = "System";
            MEducation.LastModifiedDate = DateTime.Now;
            MEducation.ObsInd = "N";
            MEducation checkEducationName = objDA.checkEducationName(EducationName);
            if (checkEducationName == null)
            {
                if (objDA.AddMEducation(MEducation))
                    return new ResultDTO() { IsSuccess = true, Message = "Successfully Saved." };
                else
                    return new ResultDTO() { IsSuccess = false, Message = "Unsuccessfully Saved." };
            }
            else
                return new ResultDTO() { IsSuccess = false, Message = "Education Name already exist." };
        }
        public List<MEducationDTO> GetMEducation()
        {
            List<MEducation> lstEducation = objDA.GetMEducations();
            List<MEducationDTO> lstEducationDTO = new List<MEducationDTO>();
            if (lstEducation != null)
                foreach (MEducation Education in lstEducation)
                {
                    MEducationDTO EducationDTO = new MEducationDTO();
                    EducationDTO.EducationID = Education.EducationID;
                    EducationDTO.EducationName = Education.Name;
                    EducationDTO.StateID = StateIDConstant;
                    lstEducationDTO.Add(EducationDTO);
                }
            return lstEducationDTO;
        }
        public ResultDTO UpdateMEducation(string EducationID, string EducationName)
        {
            MEducation MEducation = new MEducation();
            MEducation.EducationID = EducationID;
            MEducation.Name = EducationName;
            string checkEducationExist = objDA.CheckEducationforUpdate(EducationID, EducationName);
            if (string.IsNullOrEmpty(checkEducationExist))
            {
                if (objDA.UpdateEducationDetail(MEducation))
                    return new ResultDTO() { IsSuccess = true, Message = "Successfully Updated." };
                else
                    return new ResultDTO() { IsSuccess = false, Message = "Unsuccessfully Updated." };
            }
            else
            {
                return new ResultDTO() { IsSuccess = false, Message = checkEducationExist };
            }
        }
        public ResultDTO DeleteMEducation(string EducationID)
        {
            if (objDA.DeleteEducation(EducationID))
                return new ResultDTO() { IsSuccess = true, Message = "Successfully Deleted." };
            else
                return new ResultDTO() { IsSuccess = false, Message = "Unsuccessfully Deleted." };
        }

        public ResultDTO SaveSubCenter(string PHCID, string SubCenterName)
        {
            SubCenter SubCenter = new SubCenter();
            SubCenter.SubCenterID = CommonUtil.CreateUniqueID("SUBC");
            SubCenter.PHCID = PHCID;
            SubCenter.Name = SubCenterName;
            SubCenter.LastModifiedBy = "System";
            SubCenter.LastModifiedDate = DateTime.Now;
            SubCenter.ObsInd = "N";
            SubCenter checkSubCenterName = objDA.checkSubCenterName(PHCID, SubCenterName);
            if (checkSubCenterName == null)
            {
                if (objDA.AddSubCenter(SubCenter))
                    return new ResultDTO() { IsSuccess = true, Message = "Successfully Saved." };
                else
                    return new ResultDTO() { IsSuccess = false, Message = "Unsuccessfully Saved." };
            }
            else
                return new ResultDTO() { IsSuccess = false, Message = "SubCenter already exist." };
        }
        public List<SubCenterDTO> GetSubCenter(string PHCID)
        {
            List<SubCenter> lstSubCenter = objDA.GetSubCenter(PHCID);
            List<SubCenterDTO> lstSubCenterDTO = new List<SubCenterDTO>();
            if (lstSubCenter != null)
                foreach (SubCenter SubCenter in lstSubCenter)
                {
                    SubCenterDTO SubCenterDTO = new SubCenterDTO();
                    SubCenterDTO.SubCenterID = SubCenter.SubCenterID;
                    SubCenterDTO.SubCenterName = SubCenter.Name;
                    SubCenterDTO.PHCID = SubCenter.PHCID;
                    lstSubCenterDTO.Add(SubCenterDTO);
                }
            return lstSubCenterDTO;
        }
        public ResultDTO UpdateSubCenter(string PHCID, string SubCenterID, string SubCenterName)
        {
            SubCenter SubCenter = new SubCenter();
            SubCenter.SubCenterID = SubCenterID;
            SubCenter.Name = SubCenterName;
            SubCenter.PHCID = PHCID;
            string checkSubCenterExist = objDA.CheckSubCenterforUpdate(SubCenterID, PHCID, SubCenterName);
            if (string.IsNullOrEmpty(checkSubCenterExist))
            {
                if (objDA.UpdateSubCenterDetail(SubCenter))
                    return new ResultDTO() { IsSuccess = true, Message = "Successfully Updated." };
                else
                    return new ResultDTO() { IsSuccess = false, Message = "Unsuccessfully Updated." };
            }
            else
            {
                return new ResultDTO() { IsSuccess = false, Message = checkSubCenterExist };
            }
        }
        public ResultDTO DeleteSubCenter(string PHCID, string SubCenterID)
        {
            if (objDA.DeleteSubCenter(SubCenterID, PHCID))
                return new ResultDTO() { IsSuccess = true, Message = "Successfully Deleted." };
            else
                return new ResultDTO() { IsSuccess = false, Message = "Unsuccessfully Deleted." };
        }
        public PatientDetailDTO GeTPatientInfo(string PatientName, string PHCID)
        {
            PatientDetail PD = objDA.GeTPatientInfo(PatientName, PHCID);
            PatientDetailDTO patientDetailDTO = null;
            if (PD != null)
            {
                patientDetailDTO = new PatientDetailDTO();
                patientDetailDTO.PatientID = PD.PatientID;
                patientDetailDTO.PatientName = PD.Name;
                patientDetailDTO.Age = PD.age;
                patientDetailDTO.PHCID = PD.PHCID;
                patientDetailDTO.ECNumber = (PD.PatientECs.Count > 0) ? PD.PatientECs.FirstOrDefault().ECNumber : string.Empty;
                patientDetailDTO.Place = (PD.PatientAddresses.Count > 0) ? PD.PatientAddresses.FirstOrDefault().MVillage.Name : string.Empty;
                patientDetailDTO.BloodGroup = PD.BloodGroup;
            }
            return patientDetailDTO;
        }
        public ResultDTO SavePatientPrescription(string PatientID, string PHCID, string DiseaseID, string Description, List<TempDrugsDTO> lTD, List<TempLabTestDTO> lLT)
        {
            PatientPrescription PP = new PatientPrescription();
            PP.PrescriptionID = CommonUtil.CreateUniqueID("PP");
            PP.PatientID = PatientID;
            PP.PHCID = PHCID;
            PP.DiseaseID = DiseaseID;
            PP.Description = Description;
            PP.LastModifiedBy = "System";
            PP.LastModifiedDate = DateTime.Now;
            PP.ObsInd = "N";

            foreach (TempDrugsDTO item in lTD)
            {
                DrugsIssued DI = new DrugsIssued();
                DI.DrugsID = CommonUtil.CreateUniqueID("DI");
                DI.PHCID = PHCID;
                DI.PrescriptionID = PP.PrescriptionID;
                DI.DrugID = item.DrugID;
                DI.Quantity = item.Quantity;
                DI.Dosage = item.Dosage;
                DI.LastModifiedBy = "System";
                DI.LastModifiedDate = DateTime.Now;
                DI.ObsInd = "N";
                PP.DrugsIssueds.Add(DI);
            }
            if (lLT != null && lLT.Count > 0)
                foreach (TempLabTestDTO item in lLT)
                {
                    LabTestDetail LT = new LabTestDetail();
                    LT.LabTestDetailID = CommonUtil.CreateUniqueID("LT");
                    LT.LabTestID = item.LabTestID;
                    LT.PatientPrescriptionID = PP.PrescriptionID;
                    LT.PHCID = PHCID;
                    LT.LastModifiedBy = "System";
                    LT.LastModifiedDate = DateTime.Now;
                    LT.ObsInd = "N";
                    PP.LabTestDetails.Add(LT);
                }

            if (objDA.AddPatientPrescription(PP))
                return new ResultDTO() { IsSuccess = true, Message = "Successfully Saved." };
            else
                return new ResultDTO() { IsSuccess = false, Message = "Unsuccessfully Saved." };
        }
        public List<PatientVistiHistoryDTO> GetPatientVistHistory(string PatientID, string PHCID)
        {
            List<PatientPrescription> lstPatientPrescription = objDA.GetPatientVistHistory(PatientID, PHCID);
            List<PatientVistiHistoryDTO> lstPVHDTO = new List<PatientVistiHistoryDTO>();
            if (lstPatientPrescription != null)
                foreach (PatientPrescription PD in lstPatientPrescription)
                {
                    PatientVistiHistoryDTO PVHDTO = new PatientVistiHistoryDTO();
                    PVHDTO.PatientID = PD.PatientID;
                    PVHDTO.PatientName = PD.PatientDetail.Name;
                    PVHDTO.PHCID = PD.PHCID;
                    PVHDTO.DiseaseName = PD.MDisease.Name;
                    PVHDTO.Description = PD.Description;
                    PVHDTO.DrugName = GetDrugName(PD);
                    PVHDTO.LabTestName = GetLabTestName(PD);
                    lstPVHDTO.Add(PVHDTO);
                }
            return lstPVHDTO;
        }
        private string GetLabTestName(PatientPrescription PD)
        {
            PatientPrescription PP = PD;
            List<LabTestDetail> lstLT = new List<LabTestDetail>();
            string LabTestname = string.Empty;

            if (PP.DrugsIssueds.Count > 0)
                lstLT = PP.LabTestDetails.ToList();
            foreach (LabTestDetail LTD in lstLT)
                LabTestname += LTD.MLabTest.Name + ", " + Convert.ToString(LTD.Result) + ", " + LTD.Remarks + "\n";
            return LabTestname;
        }
        private string GetDrugName(PatientPrescription PD)
        {
            PatientPrescription PP = PD;
            List<DrugsIssued> lstDI = new List<DrugsIssued>();
            string DrugsIssued = string.Empty;

            if (PP.DrugsIssueds.Count > 0)
                lstDI = PP.DrugsIssueds.ToList();
            foreach (DrugsIssued DI in lstDI)
                DrugsIssued += DI.MDrug.Name + ", " + Convert.ToString(DI.Quantity) + ", " + DI.Dosage + "\n";
            return DrugsIssued;
        }
        public bool CheckPHCOpeningBalanceExist(string PHCID)
        {

            PHCTransaction checkPHCOpeningBalance = objDA.checkPHCOpeningBalance(PHCID, "Opening Balance");
            if (checkPHCOpeningBalance == null)
                return false;
            else
                return true;
        }
        public ResultDTO SavePHCOpeningBalance(string PHCID, decimal Amount)
        {
            PHCTransaction PHCT = new PHCTransaction();
            PHCT.PHCTransactionID = CommonUtil.CreateUniqueID("PHCT");
            PHCT.PHCID = PHCID;
            PHCT.Description = "Opening Balance";
            PHCT.TransactionType = "C";
            PHCT.ReceivedAmount = Amount;
            PHCT.LastModifiedBy = "System";
            PHCT.LastModifiedDate = DateTime.Now;

            PHCT.ObsInd = "N";
            PHCTransaction checkPHCOpeningBalance = objDA.checkPHCOpeningBalance(PHCID, PHCT.Description);
            if (checkPHCOpeningBalance == null)
            {
                if (objDA.AddPHCTransaction(PHCT))
                    return new ResultDTO() { IsSuccess = true, Message = "Successfully Saved." };
                else
                    return new ResultDTO() { IsSuccess = false, Message = "Unsuccessfully Saved." };
            }
            else
                return new ResultDTO() { IsSuccess = false, Message = "Opening Balance already alloted." };
        }


        public List<PHCTransactionDTO> GetPHCTransactionDetails(string PHCID)
        {
            List<PHCTransaction> lstPHCTransaction = objDA.GetPHCTransaction(PHCID);
            List<PHCTransactionDTO> lstPHCTransactionDTO = new List<PHCTransactionDTO>();
            if (lstPHCTransaction != null && lstPHCTransaction.Count > 0)
            {
                int i = 0;
                foreach (PHCTransaction PT in lstPHCTransaction)
                {
                    i += 1;
                    PHCTransactionDTO PHCTransactionDTO = new PHCTransactionDTO();
                    PHCTransactionDTO.PHCTransactionID = PT.PHCTransactionID;
                    PHCTransactionDTO.SlNo = i;
                    PHCTransactionDTO.PHCID = PT.PHCID;
                    PHCTransactionDTO.TransactionDate = PT.LastModifiedDate.ToString("dd-MMM-yyyy hh:mm:ss tt");
                    if (PT.TransactionType == "C")
                    {
                        if (!string.IsNullOrEmpty(PT.ReceivedFrom) && !string.IsNullOrEmpty(PT.ChequeNo))
                            PHCTransactionDTO.TransactionDetails = PT.ReceivedFrom + ", " + PT.ChequeNo + ".";
                        else
                            PHCTransactionDTO.TransactionDetails = PT.Description;
                        PHCTransactionDTO.CreditedAmount = Convert.ToDouble(PT.ReceivedAmount);
                    }
                    else
                    {

                        PHCTransactionDTO.TransactionDetails = PT.HandOver + ", " + PT.ChequeNo + ".";
                        PHCTransactionDTO.DebitedAmount = Convert.ToDouble(PT.SpentAmount);
                    }
                    lstPHCTransactionDTO.Add(PHCTransactionDTO);
                }
            }
            return lstPHCTransactionDTO;
        }
        public ResultDTO SavePHCTransaction(string PHCID, string TransactionType, string ReceiverorGiverName, string ChequeuNo, decimal Amount, string Description)
        {
            PHCTransaction PHCT = new PHCTransaction();
            PHCT.PHCTransactionID = CommonUtil.CreateUniqueID("PHCT");
            PHCT.PHCID = PHCID;
            PHCT.Description = Description;
            PHCT.ChequeNo = ChequeuNo;
            PHCT.TransactionType = TransactionType == "Credit" ? "C" : "D";
            if (TransactionType == "Credit")
            {
                PHCT.ReceivedFrom = ReceiverorGiverName;
                PHCT.TransactionType = "C";
                PHCT.ReceivedAmount = Amount;
            }
            else
            {
                PHCT.HandOver = ReceiverorGiverName;
                PHCT.TransactionType = "D";
                PHCT.SpentAmount = Amount;
            }
            PHCT.LastModifiedBy = "System";
            PHCT.LastModifiedDate = DateTime.Now;
            PHCT.ObsInd = "N";

            //PHCTransaction checkPHCOpeningBalance = objDA.checkPHCOpeningBalance(PHCID, PHCT.Description);
            //if (checkPHCOpeningBalance == null)
            //{
            if (objDA.AddPHCTransaction(PHCT))
                return new ResultDTO() { IsSuccess = true, Message = "Successfully Saved." };
            else
                return new ResultDTO() { IsSuccess = false, Message = "Unsuccessfully Saved." };
            //}
            //else
            //    return new ResultDTO() { IsSuccess = false, Message = "Opening Balance already alloted." };
        }
        public ResultDTO UpdateTransaction(string TransactionID, string PHCID)
        {
            try
            {
                PHCTransaction PHCTransaction = new PHCTransaction();
                PHCTransaction.PHCTransactionID = TransactionID;
                PHCTransaction.PHCID = PHCID;
                PHCTransaction.ISDebited = "Y";
                if (objDA.UpdatePHCTransaction(PHCTransaction))
                    return new ResultDTO() { IsSuccess = true, Message = "Successfully Updated." };
                else
                    return new ResultDTO() { IsSuccess = false, Message = "Unsuccessfully Updated." };
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<PHCTransactionDTO> GetPendingTransactionDetails(string PHCID)
        {
            List<PHCTransaction> lstPHCTransaction = objDA.GetPendingTransaction(PHCID);
            List<PHCTransactionDTO> lstPHCTransactionDTO = new List<PHCTransactionDTO>();
            
            if (lstPHCTransaction != null && lstPHCTransaction.Count > 0)
            {
                int i = 0;
                foreach (PHCTransaction PT in lstPHCTransaction)
                {
                    i += 1;
                    PHCTransactionDTO PHCTransactionDTO = new PHCTransactionDTO();
                    PHCTransactionDTO.PHCTransactionID = PT.PHCTransactionID;
                    PHCTransactionDTO.SlNo = i;
                    PHCTransactionDTO.PHCID = PT.PHCID;
                    PHCTransactionDTO.Name = PT.PatientDetail != null ? PT.PatientDetail.Name : PT.HandOver;
                    PHCTransactionDTO.TransactionDate = PT.LastModifiedDate.ToString("dd-MMM-yyyy hh:mm:ss tt");
                    if (PT.TransactionType == "D")
                    {
                        PHCTransactionDTO.TransactionDetails = PT.ChequeNo;
                        PHCTransactionDTO.DebitedAmount = Convert.ToDouble(PT.SpentAmount);
                    }
                    lstPHCTransactionDTO.Add(PHCTransactionDTO);
                }
            }
            return lstPHCTransactionDTO;
        }


        public List<PHCTransactionDTO> GetPatientPendingTransaction(string PatientName, string PHCID)
        {
            List<PHCTransaction> lstPHCTransaction = objDA.GetPatientPendingTransaction(PatientName, PHCID);
            List<PHCTransactionDTO> lstPHCTransactionDTO = new List<PHCTransactionDTO>();
            if (lstPHCTransaction != null && lstPHCTransaction.Count > 0)
            {
                int i = 0;
                foreach (PHCTransaction PT in lstPHCTransaction)
                {
                    i += 1;
                    PHCTransactionDTO PHCTransactionDTO = new PHCTransactionDTO();
                    PHCTransactionDTO.PHCTransactionID = PT.PHCTransactionID;
                    PHCTransactionDTO.SlNo = i;
                    PHCTransactionDTO.PHCID = PT.PHCID;
                    PHCTransactionDTO.Name = PT.PatientDetail != null ? PT.PatientDetail.Name : PT.HandOver;
                    PHCTransactionDTO.TransactionDate = PT.LastModifiedDate.ToString("dd-MMM-yyyy hh:mm:ss tt");
                    if (PT.TransactionType == "D")
                    {
                        PHCTransactionDTO.TransactionDetails = PT.ChequeNo;
                        PHCTransactionDTO.DebitedAmount = Convert.ToDouble(PT.SpentAmount);
                    }
                    lstPHCTransactionDTO.Add(PHCTransactionDTO);
                }
            }
            return lstPHCTransactionDTO;
        }


        public string CalculateBalanceAmount(string PHCID)
        {
            try
            {
                decimal amount =objDA.GetBalanceamount(PHCID);
                return ConverDoubleMoneyToStringMoney(Convert.ToString(amount));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public string ConverDoubleMoneyToStringMoney(string Amount)
        {
            string money = string.Empty;
            if (!string.IsNullOrEmpty(Amount))
            {
                decimal parsed = decimal.Parse(Amount, CultureInfo.InvariantCulture);
                CultureInfo hindi = new CultureInfo("hi-IN");
                money = string.Format(hindi, "{0:c}", parsed);
            }
            return money;

        }


        public User FindByIdAsync(string userId)
        {
            return objDA.FindById(userId);
        }


        public ResultDTO AddPHC(string talukId, string PHCID)
        {
            try
            {
                MPHC objMPHC = new MPHC();
                objMPHC.PHCID = PHCID;
                objMPHC.TalukID = PHCID;
                objMPHC.Name = "Y";
                objMPHC.LastModifiedBy = "System";
                objMPHC.LastModifiedDate = DateTime.Now;
                objMPHC.ObsInd = "N";

                if (objDA.AddPHC(objMPHC))
                    return new ResultDTO() { IsSuccess = true, Message = "Successfully Updated." };
                else
                    return new ResultDTO() { IsSuccess = false, Message = "Unsuccessfully Updated." };
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
