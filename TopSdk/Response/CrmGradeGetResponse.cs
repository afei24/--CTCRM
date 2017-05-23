using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Top.Api.Response
{
    /// <summary>
    /// CrmGradeGetResponse.
    /// </summary>
    public class CrmGradeGetResponse : TopResponse
    {
        /// <summary>
        /// 等级信息集合
        /// </summary>
        [XmlArray("grade_promotions")]
        [XmlArrayItem("grade_promotion")]
        public List<Top.Api.Domain.GradePromotion> GradePromotions { get; set; }

    }
}
