using System;
using System.Collections.Generic;
using Top.Api.Util;

namespace Top.Api.Request
{
    /// <summary>
    /// TOP API: alibaba.interact.tida.get.materialid
    /// </summary>
    public class AlibabaInteractTidaGetMaterialidRequest : BaseTopRequest<Top.Api.Response.AlibabaInteractTidaGetMaterialidResponse>
    {
        /// <summary>
        /// itemId和skuId二元组的列表
        /// </summary>
        public string ItemidSkuids { get; set; }

        #region ITopRequest Members

        public override string GetApiName()
        {
            return "alibaba.interact.tida.get.materialid";
        }

        public override IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("itemid_skuids", this.ItemidSkuids);
            if (this.otherParams != null)
            {
                parameters.AddAll(this.otherParams);
            }
            return parameters;
        }

        public override void Validate()
        {
            RequestValidator.ValidateRequired("itemid_skuids", this.ItemidSkuids);
        }

        #endregion
    }
}
