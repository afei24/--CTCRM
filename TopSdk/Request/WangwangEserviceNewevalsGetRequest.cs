using System;
using System.Collections.Generic;
using Top.Api.Util;

namespace Top.Api.Request
{
    /// <summary>
    /// TOP API: taobao.wangwang.eservice.newevals.get
    /// </summary>
    public class WangwangEserviceNewevalsGetRequest : BaseTopRequest<Top.Api.Response.WangwangEserviceNewevalsGetResponse>
    {
        /// <summary>
        /// 查询登录日志的开始日期，必须按示例的格式，否则会返回错误；  开始时间不能在当前时间30天前，开始时间和结束时间的间隔不能超过7天；  开始时间不能超过当前系统时间
        /// </summary>
        public string Btime { get; set; }

        /// <summary>
        /// 查询登录日志的结束时间，必须按示例的格式，否则会返回错误；  结束时间不能小于开始时间，结束时间和开始时间的间隔不能超过7天
        /// </summary>
        public string Etime { get; set; }

        /// <summary>
        /// 需要查询登录日志的账号列表，多个id之间用逗号隔开，每次查询的id数不能超过30个
        /// </summary>
        public string QueryIds { get; set; }

        #region ITopRequest Members

        public override string GetApiName()
        {
            return "taobao.wangwang.eservice.newevals.get";
        }

        public override IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("btime", this.Btime);
            parameters.Add("etime", this.Etime);
            parameters.Add("query_ids", this.QueryIds);
            if (this.otherParams != null)
            {
                parameters.AddAll(this.otherParams);
            }
            return parameters;
        }

        public override void Validate()
        {
            RequestValidator.ValidateRequired("btime", this.Btime);
            RequestValidator.ValidateRequired("etime", this.Etime);
            RequestValidator.ValidateRequired("query_ids", this.QueryIds);
            RequestValidator.ValidateMaxListSize("query_ids", this.QueryIds, 30);
        }

        #endregion
    }
}
