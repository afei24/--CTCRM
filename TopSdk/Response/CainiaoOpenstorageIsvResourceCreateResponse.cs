using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Top.Api.Response
{
    /// <summary>
    /// CainiaoOpenstorageIsvResourceCreateResponse.
    /// </summary>
    public class CainiaoOpenstorageIsvResourceCreateResponse : TopResponse
    {
        /// <summary>
        /// 错误码
        /// </summary>
        [XmlElement("err_code")]
        public string ErrCode { get; set; }

        /// <summary>
        /// 错误消息
        /// </summary>
        [XmlElement("err_message")]
        public string ErrMessage { get; set; }

    }
}
