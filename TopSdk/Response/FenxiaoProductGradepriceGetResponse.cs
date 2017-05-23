using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Top.Api.Response
{
    /// <summary>
    /// FenxiaoProductGradepriceGetResponse.
    /// </summary>
    public class FenxiaoProductGradepriceGetResponse : TopResponse
    {
        /// <summary>
        /// 等级折扣列表
        /// </summary>
        [XmlArray("grade_discounts")]
        [XmlArrayItem("grade_discount")]
        public List<Top.Api.Domain.GradeDiscount> GradeDiscounts { get; set; }

        /// <summary>
        /// 操作是否成功
        /// </summary>
        [XmlElement("is_success")]
        public bool IsSuccess { get; set; }

    }
}
