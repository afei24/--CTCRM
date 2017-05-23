using System;
using System.Collections.Generic;
using Top.Api.Util;

namespace Top.Api.Request
{
    /// <summary>
    /// TOP API: taobao.item.seller.get
    /// </summary>
    public class ItemSellerGetRequest : BaseTopRequest<Top.Api.Response.ItemSellerGetResponse>
    {
        /// <summary>
        /// 需要返回的商品字段列表。可选值：Item商品结构体中所有字段均可返回，多个字段用“,”分隔。
        /// </summary>
        public string Fields { get; set; }

        /// <summary>
        /// 商品数字ID
        /// </summary>
        public Nullable<long> NumIid { get; set; }

        #region ITopRequest Members

        public override string GetApiName()
        {
            return "taobao.item.seller.get";
        }

        public override IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("fields", this.Fields);
            parameters.Add("num_iid", this.NumIid);
            if (this.otherParams != null)
            {
                parameters.AddAll(this.otherParams);
            }
            return parameters;
        }

        public override void Validate()
        {
            RequestValidator.ValidateRequired("fields", this.Fields);
            RequestValidator.ValidateRequired("num_iid", this.NumIid);
            RequestValidator.ValidateMinValue("num_iid", this.NumIid, 1);
        }

        #endregion
    }
}
