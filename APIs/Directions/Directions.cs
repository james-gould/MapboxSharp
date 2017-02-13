using System;
using System.Collections.Generic;
using MapboxSharp.Utilities;
using Newtonsoft.Json;

namespace MapboxSharp.APIs
{
    /// <summary>
    /// Access to the Directions API, generating a route through OSRM.
    /// </summary>
    public class Directions
    {
        /// <summary>
        /// Generate OSRM route from the point of origin to the destination. 
        /// </summary>
        /// <param name="startLon">Longitude for your point of origin</param>
        /// <param name="startLat">Latitude for your point of origin</param>
        /// <param name="endLon">Longitude for your destination</param>
        /// <param name="endLat">Latitude for your destination</param>
        /// <param name="profile">Method of transportation used for the route. Any of the following: Driving, driving-traffic, walking, cycling</param>
        /// <returns>JSON string</returns>
        public static MapboxRoute GenerateRouteTwoPoints(double startLon, double startLat, double endLon, double endLat, DirectionsProfiles profile)
        {
            string connectionString = Connection.Instance.URL($"directions/v5/mapbox/{profile}/{startLon},{startLat};{endLon},{endLat}&steps=true");
            string jsonResponse = Connection.DownloadJsonString(connectionString);

            MapboxRoute newRoute = JsonConvert.DeserializeObject<MapboxRoute>(jsonResponse);

            return new MapboxRoute();
        }

        /// <summary>
        /// Generates a route from startPoint to endPoint, navigating via each System.Windows.Point in the provided collection.
        /// </summary>
        /// <param name="startLon">Longitude for your point of origin</param>
        /// <param name="startLat">Latitude for your point of origin</param>
        /// <param name="endLon">Longitude for your destination</param>
        /// <param name="endLat">Latitude for your destination</param>
        /// <param name="profile">Method of transportation used for the route. Any of the following: Driving, driving-traffic, walking, cycling</param>
        /// <param name="goVia">Collection of points</param>
        /// <returns>A complete route</returns>
        public static MapboxRoute GenerateRouteViaPoints(double startLon, double startLat, double endLon, double endLat, DirectionsProfiles profile, List<System.Windows.Point> goVia = null)
        {
            throw new NotImplementedException();
        }

        private List<Step> BuildRouteCollection(MapboxRoute deserializedJson)
        {
            if (deserializedJson.routes.Count == 0 || deserializedJson.routes[0]?.legs[0]?.steps == null) { throw new JsonException("Could not deserialize route from Mapbox JSON string."); }

            List<Step> currentRoute = new List<Step>();

            currentRoute.AddRange(deserializedJson.routes[0].legs[0].steps);

            return currentRoute;

        }
    }
}