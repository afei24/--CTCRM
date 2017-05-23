using System;
using System.Collections.Generic;
using Top.Api.Util;

namespace Top.Api.Request
{
    /// <summary>
    /// TOP API: taobao.item.anchor.get
    /// </summary>
    public class ItemAnchorGetRequest : BaseTopRequest<Top.Api.Response.ItemAnchorGetResponse>
    {
        /// <summary>
        /// 对应类目编号
        /// </summary>
        public Nullable<long> CatId { get; set; }

        /// <summary>
        /// 宝贝模板类型是人工打标还是自动打标：人工打标为1，自动打标为0.人工和自动打标为-1.
        /// </summary>
        public Nullable<long> Type { get; set; }

        #region ITopRequest Members

        public override string GetApiName()
        {
            return "taobao.item.anchor.get";
        }

        public override IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("cat_id", this.CatId);
            parameters.Add("type", this.Type);
            if (this.otherParams != null)
            {
                parameters.AddAll(this.otherParams);
            }
            return parameters;
        }

        public override void Validate()
        {
            RequestValidator.ValidateRequired("cat_id", this.CatId);
            RequestValidator.ValidateRequired("type", this.Type);
            RequestValidator.ValidateMaxValue("type", this.Type, 1);
            RequestValidator.ValidateMinValue("type", this.Type, -1);
        }

        #endregion
    }
}
