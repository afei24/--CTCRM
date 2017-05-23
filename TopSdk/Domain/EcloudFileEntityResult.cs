using System;
using System.Xml.Serialization;

namespace Top.Api.Domain
{
    /// <summary>
    /// EcloudFileEntityResult Data Structure.
    /// </summary>
    [Serializable]
    public class EcloudFileEntityResult : TopObject
    {
        /// <summary>
        /// model文件
        /// </summary>
        [XmlElement("model")]
        public Top.Api.Domain.FileEntity Model { get; set; }

        /// <summary>
        /// msg_code
        /// </summary>
        [XmlElement("msg_code")]
        public string MsgCode { get; set; }

        /// <summary>
        /// msg_info
        /// </summary>
        [XmlElement("msg_info")]
        public string MsgInfo { get; set; }
    }
}
