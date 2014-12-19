using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web.HttpRequest;
using System.Web;
using System.Web.HttpUtility;

namespace URL_Redirect
{
    private class ParseIncoming
    {

        protected void Page_Load(object sender, EventArgs e)
        {

            String incomingURL = HttpContext.Current.Request.RawUrl;
            String queryString = null;

            int queryStart = incomingURL.IndexOf('?');

            if (queryStart == -1)
            {
                queryString = String.Empty;
                String redirectURL = incomingURL + "?var1=1&var2=2+2%2f3&var1=3";
                Redirect(redirectURL, true);
            }
            //---------------------------------------------------------------------------------------------------------------------------
            // If query variables exist, put them in a string
            //---------------------------------------------------------------------------------------------------------------------------
            else if (queryStart >= 0)
            {
                queryString = (queryStart < incomingURL.Length - 1) ? incomingURL.Substring(queryStart + 1) : String.Empty;
            }
            //---------------------------------------------------------------------------------------------------------------------------
            // Parse query string into key/value pairs
            //---------------------------------------------------------------------------------------------------------------------------

            NameValueCollection incomingPairs = HttpUtility.ParseQueryString(queryString);

            foreach(incomingPairs as )

        }
    }
}


    
 

       
/*       //! Let's try these, maybe..
 *        
 *
 *        protected void Page_Load(object sender, EventArgs e)
 *        {
 *        string test = HttpUtility.ParseQueryString;
 *        string test2 = HttpRequest.QueryString.get;
 *        string test3 = HttpContext.Request.CurrentString;
 *        }
 * 
 *          //!HttpUtility.ParseQueryString()  
 *          //!Reference: http://stackoverflow.com/questions/776107/best-way-to-convert-query-string-to-dictionary-in-c-sharp
 *          //!More good info: http://www.dotnetperls.com/google-query
 *          //!MSDN: http://msdn.microsoft.com/en-us/library/ms150046(v=vs.110).aspx          
 */             