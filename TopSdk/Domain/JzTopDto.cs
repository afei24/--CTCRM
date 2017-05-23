using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Top.Api.Domain
{
    /// <summary>
    /// JzTopDto Data Structure.
    /// </summary>
    [Serializable]
    public class JzTopDto : TopObject
    {
        /// <summary>
        /// 快递公司列表
        /// </summary>
        [XmlArray("expresses")]
        [XmlArrayItem("expresses")]
        public List<Top.Api.Domain.Expresses> Expresses { get; set; }

        /// <summary>
        /// 商品对应的服务信息
        /// </summary>
        [XmlElement("goods_relations")]
        public string GoodsRelations { get; set; }

        /// <summary>
        /// 安装公司列表
        /// </summary>
        [XmlArray("ins_tps")]
        [XmlArrayItem("instps")]
        public List<Top.Api.Domain.Instps> InsTps { get; set; }

        /// <summary>
        /// 物流公司列表
        /// </summary>
        [XmlArray("lg_cps")]
        [XmlArrayItem("lgcps")]
        public List<Top.Api.Domain.Lgcps> LgCps { get; set; }

        /// <summary>
        /// 是否支持修改安装地址
        /// </summary>
        [XmlElement("supp_modify_ins_add")]
        public bool SuppModifyInsAdd { get; set; }

        /// <summary>
        /// 是否支持快递
        /// </summary>
        [XmlElement("support_delivery")]
        public bool SupportDelivery { get; set; }

        /// <summary>
        /// 是否支持安装
        /// </summary>
        [XmlElement("support_install")]
        public bool SupportInstall { get; set; }
    }
}
