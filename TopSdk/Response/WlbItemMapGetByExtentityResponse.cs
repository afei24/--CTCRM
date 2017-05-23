using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Top.Api.Response
{
    /// <summary>
    /// WlbItemMapGetByExtentityResponse.
    /// </summary>
    public class WlbItemMapGetByExtentityResponse : TopResponse
    {
        /// <summary>
        /// 是否成功
        /// </summary>
        [XmlElement("is_success")]
        public bool IsSuccess { get; set; }

        /// <summary>
        /// 物流宝商品id
        /// </summary>
        [XmlElement("item_id")]
        public long ItemId { get; set; }

    }
}
