using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Top.Api.Response
{
    /// <summary>
    /// TmallItemOuteridUpdateResponse.
    /// </summary>
    public class TmallItemOuteridUpdateResponse : TopResponse
    {
        /// <summary>
        /// 商家编码更新结果
        /// </summary>
        [XmlElement("outerid_update_result")]
        public string OuteridUpdateResult { get; set; }

    }
}
