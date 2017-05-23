using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Top.Api.Response
{
    /// <summary>
    /// TmallSlaSchemeSupervisionGetResponse.
    /// </summary>
    public class TmallSlaSchemeSupervisionGetResponse : TopResponse
    {
        /// <summary>
        /// 打标服务数量
        /// </summary>
        [XmlElement("reach_standard_schemes_quantity")]
        public long ReachStandardSchemesQuantity { get; set; }

        /// <summary>
        /// 不达标的服务数量
        /// </summary>
        [XmlElement("substandard_schemes_quantity")]
        public long SubstandardSchemesQuantity { get; set; }

        /// <summary>
        /// 管控的服务数量
        /// </summary>
        [XmlElement("supervised_schemes_quantity")]
        public long SupervisedSchemesQuantity { get; set; }

    }
}
