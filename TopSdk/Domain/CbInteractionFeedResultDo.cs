using System;
using System.Xml.Serialization;

namespace Top.Api.Domain
{
    /// <summary>
    /// CbInteractionFeedResultDo Data Structure.
    /// </summary>
    [Serializable]
    public class CbInteractionFeedResultDo : TopObject
    {
        /// <summary>
        /// 错误详细信息，如果成功，则为空或者null
        /// </summary>
        [XmlElement("err_msg")]
        public string ErrMsg { get; set; }

        /// <summary>
        /// 错误详细信息，如果成功，则为空或者null
        /// </summary>
        [XmlElement("err_trace")]
        public string ErrTrace { get; set; }

        /// <summary>
        /// 动态内容json
        /// </summary>
        [XmlElement("module")]
        public string Module { get; set; }

        /// <summary>
        /// 错误码，如果成功，则为0
        /// </summary>
        [XmlElement("ret_code")]
        public string RetCode { get; set; }

        /// <summary>
        /// true：调用成功，false：调用失败
        /// </summary>
        [XmlElement("success")]
        public bool Success { get; set; }
    }
}
