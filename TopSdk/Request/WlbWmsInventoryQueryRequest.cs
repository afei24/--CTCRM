using System;
using System.Collections.Generic;
using Top.Api.Util;

namespace Top.Api.Request
{
    /// <summary>
    /// TOP API: taobao.wlb.wms.inventory.query
    /// </summary>
    public class WlbWmsInventoryQueryRequest : BaseTopRequest<Top.Api.Response.WlbWmsInventoryQueryResponse>
    {
        /// <summary>
        /// 库存批次号，type=2时字段传值有效。 商品设置为批次管理时，商品产生批次库存。当商品为批次管理时，此字段不传值，返回所有批次库存信息。
        /// </summary>
        public string BatchCode { get; set; }

        /// <summary>
        /// 渠道编码，type=3时字段传值有效。（TB 淘系， OTHERS 其他）
        /// </summary>
        public string ChannelCode { get; set; }

        /// <summary>
        /// 失效日期，type=2时字段传值有效。
        /// </summary>
        public Nullable<DateTime> DueDate { get; set; }

        /// <summary>
        /// 库存类型。 (1 正品 101 残次 102 机损 103 箱损 201 冻结库存 301 在途库存 )
        /// </summary>
        public Nullable<long> InventoryType { get; set; }

        /// <summary>
        /// 菜鸟商品ID
        /// </summary>
        public string ItemId { get; set; }

        /// <summary>
        /// 分页的第几页
        /// </summary>
        public Nullable<long> PageNo { get; set; }

        /// <summary>
        /// 每页多少条，最大50条
        /// </summary>
        public Nullable<long> PageSize { get; set; }

        /// <summary>
        /// 生产日期，type=2时字段传值有效。
        /// </summary>
        public Nullable<DateTime> ProduceDate { get; set; }

        /// <summary>
        /// 仓库编码
        /// </summary>
        public string StoreCode { get; set; }

        /// <summary>
        /// 库存查询类型 1- 汇总库存，不区分批次和渠道 2- 批次库存，库存按商品批次维度划分 3- 渠道库存，库存按渠道维度划分 （当前业务不支持批次库存和渠道库存共存，批次库存无渠道属性，渠道库存无批次属性）
        /// </summary>
        public Nullable<long> Type { get; set; }

        #region ITopRequest Members

        public override string GetApiName()
        {
            return "taobao.wlb.wms.inventory.query";
        }

        public override IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("batch_code", this.BatchCode);
            parameters.Add("channel_code", this.ChannelCode);
            parameters.Add("due_date", this.DueDate);
            parameters.Add("inventory_type", this.InventoryType);
            parameters.Add("item_id", this.ItemId);
            parameters.Add("page_no", this.PageNo);
            parameters.Add("page_size", this.PageSize);
            parameters.Add("produce_date", this.ProduceDate);
            parameters.Add("store_code", this.StoreCode);
            parameters.Add("type", this.Type);
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
