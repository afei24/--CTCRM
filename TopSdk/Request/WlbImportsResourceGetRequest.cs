using System;
using System.Xml.Serialization;
using Top.Api.Domain;
using System.Collections.Generic;
using Top.Api.Util;

namespace Top.Api.Request
{
    /// <summary>
    /// TOP API: taobao.wlb.imports.resource.get
    /// </summary>
    public class WlbImportsResourceGetRequest : BaseTopRequest<Top.Api.Response.WlbImportsResourceGetResponse>
    {
        /// <summary>
        /// 卖家发货地区域ID
        /// </summary>
        public Nullable<long> FromId { get; set; }

        /// <summary>
        /// 买家收货地信息
        /// </summary>
        public string ToAddress { get; set; }

        public ReciverAddressDo ToAddress_ { set { this.ToAddress = TopUtils.ObjectToJson(value); } } 

        #region ITopRequest Members

        public override string GetApiName()
        {
            return "taobao.wlb.imports.resource.get";
        }

        public override IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("from_id", this.FromId);
            parameters.Add("to_address", this.ToAddress);
            if (this.otherParams != null)
            {
                parameters.AddAll(this.otherParams);
            }
            return parameters;
        }

        public override void Validate()
        {
            RequestValidator.ValidateRequired("from_id", this.FromId);
            RequestValidator.ValidateRequired("to_address", this.ToAddress);
        }

        #endregion
    }
}
