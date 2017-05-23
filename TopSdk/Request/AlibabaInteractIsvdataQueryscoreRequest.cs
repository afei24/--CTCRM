using System;
using System.Collections.Generic;
using Top.Api.Util;

namespace Top.Api.Request
{
    /// <summary>
    /// TOP API: alibaba.interact.isvdata.queryscore
    /// </summary>
    public class AlibabaInteractIsvdataQueryscoreRequest : BaseTopRequest<Top.Api.Response.AlibabaInteractIsvdataQueryscoreResponse>
    {
        /// <summary>
        /// 互动实例ID ISV通过绑定互动奖池并且生成互动实例接口 获取该ID
        /// </summary>
        public string InteractId { get; set; }

        #region ITopRequest Members

        public override string GetApiName()
        {
            return "alibaba.interact.isvdata.queryscore";
        }

        public override IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("interact_id", this.InteractId);
            if (this.otherParams != null)
            {
                parameters.AddAll(this.otherParams);
            }
            return parameters;
        }

        public override void Validate()
        {
            RequestValidator.ValidateRequired("interact_id", this.InteractId);
        }

        #endregion
    }
}
