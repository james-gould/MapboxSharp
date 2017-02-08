using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace MapboxSharp
{
    /// <summary>
    /// Provides an access point to the Mapbox API. Singleton implementation.
    /// </summary>
    public sealed class Connection
    {
        private static readonly Connection _instance = new Connection();
        private string _accessPoint = "https://api.mapbox.com/";
        private string _token = $"?access_token={MapboxSharp.ApiKey}";

        /// <summary>
        /// Return the instance if not null, otherwise instantiate Connection and return the instance.
        /// </summary>
        public static Connection Instance => _instance ?? new Connection();

        /// <summary>
        /// Leave the empty constructor so we know it's empty, not just forgotten :-)
        /// </summary>
        private Connection()
        {

        }

        /// <summary>
        /// Construct the URL for an API request. 
        /// </summary>
        /// <param name="insertion">The string to be added into the GET request URL</param>
        /// <returns>The full URL to make a GET reqest to.</returns>
        public string URL(string insertion)
        {
            return $"{_accessPoint}{insertion}{_token}";
        }

        /// <summary>
        /// Make a HTTP request when expecting a JSON string response. 
        /// </summary>
        /// <param name="URL"></param>
        /// <returns></returns>
        public static string JsonWebRequest(string URL)
        {
            // TODO: Error handling. This needs looking into..
            if (string.IsNullOrEmpty(URL))
            {
                throw new FormatException("Illegal request: Cannot generate JSON request from empty URL");
            }

            try
            {
                using (WebClient client = new WebClient())
                {
                    return client.DownloadString(URL);
                }
            }
            catch (WebException e)
            {
                throw e;
            }
            
        }
    }
}
