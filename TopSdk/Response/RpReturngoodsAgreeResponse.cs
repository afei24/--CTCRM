using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Top.Api.Response
{
    /// <summary>
    /// RpReturngoodsAgreeResponse.
    /// </summary>
    public class RpReturngoodsAgreeResponse : TopResponse
    {
        /// <summary>
        /// 操作成功
        /// </summary>
        [XmlElement("is_success")]
        public bool IsSuccess { get; set; }

    }
}
