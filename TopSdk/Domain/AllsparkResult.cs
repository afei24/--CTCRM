using System;
using System.Xml.Serialization;

namespace Top.Api.Domain
{
    /// <summary>
    /// AllsparkResult Data Structure.
    /// </summary>
    [Serializable]
    public class AllsparkResult : TopObject
    {
        /// <summary>
        /// 服务结果对象
        /// </summary>
        [XmlElement("data")]
        public Top.Api.Domain.ActivityWriteResult Data { get; set; }

        /// <summary>
        /// 出错代码
        /// </summary>
        [XmlElement("err_code")]
        public string ErrCode { get; set; }

        /// <summary>
        /// 出错提示
        /// </summary>
        [XmlElement("err_msg")]
        public string ErrMsg { get; set; }

        /// <summary>
        /// 是否注册成功
        /// </summary>
        [XmlElement("success")]
        public bool Success { get; set; }
    }
}
