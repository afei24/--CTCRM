using System;
using System.Collections.Generic;
using System.Text;

namespace CTCRM.Entity
{
  public  class RateConfig
    {
        public long RateID { get; set; }

        public string SellerNick { get; set; }

        public long Tid { get; set; }

        public long Oid { get; set; }

        /// <summary>
        /// 方案一：秒评
        /// </summary>
        public int IsMiaoRate { get; set; }

        /// <summary>
        /// 方案二：等买家评价
        /// </summary>
        public int IsWaitBuyerRate { get; set; }

        /// <summary>
        /// 买家一直未评，设置时间抢评:天；小时；分钟
        /// </summary>
        public int WaitBuyerTimeDay { get; set; }
        public int WaitBuyerTimeHour { get; set; }
        public int WaitBuyerTimeFen { get; set; }

        /// <summary>
        /// 黑名单买家先评了之后的处理情况：1不自动评价；2自动好评；3自动中评；4自动差评
        /// </summary>
        public int BlackBuyerRatedIsRate { get; set; }

        /// <summary>
        /// 黑名单买家一直未评，设置抢评时间天；小时；分钟
        /// </summary>
        public int BlackBuyerNoRateQiangRateDay { get; set; }
        public int BlackBuyerNoRateQiangRateHour { get; set; }
        public int BlackBuyerNoRateQiangRateFen { get; set; }

        /// <summary>
        /// 方案三：定时抢评时间天；小时；分钟
        /// </summary>
        public int IsQiangRate { get; set; }
        public int QiangRateTimeDay { get; set; }
        public int QiangRateTimeHour { get; set; }
        public int QiangRateTimeFen { get; set; }

        public int AtuoAddBlackListBadRate { get; set; }
        public int AtuoAddBlackListTuiKuan { get; set; }

        /// <summary>
        /// 差评内容
        /// </summary>
        public string BadRateContent { get; set; }

        public string Result { get; set; }

        public string Role { get; set; }

        public string Content1 { get; set; }

        public string Content2 { get; set; }

        public string Content3 { get; set; }

        public DateTime CreateDate { get; set; }

        public DateTime UpdateDate { get; set; }

        public int ContentChoice { get; set; }

        public int isAutoRating { get; set; }
    }
}
