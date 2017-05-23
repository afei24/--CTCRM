using System;
using System.Collections.Generic;
using System.Text;

namespace CTCRM.Entity
{
   
   public class SellerAuth
    {
       /// <summary>
        /// Access token
       /// </summary>
     
       public string access_token { get; set; }

       /// <summary>
       /// 卖家昵称
       /// </summary>
       public string taobao_user_nick { get; set; }

       /// <summary>
       /// 
       /// </summary>
       public string taobao_user_id { get; set; }

       /// <summary>
       /// Access token的类型目前只支持bearer
       /// </summary>
       public string token_type { get; set; }

       /// <summary>
       /// Access token过期时间
       /// </summary>
       public int expires_in { get; set; }

       /// <summary>
       /// Refresh token
       /// </summary>
       public string refresh_token { get; set; }

       /// <summary>
       /// Refresh token过期时间
       /// </summary>
       public int re_expires_in { get; set; }

       /// <summary>
       /// r1级别API或字段的访问过期时间
       /// </summary>
       public int r1_expires_in { get; set; }

       /// <summary>
       /// r2级别API或字段的访问过期时间
       /// </summary>
       public int r2_expires_in { get; set; }

       /// <summary>
       /// w1级别API或字段的访问过期时间
       /// </summary>
       public int w1_expires_in { get; set; }

       /// <summary>
       /// w2级别API或字段的访问过期时间
       /// </summary>
       public int w2_expires_in { get; set; }

    }
}
