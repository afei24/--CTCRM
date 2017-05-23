using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Top.Api.Response
{
    /// <summary>
    /// PictureUserinfoGetResponse.
    /// </summary>
    public class PictureUserinfoGetResponse : TopResponse
    {
        /// <summary>
        /// 用户使用图片空间的信息
        /// </summary>
        [XmlElement("user_info")]
        public Top.Api.Domain.UserInfo UserInfo { get; set; }

    }
}
