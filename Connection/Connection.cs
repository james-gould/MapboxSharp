using System;
using System.Collections.Generic;
using System.Linq;
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
        /// TODO: Currently not thread safe. Consider locking.
        /// </summary>
        public static Connection Instance
        {
            get { return _instance ?? new Connection(); }
        }

        /// <summary>
        /// Leave empty constructor so we know it's empty, not just forgotten :-)
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
    }
}
