using System;
using System.Xml.Serialization;

namespace Top.Api.Domain
{
    /// <summary>
    /// MessageInfo Data Structure.
    /// </summary>
    [Serializable]
    public class MessageInfo : TopObject
    {
        /// <summary>
        /// 最新的一个消息
        /// </summary>
        [XmlElement("last_msg")]
        public string LastMsg { get; set; }

        /// <summary>
        /// 资源的数量
        /// </summary>
        [XmlElement("number")]
        public long Number { get; set; }

        /// <summary>
        /// 子账号userid
        /// </summary>
        [XmlElement("sub_user_id")]
        public string SubUserId { get; set; }

        /// <summary>
        /// 业务类型，比如：item表示商品
        /// </summary>
        [XmlElement("topic")]
        public string Topic { get; set; }

        /// <summary>
        /// 总数
        /// </summary>
        [XmlElement("total")]
        public long Total { get; set; }

        /// <summary>
        /// 主账号userid
        /// </summary>
        [XmlElement("user_id")]
        public string UserId { get; set; }
    }
}
