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
                    return new GenericRepository<MDisease>(work).GetAll().Where(p => p.ObsInd == "N").ToList();
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
                    return new GenericRepository<MDrug>(work).GetAll().Where(p => p.ObsInd == "N").ToList();
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
                MDrug mDrug= new GenericRepository<MDrug>(work).FindBy(n=>n.DrugID==DrugID).FirstOrDefault();
                if (mDrug != null) {
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
                    return new GenericRepository<MLabTest>(work).GetAll().Where(p => p.ObsInd == "N").ToList();
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
                MLabTest labtest = new GenericRepository<MLabTest>(work).FindBy(n=>n.LabTestID==LabTest.LabTestID).FirstOrDefault();

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
                        (p => p.LastModifiedDate).Where(n=>n.ObsInd=="N")
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
                    MDistrict district= new GenericRepository<MDistrict>(work).FindBy(d => d.DistrictID == DistrictID && d.ObsInd == No).SingleOrDefault();
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
                    return new GenericRepository<MDistrict>(work).GetAll().Where(p => p.ObsInd == "N").ToList();
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
                    return new GenericRepository<MTaluk>(work).GetAll().Where(n => n.ObsInd == "N" && n.DistrictID == DistrictID).ToList();
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
    }
}
