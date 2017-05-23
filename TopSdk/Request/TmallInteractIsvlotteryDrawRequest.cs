using System;
using System.Collections.Generic;
using Top.Api.Util;

namespace Top.Api.Request
{
    /// <summary>
    /// TOP API: tmall.interact.isvlottery.draw
    /// </summary>
    public class TmallInteractIsvlotteryDrawRequest : BaseTopRequest<Top.Api.Response.TmallInteractIsvlotteryDrawResponse>
    {
        /// <summary>
        /// 安全码
        /// </summary>
        public string Asac { get; set; }

        /// <summary>
        /// 互动实例id
        /// </summary>
        public string InteractId { get; set; }

        /// <summary>
        /// 店铺id
        /// </summary>
        public Nullable<long> ShopId { get; set; }

        /// <summary>
        /// 安全ua
        /// </summary>
        public string Ua { get; set; }

        /// <summary>
        /// umid
        /// </summary>
        public string Umid { get; set; }

        #region ITopRequest Members

        public override string GetApiName()
        {
            return "tmall.interact.isvlottery.draw";
        }

        public override IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("asac", this.Asac);
            parameters.Add("interact_id", this.InteractId);
            parameters.Add("shop_id", this.ShopId);
            parameters.Add("ua", this.Ua);
            parameters.Add("umid", this.Umid);
            if (this.otherParams != null)
            {
                parameters.AddAll(this.otherParams);
            }
            return parameters;
        }

        public override void Validate()
        {
            RequestValidator.ValidateRequired("asac", this.Asac);
            RequestValidator.ValidateRequired("shop_id", this.ShopId);
            RequestValidator.ValidateRequired("ua", this.Ua);
            RequestValidator.ValidateRequired("umid", this.Umid);
        }

        #endregion
    }
}
