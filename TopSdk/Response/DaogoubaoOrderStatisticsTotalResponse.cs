using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Top.Api.Response
{
    /// <summary>
    /// DaogoubaoOrderStatisticsTotalResponse.
    /// </summary>
    public class DaogoubaoOrderStatisticsTotalResponse : TopResponse
    {
        /// <summary>
        /// result
        /// </summary>
        [XmlElement("result")]
        public OrderStatisticsResultDomain Result { get; set; }

	/// <summary>
/// OrderStatisticsResultDomain Data Structure.
/// </summary>
[Serializable]
public class OrderStatisticsResultDomain : TopObject
{
	        /// <summary>
	        /// home_order_num
	        /// </summary>
	        [XmlElement("home_order_num")]
	        public long HomeOrderNum { get; set; }
	
	        /// <summary>
	        /// step_order_num
	        /// </summary>
	        [XmlElement("step_order_num")]
	        public long StepOrderNum { get; set; }
	
	        /// <summary>
	        /// take_order_num
	        /// </summary>
	        [XmlElement("take_order_num")]
	        public long TakeOrderNum { get; set; }
	
	        /// <summary>
	        /// tqdj_order_num
	        /// </summary>
	        [XmlElement("tqdj_order_num")]
	        public long TqdjOrderNum { get; set; }
}

    }
}
