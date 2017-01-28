using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapboxSharp
{
    /// <summary>
    /// A C# wrapper for the Mapbox v5 API. 
    /// For the full documentation, please refer to https://www.mapbox.com/api-documentation
    /// Full list of API functionality: https://www.mapbox.com/developers/
    /// </summary>
    public class MapboxSharp
    {
        private Connection _mapboxConnection;

        public MapboxSharp(string apiKey)
        {
            _mapboxConnection = new Connection(apiKey);


        }

        public void GenerateRoute(double startLon, double startLat, double endLon, double endLat)
        {
            


        }
    }
}
