using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapboxSharp.APIs
{
    public class RouteSettings
    {
        public RouteProfiles Profile { get; set; }
        public double StartLon { get; set; }
        public double StartLat { get; set; }
        public double EndLon { get; set; }
        public double EndLat { get; set; }
        public List<DirectionsOptions> Options = null;

        public List<System.Windows.Point> NavigateVia = new List<System.Windows.Point>();

        private string UrlGenerator()
        {
            if (Options?.Count >= 1)
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("?");

                foreach (var option in Options)
                {
                    sb.Append(option + "&");
                }

                return string.Empty;
            }

            return $"directions/v5/{Profile}/{StartLon},{StartLat};{EndLon},{EndLat}{MapboxSharp.ApiKey}";
        }
    }

    public enum DirectionsOptions
    {
        
    }

    public enum RouteProfiles
    {
        Driving,
        Walking,
        Cycling
    }
}
