using System;
using System.Collections.Generic;
using Top.Api.Util;

namespace Top.Api.Request
{
    /// <summary>
    /// TOP API: taobao.scitem.map.delete
    /// </summary>
    public class ScitemMapDeleteRequest : BaseTopRequest<Top.Api.Response.ScitemMapDeleteResponse>
    {
        /// <summary>
        /// 后台商品ID
        /// </summary>
        public Nullable<long> ScItemId { get; set; }

        /// <summary>
        /// 店铺用户nick。 如果该参数为空则删除后端商品与当前调用人的商品映射关系;如果不为空则删除指定用户与后端商品的映射关系
        /// </summary>
        public string UserNick { get; set; }

        #region ITopRequest Members

        public override string GetApiName()
        {
            return "taobao.scitem.map.delete";
        }

        public override IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("sc_item_id", this.ScItemId);
            parameters.Add("user_nick", this.UserNick);
            if (this.otherParams != null)
            {
                parameters.AddAll(this.otherParams);
            }
            return parameters;
        }

        public override void Validate()
        {
            RequestValidator.ValidateRequired("sc_item_id", this.ScItemId);
        }

        #endregion
    }
}
