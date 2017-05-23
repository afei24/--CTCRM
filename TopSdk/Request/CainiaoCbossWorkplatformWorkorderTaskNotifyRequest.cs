using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Top.Api.Util;

namespace Top.Api.Request
{
    /// <summary>
    /// TOP API: cainiao.cboss.workplatform.workorder.task.notify
    /// </summary>
    public class CainiaoCbossWorkplatformWorkorderTaskNotifyRequest : BaseTopRequest<Top.Api.Response.CainiaoCbossWorkplatformWorkorderTaskNotifyResponse>
    {
        /// <summary>
        /// content
        /// </summary>
        public string Content { get; set; }

        public StructDomain Content_ { set { this.Content = TopUtils.ObjectToJson(value); } } 

        #region ITopRequest Members

        public override string GetApiName()
        {
            return "cainiao.cboss.workplatform.workorder.task.notify";
        }

        public override IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("content", this.Content);
            if (this.otherParams != null)
            {
                parameters.AddAll(this.otherParams);
            }
            return parameters;
        }

        public override void Validate()
        {
            RequestValidator.ValidateRequired("content", this.Content);
        }

	/// <summary>
/// StructDomain Data Structure.
/// </summary>
[Serializable]
public class StructDomain : TopObject
{
	        /// <summary>
	        /// 任务下发次数
	        /// </summary>
	        [XmlElement("count")]
	        public Nullable<long> Count { get; set; }
	
	        /// <summary>
	        /// 扩展字段
	        /// </summary>
	        [XmlElement("features")]
	        public string Features { get; set; }
	
	        /// <summary>
	        /// 任务创建时间
	        /// </summary>
	        [XmlElement("gmt_create")]
	        public string GmtCreate { get; set; }
	
	        /// <summary>
	        /// 工单任务id
	        /// </summary>
	        [XmlElement("task_id")]
	        public string TaskId { get; set; }
	
	        /// <summary>
	        /// 工单任务名称
	        /// </summary>
	        [XmlElement("task_name")]
	        public string TaskName { get; set; }
	
	        /// <summary>
	        /// 工单任务状态
	        /// </summary>
	        [XmlElement("task_status")]
	        public Nullable<long> TaskStatus { get; set; }
	
	        /// <summary>
	        /// 任务超时时间
	        /// </summary>
	        [XmlElement("timeout")]
	        public string Timeout { get; set; }
	
	        /// <summary>
	        /// 工单id
	        /// </summary>
	        [XmlElement("work_order_id")]
	        public string WorkOrderId { get; set; }
}

        #endregion
    }
}
