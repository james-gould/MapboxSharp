using System.Collections.Generic;

namespace MapboxSharp.APIs
{

    /// <summary>
    /// Provides an array for each intersection along the Step object.
    /// </summary>
    public class Intersection
    {
        /// <summary>
        /// Index into the bearings/entry array. Used to extract the bearing after the turn.
        /// </summary>
        public int @out { get; set; }

        /// <summary>
        /// A list of entry flags, corresponding in a 1:1 relationship to the bearings. 
        /// </summary>
        public List<bool> entry { get; set; }

        /// <summary>
        /// A list of bearing values (for example [0,90,180,270]) that are available at the intersection. 
        /// </summary>
        public List<int> bearings { get; set; }

        /// <summary>
        /// An array containing the WGS84 point of the waypoint, formatted as longitude, latitude.
        /// </summary>
        public List<double> location { get; set; }

        /// <summary>
        ///  Index into bearings/entry array. Used to calculate the bearing before the turn. 
        /// </summary>
        public int? @in { get; set; }

        public Intersection()
        {
            @out = 0;
            entry = new List<bool>();
            bearings = new List<int>();
            location = new List<double>();
            @in = 0;
        }
    }

    /// <summary>
    /// Maneuver object, included in each Step. Provides additional detail about the action needed fpr the step/
    /// </summary>
    public class Maneuver
    {
        /// <summary>
        /// Number between 0 and 360 indicating the clockwise angle from true north to the direction of travel right after the maneuver.
        /// </summary>
        public int bearing_after { get; set; }

        /// <summary>
        /// String indicating the type of maneuver
        /// </summary>
        public string type { get; set; }

        /// <summary>
        /// Provides the direction of the turn being made.
        /// </summary>
        public string modifier { get; set; }

        /// <summary>
        /// Bearing before the turn.
        /// </summary>
        public int bearing_before { get; set; }

        /// <summary>
        /// Longitude, latitude point formatted as two doubles.
        /// </summary>
        public List<double> location { get; set; }

        /// <summary>
        /// A human-readable instruction of how to execute the returned maneuver
        /// </summary>
        public string instruction { get; set; }

        /// <summary>
        /// If the maneuver is being performed on a roundabout, exit will contain an int depicting which exit to take.
        /// </summary>
        public int? exit { get; set; }

        public Maneuver()
        {
            bearing_after = 0;
            bearing_before = 0;
            type = string.Empty;
            modifier = string.Empty;
            location = new List<double>();
            instruction = string.Empty;
            exit = 0;
        }
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

        public Step()
        {
            intersections = new List<Intersection>();
            geometry = string.Empty;
            maneuver = new Maneuver();
            duration = double.NaN;
            distance = double.NaN;
            name = string.Empty;
            mode = string.Empty;
            @ref = string.Empty;
        }
    }

    /// <summary>
    /// Leg object, used for each stretch of a route. /steps/ contains each individual point a turn/action is needed, such as 'turn right' or 'left at the T juntion'.
    /// </summary>
    public class Leg
    {
        /// <summary>
        /// List of Step objects containing each part of the route.
        /// </summary>
        public List<Step> steps { get; set; }
        
        /// <summary>
        /// ???
        /// </summary>
        public string summary { get; set; }

        /// <summary>
        /// Double indicating the estimated travel time in seconds.
        /// </summary>
        public double duration { get; set; }

        /// <summary>
        /// Distance of entire leg in meters.
        /// </summary>
        public double distance { get; set; }

        public Leg()
        {
            steps = new List<Step>();
            summary = string.Empty;
            duration = double.NaN;
            distance = double.NaN;
        }
    }

    /// <summary>
    /// Route object, contains a list of Leg objects and an encoded polyline in the geometry string.
    /// </summary>
    public class Route
    {
        /// <summary>
        /// Collection of Leg objects.
        /// </summary>
        public List<Leg> legs { get; set; }

        /// <summary>
        /// Encoded polyline. Use ValidationUtils.DecodeEncodedPolyline(geometry) to convert it to a List of System.Windows.Points
        /// </summary>
        public string geometry { get; set; }

        /// <summary>
        /// Time for route in seconds.
        /// </summary>
        public double duration { get; set; }

        /// <summary>
        /// Distance for the route in meters.
        /// </summary>
        public double distance { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Route()
        {
            // Construct the properties of the Route object to be empty to avoid exceptions. Use validation checking at a higher level please.
            legs = new List<Leg>();
            geometry = string.Empty;
            duration = double.NaN;
            distance = double.NaN;
        }
    }

    /// <summary>
    /// Waypoints, each specified part of the route (start & end if no "via" points have been queried).
    /// </summary>
    public class Waypoint
    {
        /// <summary>
        /// String, name of the waypoint. Can contain special characters.
        /// </summary>
        public string name { get; set; }

        /// <summary>
        /// Array with point, formatted as longitude, latitude.
        /// </summary>
        public List<double> location { get; set; }

        public Waypoint()
        {
            name = string.Empty;
            location = new List<double>();
        }
    }

    /// <summary>
    /// Route object for the Mapbox Directions route. 
    /// </summary>
    public class MapboxRoute
    {
        /// <summary>
        /// Collection of all routes generated.
        /// </summary>
        public List<Route> routes { get; set; }

        /// <summary>
        /// Significant points along the generated route(s).
        /// </summary>
        public List<Waypoint> waypoints { get; set; }

        /// <summary>
        /// Response code to flag whether the GET request worked as intended or not. 
        /// </summary>
        public string code { get; set; }

        public MapboxRoute()
        {
            routes = new List<Route>();
            waypoints = new List<Waypoint>();
            code = string.Empty;
        }
    }
}
