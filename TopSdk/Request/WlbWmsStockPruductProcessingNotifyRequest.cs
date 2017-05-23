using System;
using System.Xml.Serialization;
using Top.Api.Domain;
using System.Collections.Generic;
using Top.Api.Util;

namespace Top.Api.Request
{
    /// <summary>
    /// TOP API: taobao.wlb.wms.stock.pruduct.processing.notify
    /// </summary>
    public class WlbWmsStockPruductProcessingNotifyRequest : BaseTopRequest<Top.Api.Response.WlbWmsStockPruductProcessingNotifyResponse>
    {
        /// <summary>
        /// 拓展属性，key-value结构，格式要求： 以英文分号“;”分隔每组key-value，以英文冒号“:”分隔key与value。如果value中带有分号，需要转成下划线“_”，如果带有冒号，需要转成中划线“-”
        /// </summary>
        public string ExtendFields { get; set; }

        /// <summary>
        /// 原料商品列表
        /// </summary>
        public string MaterialItems { get; set; }

        public List<Materialitemswlbwmsstockpruductprocessingnotify> MaterialItems_ { set { this.MaterialItems = TopUtils.ObjectToJson(value); } } 

        /// <summary>
        /// ERP单据编码
        /// </summary>
        public string OrderCode { get; set; }

        /// <summary>
        /// ERP单据创建时间
        /// </summary>
        public Nullable<DateTime> OrderCreateTime { get; set; }

        /// <summary>
        /// 单据类型 1102 仓内加工作业单
        /// </summary>
        public Nullable<long> OrderType { get; set; }

        /// <summary>
        /// 计划数量
        /// </summary>
        public Nullable<long> PlanQty { get; set; }

        /// <summary>
        /// ERP计划加工时间
        /// </summary>
        public Nullable<DateTime> PlanWorkTime { get; set; }

        /// <summary>
        /// 成品商品列表
        /// </summary>
        public string ProductItems { get; set; }

        public List<Productitemswlbwmsstockpruductprocessingnotify> ProductItems_ { set { this.ProductItems = TopUtils.ObjectToJson(value); } } 

        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }

        /// <summary>
        /// 加工类型: 1:仓内组合加工、2:仓内组合拆分
        /// </summary>
        public Nullable<long> ServiceType { get; set; }

        /// <summary>
        /// 仓库编码
        /// </summary>
        public string StoreCode { get; set; }

        #region ITopRequest Members

        public override string GetApiName()
        {
            return "taobao.wlb.wms.stock.pruduct.processing.notify";
        }

        public override IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("extend_fields", this.ExtendFields);
            parameters.Add("material_items", this.MaterialItems);
            parameters.Add("order_code", this.OrderCode);
            parameters.Add("order_create_time", this.OrderCreateTime);
            parameters.Add("order_type", this.OrderType);
            parameters.Add("plan_qty", this.PlanQty);
            parameters.Add("plan_work_time", this.PlanWorkTime);
            parameters.Add("product_items", this.ProductItems);
            parameters.Add("remark", this.Remark);
            parameters.Add("service_type", this.ServiceType);
            parameters.Add("store_code", this.StoreCode);
            if (this.otherParams != null)
            {
                parameters.AddAll(this.otherParams);
            }
            return parameters;
        }

        public override void Validate()
        {
            RequestValidator.ValidateObjectMaxListSize("material_items", this.MaterialItems, 1000);
            RequestValidator.ValidateRequired("order_code", this.OrderCode);
            RequestValidator.ValidateRequired("order_type", this.OrderType);
            RequestValidator.ValidateObjectMaxListSize("product_items", this.ProductItems, 1000);
            RequestValidator.ValidateRequired("service_type", this.ServiceType);
        }

        #endregion
    }
}
