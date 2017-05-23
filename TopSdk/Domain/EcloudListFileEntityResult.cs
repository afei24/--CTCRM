using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Top.Api.Domain
{
    /// <summary>
    /// EcloudListFileEntityResult Data Structure.
    /// </summary>
    [Serializable]
    public class EcloudListFileEntityResult : TopObject
    {
        /// <summary>
        /// 错误码
        /// </summary>
        [XmlElement("msg_code")]
        public string MsgCode { get; set; }

        /// <summary>
        /// 错误描述
        /// </summary>
        [XmlElement("msg_info")]
        public string MsgInfo { get; set; }

        /// <summary>
        /// 文件列表
        /// </summary>
        [XmlArray("objects")]
        [XmlArrayItem("file_entity")]
        public List<Top.Api.Domain.FileEntity> Objects { get; set; }
    }
}
