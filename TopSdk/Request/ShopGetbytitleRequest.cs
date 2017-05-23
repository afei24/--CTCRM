using System;
using System.Collections.Generic;
using Top.Api.Util;

namespace Top.Api.Request
{
    /// <summary>
    /// TOP API: taobao.shop.getbytitle
    /// </summary>
    public class ShopGetbytitleRequest : BaseTopRequest<Top.Api.Response.ShopGetbytitleResponse>
    {
        /// <summary>
        /// 代表需要获取的店铺信息：sid,cid,title,nick,desc,bulletin,pic_path,created,modified,shop_score
        /// </summary>
        public string Fields { get; set; }

        /// <summary>
        /// 店铺名称，必须严格匹配（不支持模糊查询）
        /// </summary>
        public string Title { get; set; }

        #region ITopRequest Members

        public override string GetApiName()
        {
            return "taobao.shop.getbytitle";
        }

        public override IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("fields", this.Fields);
            parameters.Add("title", this.Title);
            if (this.otherParams != null)
            {
                parameters.AddAll(this.otherParams);
            }
            return parameters;
        }

        public override void Validate()
        {
            RequestValidator.ValidateMaxListSize("fields", this.Fields, 20);
            RequestValidator.ValidateRequired("title", this.Title);
        }

        #endregion
    }
}
