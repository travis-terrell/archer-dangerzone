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

            // SqlParameter[] inParams = { new SqlParameter("action", Action1) };

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




/*
            List<URLReturn> list = new List<URLReturn>();
            using (DataTable dt = DataHelper.ExecuteDataTable("RetrieveURL", InParams.ToArray()))
            {
                foreach (DataRow row in dt.Rows)
                {
                    URLReturn newList = new URLReturn();
                    if (row.Table.Columns.Contains("url"))
                    {
                        newList.url = row.Field<string>("url");
                    }

                    list.Add(newList);
                }
            }

            return list;

        }
    }
}
*/
/*       public static IEnumerable (Dictionary<string, string> Action1)
        {

            List<SqlParameter> InPrams = new List<SqlParameter>();

            foreach (KeyValuePair<string, string> item in Action1)
            {
                InPrams.Add(new SqlParameter(item.Key, item.Value));
            }

            DataHelper.ExecuteDataTable("RetrieveURL", InPrams.ToArray());
*/