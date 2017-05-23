using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Top.Api.Response
{
    /// <summary>
    /// RpRefundReviewResponse.
    /// </summary>
    public class RpRefundReviewResponse : TopResponse
    {
        /// <summary>
        /// 审核操作是否成功
        /// </summary>
        [XmlElement("is_success")]
        public bool IsSuccess { get; set; }

    }
}
