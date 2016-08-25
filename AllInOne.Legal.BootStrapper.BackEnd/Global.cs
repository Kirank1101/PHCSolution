using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AllInOne.BootStrapper.BackEnd
{
    using System;
    using System.Configuration;
   

    //using Microsoft.SharePoint;
    //using Microsoft.SharePoint.ApplicationRuntime;

    /// <summary>
    /// Represents a standard global class used for application startup functionalities.
    /// </summary>
    public class Global 
    {
        #region Methods

        /// <summary>
        /// Handles the AuthenticateRequest event of the Application control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// Handles the BeginRequest event of the Application control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        protected void Application_BeginRequest(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// Handles the End event of the Application control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        public static  void Application_End()
        {
            // Code that runs on application shutdown
            // Call to BootStrapper for configuring various startups.
            BootStrapper.Shutdown();
        }

        /// <summary>
        /// Handles the Error event of the Application control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        //protected void Application_Error(object sender, EventArgs e)
        //{
        //    // Code that runs when an unhandled error occurs
        //    string errorLocation = Request.Path;
        //    HttpContext context = HttpContext.Current;
        //    Exception exception = Context.Server.GetLastError();

        //    BootStrapper.CatchApplicationError(exception);
        //    context.Server.ClearError();
        //}

        /// <summary>
        /// Handles the Start event of the Application control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        public static void Application_Start()
        {
            // Call to BootStrapper for configuring various startups.
            // Code that runs on application startup
           // string log4netConfigFile = ConfigurationManager.AppSettings["LogConfigFileLocation"];
            BootStrapper.ConfigLogger(string.Empty);
            BootStrapper.StartUp();
            //AddTask("DoStuff", 180);
        }     

        

        #endregion Methods
    }
}
