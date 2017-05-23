using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Top.Api.Response
{
    /// <summary>
    /// AlibabaInteractTidaGetMaterialidResponse.
    /// </summary>
    public class AlibabaInteractTidaGetMaterialidResponse : TopResponse
    {
        /// <summary>
        /// 试穿试戴素材信息列表
        /// </summary>
        [XmlArray("material_info_list")]
        [XmlArrayItem("item_material_info")]
        public List<Top.Api.Domain.ItemMaterialInfo> MaterialInfoList { get; set; }

    }
}
