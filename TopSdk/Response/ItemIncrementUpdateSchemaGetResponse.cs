using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Top.Api.Response
{
    /// <summary>
    /// ItemIncrementUpdateSchemaGetResponse.
    /// </summary>
    public class ItemIncrementUpdateSchemaGetResponse : TopResponse
    {
        /// <summary>
        /// 返回的结果集
        /// </summary>
        [XmlElement("update_rules")]
        public string UpdateRules { get; set; }

    }
}
