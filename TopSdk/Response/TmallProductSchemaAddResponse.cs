using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Top.Api.Response
{
    /// <summary>
    /// TmallProductSchemaAddResponse.
    /// </summary>
    public class TmallProductSchemaAddResponse : TopResponse
    {
        /// <summary>
        /// 新发产品结果
        /// </summary>
        [XmlElement("add_product_result")]
        public string AddProductResult { get; set; }

    }
}
