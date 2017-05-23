using System;
using System.Collections.Generic;
using Top.Api.Util;

namespace Top.Api.Request
{
    /// <summary>
    /// TOP API: taobao.logistics.address.remove
    /// </summary>
    public class LogisticsAddressRemoveRequest : BaseTopRequest<Top.Api.Response.LogisticsAddressRemoveResponse>
    {
        /// <summary>
        /// 地址库ID
        /// </summary>
        public Nullable<long> ContactId { get; set; }

        #region ITopRequest Members

        public override string GetApiName()
        {
            return "taobao.logistics.address.remove";
        }

        public override IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("contact_id", this.ContactId);
            if (this.otherParams != null)
            {
                parameters.AddAll(this.otherParams);
            }
            return parameters;
        }

        public override void Validate()
        {
            RequestValidator.ValidateRequired("contact_id", this.ContactId);
        }

        #endregion
    }
}
