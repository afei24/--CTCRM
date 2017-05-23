using System;
using System.Collections.Generic;
using Top.Api.Util;

namespace Top.Api.Request
{
    /// <summary>
    /// TOP API: taobao.items.seller.list.get
    /// </summary>
    public class ItemsSellerListGetRequest : BaseTopRequest<Top.Api.Response.ItemsSellerListGetResponse>
    {
        /// <summary>
        /// 需要返回的商品字段列表。可选值：点击返回结果中的Item结构体中能展示出来的所有字段，多个字段用“,”分隔。注：返回所有sku信息的字段名称是sku而不是skus。
        /// </summary>
        public string Fields { get; set; }

        /// <summary>
        /// 商品ID列表，多个ID用半角逗号隔开，一次最多不超过20个。注：获取不存在的商品ID或获取别人的商品都不会报错，但没有商品数据返回。
        /// </summary>
        public string NumIids { get; set; }

        #region ITopRequest Members

        public override string GetApiName()
        {
            return "taobao.items.seller.list.get";
        }

        public override IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("fields", this.Fields);
            parameters.Add("num_iids", this.NumIids);
            if (this.otherParams != null)
            {
                parameters.AddAll(this.otherParams);
            }
            return parameters;
        }

        public override void Validate()
        {
            RequestValidator.ValidateRequired("fields", this.Fields);
            RequestValidator.ValidateRequired("num_iids", this.NumIids);
            RequestValidator.ValidateMaxListSize("num_iids", this.NumIids, 20);
        }

        #endregion
    }
}
