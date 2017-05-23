using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Top.Api.Response
{
    /// <summary>
    /// InventoryStoreQueryResponse.
    /// </summary>
    public class InventoryStoreQueryResponse : TopResponse
    {
        /// <summary>
        /// 仓库列表
        /// </summary>
        [XmlArray("store_list")]
        [XmlArrayItem("store")]
        public List<Top.Api.Domain.Store> StoreList { get; set; }

    }
}
