using System;
using System.Collections.Generic;
using MapboxSharp.Utilities;

namespace MapboxSharp.APIs
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
        public static MapboxRoute GenerateRouteTwoPoints(double startLon, double startLat, double endLon, double endLat)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Generates a route from startPoint to endPoint, navigating via each System.Windows.Point in the provided collection.
        /// </summary>
        /// <param name="startLon">Longitude for your point of origin</param>
        /// <param name="startLat">Latitude for your point of origin</param>
        /// <param name="endLon">Longitude for your destination</param>
        /// <param name="endLat">Latitude for your destination</param>
        /// <param name="goVia">Collection of points</param>
        /// <returns>A complete route</returns>
        public static MapboxRoute GenerateRouteViaPoints(double startLon, double startLat, double endLon, double endLat, List<System.Windows.Point> goVia = null)
        {
            throw new NotImplementedException();
        }
    }
}
