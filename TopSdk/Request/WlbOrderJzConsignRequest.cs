using System;
using System.Xml.Serialization;
using Top.Api.Domain;
using System.Collections.Generic;
using Top.Api.Util;

namespace Top.Api.Request
{
    /// <summary>
    /// TOP API: taobao.wlb.order.jz.consign
    /// </summary>
    public class WlbOrderJzConsignRequest : BaseTopRequest<Top.Api.Response.WlbOrderJzConsignResponse>
    {
        /// <summary>
        /// 安装收货人信息,如果为空,则取默认收货人信息
        /// </summary>
        public string InsReceiverTo { get; set; }

        public JzReceiverTo InsReceiverTo_ { set { this.InsReceiverTo = TopUtils.ObjectToJson(value); } } 

        /// <summary>
        /// 安装公司信息,需要安装时,才填写
        /// </summary>
        public string InsTpDto { get; set; }

        public Tpdto InsTpDto_ { set { this.InsTpDto = TopUtils.ObjectToJson(value); } } 

        /// <summary>
        /// 家装收货人信息,如果为空,则取默认收货信息
        /// </summary>
        public string JzReceiverTo { get; set; }

        public JzReceiverTo JzReceiverTo_ { set { this.JzReceiverTo = TopUtils.ObjectToJson(value); } } 

        /// <summary>
        /// 发货参数
        /// </summary>
        public string JzTopArgs { get; set; }

        public JzTopArgs JzTopArgs_ { set { this.JzTopArgs = TopUtils.ObjectToJson(value); } } 

        /// <summary>
        /// 物流公司信息
        /// </summary>
        public string LgTpDto { get; set; }

        public Tpdto LgTpDto_ { set { this.LgTpDto = TopUtils.ObjectToJson(value); } } 

        /// <summary>
        /// 卖家联系人地址库ID，可以通过taobao.logistics.address.search接口查询到地址库ID。如果为空，取的卖家的默认取货地址
        /// </summary>
        public Nullable<long> SenderId { get; set; }

        /// <summary>
        /// 交易号
        /// </summary>
        public Nullable<long> Tid { get; set; }

        #region ITopRequest Members

        public override string GetApiName()
        {
            return "taobao.wlb.order.jz.consign";
        }

        public override IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("ins_receiver_to", this.InsReceiverTo);
            parameters.Add("ins_tp_dto", this.InsTpDto);
            parameters.Add("jz_receiver_to", this.JzReceiverTo);
            parameters.Add("jz_top_args", this.JzTopArgs);
            parameters.Add("lg_tp_dto", this.LgTpDto);
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
            RequestValidator.ValidateRequired("lg_tp_dto", this.LgTpDto);
            RequestValidator.ValidateRequired("tid", this.Tid);
        }

        #endregion
    }
}
