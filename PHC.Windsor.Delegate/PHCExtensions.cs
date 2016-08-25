namespace PHC.Binder.BackEnd.Windsor
{
    //using CaseConverter.BackEnd;
    //using CaseConverter.BackEnd.Impl;

    using Castle.MicroKernel;
    using Castle.MicroKernel.Registration;
    using Castle.Windsor;

    //using DataSync.BackEnd;

    //using ExternalInterface.BackEnd;
    //using ExternalInterface.BackEnd.Impl;

    using log4net;
    using PHC.DAInterfaces;
    using PHC.DataAccessLayer;
    using PHC.DAInterfaces.DataAccess;
    using PHC.BAInterfaces.Business;
    using PHC.Business;
    using PHC.BAInterfaces.Validations;




    /// <summary>
    /// Description of BackEndExtension.
    /// </summary>
    public class PHCExtensions : IWindsorInstaller
    {
        #region Fields

        /// <summary>
        /// logging instance
        /// </summary>
        private static readonly ILog Logger = LogManager.GetLogger(typeof(PHCExtensions));

        #endregion Fields

        #region Methods

        public virtual void Install(IWindsorContainer container, IConfigurationStore store)
        {
            if (Logger.IsDebugEnabled)
            {
                Logger.Debug("Adding the All components now...");
            }

            container.Register(
                  Component.For<ITransactionDA>().ImplementedBy<TransactionDA>().LifeStyle.Transient,
                  Component.For<ITransactionBusiness>().ImplementedBy<TransactionBusiness>().LifeStyle.Transient,
                  Component.For<IValidate>().ImplementedBy<UIValidation>().LifeStyle.Transient
                );
        }

        #endregion Methods
    }
}