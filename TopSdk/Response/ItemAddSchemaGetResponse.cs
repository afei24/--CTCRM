using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Top.Api.Response
{
    /// <summary>
    /// ItemAddSchemaGetResponse.
    /// </summary>
    public class ItemAddSchemaGetResponse : TopResponse
    {
        /// <summary>
        /// 返回结果的集合
        /// </summary>
        [XmlElement("add_rules")]
        public string AddRules { get; set; }

    }
}
