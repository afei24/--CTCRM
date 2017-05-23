using System;
using System.Xml.Serialization;

namespace Top.Api.Domain
{
    /// <summary>
    /// EcloudJangoCodeResult Data Structure.
    /// </summary>
    [Serializable]
    public class EcloudJangoCodeResult : TopObject
    {
        /// <summary>
        /// JangoCode信息表
        /// </summary>
        [XmlElement("model")]
        public Top.Api.Domain.JangoCode Model { get; set; }

        /// <summary>
        /// 错误码
        /// </summary>
        [XmlElement("msg_code")]
        public string MsgCode { get; set; }

        /// <summary>
        /// 错误信息
        /// </summary>
        [XmlElement("msg_info")]
        public string MsgInfo { get; set; }
    }
}
