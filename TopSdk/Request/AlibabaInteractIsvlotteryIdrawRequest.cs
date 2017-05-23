using System;
using System.Collections.Generic;
using Top.Api.Util;

namespace Top.Api.Request
{
    /// <summary>
    /// TOP API: alibaba.interact.isvlottery.idraw
    /// </summary>
    public class AlibabaInteractIsvlotteryIdrawRequest : BaseTopRequest<Top.Api.Response.AlibabaInteractIsvlotteryIdrawResponse>
    {
        /// <summary>
        /// 抽奖ID列表 用逗号隔开
        /// </summary>
        public string AwardIds { get; set; }

        /// <summary>
        /// 互动实例ID
        /// </summary>
        public string InteractId { get; set; }

        /// <summary>
        /// 埋点参数
        /// </summary>
        public string Ua { get; set; }

        #region ITopRequest Members

        public override string GetApiName()
        {
            return "alibaba.interact.isvlottery.idraw";
        }

        public override IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("award_ids", this.AwardIds);
            parameters.Add("interact_id", this.InteractId);
            parameters.Add("ua", this.Ua);
            if (this.otherParams != null)
            {
                parameters.AddAll(this.otherParams);
            }
            return parameters;
        }

        public override void Validate()
        {
            RequestValidator.ValidateRequired("interact_id", this.InteractId);
            RequestValidator.ValidateRequired("ua", this.Ua);
        }

        #endregion
    }
}
