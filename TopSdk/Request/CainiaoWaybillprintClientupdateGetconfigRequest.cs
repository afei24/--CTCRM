using System;
using System.Collections.Generic;
using Top.Api.Util;

namespace Top.Api.Request
{
    /// <summary>
    /// TOP API: cainiao.waybillprint.clientupdate.getconfig
    /// </summary>
    public class CainiaoWaybillprintClientupdateGetconfigRequest : BaseTopRequest<Top.Api.Response.CainiaoWaybillprintClientupdateGetconfigResponse>
    {
        /// <summary>
        /// 服务发起机器局域网ip
        /// </summary>
        public string LanIp { get; set; }

        /// <summary>
        /// 服务发起机器的物理地址
        /// </summary>
        public string Mac { get; set; }

        /// <summary>
        /// 当前消息版本
        /// </summary>
        public Nullable<long> Msgid { get; set; }

        /// <summary>
        /// 当前打印客户端版本
        /// </summary>
        public string Version { get; set; }

        #region ITopRequest Members

        public override string GetApiName()
        {
            return "cainiao.waybillprint.clientupdate.getconfig";
        }

        public override IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("lan_ip", this.LanIp);
            parameters.Add("mac", this.Mac);
            parameters.Add("msgid", this.Msgid);
            parameters.Add("version", this.Version);
            if (this.otherParams != null)
            {
                parameters.AddAll(this.otherParams);
            }
            return parameters;
        }

        public override void Validate()
        {
            RequestValidator.ValidateRequired("lan_ip", this.LanIp);
            RequestValidator.ValidateRequired("mac", this.Mac);
            RequestValidator.ValidateRequired("msgid", this.Msgid);
            RequestValidator.ValidateRequired("version", this.Version);
        }

        #endregion
    }
}
