using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Top.Api.Response
{
    /// <summary>
    /// TmallItemDescModulesGetResponse.
    /// </summary>
    public class TmallItemDescModulesGetResponse : TopResponse
    {
        /// <summary>
        /// 返回描述模块信息
        /// </summary>
        [XmlElement("modular_desc_info")]
        public Top.Api.Domain.ModularDescInfo ModularDescInfo { get; set; }

    }
}
