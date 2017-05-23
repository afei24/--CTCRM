using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Top.Api.Response
{
    /// <summary>
    /// TmallProductUpdateSchemaGetResponse.
    /// </summary>
    public class TmallProductUpdateSchemaGetResponse : TopResponse
    {
        /// <summary>
        /// 参数产品ID对产品的更新规则
        /// </summary>
        [XmlElement("update_product_schema")]
        public string UpdateProductSchema { get; set; }

    }
}
