using System;
using System.Collections.Generic;
using Top.Api.Util;

namespace Top.Api.Request
{
    /// <summary>
    /// TOP API: taobao.traderate.explain.add
    /// </summary>
    public class TraderateExplainAddRequest : BaseTopRequest<Top.Api.Response.TraderateExplainAddResponse>
    {
        /// <summary>
        /// 子订单ID
        /// </summary>
        public Nullable<long> Oid { get; set; }

        /// <summary>
        /// 评价解释内容,最大长度: 500个汉字
        /// </summary>
        public string Reply { get; set; }

        #region ITopRequest Members

        public override string GetApiName()
        {
            return "taobao.traderate.explain.add";
        }

        public override IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("oid", this.Oid);
            parameters.Add("reply", this.Reply);
            if (this.otherParams != null)
            {
                parameters.AddAll(this.otherParams);
            }
            return parameters;
        }

        public override void Validate()
        {
            RequestValidator.ValidateRequired("oid", this.Oid);
            RequestValidator.ValidateRequired("reply", this.Reply);
        }

        #endregion
    }
}
