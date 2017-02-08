using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapboxSharp.APIs
{
    /// <summary>
    /// Contains the temporary credentials for the S3 bucket used for the uploads API.
    /// </summary>
    public class AwsCredentials
    {
        /// <summary>
        /// AWS access key ID
        /// </summary>
        public string accessKeyId { get; set; }

        /// <summary>
        /// S3 Bucket name
        /// </summary>
        public string bucket { get; set; }

        /// <summary>
        /// Unique key for data to be staged
        /// </summary>
        public string key { get; set; }

        /// <summary>
        /// AWS secret access key
        /// </summary>
        public string secretAccessKey { get; set; }

        /// <summary>
        /// Temporary security token
        /// </summary>
        public string sessionToken { get; set; }

        /// <summary>
        /// Destination URL for the file..
        /// </summary>
        public string url { get; set; }
    }
}
