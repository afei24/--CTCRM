using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CTCRM.Entity;
using System.Data;
using System.Data.SqlClient;


//2016-10-20
namespace CTCRM.DAL
{
    public class MsgContentsDLL
    {
        //添加msg
        public static bool addMsg(MsgContents msg)
        {
            try
            {
                string query = "insert into tab_msgTemp(page_type,type_title,msg_content,msg_use) values(@page_type,@type_title,@msg_content,@msg_use)";
                SqlParameter[] param = new SqlParameter[] 
                {
                    new SqlParameter("@page_type",msg.PageType),
                    new SqlParameter("@type_title",msg.TypeTitle),
                    new SqlParameter("@msg_content",msg.MsgContent),
                    new SqlParameter("@msg_use",msg.msgUse)

                };
                DataBase.ExecuteSql(query, param);
                return true;
            }
            catch
            {
                return false;
            }
        }

        //删除msg
        public static bool deleteMsg(string id)
        {
            try
            {
                string query = "delete from  tab_msgTemp where id=@id";
                SqlParameter[] param = new SqlParameter[] 
                {
                    new SqlParameter("@id",id)
                };
                DataBase.ExecuteSql(query, param);
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static bool updateMsg(string id, string pageType, string msg,int use)
        {
            try
            {
                string query = "update tab_msgTemp set page_type=@pageTtype,msg_content=@msg_content,msg_use=@msg_use  where id=@id";
                SqlParameter[] param = new SqlParameter[] 
                {
                    new SqlParameter("@id",id),
                     new SqlParameter("@pageTtype",pageType),
                      new SqlParameter("@msg_content",msg),
                      new SqlParameter("@msg_use",use)
                };
                DataBase.ExecuteSql(query, param);
                return true;
            }
            catch
            {
                return false;
            }

        }


        //根据类型获取msg
        public static DataTable getMsgByPageType(string pageType)
        {
            try
            {
                string query = "select * from  tab_msgTemp where page_type=@page_type";
                SqlParameter[] param = new SqlParameter[] 
                {
                    new SqlParameter("@page_type",pageType)
                };
                return DataBase.ExecuteDt(query, param, CommandType.Text); ;
            }
            catch
            {
                return null; ;
            }
        }

        //根据类型和二级标题获取msg
        public static DataTable getMsgByPageType(string pageType, string title)
        {
            try
            {
                string query = "select * from  tab_msgTemp where page_type=@page_type";
                SqlParameter[] param = new SqlParameter[] 
                {
                    new SqlParameter("@page_type",pageType),
                   
                };
                return DataBase.ExecuteDt(query, param, CommandType.Text); 
            }
            catch
            {
                return null; ;
            }
        }

        //根据类型和二级标题获取msg
        public static DataTable getMsgByPageType()
        {
            try
            {
                string query = "select num=row_number() over(order by id),* from  tab_msgTemp order by page_type";
                return DataBase.ExecuteDt(query); ;
            }
            catch
            {
                return null; ;
            }
        }

        //根据类型和二级标题获取msg
        public static DataTable getMsgByPageType(int ret)
        {
            try
            {
                string query = "select num=row_number() over(order by id),* from  tab_msgTemp where msg_use=@msg_use order by page_type";
                SqlParameter[] param = new SqlParameter[] 
                {
                    new SqlParameter("@msg_use",ret)
                };
                return DataBase.ExecuteDt(query, param, CommandType.Text); 
            }
            catch
            {
                return null; ;
            }
        }

    }
}
