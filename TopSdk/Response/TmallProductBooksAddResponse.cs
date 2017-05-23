using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Top.Api.Response
{
    /// <summary>
    /// TmallProductBooksAddResponse.
    /// </summary>
    public class TmallProductBooksAddResponse : TopResponse
    {
        /// <summary>
        /// 请求相应结构
        /// </summary>
        [XmlElement("product_books")]
        public Top.Api.Domain.ProductBooks ProductBooks { get; set; }

    }
}
