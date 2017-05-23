using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Top.Api.Response
{
    /// <summary>
    /// AlibabaInteractActivityApplyResponse.
    /// </summary>
    public class AlibabaInteractActivityApplyResponse : TopResponse
    {
        /// <summary>
        /// 服务结果对象
        /// </summary>
        [XmlElement("data")]
        public Top.Api.Domain.ActivityWriteResult Data { get; set; }

        /// <summary>
        /// 出错提示信息
        /// </summary>
        [XmlElement("err_msg")]
        public string ErrMsg { get; set; }

        /// <summary>
        /// top接口执行成功与否
        /// </summary>
        [XmlElement("is_success")]
        public bool IsSuccess { get; set; }

    }
}
