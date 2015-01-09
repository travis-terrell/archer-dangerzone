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

namespace RedirectMe.Helpers
{
    public class URLReturn
    {
        public string url { get; set; }
    }

    public class SQLAction
    {

        public static string GetURL(Dictionary<string, string> Action1)
        {
            List<SqlParameter> InParams = new List<SqlParameter>();
            foreach (KeyValuePair<string, string> item in Action1)
            {
                InParams.Add(new SqlParameter(item.Key, item.Value));
            }

            using (DataTable dt = DataHelper.ExecuteDataTable("RetrieveURL", InParams.ToArray()))
            {
                foreach (DataRow row in dt.Rows)
                    if (row.Table.Columns.Contains("url"))
                    {
                        string returnedURL = row.Field<string>("url");
                        return returnedURL;
                    }
            }
            return null;
        }
    }
}