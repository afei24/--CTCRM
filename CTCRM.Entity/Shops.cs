using System;
using System.Collections.Generic;
using System.Text;

namespace CTCRM.Entity
{
    public class Shops
    {
        /// <summary>
        /// 店铺编号
        /// </summary>
        public Int64 SID { get; set; }
        /// <summary>
        /// 店铺标题
        /// </summary>
        
        public string Title { get; set; }
        /// <summary>
        /// 图片路径
        /// </summary>
     
        public string Pic_Path { get; set; }
        /// <summary>
        /// 类别名称
        /// </summary>
        public string Cat_Name { get; set; }
        /// <summary>
        /// 类别ID
        /// </summary>
      
        public Int64 Cid { get; set; }
        /// <summary>
        /// 描述
        /// </summary>
     
        public string S_Desc { get; set; }
        /// <summary>
        /// 经营范围
        /// </summary>
     
        public string Area { get; set; }
        /// <summary>
        /// 淘宝更新时间
        /// </summary>
   
        public DateTime Modified { get; set; }
        /// <summary>
        /// 提交时间
        /// </summary>
     
        public DateTime PostDate { get; set; }
        /// <summary>
        /// 主要货源
        /// </summary>
      
        public string Source { get; set; }
        /// <summary>
        /// 是否有实体店
        /// </summary>
     
        public Boolean is_Shi { get; set; }
        /// <summary>
        /// 是否有仓库或者工厂
        /// </summary>
   
        public Boolean is_Factory { get; set; }
        /// <summary>
        /// 卖家昵称
        /// </summary>
    
        public string Nick { get; set; }
        /// <summary>
        /// 店铺公告
        /// </summary>
     
        public string Bulletin { get; set; }
        /// <summary>
        /// 店铺商品评分
        /// </summary>
   
        public float Items_Score { get; set; }
        /// <summary>
        /// 店铺服务评分
        /// </summary>
     
        public float Service_Score { get; set; }
        /// <summary>
        /// 发货速度评分
        /// </summary>
        public float Delivery_Score { get; set; }
    }
}
