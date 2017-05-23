using System;
using System.Collections.Generic;
using Top.Api.Util;

namespace Top.Api.Request
{
    /// <summary>
    /// TOP API: tmall.item.desc.modules.get
    /// </summary>
    public class TmallItemDescModulesGetRequest : BaseTopRequest<Top.Api.Response.TmallItemDescModulesGetResponse>
    {
        /// <summary>
        /// 淘宝后台发布商品的叶子类目id，可通过taobao.itemcats.get查到。api 访问地址http://api.taobao.com/apidoc/api.htm?spm=0.0.0.0.CFhhk4&path=cid:3-apiId:122
        /// </summary>
        public Nullable<long> CatId { get; set; }

        /// <summary>
        /// 商家主帐号id
        /// </summary>
        public Nullable<long> UsrId { get; set; }

        #region ITopRequest Members

        public override string GetApiName()
        {
            return "tmall.item.desc.modules.get";
        }

        public override IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("cat_id", this.CatId);
            parameters.Add("usr_id", this.UsrId);
            if (this.otherParams != null)
            {
                parameters.AddAll(this.otherParams);
            }
            return parameters;
        }

        public override void Validate()
        {
            RequestValidator.ValidateRequired("cat_id", this.CatId);
            RequestValidator.ValidateRequired("usr_id", this.UsrId);
        }

        #endregion
    }
}
