using System;
using System.Collections.Generic;
using Top.Api.Util;

namespace Top.Api.Request
{
    /// <summary>
    /// TOP API: taobao.promotion.meal.get
    /// </summary>
    public class PromotionMealGetRequest : BaseTopRequest<Top.Api.Response.PromotionMealGetResponse>
    {
        /// <summary>
        /// 搭配套餐id
        /// </summary>
        public Nullable<long> MealId { get; set; }

        /// <summary>
        /// 套餐状态。有效：VALID;失效：INVALID(有效套餐为可使用的套餐,无效套餐为套餐中有商品下架或库存为0时)。默认时两种情况都会查询。
        /// </summary>
        public string Status { get; set; }

        #region ITopRequest Members

        public override string GetApiName()
        {
            return "taobao.promotion.meal.get";
        }

        public override IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("meal_id", this.MealId);
            parameters.Add("status", this.Status);
            if (this.otherParams != null)
            {
                parameters.AddAll(this.otherParams);
            }
            return parameters;
        }

        public override void Validate()
        {
        }

        #endregion
    }
}
