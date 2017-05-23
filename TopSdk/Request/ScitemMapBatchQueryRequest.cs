using System;
using System.Collections.Generic;
using Top.Api.Util;

namespace Top.Api.Request
{
    /// <summary>
    /// TOP API: taobao.scitem.map.batch.query
    /// </summary>
    public class ScitemMapBatchQueryRequest : BaseTopRequest<Top.Api.Response.ScitemMapBatchQueryResponse>
    {
        /// <summary>
        /// 后端商品的商家编码
        /// </summary>
        public string OuterCode { get; set; }

        /// <summary>
        /// 当前页码数
        /// </summary>
        public Nullable<long> PageIndex { get; set; }

        /// <summary>
        /// 分页记录个数，如果用户输入的记录数大于50，则一页显示50条记录
        /// </summary>
        public Nullable<long> PageSize { get; set; }

        /// <summary>
        /// 后端商品id
        /// </summary>
        public Nullable<long> ScItemId { get; set; }

        #region ITopRequest Members

        public override string GetApiName()
        {
            return "taobao.scitem.map.batch.query";
        }

        public override IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("outer_code", this.OuterCode);
            parameters.Add("page_index", this.PageIndex);
            parameters.Add("page_size", this.PageSize);
            parameters.Add("sc_item_id", this.ScItemId);
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
