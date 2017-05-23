using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Top.Api.Response
{
    /// <summary>
    /// TmallItemSchemaAddResponse.
    /// </summary>
    public class TmallItemSchemaAddResponse : TopResponse
    {
        /// <summary>
        /// 返回商品发布结果
        /// </summary>
        [XmlElement("add_item_result")]
        public string AddItemResult { get; set; }

        /// <summary>
        /// 发布商品操作成功时间
        /// </summary>
        [XmlElement("gmt_create")]
        public string GmtCreate { get; set; }

    }
}
