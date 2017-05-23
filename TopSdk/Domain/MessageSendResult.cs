using System;
using System.Xml.Serialization;

namespace Top.Api.Domain
{
    /// <summary>
    /// MessageSendResult Data Structure.
    /// </summary>
    [Serializable]
    public class MessageSendResult : TopObject
    {
        /// <summary>
        /// 错误码
        /// </summary>
        [XmlElement("err_code")]
        public string ErrCode { get; set; }

        /// <summary>
        /// 错误描述
        /// </summary>
        [XmlElement("err_msg")]
        public string ErrMsg { get; set; }

        /// <summary>
        /// 发送结果
        /// </summary>
        [XmlElement("is_success")]
        public string IsSuccess { get; set; }

        /// <summary>
        /// nick
        /// </summary>
        [XmlElement("nick")]
        public string Nick { get; set; }
    }
}
