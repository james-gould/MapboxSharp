using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MapboxSharp.Utilities
{
    /// <summary>
    /// Static validation methods for a variety of inputs.
    /// </summary>
    public static class ValidationUtils
    {
        /// <summary>
        /// Mapbox accepts WGS84 coordinates in (lon, lat) format. 
        /// </summary>
        /// <param name="lon"></param>
        /// <param name="lat"></param>
        /// <returns></returns>
        public static bool ValidLonLat(double lon, double lat)
        {
            return (lat >= -90 && lat <= 90) && (lon >= -180 && lon <= 180);
        }

        /// <summary>
        /// Decodes a polyline that have been encoded using Google's Encoded Polyline algorithm.
        /// </summary>
        /// <param name="polyline">Encoded polyline string, typically from OSRM.</param>
        /// <returns>List of System.Windows.Points as a polyline</returns>
        public static List<Point> DecodeEncodedPolyline(string polyline)
        {

            if (String.IsNullOrEmpty(polyline)) return null;

            List<Point> polylineList = new List<Point>();

            char[] polylinechars = polyline.ToCharArray();
            int index = 0;

            int currentLat = 0;
            int currentLng = 0;

            try
            {
                while (index < polylinechars.Length)
                {
                    // calculate next latitude
                    int sum = 0;
                    int shifter = 0;
                    int next5bits;
                    do
                    {
                        next5bits = polylinechars[index++] - 63;
                        sum |= (next5bits & 31) << shifter;
                        shifter += 5;
                    } while (next5bits >= 32 && index < polylinechars.Length);

                    if (index >= polylinechars.Length)
                        break;

                    currentLat += (sum & 1) == 1 ? ~(sum >> 1) : sum >> 1;

                    //calculate next longitude
                    sum = 0;
                    shifter = 0;
                    do
                    {
                        next5bits = polylinechars[index++] - 63;
                        sum |= (next5bits & 31) << shifter;
                        shifter += 5;
                    } while (next5bits >= 32 && index < polylinechars.Length);

                    if (index >= polylinechars.Length && next5bits >= 32)
                        break;

                    currentLng += (sum & 1) == 1 ? ~(sum >> 1) : sum >> 1;

                    Point p = new Point
                    {
                        Y = Convert.ToDouble(currentLat) / 100000.0,
                        X = Convert.ToDouble(currentLng) / 100000.0
                    };
                    polylineList.Add(p);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error building polyline list");
                Console.Write(e.StackTrace);

                polylineList = new List<Point>();
            }

            return polylineList;
        }
    }
}
