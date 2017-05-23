using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Top.Api.Response
{
    /// <summary>
    /// TmallItemSchemaUpdateResponse.
    /// </summary>
    public class TmallItemSchemaUpdateResponse : TopResponse
    {
        /// <summary>
        /// 商品更新操作成功时间
        /// </summary>
        [XmlElement("gmt_modified")]
        public string GmtModified { get; set; }

        /// <summary>
        /// 返回商品发布结果
        /// </summary>
        [XmlElement("update_item_result")]
        public string UpdateItemResult { get; set; }

    }
}
