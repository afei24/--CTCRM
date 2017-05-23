using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Top.Api.Response
{
    /// <summary>
    /// ProductImgDeleteResponse.
    /// </summary>
    public class ProductImgDeleteResponse : TopResponse
    {
        /// <summary>
        /// 返回productimg中的：id,product_id
        /// </summary>
        [XmlElement("product_img")]
        public Top.Api.Domain.ProductImg ProductImg { get; set; }

    }
}
