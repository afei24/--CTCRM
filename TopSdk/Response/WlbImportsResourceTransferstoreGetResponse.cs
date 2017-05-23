using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Top.Api.Response
{
    /// <summary>
    /// WlbImportsResourceTransferstoreGetResponse.
    /// </summary>
    public class WlbImportsResourceTransferstoreGetResponse : TopResponse
    {
        /// <summary>
        /// 符合条件的中转仓列表
        /// </summary>
        [XmlArray("stores")]
        [XmlArrayItem("tran_store_result")]
        public List<Top.Api.Domain.TranStoreResult> Stores { get; set; }

    }
}
