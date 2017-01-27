using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapboxSharp
{
    /// <summary>
    /// Provides an access point to the Mapbox API.
    /// </summary>
    public class Connection
    {
        public string AccessPoint { get; private set; }
        public string ApiKey { get; }
        public string Token { get; private set; }

        public Connection(string apiKey)
        {
            if (string.IsNullOrEmpty(apiKey))
            {
                throw new FormatException("API key cannot be null or empty");
            }

            ApiKey = apiKey;
            AccessPoint = "https://api.mapbox.com/";
            Token = $"?access_token={ApiKey}";
        }
    }
}
