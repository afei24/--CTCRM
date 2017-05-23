using System;
using System.Xml.Serialization;

namespace Top.Api.Domain
{
    /// <summary>
    /// JangoCode Data Structure.
    /// </summary>
    [Serializable]
    public class JangoCode : TopObject
    {
        /// <summary>
        /// code
        /// </summary>
        [XmlElement("code")]
        public string Code { get; set; }

        /// <summary>
        /// resource
        /// </summary>
        [XmlElement("resource")]
        public string Resource { get; set; }
    }
}
