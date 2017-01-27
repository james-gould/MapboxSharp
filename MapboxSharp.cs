using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapboxSharp
{
    /// <summary>
    /// A C# wrapper for the Mapbox v5 API. 
    /// For full documentation, please refer to https://www.mapbox.com/api-documentation
    /// Full list of API functionality: https://www.mapbox.com/developers/
    /// </summary>
    public class MapboxSharp
    {
        private string _apiKey;
        private string _accessToken;
        private string _accessPoint;

        public MapboxSharp(string apiKey)
        {
            if (string.IsNullOrEmpty(apiKey))
            {
                throw new FormatException("Mapbox API key cannot be empty.");
            }

            _apiKey = apiKey;
            _accessToken = $"?access_token={_apiKey}";
            _accessPoint = "https://api.mapbox.com/";
        }
    }
}
