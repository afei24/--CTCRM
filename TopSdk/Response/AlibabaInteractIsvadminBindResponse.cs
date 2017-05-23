using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Top.Api.Response
{
    /// <summary>
    /// AlibabaInteractIsvadminBindResponse.
    /// </summary>
    public class AlibabaInteractIsvadminBindResponse : TopResponse
    {
        /// <summary>
        /// 返回创建并且绑定成功的互动实例
        /// </summary>
        [XmlElement("result")]
        public Top.Api.Domain.CommonResult Result { get; set; }

    }
}
