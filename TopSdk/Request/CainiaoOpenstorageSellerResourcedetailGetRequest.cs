using System;
using System.Collections.Generic;
using Top.Api.Util;

namespace Top.Api.Request
{
    /// <summary>
    /// TOP API: cainiao.openstorage.seller.resourcedetail.get
    /// </summary>
    public class CainiaoOpenstorageSellerResourcedetailGetRequest : BaseTopRequest<Top.Api.Response.CainiaoOpenstorageSellerResourcedetailGetResponse>
    {
        /// <summary>
        /// 商家资源id
        /// </summary>
        public Nullable<long> SellerResourceId { get; set; }

        #region ITopRequest Members

        public override string GetApiName()
        {
            return "cainiao.openstorage.seller.resourcedetail.get";
        }

        public override IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("seller_resource_id", this.SellerResourceId);
            if (this.otherParams != null)
            {
                parameters.AddAll(this.otherParams);
            }
            return parameters;
        }

        public override void Validate()
        {
        }

        #endregion
    }
}
