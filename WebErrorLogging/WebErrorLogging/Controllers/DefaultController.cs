using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Serilog;
using WebErrorLogging.Utilities;


namespace WebErrorLogging.Controllers
{
    public class DefaultController : Controller
    {
        private ILogger _errorlog;
        public ActionResult Index()
        {
            try
            {
                throw new NotImplementedException();
            }
            catch (Exception e)
            {

                _errorlog = new LoggerConfiguration()
                    .ReadFrom.AppSettings()
                    .CreateLogger();

                _errorlog.Error(e, "DefaultController");
                throw;
            }

            return View();
        }


        // GET: Default   
        #region Database Error Logging
        //// Database Error Logging
        //public ActionResult Index()
        //{
        //    try
        //    {
        //        HelperStoreSqlLog.WriteDebug(null, "Debug ");
        //        HelperStoreSqlLog.WriteWarning(null, "Warning ");
        //        throw new NotImplementedException();
        //    }
        //    catch (Exception e)
        //    {
        //        HelperStoreSqlLog.WriteError(e, "Error");
        //        HelperStoreSqlLog.WriteFatal(e, "Fatal");
        //        HelperStoreSqlLog.WriteVerbose(e, "Verbose");
        //        throw;
        //    }

        //    return View();
        //} 
        #endregion

        #region Text File Logging
        //public ActionResult Index()
        //{
        //    try
        //    {
        //        Helper.WriteDebug(null, "Debug ");
        //        Helper.WriteWarning(null, "Warning ");
        //        throw new NotImplementedException();
        //    }
        //    catch (Exception e)
        //    {
        //        Helper.WriteError(e, "Error");
        //        Helper.WriteFatal(e, "Fatal");
        //        Helper.WriteVerbose(e, "Verbose");
        //        throw;
        //    }

        //    return View();
        //} 
        #endregion

    }
}