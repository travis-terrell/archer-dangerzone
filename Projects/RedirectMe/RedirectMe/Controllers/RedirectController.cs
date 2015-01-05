using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Diagnostics;

namespace RedirectMe.Controllers
{
    public class RedirectController : Controller
    {
        //
        // GET: /Redirect/

        public ActionResult Redirect()
        {

            NameValueCollection incomingQuery = Request.QueryString;

            if (incomingQuery.HasKeys())
            {
                string clientid = incomingQuery.Get(incomingQuery["clientid"]);
                string id = incomingQuery.Get(incomingQuery["id"]);
                string ts = incomingQuery.Get(incomingQuery["ts"]);
                string slotId = incomingQuery.Get(incomingQuery["slotId"]);
                string q = incomingQuery.Get(incomingQuery["q"]);
                string u = incomingQuery.Get(incomingQuery["u"]);
                string ty = incomingQuery.Get(incomingQuery["ty"]);

                //*****************************************************************************************
                // We need to do replacements via database queries here.
                // e.g.
                clientid = "112";
                id = "2";
                ts = "2";
                slotId = "2";
                q = "2";
                u = "2";
                ty = "2";
                //*****************************************************************************************
                var outgoingQuery = new NameValueCollection();
                outgoingQuery.Add("clientid", clientid);
                outgoingQuery.Add("id", id);
                outgoingQuery.Add("ts", ts);
                outgoingQuery.Add("slotId", slotId);
                outgoingQuery.Add("q", q);
                outgoingQuery.Add("u", u);
                outgoingQuery.Add("ty", ty);

                string domain = "http://treesap.me/?";

                string outgoingString = incomingQuery.ToString();

                string RedirectURL = domain + outgoingString;

                Response.StatusCode = 302;
                Response.Status = "302 Moved Temporarily";
                return Redirect(RedirectURL);
                //NameValueCollection outgoingString = new NameValueCollection();
                
                Debug.Print(outgoingString);

            }

            return HttpNotFound("Something went wrong!");
        }

    }
}
