using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Top.Api.Response
{
    /// <summary>
    /// PromotionMealGetResponse.
    /// </summary>
    public class PromotionMealGetResponse : TopResponse
    {
        /// <summary>
        /// 搭配套餐列表。
        /// </summary>
        [XmlArray("meal_list")]
        [XmlArrayItem("meal")]
        public List<Top.Api.Domain.Meal> MealList { get; set; }

    }
}
