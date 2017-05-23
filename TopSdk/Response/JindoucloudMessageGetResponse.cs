using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Top.Api.Response
{
    /// <summary>
    /// JindoucloudMessageGetResponse.
    /// </summary>
    public class JindoucloudMessageGetResponse : TopResponse
    {
        /// <summary>
        /// 服务器取数据的结束时间
        /// </summary>
        [XmlElement("end_modified")]
        public string EndModified { get; set; }

        /// <summary>
        /// 返回的数据中序列号的最大值，可能为null
        /// </summary>
        [XmlElement("end_seq")]
        public long EndSeq { get; set; }

        /// <summary>
        /// 消息列表
        /// </summary>
        [XmlArray("messages")]
        [XmlArrayItem("string")]
        public List<string> Messages { get; set; }

        /// <summary>
        /// 服务器取数据的开始时间
        /// </summary>
        [XmlElement("start_modified")]
        public string StartModified { get; set; }

        /// <summary>
        /// 返回的数据中序列号的最小值，可能为null
        /// </summary>
        [XmlElement("start_seq")]
        public long StartSeq { get; set; }

    }
}
