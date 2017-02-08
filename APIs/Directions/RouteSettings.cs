using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapboxSharp.APIs
{
    /// <summary>
    /// Settings for the Directions API request. 
    /// </summary>
    public class RouteSettings
    {
        public DirectionsProfiles Profile { get; set; }
        public double StartLon { get; set; }
        public double StartLat { get; set; }
        public double EndLon { get; set; }
        public double EndLat { get; set; }

        public DirectionsOptions Options;

        public List<System.Windows.Point> NavigateVia = new List<System.Windows.Point>();
    }

    public class DirectionsOptions
    {
        public bool Alternatives = false;
        public bool Steps = false;
        public bool ContinueStraight = false;
        public DirectionsProfiles Profile = DirectionsProfiles.Driving;

        public DirectionsGeometries Geometries = DirectionsGeometries.Polyline;

        /// <summary>
        /// Parameters for Directions URL. Alternatives, Steps, ContinueStraight, Profile, Geometries.
        /// </summary>
        public DirectionsOptions()
        {
            
        }
    }

    public enum DirectionsOverview
    {
        Full,
        Simplified,
        False   
    }

    public enum DirectionsGeometries
    {
        GeoJson,
        Polyline,
        Polyine6,
    }

    public enum DirectionsProfiles
    {
        Driving,
        Walking,
        Cycling
    }
}
