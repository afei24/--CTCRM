using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Top.Api.Response
{
    /// <summary>
    /// RpReturngoodsRefuseResponse.
    /// </summary>
    public class RpReturngoodsRefuseResponse : TopResponse
    {
        /// <summary>
        /// asdf
        /// </summary>
        [XmlElement("result")]
        public bool Result { get; set; }

    }
}
