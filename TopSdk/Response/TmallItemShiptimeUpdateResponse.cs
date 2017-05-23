using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Top.Api.Response
{
    /// <summary>
    /// TmallItemShiptimeUpdateResponse.
    /// </summary>
    public class TmallItemShiptimeUpdateResponse : TopResponse
    {
        /// <summary>
        /// 被更新商品ID
        /// </summary>
        [XmlElement("shiptime_update_result")]
        public string ShiptimeUpdateResult { get; set; }

    }
}
