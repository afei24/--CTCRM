using System;
using System.Collections.Generic;
using Top.Api.Util;

namespace Top.Api.Request
{
    /// <summary>
    /// TOP API: taobao.categoryrecommend.items.get
    /// </summary>
    public class CategoryrecommendItemsGetRequest : BaseTopRequest<Top.Api.Response.CategoryrecommendItemsGetResponse>
    {
        /// <summary>
        /// 传入叶子类目ID
        /// </summary>
        public Nullable<long> CategoryId { get; set; }

        /// <summary>
        /// 请求个数，建议获取20个
        /// </summary>
        public Nullable<long> Count { get; set; }

        /// <summary>
        /// 额外参数
        /// </summary>
        public string Ext { get; set; }

        /// <summary>
        /// 请求类型，1：类目下热门商品推荐。其他值当非法值处理
        /// </summary>
        public Nullable<long> RecommendType { get; set; }

        #region ITopRequest Members

        public override string GetApiName()
        {
            return "taobao.categoryrecommend.items.get";
        }

        public override IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("category_id", this.CategoryId);
            parameters.Add("count", this.Count);
            parameters.Add("ext", this.Ext);
            parameters.Add("recommend_type", this.RecommendType);
            if (this.otherParams != null)
            {
                parameters.AddAll(this.otherParams);
            }
            return parameters;
        }

        public override void Validate()
        {
            RequestValidator.ValidateRequired("category_id", this.CategoryId);
            RequestValidator.ValidateRequired("count", this.Count);
            RequestValidator.ValidateRequired("recommend_type", this.RecommendType);
        }

        #endregion
    }
}
