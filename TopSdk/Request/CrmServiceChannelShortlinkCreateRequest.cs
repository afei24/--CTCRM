using System;
using System.Collections.Generic;
using Top.Api.Util;

namespace Top.Api.Request
{
    /// <summary>
    /// TOP API: taobao.crm.service.channel.shortlink.create
    /// </summary>
    public class CrmServiceChannelShortlinkCreateRequest : BaseTopRequest<Top.Api.Response.CrmServiceChannelShortlinkCreateResponse>
    {
        /// <summary>
        /// 淘短链类型：LT_ITEM（商品淘短链）,LT_SHOP（店铺首页淘短链）,LT_ACTIVITY（活动页淘短链）,LT_TRADE（订单详情页淘短链）。
        /// </summary>
        public string LinkType { get; set; }

        /// <summary>
        /// 类型为LT_ITEM时必须传入商品ID，类型为LT_SHOP时必须传入空值，类型为LT_ACTIVITY时传入活动页URL（URL必须是taobao.com,tmall.com,jaeapp.com这三个域名下的URL），类型为LT_TRADE时传入订单ID。
        /// </summary>
        public string ShortLinkData { get; set; }

        /// <summary>
        /// 淘短链名称（最多只能16个中文字符，类型为订单链接时传入订单ID）。
        /// </summary>
        public string ShortLinkName { get; set; }

        #region ITopRequest Members

        public override string GetApiName()
        {
            return "taobao.crm.service.channel.shortlink.create";
        }

        public override IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("link_type", this.LinkType);
            parameters.Add("short_link_data", this.ShortLinkData);
            parameters.Add("short_link_name", this.ShortLinkName);
            if (this.otherParams != null)
            {
                parameters.AddAll(this.otherParams);
            }
            return parameters;
        }

        public override void Validate()
        {
            RequestValidator.ValidateRequired("link_type", this.LinkType);
            RequestValidator.ValidateRequired("short_link_name", this.ShortLinkName);
        }

        #endregion
    }
}
