using System;
using System.Xml.Serialization;

namespace Top.Api.Domain
{
    /// <summary>
    /// BillRecordDto Data Structure.
    /// </summary>
    [Serializable]
    public class BillRecordDto : TopObject
    {
        /// <summary>
        /// appkey
        /// </summary>
        [XmlElement("appkey")]
        public string Appkey { get; set; }

        /// <summary>
        /// 备用字段
        /// </summary>
        [XmlElement("extend1")]
        public string Extend1 { get; set; }

        /// <summary>
        /// 备用字段
        /// </summary>
        [XmlElement("extend10")]
        public string Extend10 { get; set; }

        /// <summary>
        /// 备用字段
        /// </summary>
        [XmlElement("extend2")]
        public string Extend2 { get; set; }

        /// <summary>
        /// 备用字段
        /// </summary>
        [XmlElement("extend3")]
        public string Extend3 { get; set; }

        /// <summary>
        /// 备用字段
        /// </summary>
        [XmlElement("extend4")]
        public string Extend4 { get; set; }

        /// <summary>
        /// 备用字段
        /// </summary>
        [XmlElement("extend5")]
        public string Extend5 { get; set; }

        /// <summary>
        /// 备用字段
        /// </summary>
        [XmlElement("extend6")]
        public string Extend6 { get; set; }

        /// <summary>
        /// 备用字段
        /// </summary>
        [XmlElement("extend7")]
        public string Extend7 { get; set; }

        /// <summary>
        /// 备用字段
        /// </summary>
        [XmlElement("extend8")]
        public string Extend8 { get; set; }

        /// <summary>
        /// 备用字段
        /// </summary>
        [XmlElement("extend9")]
        public string Extend9 { get; set; }

        /// <summary>
        /// 金额（单位：分）
        /// </summary>
        [XmlElement("fee")]
        public Nullable<long> Fee { get; set; }

        /// <summary>
        /// 卖家ID
        /// </summary>
        [XmlElement("nick")]
        public string Nick { get; set; }

        /// <summary>
        /// 服务市场有效订单ID
        /// </summary>
        [XmlElement("order_id")]
        public Nullable<long> OrderId { get; set; }

        /// <summary>
        /// 外部确认账单ID
        /// </summary>
        [XmlElement("out_confirm_id")]
        public string OutConfirmId { get; set; }

        /// <summary>
        /// 外部订单ID
        /// </summary>
        [XmlElement("out_order_id")]
        public string OutOrderId { get; set; }

        /// <summary>
        /// 记录产生时间
        /// </summary>
        [XmlElement("start_date")]
        public Nullable<DateTime> StartDate { get; set; }

        /// <summary>
        /// 状态：1成功、2失败
        /// </summary>
        [XmlElement("status")]
        public Nullable<long> Status { get; set; }

        /// <summary>
        /// 目标号码
        /// </summary>
        [XmlElement("target_no")]
        public string TargetNo { get; set; }

        /// <summary>
        /// 账单分类：1短信
        /// </summary>
        [XmlElement("type")]
        public Nullable<long> Type { get; set; }
    }
}
