using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapboxSharp.APIs.Directions
{

    /// <summary>
    /// Provides an array for each intersection along the Step object.
    /// </summary>
    public class Intersection
    {
        public int @out { get; set; }
        public List<bool> entry { get; set; }
        public List<int> bearings { get; set; }
        public List<double> location { get; set; }
        public int? @in { get; set; }
    }
    /// <summary>
    /// Maneuver object, included in each Step. Provides additional detail about the action needed fpr the step/
    /// </summary>
    public class Maneuver
    {
        public int bearing_after { get; set; }
        public string type { get; set; }
        public string modifier { get; set; }
        public int bearing_before { get; set; }
        public List<double> location { get; set; }
        public string instruction { get; set; }
        public int? exit { get; set; }
    }

    /// <summary>
    /// Most important object. Contains all information for each individual part of the route. 
    /// </summary>
    public class Step
    {
        public List<Intersection> intersections { get; set; }

        /// <summary>
        /// Encoded polyline for the step.
        /// </summary>
        public string geometry { get; set; }

        /// <summary>
        /// Direction of turn for the step. 'Turn right' || 'Next left' || 'Slight left off roundabout'
        /// </summary>
        public Maneuver maneuver { get; set; }

        /// <summary>
        /// Time for step given average speed (assumed)
        /// </summary>
        public double duration { get; set; } 

        /// <summary>
        /// In meters.
        /// </summary>
        public double distance { get; set; }

        /// <summary>
        /// Name of road at start of step.
        /// </summary>
        public string name { get; set; }

        /// <summary>
        /// The given travel mode when querying -> cycling, driving etc.
        /// </summary>
        public string mode { get; set; }

        /// <summary>
        /// Typically B/A roads such as A38 or B3423 (Can non-UK people please confirm this? Too much sovereignty).
        /// </summary>
        public string @ref { get; set; } 
    }

    /// <summary>
    /// Leg object, used for each stretch of a route. /steps/ contains each individual point a turn/action is needed, such as 'turn right' or 'left at the T juntion'.
    /// </summary>
    public class Leg
    {
        public List<Step> steps { get; set; }
        public string summary { get; set; }
        public double duration { get; set; }
        public double distance { get; set; }
    }

    /// <summary>
    /// Route object, contains a list of Leg objects and an encoded polyline in the geometry string. Use ValidationUtils.DecodeEncodedPolyline(geometry) to convert to a collection of System.Windows.Points
    /// </summary>
    public class Route
    {
        public List<Leg> legs { get; set; }
        public string geometry { get; set; }
        public double duration { get; set; }
        public double distance { get; set; }
    }

    /// <summary>
    /// Waypoints, each specified part of the route (start & end if no "via" points have been queried).
    /// </summary>
    public class Waypoint
    {
        public string name { get; set; }
        public List<double> location { get; set; }
    }

    /// <summary>
    /// Route object for the Mapbox Directions route. 
    /// </summary>
    public class MapboxRoute
    {
        public List<Route> routes { get; set; }
        public List<Waypoint> waypoints { get; set; }
        public string code { get; set; }
    }
}
