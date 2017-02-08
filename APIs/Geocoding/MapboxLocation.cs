using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapboxSharp.APIs
{
    /// <summary>
    /// Additional information for the current Feature
    /// </summary>
    public class Properties
    {
        public string wikidata { get; set; }
    }

    /// <summary>
    /// Geometry for the current Feature
    /// </summary>
    public class Geometry
    {
        public string type { get; set; }
        public List<double> coordinates { get; set; }
    }

    /// <summary>
    /// Identifying information for the current Feature
    /// </summary>
    public class Context
    {
        public string id { get; set; }
        public string text { get; set; }
        public string short_code { get; set; }
        public string wikidata { get; set; }
    }

    /// <summary>
    /// Map features
    /// </summary>
    public class Feature
    {
        public string id { get; set; }
        public string type { get; set; }
        public string text { get; set; }
        public string place_name { get; set; }
        public double relevance { get; set; }
        public Properties properties { get; set; }
        public List<double> bbox { get; set; }
        public List<double> center { get; set; }
        public Geometry geometry { get; set; }
        public List<Context> context { get; set; }
    }

    /// <summary>
    /// Root object for Geocoding GeoJSON responses.
    /// </summary>
    public class MapboxLocation
    {
        public string type { get; set; }
        public List<string> query { get; set; }
        public List<Feature> features { get; set; }
        public string attribution { get; set; }
    }

}
