using System;
using System.Xml.Serialization;

namespace Top.Api.Domain
{
    /// <summary>
    /// CommonResult Data Structure.
    /// </summary>
    [Serializable]
    public class CommonResult : TopObject
    {
        /// <summary>
        /// 错误码
        /// </summary>
        [XmlElement("code")]
        public string Code { get; set; }

        /// <summary>
        /// 创建的互动实例
        /// </summary>
        [XmlElement("data")]
        public Top.Api.Domain.InteractDTO Data { get; set; }

        /// <summary>
        /// 错误描述
        /// </summary>
        [XmlElement("msg")]
        public string Msg { get; set; }

        /// <summary>
        /// 是否调用成功
        /// </summary>
        [XmlElement("succ")]
        public bool Succ { get; set; }
    }
}
