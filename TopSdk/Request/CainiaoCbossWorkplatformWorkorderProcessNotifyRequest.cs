using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Top.Api.Util;

namespace Top.Api.Request
{
    /// <summary>
    /// TOP API: cainiao.cboss.workplatform.workorder.process.notify
    /// </summary>
    public class CainiaoCbossWorkplatformWorkorderProcessNotifyRequest : BaseTopRequest<Top.Api.Response.CainiaoCbossWorkplatformWorkorderProcessNotifyResponse>
    {
        /// <summary>
        /// 服务入参
        /// </summary>
        public string Content { get; set; }

        public StructDomain Content_ { set { this.Content = TopUtils.ObjectToJson(value); } } 

        #region ITopRequest Members

        public override string GetApiName()
        {
            return "cainiao.cboss.workplatform.workorder.process.notify";
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
	        /// 进度的操作时间
	        /// </summary>
	        [XmlElement("action_time")]
	        public string ActionTime { get; set; }
	
	        /// <summary>
	        /// 工单进度的凭证图片地址
	        /// </summary>
	        [XmlElement("attach_path")]
	        public string AttachPath { get; set; }
	
	        /// <summary>
	        /// 工单业务状态
	        /// </summary>
	        [XmlElement("biz_status")]
	        public Nullable<long> BizStatus { get; set; }
	
	        /// <summary>
	        /// 操作者淘宝/旺旺 姓名/昵称
	        /// </summary>
	        [XmlElement("dealer_name")]
	        public string DealerName { get; set; }
	
	        /// <summary>
	        /// 操作者淘宝/旺旺角色
	        /// </summary>
	        [XmlElement("dealer_role")]
	        public Nullable<long> DealerRole { get; set; }
	
	        /// <summary>
	        /// 扩展字段,半角分号分隔
	        /// </summary>
	        [XmlElement("features")]
	        public string Features { get; set; }
	
	        /// <summary>
	        /// 任务的操作备注
	        /// </summary>
	        [XmlElement("memo")]
	        public string Memo { get; set; }
	
	        /// <summary>
	        /// 下发的进度类型
	        /// </summary>
	        [XmlElement("op_type")]
	        public Nullable<long> OpType { get; set; }
	
	        /// <summary>
	        /// 任务id
	        /// </summary>
	        [XmlElement("task_id")]
	        public string TaskId { get; set; }
	
	        /// <summary>
	        /// 任务名称
	        /// </summary>
	        [XmlElement("task_name")]
	        public string TaskName { get; set; }
	
	        /// <summary>
	        /// 工单id
	        /// </summary>
	        [XmlElement("work_order_id")]
	        public string WorkOrderId { get; set; }
}

        #endregion
    }
}
