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
        /// <summary>
        /// Make a HTTP request when expecting a JSON string response. 
        /// </summary>
        /// <param name="conn"></param>
        /// <returns></returns>
        public static string JsonWebRequest(string conn)
        {
            if (string.IsNullOrEmpty(conn))
            {
                throw new WebException("Could not generate JSON request from empty URL");
            }

            using (WebClient client = new WebClient())
            {
                return client.DownloadString(conn);
            }
        }
    }
}
