using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Top.Api.Response
{
    /// <summary>
    /// TmallProductSpecAddResponse.
    /// </summary>
    public class TmallProductSpecAddResponse : TopResponse
    {
        /// <summary>
        /// 产品规格对象
        /// </summary>
        [XmlElement("product_spec")]
        public Top.Api.Domain.ProductSpec ProductSpec { get; set; }

    }
}
