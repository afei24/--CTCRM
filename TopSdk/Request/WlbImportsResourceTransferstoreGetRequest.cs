using System;
using System.Xml.Serialization;
using Top.Api.Domain;
using System.Collections.Generic;
using Top.Api.Util;

namespace Top.Api.Request
{
    /// <summary>
    /// TOP API: taobao.wlb.imports.resource.transferstore.get
    /// </summary>
    public class WlbImportsResourceTransferstoreGetRequest : BaseTopRequest<Top.Api.Response.WlbImportsResourceTransferstoreGetResponse>
    {
        /// <summary>
        /// 商品前台叶子类目ID
        /// </summary>
        public string Cids { get; set; }

        /// <summary>
        /// 卖家发货地址的区域ID，如果不填则为默认发货地址ID
        /// </summary>
        public Nullable<long> FromId { get; set; }

        /// <summary>
        /// 通过taobao.wlb.imports.resource.get接口查询出来的资源ID
        /// </summary>
        public Nullable<long> ResourceId { get; set; }

        /// <summary>
        /// 买家收货地信息
        /// </summary>
        public string ToAddress { get; set; }

        public ReciverAddressDo ToAddress_ { set { this.ToAddress = TopUtils.ObjectToJson(value); } } 

        #region ITopRequest Members

        public override string GetApiName()
        {
            return "taobao.wlb.imports.resource.transferstore.get";
        }

        public override IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("cids", this.Cids);
            parameters.Add("from_id", this.FromId);
            parameters.Add("resource_id", this.ResourceId);
            parameters.Add("to_address", this.ToAddress);
            if (this.otherParams != null)
            {
                parameters.AddAll(this.otherParams);
            }
            return parameters;
        }

        public override void Validate()
        {
            RequestValidator.ValidateRequired("cids", this.Cids);
            RequestValidator.ValidateMaxListSize("cids", this.Cids, 20);
            RequestValidator.ValidateRequired("resource_id", this.ResourceId);
            RequestValidator.ValidateRequired("to_address", this.ToAddress);
        }

        #endregion
    }
}
