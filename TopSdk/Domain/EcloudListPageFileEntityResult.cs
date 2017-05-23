using System;
using System.Xml.Serialization;

namespace Top.Api.Domain
{
    /// <summary>
    /// EcloudListPageFileEntityResult Data Structure.
    /// </summary>
    [Serializable]
    public class EcloudListPageFileEntityResult : TopObject
    {
        /// <summary>
        /// 文件列表信息
        /// </summary>
        [XmlElement("model")]
        public Top.Api.Domain.ListPageFileEntity Model { get; set; }

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
