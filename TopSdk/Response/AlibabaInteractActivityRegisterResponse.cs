using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Top.Api.Response
{
    /// <summary>
    /// AlibabaInteractActivityRegisterResponse.
    /// </summary>
    public class AlibabaInteractActivityRegisterResponse : TopResponse
    {
        /// <summary>
        /// 活动注册成功，将活动注册后的ID和h5链接返回给调用方
        /// </summary>
        [XmlElement("register_sucess_info")]
        public Top.Api.Domain.AllsparkResult RegisterSucessInfo { get; set; }

    }
}
