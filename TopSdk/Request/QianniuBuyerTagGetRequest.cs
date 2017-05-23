using System;
using System.Collections.Generic;
using Top.Api.Util;

namespace Top.Api.Request
{
    /// <summary>
    /// TOP API: taobao.qianniu.buyer.tag.get
    /// </summary>
    public class QianniuBuyerTagGetRequest : BaseTopRequest<Top.Api.Response.QianniuBuyerTagGetResponse>
    {
        /// <summary>
        /// 买家nick
        /// </summary>
        public string BuyerNick { get; set; }

        /// <summary>
        /// 支持的表，多个tag用英文逗号切割
        /// </summary>
        public string TagList { get; set; }

        #region ITopRequest Members

        public override string GetApiName()
        {
            return "taobao.qianniu.buyer.tag.get";
        }

        public override IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("buyer_nick", this.BuyerNick);
            parameters.Add("tag_list", this.TagList);
            if (this.otherParams != null)
            {
                parameters.AddAll(this.otherParams);
            }
            return parameters;
        }

        public override void Validate()
        {
            RequestValidator.ValidateRequired("buyer_nick", this.BuyerNick);
            RequestValidator.ValidateRequired("tag_list", this.TagList);
        }

        #endregion
    }
}
