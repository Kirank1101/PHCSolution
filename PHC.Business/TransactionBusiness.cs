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
                    DrugStockDTO.BatchNo= DrugStock.BatchNo; 
                    DrugStockDTO.MfDate = DrugStock.ManufactureDate;
                    DrugStockDTO.ExpDate = DrugStock.ExpiryDate;
                    DrugStockDTO.PurchaseDate= DrugStock.PurchaseDate;
                    
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
            DrugStockDetail.Quantity= Quantity;
            DrugStockDetail.BatchNo= BatchNo;
            DrugStockDetail.ManufactureDate= MfDate.ConvertToDate();
            DrugStockDetail.ExpiryDate = ExpDate.ConvertToDate();
            DrugStockDetail.PurchaseDate= PurchaseDate.ConvertToDate();
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


        public ResultDTO SavePatientDetails(string PatientName, string ECNumber, short Age, string DOB, string Gender, string BloodGroup, string Village, string ContactNo, string PhoneNo)
        {
            throw new NotImplementedException();
        }

        public ResultDTO UpdatePatientDetail(string PatientID, string PatientName, string ECNumber, short Age, string DOB, string Gender, string BloodGroup, string Village, string ContactNo, string PhoneNo)
        {
            PatientDetail PatientDetail = new PatientDetail();
            PatientDetail.PatientID = PatientID;
            PatientDetail.Name = PatientName;
            PatientDetail.age = Age;
            PatientDetail.DOB = DOB.ConvertToDate();
            PatientDetail.Sex = Gender;
            PatientDetail.BloodGroup = BloodGroup;
            PatientDetail.LastModifiedBy = "System";
            PatientAddress PatientAddress = new DataAccess.PatientAddress();
            PatientAddress.PatientID = PatientID;

            //PatientDetail.DrugStockID = DrugStockID;
            //PatientDetail.PHCID = PHCID;
            //PatientDetail.DrugID = DrugID;
            //PatientDetail.Quantity = Quantity;
            //PatientDetail.BatchNo = BatchNo;
            //PatientDetail.ManufactureDate = MfDate.ConvertToDate();
            //PatientDetail.ExpiryDate = ExpDate.ConvertToDate();
            //PatientDetail.PurchaseDate = PurchaseDate.ConvertToDate();
            //PatientDetail.LastModifiedBy = "System";
            //if (objDA.UpdateDrugStock(PatientDetail))
                return new ResultDTO() { IsSuccess = true, Message = "Successfully Updated." };
            //else
            //    return new ResultDTO() { IsSuccess = false, Message = "Unsuccessfully Updated." };
        }

        public ResultDTO DeletePatientDetail(string PatientID)
        {
            throw new NotImplementedException();
        }

        public List<PatientDetailDTO> GetPatientDetail(string PHCID)
        {
            throw new NotImplementedException();
        }

        public List<MVillageDTO> GetMVillages(string PHCID)
        {
            throw new NotImplementedException();
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
    }
}
