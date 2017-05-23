using System;
using System.Collections.Generic;
using Top.Api.Util;

namespace Top.Api.Request
{
    /// <summary>
    /// TOP API: taobao.itempropvalues.get
    /// </summary>
    public class ItempropvaluesGetRequest : BaseTopRequest<Top.Api.Response.ItempropvaluesGetResponse>
    {
        /// <summary>
        /// 属性的Key，支持多条，以“,”分隔
        /// </summary>
        public string AttrKeys { get; set; }

        /// <summary>
        /// 叶子类目ID ,通过taobao.itemcats.get获得叶子类目ID
        /// </summary>
        public Nullable<long> Cid { get; set; }

        /// <summary>
        /// 假如传2005-01-01 00:00:00，则取所有的属性和子属性(状态为删除的属性值不返回prop_name)
        /// </summary>
        public Nullable<DateTime> Datetime { get; set; }

        /// <summary>
        /// 需要返回的字段。目前支持有：cid,pid,prop_name,vid,name,name_alias,status,sort_order
        /// </summary>
        public string Fields { get; set; }

        /// <summary>
        /// 属性和属性值 id串，格式例如(pid1;pid2)或(pid1:vid1;pid2:vid2)或(pid1;pid2:vid2)
        /// </summary>
        public string Pvs { get; set; }

        /// <summary>
        /// 获取类目的类型：1代表集市、2代表天猫
        /// </summary>
        public Nullable<long> Type { get; set; }

        #region ITopRequest Members

        public override string GetApiName()
        {
            return "taobao.itempropvalues.get";
        }

        public override IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("attr_keys", this.AttrKeys);
            parameters.Add("cid", this.Cid);
            parameters.Add("datetime", this.Datetime);
            parameters.Add("fields", this.Fields);
            parameters.Add("pvs", this.Pvs);
            parameters.Add("type", this.Type);
            if (this.otherParams != null)
            {
                parameters.AddAll(this.otherParams);
            }
            return parameters;
        }

        public override void Validate()
        {
            RequestValidator.ValidateMaxListSize("attr_keys", this.AttrKeys, 20);
            RequestValidator.ValidateRequired("cid", this.Cid);
            RequestValidator.ValidateRequired("fields", this.Fields);
            RequestValidator.ValidateMaxListSize("fields", this.Fields, 20);
            RequestValidator.ValidateMaxValue("type", this.Type, 2);
            RequestValidator.ValidateMinValue("type", this.Type, 1);
        }

        #endregion
    }
}
