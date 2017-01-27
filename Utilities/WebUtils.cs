using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;

namespace MapboxSharp.Utilities
{
    public static class WebUtils
    {
        public static string WebRequest(string conn)
        {
            if (string.IsNullOrEmpty(conn))
            {
                throw new WebException("Could not generate web request from empty string");
            }
            using (WebClient client = new WebClient())
            {
                return client.DownloadString(conn);
            }
        }
    }
}
