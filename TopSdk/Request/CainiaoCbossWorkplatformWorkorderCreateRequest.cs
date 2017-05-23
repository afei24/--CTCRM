using System;
using System.Collections.Generic;
using Top.Api.Util;

namespace Top.Api.Request
{
    /// <summary>
    /// TOP API: cainiao.cboss.workplatform.workorder.create
    /// </summary>
    public class CainiaoCbossWorkplatformWorkorderCreateRequest : BaseTopRequest<Top.Api.Response.CainiaoCbossWorkplatformWorkorderCreateResponse>
    {
        /// <summary>
        /// 凭证地址列表
        /// </summary>
        public string AttachPathList { get; set; }

        /// <summary>
        /// 外部业务系统主键
        /// </summary>
        public string BizEntityValue { get; set; }

        /// <summary>
        /// 业务类型
        /// </summary>
        public string BizType { get; set; }

        /// <summary>
        /// 创建者淘宝id（区分子账号）
        /// </summary>
        public string CreatorId { get; set; }

        /// <summary>
        /// 创建者角色
        /// </summary>
        public string CreatorRole { get; set; }

        /// <summary>
        /// 扩展字段
        /// </summary>
        public string Features { get; set; }

        /// <summary>
        /// 运单号
        /// </summary>
        public string MailNo { get; set; }

        /// <summary>
        /// 货主商家用户id
        /// </summary>
        public string MemberId { get; set; }

        /// <summary>
        /// 货主用户角色
        /// </summary>
        public string MemberRole { get; set; }

        /// <summary>
        /// 工单创建备注
        /// </summary>
        public string Memo { get; set; }

        /// <summary>
        /// 店铺用户id
        /// </summary>
        public string ShopUserId { get; set; }

        /// <summary>
        /// 工单来源
        /// </summary>
        public string Source { get; set; }

        /// <summary>
        /// 来源签名，用于唯一区分不同的来源方
        /// </summary>
        public string SourceSign { get; set; }

        /// <summary>
        /// 交易订单id
        /// </summary>
        public string TradeId { get; set; }

        /// <summary>
        /// 工单类型
        /// </summary>
        public string WorkOrderType { get; set; }

        #region ITopRequest Members

        public override string GetApiName()
        {
            return "cainiao.cboss.workplatform.workorder.create";
        }

        public override IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("attach_path_list", this.AttachPathList);
            parameters.Add("biz_entity_value", this.BizEntityValue);
            parameters.Add("biz_type", this.BizType);
            parameters.Add("creator_id", this.CreatorId);
            parameters.Add("creator_role", this.CreatorRole);
            parameters.Add("features", this.Features);
            parameters.Add("mail_no", this.MailNo);
            parameters.Add("member_id", this.MemberId);
            parameters.Add("member_role", this.MemberRole);
            parameters.Add("memo", this.Memo);
            parameters.Add("shop_user_id", this.ShopUserId);
            parameters.Add("source", this.Source);
            parameters.Add("source_sign", this.SourceSign);
            parameters.Add("trade_id", this.TradeId);
            parameters.Add("work_order_type", this.WorkOrderType);
            if (this.otherParams != null)
            {
                parameters.AddAll(this.otherParams);
            }
            return parameters;
        }

        public override void Validate()
        {
            RequestValidator.ValidateMaxListSize("attach_path_list", this.AttachPathList, 20);
        }

        #endregion
    }
}
