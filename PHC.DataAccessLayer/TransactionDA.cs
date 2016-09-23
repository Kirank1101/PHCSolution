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
        public List<User> GetUsers()
        {
            IUnitOfWork work = null;
            using (work = GetUOW.GetUOWInstance)
            {
                return  new GenericRepository<User>(work).GetAll().ToList();

            }

            //ObjectContext
            //var objectContext = ((IObjectContextAdapter)myDbContextObject).ObjectContext;
        }
        public bool AddPatientInfo(PatientDetail  obj)
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
                User uer= new User();
               
                new GenericRepository<User>(work).Add(uer);

                MDrug n= new MDrug();

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
                return new GenericRepository<User>(work).GetAll().Where(u=>u.LoginID==UserId).Single();
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
                    return new GenericRepository<MDisease>(work).GetAll().Where(p => p.ObsInd=="N").ToList();
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
    }
}
