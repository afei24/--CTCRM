using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Top.Api.Response
{
    /// <summary>
    /// InventoryIpcInventorydetailGetResponse.
    /// </summary>
    public class InventoryIpcInventorydetailGetResponse : TopResponse
    {
        /// <summary>
        /// 库存明细列表
        /// </summary>
        [XmlArray("inventory_details")]
        [XmlArrayItem("ipc_inventory_detail_do")]
        public List<Top.Api.Domain.IpcInventoryDetailDo> InventoryDetails { get; set; }

    }
}
