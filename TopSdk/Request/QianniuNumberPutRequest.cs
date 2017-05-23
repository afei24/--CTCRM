using System;
using System.Collections.Generic;
using Top.Api.Util;

namespace Top.Api.Request
{
    /// <summary>
    /// TOP API: taobao.qianniu.number.put
    /// </summary>
    public class QianniuNumberPutRequest : BaseTopRequest<Top.Api.Response.QianniuNumberPutResponse>
    {
        /// <summary>
        /// 考虑到稳定性，建议一次卖家最多为200个。 标准json格式的数组构成的字符串。每个元素为{user_id:****,field:"****",value:"****"}分别是用户的userid，数据的名称，以及数据的值。
        /// </summary>
        public string Data { get; set; }

        #region ITopRequest Members

        public override string GetApiName()
        {
            return "taobao.qianniu.number.put";
        }

        public override IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("data", this.Data);
            if (this.otherParams != null)
            {
                parameters.AddAll(this.otherParams);
            }
            return parameters;
        }

        public override void Validate()
        {
            RequestValidator.ValidateRequired("data", this.Data);
        }

        #endregion
    }
}
