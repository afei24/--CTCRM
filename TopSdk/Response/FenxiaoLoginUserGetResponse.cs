using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Top.Api.Response
{
    /// <summary>
    /// FenxiaoLoginUserGetResponse.
    /// </summary>
    public class FenxiaoLoginUserGetResponse : TopResponse
    {
        /// <summary>
        /// 登录用户信息
        /// </summary>
        [XmlElement("login_user")]
        public Top.Api.Domain.LoginUser LoginUser { get; set; }

    }
}
