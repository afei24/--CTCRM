using System;
using System.Xml.Serialization;

namespace Top.Api.Domain
{
    /// <summary>
    /// DashboardRealtimeLowBO Data Structure.
    /// </summary>
    [Serializable]
    public class DashboardRealtimeLowBO : TopObject
    {
        /// <summary>
        /// 客单价
        /// </summary>
        [XmlElement("pct_all")]
        public string PctAll { get; set; }

        /// <summary>
        /// PC端客单价
        /// </summary>
        [XmlElement("pct_pc")]
        public string PctPc { get; set; }

        /// <summary>
        /// 无线端客单价
        /// </summary>
        [XmlElement("pct_wireless")]
        public string PctWireless { get; set; }

        /// <summary>
        /// PV
        /// </summary>
        [XmlElement("pv_all")]
        public long PvAll { get; set; }

        /// <summary>
        /// PC端PV
        /// </summary>
        [XmlElement("pv_pc")]
        public long PvPc { get; set; }

        /// <summary>
        /// 无线端PV
        /// </summary>
        [XmlElement("pv_wireless")]
        public long PvWireless { get; set; }

        /// <summary>
        /// UV
        /// </summary>
        [XmlElement("uv_all")]
        public long UvAll { get; set; }

        /// <summary>
        /// PC端UV
        /// </summary>
        [XmlElement("uv_pc")]
        public long UvPc { get; set; }

        /// <summary>
        /// 无线端UV
        /// </summary>
        [XmlElement("uv_wireless")]
        public long UvWireless { get; set; }
    }
}
