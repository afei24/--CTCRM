using System;
using System.Xml.Serialization;
using Top.Api.Domain;
using System.Collections.Generic;
using Top.Api.Util;

namespace Top.Api.Request
{
    /// <summary>
    /// TOP API: taobao.wlb.order.jzwithins.consign
    /// </summary>
    public class WlbOrderJzwithinsConsignRequest : BaseTopRequest<Top.Api.Response.WlbOrderJzwithinsConsignResponse>
    {
        /// <summary>
        /// 物流服务商信息
        /// </summary>
        public string InsPartner { get; set; }

        public JzPartnerNew InsPartner_ { set { this.InsPartner = TopUtils.ObjectToJson(value); } } 

        /// <summary>
        /// 家装物流发货参数
        /// </summary>
        public string JzConsignArgs { get; set; }

        public JzConsignArgsNew JzConsignArgs_ { set { this.JzConsignArgs = TopUtils.ObjectToJson(value); } } 

        /// <summary>
        /// 淘宝交易订单号
        /// </summary>
        public Nullable<long> Tid { get; set; }

        /// <summary>
        /// 物流服务商信息
        /// </summary>
        public string TmsPartner { get; set; }

        public JzPartnerNew TmsPartner_ { set { this.TmsPartner = TopUtils.ObjectToJson(value); } } 

        #region ITopRequest Members

        public override string GetApiName()
        {
            return "taobao.wlb.order.jzwithins.consign";
        }

        public override IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("ins_partner", this.InsPartner);
            parameters.Add("jz_consign_args", this.JzConsignArgs);
            parameters.Add("tid", this.Tid);
            parameters.Add("tms_partner", this.TmsPartner);
            if (this.otherParams != null)
            {
                parameters.AddAll(this.otherParams);
            }
            return parameters;
        }

        public override void Validate()
        {
            RequestValidator.ValidateRequired("jz_consign_args", this.JzConsignArgs);
            RequestValidator.ValidateRequired("tid", this.Tid);
            RequestValidator.ValidateRequired("tms_partner", this.TmsPartner);
        }

        #endregion
    }
}
