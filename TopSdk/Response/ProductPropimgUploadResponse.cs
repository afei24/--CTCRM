using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Top.Api.Response
{
    /// <summary>
    /// ProductPropimgUploadResponse.
    /// </summary>
    public class ProductPropimgUploadResponse : TopResponse
    {
        /// <summary>
        /// 支持返回产品属性图片中的：url,id,created,modified
        /// </summary>
        [XmlElement("product_prop_img")]
        public Top.Api.Domain.ProductPropImg ProductPropImg { get; set; }

    }
}
