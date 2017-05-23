using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Top.Api.Domain
{
    /// <summary>
    /// Requestwlbwmsstockinorderconfirm Data Structure.
    /// </summary>
    [Serializable]
    public class Requestwlbwmsstockinorderconfirm : TopObject
    {
        /// <summary>
        /// 支持出入库单多次确认，多次收货后确认时  0 最后一次确认或是一次性确认；1 多次确认；当多次确认时，确认的ITEM种类全部被确认时，确认完成默认值为 0 例如输入2认为是0
        /// </summary>
        [XmlElement("confirm_type")]
        public Nullable<long> ConfirmType { get; set; }

        /// <summary>
        /// ERP订单编码
        /// </summary>
        [XmlElement("order_code")]
        public string OrderCode { get; set; }

        /// <summary>
        /// 仓库订单入库时间
        /// </summary>
        [XmlElement("order_confirm_time")]
        public string OrderConfirmTime { get; set; }

        /// <summary>
        /// 订单商品列表
        /// </summary>
        [XmlArray("order_items")]
        [XmlArrayItem("order_itemswlbwmsstockinorderconfirm")]
        public List<Top.Api.Domain.OrderItemswlbwmsstockinorderconfirm> OrderItems { get; set; }

        /// <summary>
        /// 单据类型(501销退入库单、504换货入库单、504换货入库单、601采购入库单、904其他入库单）
        /// </summary>
        [XmlElement("order_type")]
        public Nullable<long> OrderType { get; set; }

        /// <summary>
        /// 外部业务编码，类似消息ID，多次确认时，每次传入要求唯一；
        /// </summary>
        [XmlElement("out_biz_code")]
        public string OutBizCode { get; set; }

        /// <summary>
        /// 仓配订单编码
        /// </summary>
        [XmlElement("store_order_code")]
        public string StoreOrderCode { get; set; }
    }
}
