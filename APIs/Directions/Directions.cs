using MapboxSharp.Utilities;

namespace MapboxSharp.APIs.Directions
{
    /// <summary>
    /// Access to the Directions API, generating a route through OSRM.
    /// </summary>
    public static class Directions
    {
        /// <summary>
        /// Generate OSRM route from the point of origin to the destination. 
        /// </summary>
        /// <param name="startLon">Longitude for your point of origin</param>
        /// <param name="startLat">Latitude for your point of origin</param>
        /// <param name="endLon">Longitude for your destination</param>
        /// <param name="endLat">Latitude for your destination</param>
        /// <returns>JSON string</returns>
        public static string GenerateRouteTwoPoints(double startLon, double startLat, double endLon, double endLat)
        {
            if (ValidationUtils.ValidLonLat(startLon, startLat) && ValidationUtils.ValidLonLat(endLon, endLat))
            {
                   
            }


            return string.Empty;
        }
    }
}
