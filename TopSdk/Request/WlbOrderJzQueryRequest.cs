using System;
using System.Xml.Serialization;
using Top.Api.Domain;
using System.Collections.Generic;
using Top.Api.Util;

namespace Top.Api.Request
{
    /// <summary>
    /// TOP API: taobao.wlb.order.jz.query
    /// </summary>
    public class WlbOrderJzQueryRequest : BaseTopRequest<Top.Api.Response.WlbOrderJzQueryResponse>
    {
        /// <summary>
        /// 家装安装服务收货人信息
        /// </summary>
        public string InsJzReceiverTO { get; set; }

        public JzReceiverTo InsJzReceiverTO_ { set { this.InsJzReceiverTO = TopUtils.ObjectToJson(value); } } 

        /// <summary>
        /// 家装收货人信息
        /// </summary>
        public string JzReceiverTo { get; set; }

        public JzReceiverTo JzReceiverTo_ { set { this.JzReceiverTo = TopUtils.ObjectToJson(value); } } 

        /// <summary>
        /// 卖家联系人地址库ID，可以通过taobao.logistics.address.search接口查询到地址库ID。如果为空，取的卖家的默认取货地址
        /// </summary>
        public Nullable<long> SenderId { get; set; }

        /// <summary>
        /// 交易id
        /// </summary>
        public Nullable<long> Tid { get; set; }

        #region ITopRequest Members

        public override string GetApiName()
        {
            return "taobao.wlb.order.jz.query";
        }

        public override IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("ins_jz_receiver_t_o", this.InsJzReceiverTO);
            parameters.Add("jz_receiver_to", this.JzReceiverTo);
            parameters.Add("sender_id", this.SenderId);
            parameters.Add("tid", this.Tid);
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
