using System;
using System.Collections.Generic;
using Top.Api.Util;

namespace Top.Api.Request
{
    /// <summary>
    /// TOP API: tmall.brandcat.propinput.get
    /// </summary>
    public class TmallBrandcatPropinputGetRequest : BaseTopRequest<Top.Api.Response.TmallBrandcatPropinputGetResponse>
    {
        /// <summary>
        /// 品牌ID，如果类目没有品牌，指定null
        /// </summary>
        public Nullable<long> BrandId { get; set; }

        /// <summary>
        /// 类目ID
        /// </summary>
        public Nullable<long> Cid { get; set; }

        /// <summary>
        /// 属性ID，如果属性有子属性，请指定最后一级子属性ID，tmall.brandcat.propinput.get返回的即为的该属性ID对应的输入特征，对于有子属性模板的情况指定顶级属性ID即可
        /// </summary>
        public Nullable<long> Pid { get; set; }

        #region ITopRequest Members

        public override string GetApiName()
        {
            return "tmall.brandcat.propinput.get";
        }

        public override IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("brand_id", this.BrandId);
            parameters.Add("cid", this.Cid);
            parameters.Add("pid", this.Pid);
            if (this.otherParams != null)
            {
                parameters.AddAll(this.otherParams);
            }
            return parameters;
        }

        public override void Validate()
        {
            RequestValidator.ValidateRequired("brand_id", this.BrandId);
            RequestValidator.ValidateRequired("cid", this.Cid);
            RequestValidator.ValidateRequired("pid", this.Pid);
        }

        #endregion
    }
}
