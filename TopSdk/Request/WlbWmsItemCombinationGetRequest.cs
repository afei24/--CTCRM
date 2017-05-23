using System;
using System.Collections.Generic;
using Top.Api.Util;

namespace Top.Api.Request
{
    /// <summary>
    /// TOP API: taobao.wlb.wms.item.combination.get
    /// </summary>
    public class WlbWmsItemCombinationGetRequest : BaseTopRequest<Top.Api.Response.WlbWmsItemCombinationGetResponse>
    {
        /// <summary>
        /// 货品Id
        /// </summary>
        public Nullable<long> Itemid { get; set; }

        #region ITopRequest Members

        public override string GetApiName()
        {
            return "taobao.wlb.wms.item.combination.get";
        }

        public override IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("itemid", this.Itemid);
            if (this.otherParams != null)
            {
                parameters.AddAll(this.otherParams);
            }
            return parameters;
        }

        public override void Validate()
        {
            RequestValidator.ValidateRequired("itemid", this.Itemid);
        }

        #endregion
    }
}
