using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CTCRM.Entity;
using CTCRM.DAL;
using System.Data;

namespace CTCRM.Components
{
   public class MsgContentsBLL
    {
        /// <summary>
        /// 添加短信
        /// </summary>
        /// <param name="msg"></param>
        /// <returns></returns>
        public static bool addMsg(MsgContents msg)
        {
            return MsgContentsDLL.addMsg(msg);
        }


        public static bool deleteMsg(string id)
        {
            return MsgContentsDLL.deleteMsg(id);
        }

        public static bool updateMsg(string id, string pageType, string msg,int use)
        {
            return MsgContentsDLL.updateMsg(id, pageType, msg, use);
        }

        /// <summary>
        /// 根据类型获取短信
        /// </summary>
        /// <param name="pageType"></param>
        /// <returns></returns>
        public static DataTable getMsgByPageType(string pageType)
        {
            return MsgContentsDLL.getMsgByPageType(pageType);
        }

        /// <summary>
        /// 根据类型和二级标题获取短信
        /// </summary>
        /// <param name="pageType"></param>
        /// <param name="title"></param>
        /// <returns></returns>
        public static DataTable getMsgByPageType(string pageType, string title)
        {
            return MsgContentsDLL.getMsgByPageType(pageType, title);
        }

       /// <summary>
       /// 获取所有模板短信
       /// </summary>
       /// <returns></returns>
        public static DataTable getMsgByPageType()
        {
            return MsgContentsDLL.getMsgByPageType();
        }

        /// <summary>
        /// 获取所有模板短信
        /// </summary>
        /// <returns></returns>
        public static DataTable getMsgByPageType(int ret)
        {
            return MsgContentsDLL.getMsgByPageType(ret);
        }


    }
}
