using System;
using System.Xml.Serialization;

namespace Top.Api.Domain
{
    /// <summary>
    /// EcloudStringResult Data Structure.
    /// </summary>
    [Serializable]
    public class EcloudStringResult : TopObject
    {
        /// <summary>
        /// 返回值内容
        /// </summary>
        [XmlElement("model")]
        public string Model { get; set; }

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
