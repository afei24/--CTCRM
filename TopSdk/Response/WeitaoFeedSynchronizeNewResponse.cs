using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Top.Api.Response
{
    /// <summary>
    /// WeitaoFeedSynchronizeNewResponse.
    /// </summary>
    public class WeitaoFeedSynchronizeNewResponse : TopResponse
    {
        /// <summary>
        /// 增加错误信息
        /// </summary>
        [XmlElement("errmsg")]
        public string Errmsg { get; set; }

        /// <summary>
        /// 推送结果
        /// </summary>
        [XmlElement("result")]
        public Top.Api.Domain.PushResult Result { get; set; }

    }
}
