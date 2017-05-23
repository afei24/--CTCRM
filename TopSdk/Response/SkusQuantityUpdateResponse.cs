using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Top.Api.Response
{
    /// <summary>
    /// SkusQuantityUpdateResponse.
    /// </summary>
    public class SkusQuantityUpdateResponse : TopResponse
    {
        /// <summary>
        /// iid、numIid、num和modified，skus中每个sku的skuId、quantity和modified
        /// </summary>
        [XmlElement("item")]
        public Top.Api.Domain.Item Item { get; set; }

    }
}
