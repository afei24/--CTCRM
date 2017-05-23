using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Top.Api.Response
{
    /// <summary>
    /// RpReturngoodsRefillResponse.
    /// </summary>
    public class RpReturngoodsRefillResponse : TopResponse
    {
        /// <summary>
        /// 验货操作是否成功
        /// </summary>
        [XmlElement("is_success")]
        public bool IsSuccess { get; set; }

    }
}
