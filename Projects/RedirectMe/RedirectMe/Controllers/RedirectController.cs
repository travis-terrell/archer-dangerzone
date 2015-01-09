using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Data.SqlClient;
using Inuvo.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Diagnostics;
using RedirectMe.Helpers;

namespace RedirectMe.Controllers
{
    public class RedirectController : Controller
    {

        public ActionResult Redirect()
        {
            // Get parameters from browser, store as variables
            NameValueCollection incomingQuery = Request.QueryString;

            if (incomingQuery.HasKeys())
            {
                string clientid = incomingQuery["clientid"];
                string id = incomingQuery["id"];
                string ts = incomingQuery["ts"];
                string slotId = incomingQuery["slotId"];
                string q = incomingQuery["q"];
                string u = incomingQuery["u"];
                string ty = incomingQuery["ty"];

                // Query ClientDB, obtain URL
                Dictionary<string, string> ParamsList = new Dictionary<string, string>();
                ParamsList.Add("clientid", clientid);

                string clientURL = SQLAction.GetURL(ParamsList);

                // Substitute values
                StringBuilder substitute = new StringBuilder(clientURL);
                substitute.Replace("!!clientid!!", clientid);
                substitute.Replace("!!id!!", id);
                substitute.Replace("!!ts!!", ts);
                substitute.Replace("!!slotId!!", slotId);
                substitute.Replace("!!q!!", q);
                substitute.Replace("!!u!!", u);
                substitute.Replace("!!ty!!", ty);
                clientURL = substitute.ToString();

                // Send redirect to browser
                Response.StatusCode = 302;
                Response.Status = "302 Moved Temporarily";
                if (String.IsNullOrEmpty(clientURL))
                {
                    return HttpNotFound("ClientID doesn't exist in database.");
                }
                else
                {
                    return Redirect(clientURL);
                }
                //return Redirect(clientURL);
            }

            //Return 404 if no variables found
            return HttpNotFound("Where the hell are the parameters?");
        }
    }
}