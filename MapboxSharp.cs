﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MapboxSharp.APIs;
using MapboxSharp.Utilities;

using vdr = MapboxSharp.Utilities.ValidationUtils;


namespace MapboxSharp
{
    /// <summary>
    /// A C# wrapper for the Mapbox v5 API. 
    /// For the full documentation, please refer to https://www.mapbox.com/api-documentation
    /// Full list of API functionality: https://www.mapbox.com/developers/
    /// </summary>
    public sealed class MapboxSharp
    {
        public static string ApiKey;

        public MapboxSharp(string apiKey)
        {
            if (string.IsNullOrEmpty(apiKey))
            {
                throw new FormatException("Your API key cannot be empty.");
            }

            ApiKey = apiKey;
        }

        /// <summary>
        /// Generate the fastest route between two points. Provides step by step instructions for each part of the journey.
        /// </summary>
        /// <param name="startLon">Longitude of the point of origin</param>
        /// <param name="startLat">Latitude of the point of origin</param>
        /// <param name="endLon">Longitude of the destination</param>
        /// <param name="endLat">Latitude of the destination</param>
        /// <param name="goVia">Collection of System.Windows.Points, if the route being generated should navigate via points on the map add them to this list.</param>
        /// <returns></return>
        public MapboxRoute GenerateRoute(double startLon, double startLat, double endLon, double endLat, List<System.Windows.Point> goVia = null)
        {
            if (!vdr.ValidLonLat(startLon, startLat) || !vdr.ValidLonLat(endLon, endLat))
            {
                throw new FormatException("Invalid longitude/latitude provided when generating a route.");
            }

            // If goVia is not null and has at least 1 item
            if (goVia?.Count >= 1)
            {
                return Directions.GenerateRouteViaPoints(startLon, startLat, endLon, endLat, goVia);
            }

            return Directions.GenerateRouteTwoPoints(startLon, startLat, endLon, endLat);
        }
    }
}
