using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Top.Api.Response
{
    /// <summary>
    /// FuwuSkuGetResponse.
    /// </summary>
    public class FuwuSkuGetResponse : TopResponse
    {
        /// <summary>
        /// 内购服务及SKU详情
        /// </summary>
        [XmlElement("result")]
        public Top.Api.Domain.ArticleViewResult Result { get; set; }

    }
}
