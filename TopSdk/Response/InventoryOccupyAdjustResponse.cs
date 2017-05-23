using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Top.Api.Response
{
    /// <summary>
    /// InventoryOccupyAdjustResponse.
    /// </summary>
    public class InventoryOccupyAdjustResponse : TopResponse
    {
        /// <summary>
        /// 操作返回码
        /// </summary>
        [XmlElement("operate_code")]
        public string OperateCode { get; set; }

        /// <summary>
        /// 提示信息
        /// </summary>
        [XmlArray("tip_infos")]
        [XmlArrayItem("tip_info")]
        public List<Top.Api.Domain.TipInfo> TipInfos { get; set; }

    }
}
