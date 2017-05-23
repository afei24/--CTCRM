using System;
using System.Collections.Generic;
using Top.Api.Util;

namespace Top.Api.Request
{
    /// <summary>
    /// TOP API: cainiao.openstorage.isv.resourcedetail.get
    /// </summary>
    public class CainiaoOpenstorageIsvResourcedetailGetRequest : BaseTopRequest<Top.Api.Response.CainiaoOpenstorageIsvResourcedetailGetResponse>
    {
        /// <summary>
        /// isv资源id
        /// </summary>
        public Nullable<long> IsvResourceId { get; set; }

        #region ITopRequest Members

        public override string GetApiName()
        {
            return "cainiao.openstorage.isv.resourcedetail.get";
        }

        public override IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("isv_resource_id", this.IsvResourceId);
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
