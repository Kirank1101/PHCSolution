using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Objects;
using PHC.DataAccess;
using PHC.DAInterfaces;
using PHC.DAInterfaces.DataAccess;

namespace PHC.DataAccessLayer
{
    public class TransactionDA : ITransactionDA
    {
        const string yes = "Y";
        const string No = "N";
        public List<User> GetUsers()
        {
            IUnitOfWork work = null;
            using (work = GetUOW.GetUOWInstance)
            {
                return new GenericRepository<User>(work).GetAll().ToList();

            }

            //ObjectContext
            //var objectContext = ((IObjectContextAdapter)myDbContextObject).ObjectContext;
        }
        public bool AddPatientInfo(PatientDetail obj)
        {
            IUnitOfWork work = null;
            using (work = GetUOW.GetUOWInstance)
            {
                new GenericRepository<PatientDetail>(work).Add(obj);
                work.Save();
            }
            return true;
        }
        public bool SaveUserRegistration(User obj)
        {
            IUnitOfWork work = null;
            using (work = GetUOW.GetUOWInstance)
            {
                new GenericRepository<User>(work).Add(obj);
                work.Save();
            }
            return true;
        }
        public bool SetUsers()
        {
            IUnitOfWork work = null;
            using (work = GetUOW.GetUOWInstance)
            {
                User uer = new User();

                new GenericRepository<User>(work).Add(uer);

                MDrug n = new MDrug();

                new GenericRepository<MDrug>(work).Add(n);

                work.Save();

            }

            return false;

            //ObjectContext
            //var objectContext = ((IObjectContextAdapter)myDbContextObject).ObjectContext;
        }
        User ITransactionDA.GetUsers(string UserId)
        {
            IUnitOfWork work = null;
            using (work = GetUOW.GetUOWInstance)
            {
                return new GenericRepository<User>(work).GetAll().Where(u => u.LoginID == UserId).Single();
            }
        }
        public User GetUsers(string UserName, string Password)
        {
            IUnitOfWork work = null;
            using (work = GetUOW.GetUOWInstance)
            {
                try
                {
                    return new GenericRepository<User>(work).GetAll().Where(p => p.LoginID == UserName && p.Password == Password).Single();
                }
                catch (Exception ex)
                {
                    return null;
                    throw ex;
                }
            }
        }
        public List<MDisease> GetMDiseases()
        {
            IUnitOfWork work = null;
            using (work = GetUOW.GetUOWInstance)
            {
                try
                {
                    return new GenericRepository<MDisease>(work).GetAll().Where(p => p.ObsInd == No).ToList();
                }
                catch (Exception ex)
                {
                    return null;
                    throw ex;
                }
            }
        }
        public MDisease GetMDiseases(string DiseaseName)
        {
            IUnitOfWork work = null;
            using (work = GetUOW.GetUOWInstance)
            {
                try
                {
                    return new GenericRepository<MDisease>(work).FindBy(n => n.Name == DiseaseName && n.ObsInd == No).FirstOrDefault();
                }
                catch (Exception ex)
                {
                    return null;
                    throw ex;
                }
            }
        }
        public bool AddMDisease(MDisease Disease)
        {
            IUnitOfWork work = null;
            using (work = GetUOW.GetUOWInstance)
            {
                new GenericRepository<MDisease>(work).Add(Disease);
                work.Save();
            }
            return true;
        }
        public bool UpdateMDisease(MDisease Disease)
        {

            IUnitOfWork work = null;
            using (work = GetUOW.GetUOWInstance)
            {
                MDisease mDisease = new GenericRepository<MDisease>(work).FindBy(n => n.DiseaseID == Disease.DiseaseID).FirstOrDefault();

                if (mDisease != null)
                {
                    //con.Edit(empobj);
                    mDisease.Name = Disease.Name;
                    mDisease.LastModifiedBy = "System";
                    mDisease.LastModifiedDate = DateTime.Now;
                    work.Save();

                    return true;
                }
                else
                    return false;
            }
        }
        public bool DeleteMDisease(String DiseaseID)
        {
            IUnitOfWork work = null;
            using (work = GetUOW.GetUOWInstance)
            {
                MDisease mDisease = new GenericRepository<MDisease>(work).FindBy(n => n.DiseaseID == DiseaseID).FirstOrDefault();
                if (mDisease != null)
                {
                    new GenericRepository<MDisease>(work).Delete(mDisease);
                }
                work.Save();
            }
            return true;
        }
        public List<MDrug> GetMDrugs()
        {
            IUnitOfWork work = null;
            using (work = GetUOW.GetUOWInstance)
            {
                try
                {
                    return new GenericRepository<MDrug>(work).GetAll().Where(p => p.ObsInd == No).ToList();
                }
                catch (Exception ex)
                {
                    return null;
                    throw ex;
                }
            }
        }
        public MDrug GetMdrug(string DrugName)
        {
            IUnitOfWork work = null;
            using (work = GetUOW.GetUOWInstance)
            {
                try
                {
                    return new GenericRepository<MDrug>(work).FindBy(n => n.Name == DrugName && n.ObsInd == No).FirstOrDefault();
                }
                catch (Exception ex)
                {
                    return null;
                    throw ex;
                }
            }
        }
        public bool AddMDrug(MDrug Drug)
        {
            IUnitOfWork work = null;
            using (work = GetUOW.GetUOWInstance)
            {
                new GenericRepository<MDrug>(work).Add(Drug);
                work.Save();
            }
            return true;
        }
        public bool UpdateMDrug(MDrug Drug)
        {
            IUnitOfWork work = null;
            using (work = GetUOW.GetUOWInstance)
            {
                MDrug mDrug = new GenericRepository<MDrug>(work).FindBy(n => n.DrugID == Drug.DrugID).FirstOrDefault();

                if (mDrug != null)
                {
                    //con.Edit(empobj);
                    mDrug.Name = Drug.Name;
                    mDrug.LastModifiedBy = "System";
                    mDrug.LastModifiedDate = DateTime.Now;
                    work.Save();

                    return true;
                }
                else
                    return false;
            }
        }
        public bool DeleteMDrug(string DrugID)
        {
            IUnitOfWork work = null;
            using (work = GetUOW.GetUOWInstance)
            {
                MDrug mDrug = new GenericRepository<MDrug>(work).FindBy(n => n.DrugID == DrugID).FirstOrDefault();
                if (mDrug != null)
                {
                    new GenericRepository<MDrug>(work).Delete(mDrug);
                    work.Save();
                }

            }
            return true;
        }
        public List<MLabTest> GetMLabTests()
        {
            IUnitOfWork work = null;
            using (work = GetUOW.GetUOWInstance)
            {
                try
                {
                    return new GenericRepository<MLabTest>(work).GetAll().Where(p => p.ObsInd == No).ToList();
                }
                catch (Exception ex)
                {
                    return null;
                    throw ex;
                }
            }
        }
        public MLabTest GetMLabTests(string LabTestName)
        {
            IUnitOfWork work = null;
            using (work = GetUOW.GetUOWInstance)
            {
                try
                {
                    return new GenericRepository<MLabTest>(work).FindBy(d => d.Name == LabTestName && d.ObsInd == No).SingleOrDefault();
                }
                catch (Exception ex)
                {
                    return null;
                    throw ex;
                }
            }
        }
        public bool AddMLabTest(MLabTest LabTest)
        {
            IUnitOfWork work = null;
            using (work = GetUOW.GetUOWInstance)
            {
                new GenericRepository<MLabTest>(work).Add(LabTest);
                work.Save();
            }
            return true;
        }
        public bool UpdateMLabTest(MLabTest LabTest)
        {
            IUnitOfWork work = null;
            using (work = GetUOW.GetUOWInstance)
            {
                MLabTest labtest = new GenericRepository<MLabTest>(work).FindBy(n => n.LabTestID == LabTest.LabTestID).FirstOrDefault();

                if (labtest != null)
                {
                    //con.Edit(empobj);
                    labtest.Name = LabTest.Name;
                    labtest.LastModifiedBy = "System";
                    labtest.LastModifiedDate = DateTime.Now;
                    work.Save();

                    return true;
                }
                else
                    return false;
            }
        }
        public bool DeleteMLabTest(string LabTestID)
        {
            IUnitOfWork work = null;
            using (work = GetUOW.GetUOWInstance)
            {
                MLabTest mLabTest = new GenericRepository<MLabTest>(work).FindBy(n => n.LabTestID == LabTestID).FirstOrDefault();
                if (mLabTest != null)
                {
                    new GenericRepository<MLabTest>(work).Delete(mLabTest);

                    work.Save();
                }
            }
            return true;
        }
        public List<MTaluk> GetMTaluks()
        {
            IUnitOfWork work = null;
            using (work = GetUOW.GetUOWInstance)
            {
                try
                {
                    return new GenericRepository<MTaluk>(work).GetAll().OrderByDescending
                        (p => p.LastModifiedDate).Where(n => n.ObsInd == No)
                        .Take(5).ToList();
                }
                catch (Exception ex)
                {
                    return null;
                    throw ex;
                }
            }
        }
        public string GetDistrictName(string DistrictID)
        {
            IUnitOfWork work = null;
            using (work = GetUOW.GetUOWInstance)
            {
                try
                {
                    MDistrict district = new GenericRepository<MDistrict>(work).FindBy(d => d.DistrictID == DistrictID && d.ObsInd == No).SingleOrDefault();
                    return district.Name;
                }
                catch (Exception ex)
                {
                    return null;
                    throw ex;
                }
            }
        }
        public MTaluk GetMTaluk(string TalukName)
        {
            IUnitOfWork work = null;
            using (work = GetUOW.GetUOWInstance)
            {
                try
                {
                    return new GenericRepository<MTaluk>(work).FindBy(d => d.Name == TalukName && d.ObsInd == No).SingleOrDefault();
                }
                catch (Exception ex)
                {
                    return null;
                    throw ex;
                }
            }
        }
        public bool AddMTaluk(MTaluk MTaluk)
        {
            IUnitOfWork work = null;
            using (work = GetUOW.GetUOWInstance)
            {
                new GenericRepository<MTaluk>(work).Add(MTaluk);
                work.Save();
            }
            return true;
        }
        public bool UpdateMTaluk(MTaluk Taluk)
        {
            IUnitOfWork work = null;
            using (work = GetUOW.GetUOWInstance)
            {
                MTaluk MTaluk = new GenericRepository<MTaluk>(work).FindBy(n => n.TalukID == Taluk.TalukID).FirstOrDefault();

                if (MTaluk != null)
                {
                    //con.Edit(empobj);
                    MTaluk.Name = Taluk.Name;
                    MTaluk.DistrictID = Taluk.DistrictID;
                    MTaluk.LastModifiedBy = "System";
                    MTaluk.LastModifiedDate = DateTime.Now;
                    work.Save();

                    return true;
                }
                else
                    return false;
            }
        }
        public bool DeleteMTaluk(string TalukID)
        {
            IUnitOfWork work = null;
            using (work = GetUOW.GetUOWInstance)
            {
                MTaluk mTaluk = new GenericRepository<MTaluk>(work).FindBy(n => n.TalukID == TalukID).FirstOrDefault();
                if (mTaluk != null)
                {
                    new GenericRepository<MTaluk>(work).Delete(mTaluk);
                    work.Save();
                }
            }
            return true;
        }
        public List<MDistrict> GetMDistrict()
        {
            IUnitOfWork work = null;
            using (work = GetUOW.GetUOWInstance)
            {
                try
                {
                    return new GenericRepository<MDistrict>(work).GetAll().Where(p => p.ObsInd == No).ToList();
                }
                catch (Exception ex)
                {
                    return null;
                    throw ex;
                }
            }
        }
        public List<MTaluk> GetMTaluks(string DistrictID)
        {
            IUnitOfWork work = null;
            using (work = GetUOW.GetUOWInstance)
            {
                try
                {
                    return new GenericRepository<MTaluk>(work).GetAll().Where(n => n.ObsInd == No && n.DistrictID == DistrictID).ToList();
                }
                catch (Exception ex)
                {
                    return null;
                    throw ex;
                }
            }
        }
        public MPHC GetMPHC(string PHCName)
        {
            IUnitOfWork work = null;
            using (work = GetUOW.GetUOWInstance)
            {
                try
                {
                    return new GenericRepository<MPHC>(work).FindBy(d => d.Name == PHCName && d.ObsInd == No).FirstOrDefault();
                }
                catch (Exception ex)
                {
                    return null;
                    throw ex;
                }
            }
        }
        public bool AddMPHC(MPHC MPHC)
        {
            IUnitOfWork work = null;
            using (work = GetUOW.GetUOWInstance)
            {
                new GenericRepository<MPHC>(work).Add(MPHC);
                work.Save();
            }
            return true;
        }
        public List<MPHC> GetMPHCList()
        {
            IUnitOfWork work = null;
            using (work = GetUOW.GetUOWInstance)
            {
                try
                {
                    return new GenericRepository<MPHC>(work).GetAll().OrderByDescending
                        (p => p.LastModifiedDate).Where(n => n.ObsInd == No)
                        .Take(5).ToList();
                }
                catch (Exception ex)
                {
                    return null;
                    throw ex;
                }
            }
        }
        public MTaluk GetMTalukOnID(string TalukID)
        {
            IUnitOfWork work = null;
            using (work = GetUOW.GetUOWInstance)
            {
                try
                {
                    return new GenericRepository<MTaluk>(work).FindBy(d => d.TalukID == TalukID && d.ObsInd == No).SingleOrDefault();
                }
                catch (Exception ex)
                {
                    return null;
                    throw ex;
                }
            }
        }
        public bool DeleteMPHC(string PHCID)
        {
            IUnitOfWork work = null;
            using (work = GetUOW.GetUOWInstance)
            {
                MPHC mPHC = new GenericRepository<MPHC>(work).FindBy(n => n.PHCID == PHCID).FirstOrDefault();
                if (mPHC != null)
                {
                    new GenericRepository<MPHC>(work).Delete(mPHC);
                    work.Save();
                }
            }
            return true;
        }
        public bool UpdateMPHC(MPHC PHC)
        {
            IUnitOfWork work = null;
            using (work = GetUOW.GetUOWInstance)
            {
                MPHC MPHC = new GenericRepository<MPHC>(work).FindBy(n => n.PHCID == PHC.PHCID).FirstOrDefault();

                if (MPHC != null)
                {
                    //con.Edit(empobj);
                    MPHC.Name = PHC.Name;
                    MPHC.LastModifiedBy = "System";
                    MPHC.LastModifiedDate = DateTime.Now;
                    work.Save();

                    return true;
                }
                else
                    return false;
            }
        }
        public List<DrugStockDetail> GetDrugPurchaseDetail(string PHCID)
        {
            IUnitOfWork work = null;
            using (work = GetUOW.GetUOWInstance)
            {
                try
                {
                    return new GenericRepository<DrugStockDetail>(work).GetAll().OrderByDescending
                        (p => p.LastModifiedDate).Where(n => n.ObsInd == No && n.PHCID == PHCID)
                        .Take(50).ToList();
                }
                catch (Exception ex)
                {
                    return null;
                    throw ex;
                }
            }
        }
        public string GetDrugName(string DrugID)
        {
            IUnitOfWork work = null;
            using (work = GetUOW.GetUOWInstance)
            {
                try
                {
                    MDrug mDrug = new GenericRepository<MDrug>(work).FindBy(d => d.DrugID == DrugID && d.ObsInd == No).SingleOrDefault();
                    return mDrug.Name;
                }
                catch (Exception ex)
                {
                    return null;
                    throw ex;
                }
            }
        }
        public bool AddDrugStock(DrugStockDetail DrugStockDetail)
        {
            IUnitOfWork work = null;
            using (work = GetUOW.GetUOWInstance)
            {
                new GenericRepository<DrugStockDetail>(work).Add(DrugStockDetail);
                work.Save();
            }
            return true;
        }
        public bool UpdateDrugStock(DrugStockDetail DrugStockDetail)
        {
            IUnitOfWork work = null;
            using (work = GetUOW.GetUOWInstance)
            {
                DrugStockDetail drugstock = new GenericRepository<DrugStockDetail>(work).FindBy(n => n.DrugStockID == DrugStockDetail.DrugStockID).FirstOrDefault();

                if (drugstock != null)
                {
                    //con.Edit(empobj);
                    drugstock.DrugID = DrugStockDetail.DrugID;
                    drugstock.PHCID = DrugStockDetail.PHCID;
                    drugstock.Quantity = DrugStockDetail.Quantity;
                    drugstock.BatchNo = DrugStockDetail.BatchNo;
                    drugstock.ManufactureDate = DrugStockDetail.ManufactureDate;
                    drugstock.ExpiryDate = DrugStockDetail.ExpiryDate;
                    drugstock.PurchaseDate = DrugStockDetail.PurchaseDate;
                    drugstock.LastModifiedBy = "System";
                    drugstock.LastModifiedDate = DateTime.Now;
                    work.Save();

                    return true;
                }
                else
                    return false;
            }
        }
        public bool DeleteDrugStock(string DrugStockID)
        {
            IUnitOfWork work = null;
            using (work = GetUOW.GetUOWInstance)
            {
                DrugStockDetail DrugStockDetail = new GenericRepository<DrugStockDetail>(work).FindBy(n => n.DrugStockID == DrugStockID).FirstOrDefault();
                if (DrugStockDetail != null)
                {
                    new GenericRepository<DrugStockDetail>(work).Delete(DrugStockDetail);
                    work.Save();
                }
            }
            return true;
        }
        public bool UpdatePatientDetail(PatientDetail PatientDetail)
        {
            IUnitOfWork work = null;
            using (work = GetUOW.GetUOWInstance)
            {
                PatientDetail PD = new GenericRepository<PatientDetail>(work).FindBy(n => n.PatientID == PatientDetail.PatientID).FirstOrDefault();

                if (PD != null)
                {
                    //con.Edit(empobj);
                    PD.Name = PatientDetail.Name;
                    PD.age = PatientDetail.age;
                    PD.DOB = PatientDetail.DOB;
                    PD.Sex = PatientDetail.Sex;
                    PD.BloodGroup = PatientDetail.BloodGroup;
                    PD.LastModifiedBy = "System";
                    PD.LastModifiedDate = DateTime.Now;
                    PatientAddress PA = PD.PatientAddresses.FirstOrDefault();
                    PatientAddress PatientAddres = PatientDetail.PatientAddresses.FirstOrDefault();
                    PA.VillageID = PatientAddres.VillageID;
                    PA.Address = PatientAddres.Address;
                    PA.ContactNo = PatientAddres.ContactNo;
                    PA.PhoneNo = PatientAddres.PhoneNo;
                    PA.LastModifiedBy = "System";
                    PA.LastModifiedDate = DateTime.Now;
                    //PatientDetail.PatientAddresses.Add(PA);
                    if (PatientDetail.PatientECs != null && PatientDetail.PatientECs.Count > 0)
                    {
                        PatientEC PatientEC = PatientDetail.PatientECs.FirstOrDefault();
                        if (PD.PatientECs.Count == 0)
                        {
                            PatientEC PECnew = new PatientEC();
                            PECnew = PatientEC;
                            PD.PatientECs.Add(PECnew);
                        }
                        else
                        {
                            PatientEC PEC = PD.PatientECs.FirstOrDefault();
                            PEC.ECNumber = PatientEC.ECNumber;
                            PEC.LastModifiedBy = "System";
                            PEC.LastModifiedDate = DateTime.Now;
                            //PatientDetail.PatientECs.Add(PEC);
                        }
                    }

                    work.Save();

                    return true;
                }
                else
                    return false;
            }
        }
        public bool AddPatientDetails(PatientDetail PatientDetail)
        {

            IUnitOfWork work = null;
            using (work = GetUOW.GetUOWInstance)
            {
                new GenericRepository<PatientDetail>(work).Add(PatientDetail);
                work.Save();
            }
            return true;
        }
        public List<PatientDetail> GetPatientDetail(string PHCID)
        {
            IUnitOfWork work = null;
            work = GetUOW.GetUOWInstance;
            {
                try
                {
                    return new GenericRepository<PatientDetail>(work)
                        .FindBy(d => d.PHCID == PHCID)
                        .OrderByDescending(p => p.LastModifiedDate)
                        .Take(50)
                        .ToList();


                }
                catch (Exception ex)
                {
                    return null;
                    throw ex;
                }
            }
        }
        public string GetVillageName(string VillageID)
        {
            IUnitOfWork work = null;
            using (work = GetUOW.GetUOWInstance)
            {
                try
                {
                    MVillage mVillage = new GenericRepository<MVillage>(work).FindBy(d => d.VillageID == VillageID && d.ObsInd == No).FirstOrDefault();
                    return mVillage.Name;
                }
                catch (Exception ex)
                {
                    return null;
                    throw ex;
                }
            }
        }
        public List<MVillage> getMVillage(string PHCID)
        {
            IUnitOfWork work = null;
            using (work = GetUOW.GetUOWInstance)
            {
                try
                {
                    return new GenericRepository<MVillage>(work)
                        .FindBy(d => d.PHCID == PHCID)
                        .OrderByDescending(p => p.LastModifiedDate)
                        .ToList();
                }
                catch (Exception ex)
                {
                    return null;
                    throw ex;
                }
            }
        }
        public PatientEC GetPatientEC(string PatientID)
        {
            IUnitOfWork work = null;
            using (work = GetUOW.GetUOWInstance)
            {
                try
                {
                    return new GenericRepository<PatientEC>(work).FindBy(d => d.PatientID == PatientID && d.ObsInd == No).SingleOrDefault();
                }
                catch (Exception ex)
                {
                    return null;
                    throw ex;
                }
            }
        }
        public string CheeckPatientName(string PatientName, string ECNumber, string PHCID)
        {
            IUnitOfWork work = null;
            using (work = GetUOW.GetUOWInstance)
            {
                try
                {
                    PatientDetail PD = new PatientDetail();
                    PD = new GenericRepository<PatientDetail>(work)
                        .FindBy(d => d.Name == PatientName && d.PHCID == PHCID && d.ObsInd == No)
                        .FirstOrDefault();
                    if (PD != null && PD.Name == PatientName)
                        return "Patient Name exist";
                    else
                    {
                        if (!string.IsNullOrEmpty(ECNumber))
                        {
                            PatientEC PEC = new GenericRepository<PatientEC>(work)
                                 .FindBy(d => d.ECNumber == ECNumber && d.PHCID == PHCID && d.ObsInd == No)
                                 .FirstOrDefault();
                            if (PEC != null && PEC.ECNumber == ECNumber)
                            {
                                return "EC number already exist";
                            }
                        }
                        return string.Empty;
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
        public string CheckPatientNameAndECNumberforUpdate(string PatientID, string ECNumber, string PatientName, string PHCID)
        {
            IUnitOfWork work = null;
            using (work = GetUOW.GetUOWInstance)
            {
                try
                {
                    PatientDetail PD = new PatientDetail();
                    PD = new GenericRepository<PatientDetail>(work)
                        .FindBy(d => d.PatientID != PatientID && d.Name == PatientName && d.PHCID == PHCID && d.ObsInd == No)
                        .FirstOrDefault();
                    if (PD != null && PD.Name == PatientName)
                        return "Patient Name exist";
                    else
                    {
                        if (!string.IsNullOrEmpty(ECNumber))
                        {
                            PatientEC PEC = new GenericRepository<PatientEC>(work)
                                 .FindBy(d => d.PatientID != PatientID && d.ECNumber == ECNumber && d.PHCID == PHCID && d.ObsInd == No)
                                 .FirstOrDefault();
                            if (PEC != null && PEC.ECNumber == ECNumber)
                            {
                                return "EC number already exist";
                            }
                        }
                        return string.Empty;
                    }

                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
        public bool AddUser(User userObj)
        {
            IUnitOfWork work = null;
            using (work = GetUOW.GetUOWInstance)
            {
                new GenericRepository<User>(work).Add(userObj);
                work.Save();
            }
            return true;
        }
        public List<MVillage> GetMVillage(string PHCID)
        {
            IUnitOfWork work = null;
            using (work = GetUOW.GetUOWInstance)
            {
                try
                {
                    return new GenericRepository<MVillage>(work)
                        .FindBy(p => p.PHCID == PHCID && p.ObsInd == No)
                        .OrderByDescending(p => p.LastModifiedDate)
                        .ToList();
                }
                catch (Exception ex)
                {
                    return null;
                    throw ex;
                }
            }
        }
        public bool DeleteVillage(string VillageID, string PHCID)
        {
            IUnitOfWork work = null;
            using (work = GetUOW.GetUOWInstance)
            {
                MVillage MVillage = new GenericRepository<MVillage>(work).FindBy(n => n.VillageID == VillageID && n.PHCID == PHCID).FirstOrDefault();
                if (MVillage != null)
                {
                    MVillage.ObsInd = yes;
                    MVillage.LastModifiedBy = "System";
                    MVillage.LastModifiedDate = DateTime.Now;
                    work.Save();
                }
            }
            return true;
        }
        public bool AddMVillage(MVillage MVillage)
        {
            IUnitOfWork work = null;
            using (work = GetUOW.GetUOWInstance)
            {
                new GenericRepository<MVillage>(work).Add(MVillage);
                work.Save();
            }
            return true;
        }
        public MVillage CheckVillage(string PHCID, string VillageName)
        {
            IUnitOfWork work = null;
            using (work = GetUOW.GetUOWInstance)
            {
                try
                {
                    return new GenericRepository<MVillage>(work)
                        .FindBy(n => n.PHCID == PHCID && n.Name == VillageName && n.ObsInd == No)
                        .FirstOrDefault();
                }
                catch (Exception ex)
                {
                    return null;
                    throw ex;
                }
            }
        }
        public string CheckVillageforUpdate(string VillageID, string PHCID, string VillageName)
        {
            IUnitOfWork work = null;
            using (work = GetUOW.GetUOWInstance)
            {
                try
                {
                    MVillage MVillage = new MVillage();
                    MVillage = new GenericRepository<MVillage>(work)
                        .FindBy(d => d.VillageID != VillageID && d.Name == VillageName && d.PHCID == PHCID && d.ObsInd == No)
                        .FirstOrDefault();
                    if (MVillage != null && MVillage.Name == VillageName)
                        return "Village Name exist";
                    else
                        return string.Empty;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
        public bool UpdateVillageDetail(MVillage MVillage)
        {
            IUnitOfWork work = null;
            using (work = GetUOW.GetUOWInstance)
            {
                MVillage mVillage = new GenericRepository<MVillage>(work).FindBy(n => n.VillageID == MVillage.VillageID && n.PHCID == MVillage.PHCID).FirstOrDefault();

                if (mVillage != null)
                {
                    //con.Edit(empobj);
                    mVillage.Name = MVillage.Name;
                    mVillage.LastModifiedBy = "System";
                    mVillage.LastModifiedDate = DateTime.Now;
                    work.Save();

                    return true;
                }
                else
                    return false;
            }
        }


        public MScheme checkSchemeName(string SchemeName)
        {
            IUnitOfWork work = null;
            using (work = GetUOW.GetUOWInstance)
            {
                try
                {
                    return new GenericRepository<MScheme>(work)
                        .FindBy(n => n.Name == SchemeName && n.ObsInd == No)
                        .FirstOrDefault();
                }
                catch (Exception ex)
                {
                    return null;
                    throw ex;
                }
            }
        }
        public string CheckSchemforUpdate(string SchemeID, string SchemeName)
        {
            IUnitOfWork work = null;
            using (work = GetUOW.GetUOWInstance)
            {
                try
                {
                    MScheme MScheme = new MScheme();
                    MScheme = new GenericRepository<MScheme>(work)
                        .FindBy(d => d.SchemeID != SchemeID && d.Name == SchemeName && d.ObsInd == No)
                        .FirstOrDefault();
                    if (MScheme != null && MScheme.Name == SchemeName)
                        return "Scheme Name exist";
                    else
                        return string.Empty;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
        public List<MScheme> GetMSchemes()
        {
            IUnitOfWork work = null;
            using (work = GetUOW.GetUOWInstance)
            {
                try
                {
                    return new GenericRepository<MScheme>(work)
                        .FindBy(p => p.ObsInd == No)
                        .OrderByDescending(p => p.LastModifiedDate)
                        .ToList();
                }
                catch (Exception ex)
                {
                    return null;
                    throw ex;
                }
            }
        }
        public bool AddMScheme(MScheme MScheme)
        {
            IUnitOfWork work = null;
            using (work = GetUOW.GetUOWInstance)
            {
                new GenericRepository<MScheme>(work).Add(MScheme);
                work.Save();
            }
            return true;
        }
        public bool UpdateSchemeDetail(MScheme MScheme)
        {
            IUnitOfWork work = null;
            using (work = GetUOW.GetUOWInstance)
            {
                MScheme mScheme = new GenericRepository<MScheme>(work).FindBy(n => n.SchemeID == MScheme.SchemeID).FirstOrDefault();

                if (mScheme != null)
                {
                    //con.Edit(empobj);
                    mScheme.Name = MScheme.Name;
                    mScheme.LastModifiedBy = "System";
                    mScheme.LastModifiedDate = DateTime.Now;
                    work.Save();

                    return true;
                }
                else
                    return false;
            }
        }
        public bool DeleteMScheme(string SchemeID)
        {
            IUnitOfWork work = null;
            using (work = GetUOW.GetUOWInstance)
            {
                MScheme MScheme = new GenericRepository<MScheme>(work).FindBy(n => n.SchemeID == SchemeID).FirstOrDefault();
                if (MScheme != null)
                {
                    MScheme.ObsInd = yes;
                    MScheme.LastModifiedBy = "System";
                    MScheme.LastModifiedDate = DateTime.Now;
                    work.Save();
                }
            }
            return true;
        }


        public MReligion checkReligionName(string ReligionName)
        {
            IUnitOfWork work = null;
            using (work = GetUOW.GetUOWInstance)
            {
                try
                {
                    return new GenericRepository<MReligion>(work)
                        .FindBy(n => n.ReligionName == ReligionName && n.ObsInd == No)
                        .FirstOrDefault();
                }
                catch (Exception ex)
                {
                    return null;
                    throw ex;
                }
            }
        }
        public string CheckReligionforUpdate(string ReligionID, string ReligionName)
        {
            IUnitOfWork work = null;
            using (work = GetUOW.GetUOWInstance)
            {
                try
                {
                    MReligion MReligion = new MReligion();
                    MReligion = new GenericRepository<MReligion>(work)
                        .FindBy(d => d.ReligionID != ReligionID && d.ReligionName == ReligionName && d.ObsInd == No)
                        .FirstOrDefault();
                    if (MReligion != null && MReligion.ReligionName == ReligionName)
                        return "Religion Name exist";
                    else
                        return string.Empty;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
        public List<MReligion> GetMReligions()
        {
            IUnitOfWork work = null;
            using (work = GetUOW.GetUOWInstance)
            {
                try
                {
                    return new GenericRepository<MReligion>(work)
                        .FindBy(p => p.ObsInd == No)
                        .OrderByDescending(p => p.LastModifiedDate)
                        .ToList();
                }
                catch (Exception ex)
                {
                    return null;
                    throw ex;
                }
            }
        }
        public bool AddMReligion(MReligion MReligion)
        {
            IUnitOfWork work = null;
            using (work = GetUOW.GetUOWInstance)
            {
                new GenericRepository<MReligion>(work).Add(MReligion);
                work.Save();
            }
            return true;
        }
        public bool UpdateReligionDetail(MReligion MReligion)
        {
            IUnitOfWork work = null;
            using (work = GetUOW.GetUOWInstance)
            {
                MReligion mReligion = new GenericRepository<MReligion>(work).FindBy(n => n.ReligionID == MReligion.ReligionID).FirstOrDefault();

                if (mReligion != null)
                {
                    //con.Edit(empobj);
                    mReligion.ReligionName = MReligion.ReligionName;
                    mReligion.LastModifiedBy = "System";
                    mReligion.LastModifiedDate = DateTime.Now;
                    work.Save();

                    return true;
                }
                else
                    return false;
            }
        }
        public bool DeleteReligion(string ReligionID)
        {
            IUnitOfWork work = null;
            using (work = GetUOW.GetUOWInstance)
            {
                MReligion MReligion = new GenericRepository<MReligion>(work).FindBy(n => n.ReligionID == ReligionID).FirstOrDefault();
                if (MReligion != null)
                {
                    MReligion.ObsInd = yes;
                    MReligion.LastModifiedBy = "System";
                    MReligion.LastModifiedDate = DateTime.Now;
                    work.Save();
                }
            }
            return true;
        }

        public MEducation checkEducationName(string EducationName)
        {
            IUnitOfWork work = null;
            using (work = GetUOW.GetUOWInstance)
            {
                try
                {
                    return new GenericRepository<MEducation>(work)
                        .FindBy(n => n.Name == EducationName && n.ObsInd == No)
                        .FirstOrDefault();
                }
                catch (Exception ex)
                {
                    return null;
                    throw ex;
                }
            }
        }
        public string CheckEducationforUpdate(string EducationID, string EducationName)
        {
            IUnitOfWork work = null;
            using (work = GetUOW.GetUOWInstance)
            {
                try
                {
                    MEducation MEducation = new MEducation();
                    MEducation = new GenericRepository<MEducation>(work)
                        .FindBy(d => d.EducationID != EducationID && d.Name == EducationName && d.ObsInd == No)
                        .FirstOrDefault();
                    if (MEducation != null && MEducation.Name == EducationName)
                        return "Education Name exist";
                    else
                        return string.Empty;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
        public List<MEducation> GetMEducations()
        {
            IUnitOfWork work = null;
            using (work = GetUOW.GetUOWInstance)
            {
                try
                {
                    return new GenericRepository<MEducation>(work)
                        .FindBy(p => p.ObsInd == No)
                        .OrderByDescending(p => p.LastModifiedDate)
                        .ToList();
                }
                catch (Exception ex)
                {
                    return null;
                    throw ex;
                }
            }
        }
        public bool AddMEducation(MEducation MEducation)
        {
            IUnitOfWork work = null;
            using (work = GetUOW.GetUOWInstance)
            {
                new GenericRepository<MEducation>(work).Add(MEducation);
                work.Save();
            }
            return true;
        }
        public bool UpdateEducationDetail(MEducation MEducation)
        {
            IUnitOfWork work = null;
            using (work = GetUOW.GetUOWInstance)
            {
                MEducation mEducation = new GenericRepository<MEducation>(work).FindBy(n => n.EducationID == MEducation.EducationID).FirstOrDefault();

                if (mEducation != null)
                {
                    //con.Edit(empobj);
                    mEducation.Name = MEducation.Name;
                    mEducation.LastModifiedBy = "System";
                    mEducation.LastModifiedDate = DateTime.Now;
                    work.Save();

                    return true;
                }
                else
                    return false;
            }
        }
        public bool DeleteEducation(string EducationID)
        {
            IUnitOfWork work = null;
            using (work = GetUOW.GetUOWInstance)
            {
                MEducation MEducation = new GenericRepository<MEducation>(work).FindBy(n => n.EducationID == EducationID).FirstOrDefault();
                if (MEducation != null)
                {
                    MEducation.ObsInd = yes;
                    MEducation.LastModifiedBy = "System";
                    MEducation.LastModifiedDate = DateTime.Now;
                    work.Save();
                }
            }
            return true;
        }

        public SubCenter checkSubCenterName(string PHCID, string SubCenterName)
        {
            IUnitOfWork work = null;
            using (work = GetUOW.GetUOWInstance)
            {
                try
                {
                    return new GenericRepository<SubCenter>(work)
                        .FindBy(n => n.Name == SubCenterName && n.PHCID == PHCID && n.ObsInd == No)
                        .FirstOrDefault();
                }
                catch (Exception ex)
                {
                    return null;
                    throw ex;
                }
            }
        }
        public string CheckSubCenterforUpdate(string SubCenterID, string PHCID, string SubCenterName)
        {
            IUnitOfWork work = null;
            using (work = GetUOW.GetUOWInstance)
            {
                try
                {
                    SubCenter SubCenter = new SubCenter();
                    SubCenter = new GenericRepository<SubCenter>(work)
                        .FindBy(d => d.SubCenterID != SubCenterID && d.Name == SubCenterName && d.PHCID == PHCID && d.ObsInd == No)
                        .FirstOrDefault();
                    if (SubCenter != null && SubCenter.Name == SubCenterName)
                        return "SubCenter already exist";
                    else
                        return string.Empty;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
        public List<SubCenter> GetSubCenter(string PHCID)
        {
            IUnitOfWork work = null;
            using (work = GetUOW.GetUOWInstance)
            {
                try
                {
                    return new GenericRepository<SubCenter>(work)
                        .FindBy(p => p.PHCID == PHCID && p.ObsInd == No)
                        .OrderByDescending(p => p.LastModifiedDate)
                        .ToList();
                }
                catch (Exception ex)
                {
                    return null;
                    throw ex;
                }
            }
        }
        public bool AddSubCenter(SubCenter SubCenter)
        {
            IUnitOfWork work = null;
            using (work = GetUOW.GetUOWInstance)
            {
                new GenericRepository<SubCenter>(work).Add(SubCenter);
                work.Save();
            }
            return true;
        }
        public bool UpdateSubCenterDetail(SubCenter SubCenter)
        {
            IUnitOfWork work = null;
            using (work = GetUOW.GetUOWInstance)
            {
                SubCenter subCenter = new GenericRepository<SubCenter>(work).FindBy(n => n.SubCenterID == SubCenter.SubCenterID && n.PHCID == SubCenter.PHCID).FirstOrDefault();

                if (subCenter != null)
                {
                    //con.Edit(empobj);
                    subCenter.Name = SubCenter.Name;
                    subCenter.LastModifiedBy = "System";
                    subCenter.LastModifiedDate = DateTime.Now;
                    work.Save();

                    return true;
                }
                else
                    return false;
            }
        }
        public bool DeleteSubCenter(string SubCenterID, string PHCID)
        {
            IUnitOfWork work = null;
            using (work = GetUOW.GetUOWInstance)
            {
                SubCenter SubCenter = new GenericRepository<SubCenter>(work).FindBy(n => n.SubCenterID == SubCenterID && n.PHCID == PHCID).FirstOrDefault();
                if (SubCenter != null)
                {
                    SubCenter.ObsInd = yes;
                    SubCenter.LastModifiedBy = "System";
                    SubCenter.LastModifiedDate = DateTime.Now;
                    work.Save();
                }
            }
            return true;
        }
        public bool AddPatientPrescription(PatientPrescription PP)
        {
            IUnitOfWork work = null;
            using (work = GetUOW.GetUOWInstance)
            {
                new GenericRepository<PatientPrescription>(work).Add(PP);
                work.Save();
            }
            return true;
        }
        public PatientDetail GeTPatientInfo(string PatientName, string PHCID)
        {

            IUnitOfWork work = null;
            work = GetUOW.GetUOWInstance;
            {
                try
                {
                    return new GenericRepository<PatientDetail>(work).FindBy(d => d.Name == PatientName && d.PHCID == PHCID && d.ObsInd == No).SingleOrDefault();
                }
                catch (Exception ex)
                {
                    return null;
                    throw ex;
                }
            }
        }


        public List<PatientPrescription> GetPatientVistHistory(string PatientID, string PHCID)
        {
            IUnitOfWork work = null;
            work = GetUOW.GetUOWInstance;
            {
                try
                {
                    return new GenericRepository<PatientPrescription>(work)
                        .FindBy(p => p.PHCID == PHCID && p.PatientID == PatientID && p.ObsInd == No)
                        .OrderByDescending(p => p.LastModifiedDate)
                        .ToList();
                }
                catch (Exception ex)
                {
                    return null;
                    throw ex;
                }
            }
        }
        public PHCTransaction checkPHCOpeningBalance(string PHCID, string Description)
        {
            IUnitOfWork work = null;
            work = GetUOW.GetUOWInstance;
            {
                try
                {
                    return new GenericRepository<PHCTransaction>(work)
                        .FindBy(p => p.PHCID == PHCID && p.Description == Description && p.ObsInd == No)
                        .OrderByDescending(p => p.LastModifiedDate)
                        .FirstOrDefault();
                }
                catch (Exception ex)
                {
                    return null;
                    throw ex;
                }
            }

        }
        public bool AddPHCTransaction(PHCTransaction PHCT)
        {
            IUnitOfWork work = null;
            using (work = GetUOW.GetUOWInstance)
            {
                new GenericRepository<PHCTransaction>(work).Add(PHCT);
                work.Save();
            }
            return true;
        }
        public List<PHCTransaction> GetPHCTransaction(string PHCID)
        {
            IUnitOfWork work = null;
            work = GetUOW.GetUOWInstance;
            {
                try
                {
                    return new GenericRepository<PHCTransaction>(work)
                        .FindBy(p => p.PHCID == PHCID && p.ObsInd == No)
                        .OrderByDescending(p => p.LastModifiedDate)
                        .ToList();
                }
                catch (Exception ex)
                {
                    return null;
                    throw ex;
                }
            }
        }
        public bool UpdatePHCTransaction(PHCTransaction PHCTransaction)
        {

            IUnitOfWork work = null;
            using (work = GetUOW.GetUOWInstance)
            {
                PHCTransaction pHCTransaction = new GenericRepository<PHCTransaction>(work).FindBy(n => n.PHCTransactionID == PHCTransaction.PHCTransactionID && n.PHCID == PHCTransaction.PHCID).FirstOrDefault();

                if (pHCTransaction != null)
                {
                    //con.Edit(empobj);
                    pHCTransaction.ISDebited = PHCTransaction.ISDebited;
                    pHCTransaction.LastModifiedBy = "System";
                    pHCTransaction.LastModifiedDate = DateTime.Now;
                    work.Save();

                    return true;
                }
                else
                    return false;
            }
        }
        public List<PHCTransaction> GetPendingTransaction(string PHCID)
        {
            IUnitOfWork work = null;
            work = GetUOW.GetUOWInstance;
            {
                try
                {
                    return new GenericRepository<PHCTransaction>(work)
                        .FindBy(p => p.PHCID == PHCID && p.ISDebited != "Y" && p.TransactionType=="D"  && p.ObsInd == No)
                        .OrderByDescending(p => p.LastModifiedDate)
                        .ToList();
                }
                catch (Exception ex)
                {
                    return null;
                    throw ex;
                }
            }
        }


        public List<PHCTransaction> GetPatientPendingTransaction(string PatientName, string PHCID)
        {
            IUnitOfWork work = null;
            work = GetUOW.GetUOWInstance;
            {
                try
                {
                    return new GenericRepository<PHCTransaction>(work)
                        .FindBy(p => p.PHCID == PHCID && p.ISDebited != "Y" && p.TransactionType == "D" && p.ObsInd == No && p.PatientDetail.Name == PatientName)
                        .OrderByDescending(p => p.LastModifiedDate)
                        .ToList();
                }
                catch (Exception ex)
                {
                    return null;
                    throw ex;
                }
            }
        }
    }
}
