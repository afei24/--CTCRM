using CHENGTUAN.Components;
using CHENGTUAN.Entity;
using CTCRM.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace CTCRM.DAL
{
  public  class tuiGuangDAL
  {

      #region IP 代理

      /// <summary>
      /// IP 代理
      /// </summary>
      /// <param name="ip"></param>
      /// <returns></returns>
      public static bool AddIPProxy(string ip)
      {
          try
          {
              string query = "insert into IPProxy(ip,createTime)values(@ip,getdate())";

              SqlParameter[] param = new SqlParameter[] 
                {
                    new SqlParameter("@ip",ip)
                };
              DataBase.ExecuteSql(query, param);
              return true;
          }
          catch (Exception ex)
          {
              ExceptionReporter.WriteLog(ex, ExceptionPostion.TBApply_Data);
              return false;
          }
      }

      public static bool ChekIPProxy(string ip)
      {

          try
          {
              string query = "select 1 from IPProxy where ip = @ip ";
              // 设置SQL参数
              SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@ip",ip) 
            };
              DataTable dt = DataBase.ExecuteDt(query, param, CommandType.Text);
              return dt.Rows.Count > 0;
          }
          catch (Exception ex)
          {
              ExceptionReporter.WriteLog(ex, ExceptionPostion.TBApply_Data);
              return false;
          }
      }
      public static bool DeleteIPProxy(string ip)
      {
          try
          {
              string query = "delete from IPProxy where ip = @ip";

              SqlParameter[] param = new SqlParameter[] 
                {
                    new SqlParameter("@ip",ip) 
                };
              DataBase.ExecuteSql(query, param);
              return true;
          }
          catch (Exception ex)
          {
              ExceptionReporter.WriteLog(ex, ExceptionPostion.TBApply_Data);
              return false;
          }
      }
      public static DataTable GetIPProxyList()
      {
          try
          {
              string query = "select * from IPProxy";
              DataTable dt = DataBase.ExecuteDt(query);
              return dt;
          }
          catch (Exception ex)
          {
              ExceptionReporter.WriteLog(ex, ExceptionPostion.TBApply_Data);
              return null;
          }
      }
      #endregion

      #region 推广管理

      public static bool AddTuiGuang(TuiguangPro tuiguang)
      {
          try
          {
              string query = @"insert into TuiguangPro(itemNo,sellerNick,itemPicUrl,itemTitle,itemUrl,price,
                               inventory,tuiStatus,tuiAddress,createTime,endUseTime,openId)
                               values(@itemNo,@sellerNick,@itemPicUrl,@itemTitle,@itemUrl,@price,
                               @inventory,@tuiStatus,@tuiAddress,getdate(),@endUseTime,@openId)";

              SqlParameter[] param = new SqlParameter[] 
                {
                    new SqlParameter("@itemNo",string.IsNullOrEmpty(tuiguang.ItemNo)?"":tuiguang.ItemNo),
                    new SqlParameter("@sellerNick",string.IsNullOrEmpty(tuiguang.SellerNick)?"":tuiguang.SellerNick),
                    new SqlParameter("@itemPicUrl",string.IsNullOrEmpty(tuiguang.ItemPicUrl)?"":tuiguang.ItemPicUrl),
                    new SqlParameter("@itemTitle",string.IsNullOrEmpty(tuiguang.ItemTitle)?"":tuiguang.ItemTitle),
                    new SqlParameter("@itemUrl",string.IsNullOrEmpty(tuiguang.ItemUrl)?"":tuiguang.ItemUrl),
                    new SqlParameter("@price",string.IsNullOrEmpty(tuiguang.Price)?"":tuiguang.Price),
                    new SqlParameter("@inventory",string.IsNullOrEmpty(tuiguang.Inventory)?"":tuiguang.Inventory),
                    new SqlParameter("@tuiStatus",string.IsNullOrEmpty(tuiguang.TuiStatus)?"":tuiguang.TuiStatus),
                    new SqlParameter("@tuiAddress",string.IsNullOrEmpty(tuiguang.TuiAddress)?"":tuiguang.TuiAddress),
                    new SqlParameter("@endUseTime",string.IsNullOrEmpty(tuiguang.EndUseTime)?"":tuiguang.EndUseTime),
                    new SqlParameter("@openId",string.IsNullOrEmpty(tuiguang.OpenId)?"":tuiguang.OpenId)
                };
              DataBase.ExecuteSql(query, param);
              return true;
          }
          catch (Exception ex)
          {
              ExceptionReporter.WriteLog(ex, ExceptionPostion.TBApply_Data);
              return false;
          }
      }

      /// <summary>
      /// 返回有木丫使用的数据
      /// </summary>
      /// <param name="openId"></param>
      /// <returns></returns>
      public static DataTable GetTuiGuangItemsForYMY(string openId)
      {
          try
          {
              string query = "select * from TuiguangPro where openId = @openId and tuiStatus = 1";
              // 设置SQL参数
              SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@openId",openId) 
            };
              return DataBase.ExecuteDt(query, param, CommandType.Text);
          }
          catch (Exception ex)
          {
              ExceptionReporter.WriteLog(ex, ExceptionPostion.TBApply_Data);
              return null;
          }
      }

      public static DataTable GetAdLog(string sellerNick, string starteDate, string endDate)
      {
          string query = @"select count(1) as accessCount,CONVERT(varchar(100),createTime,23) as accessDate from TuiguangLog where sellerNick = @sellerNick  ";
          List<SqlParameter> list = new List<SqlParameter>();
          if (!string.IsNullOrEmpty(sellerNick))
          {
              SqlParameter p1 = new SqlParameter("@sellerNick", sellerNick);
              list.Add(p1);
          }
          if (!string.IsNullOrEmpty(starteDate))
          {
              query += " AND CONVERT(varchar(100),createTime,23) >= @startDate ";
              SqlParameter P2 = new SqlParameter("@startDate", Convert.ToDateTime(starteDate));
              list.Add(P2);
          }
          if (!string.IsNullOrEmpty(endDate))
          {
              query += " AND CONVERT(varchar(100),createTime,23) <= @endDate ";
              SqlParameter P3 = new SqlParameter("@endDate", Convert.ToDateTime(endDate).AddDays(1));
              list.Add(P3);
          }
          query += " group by CONVERT(varchar(100),createTime,23) order by CONVERT(varchar(100),createTime,23) desc ";
          SqlParameter[] strParam = list.ToArray();
          DataTable dt = DataBase.ExecuteDt(query, strParam, CommandType.Text);
          return dt;
      }

      public static DataTable GetAdLogBack(string sellerNick, string starteDate, string endDate)
      {
          string query = @"select sellerNick,planCount,count(1) as accessCount,CONVERT(varchar(100),createTime,23) as accessDate from TuiguangLog where 1 = 1 ";
          List<SqlParameter> list = new List<SqlParameter>();
          if (!string.IsNullOrEmpty(sellerNick))
          {
              query += " AND sellerNick = @sellerNick   ";
              SqlParameter p1 = new SqlParameter("@sellerNick", sellerNick);
              list.Add(p1);
          }
          if (!string.IsNullOrEmpty(starteDate))
          {
              query += " AND CONVERT(varchar(100),createTime,23) >= @startDate ";
              SqlParameter P2 = new SqlParameter("@startDate", Convert.ToDateTime(starteDate));
              list.Add(P2);
          }
          if (!string.IsNullOrEmpty(endDate))
          {
              query += " AND CONVERT(varchar(100),createTime,23) <= @endDate ";
              SqlParameter P3 = new SqlParameter("@endDate", Convert.ToDateTime(endDate).AddDays(1));
              list.Add(P3);
          }
          query += " group by CONVERT(varchar(100),createTime,23),sellerNick,planCount order by CONVERT(varchar(100),createTime,23) desc ";
          SqlParameter[] strParam = list.ToArray();
          DataTable dt = DataBase.ExecuteDt(query, strParam, CommandType.Text);
          return dt;
      }

      public static DataTable GetSystemOpenIDs()
      {
          try
          {
              string query = "select openid from TuiGuangIDs";
              return DataBase.ExecuteDt(query);
          }
          catch (Exception ex)
          {
              ExceptionReporter.WriteLog(ex, ExceptionPostion.TBApply_Data);
              return null;
          }
      }

      /// <summary>
      /// 下架/上架推广位
      /// </summary>
      /// <param name="o"></param>
      /// <returns></returns>
      public static bool UpdateTuiPro(TuiguangPro o)
      {
          try
          {
              string query = @"update TuiguangPro set tuiStatus = @tuiStatus where itemNo = @itemNo and sellerNick = @sellerNick";
              SqlParameter[] param = new SqlParameter[] 
                {
                    new SqlParameter("@tuiStatus",o.TuiStatus),
                    new SqlParameter("@itemNo",o.ItemNo),
                    new SqlParameter("@sellerNick",o.SellerNick),
                };
              DataBase.ExecuteSql(query, param);
              return true;
          }
          catch (Exception ex)
          {
              ExceptionReporter.WriteLog(ex, ExceptionPostion.TBApply_Data);
              return false;
          }
      }
      /// <summary>
      /// 标记分配的OPENID
      /// </summary>
      /// <param name="o"></param>
      /// <returns></returns>
      public static bool UpdateOpenStatus(string openID)
      {
          try
          {
              string query = @"update TuiGuangIDs set status = 1 where openid = @openid";
              SqlParameter[] param = new SqlParameter[] 
                {
                    new SqlParameter("@openid",openID)
                };
              DataBase.ExecuteSql(query, param);
              return true;
          }
          catch (Exception ex)
          {
              ExceptionReporter.WriteLog(ex, ExceptionPostion.TBApply_Data);
              return false;
          }
      }

      public static bool AddOPENID(string openID)
      {
          try
          {
              string query = @"insert TuiGuangIDs(openid,status)values(@openid,0)";
              SqlParameter[] param = new SqlParameter[] 
                {
                    new SqlParameter("@openid",openID)
                };
              DataBase.ExecuteSql(query, param);
              return true;
          }
          catch (Exception ex)
          {
              ExceptionReporter.WriteLog(ex, ExceptionPostion.TBApply_Data);
              return false;
          }
      }

      public static DataTable GetAllOPENIDs()
      {
          try
          {
              string query = @"select * from TuiGuangIDs order by status";
              return DataBase.ExecuteDt(query);
          }
          catch (Exception ex)
          {
              ExceptionReporter.WriteLog(ex, ExceptionPostion.TBApply_Data);
              return null;
          }
      }
      public static DataTable GetTuiGuangLog(string sellerNick, string startDate, string endDate)
      {
          try
          {
              string query = @"select * from TuiguangLog where 1 = 1  ";
              List<SqlParameter> list = new List<SqlParameter>();
              if (!string.IsNullOrEmpty(sellerNick))
              {
                  query += " AND sellerNick = @sellerNick ";
                  SqlParameter p1 = new SqlParameter("@sellerNick", sellerNick);
                  list.Add(p1);
              }
              if (!string.IsNullOrEmpty(startDate))
              {
                  query += " AND createTime >= @startDate ";
                  SqlParameter P2 = new SqlParameter("@startDate", Convert.ToDateTime(startDate));
                  list.Add(P2);
              }
              if (!string.IsNullOrEmpty(endDate))
              {
                  query += " AND createTime <= @endDate ";
                  SqlParameter P3 = new SqlParameter("@endDate", Convert.ToDateTime(endDate).AddDays(1));
                  list.Add(P3);
              }
              query += " order by createTime desc";
              SqlParameter[] strParam = list.ToArray();
              DataTable dt = DataBase.ExecuteDt(query, strParam, CommandType.Text);
              return dt;
          }
          catch (Exception ex)
          {
              ExceptionReporter.WriteLog(ex, ExceptionPostion.TBApply_Data);
              return null;
          }
      }

      public static bool DeleteTuiGuangHis(string transNo)
      {
          try
          {
              string query = @"delete from TuiguangLog where transNo = @transNo";
              SqlParameter[] param = new SqlParameter[] 
                {
                    new SqlParameter("@transNo",transNo)  
                };
              DataBase.ExecuteSql(query, param);
              return true;
          }
          catch (Exception ex)
          {
              ExceptionReporter.WriteLog(ex, ExceptionPostion.TBApply_Data);
              return false;
          }
      }

      public static string GetTuiSataus(string itemNo)
      {
          try
          {
              string query = "select tuiStatus from TuiguangPro where itemNo = @itemNo";
              // 设置SQL参数
              SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@itemNo",itemNo) 
            };
              DataTable tb = DataBase.ExecuteDt(query, param, CommandType.Text);
              if (tb != null && tb.Rows.Count == 1)
              {
                  return tb.Rows[0]["tuiStatus"].ToString();
              }
          }
          catch (Exception ex)
          {
              ExceptionReporter.WriteLog(ex, ExceptionPostion.TBApply_Data);
          }
          return "";
      }
      public static bool DeleteTuiPro(string itemNo)
      {
          try
          {
              string query = @"delete from TuiguangPro where itemNo = @itemNo";
              SqlParameter[] param = new SqlParameter[] 
                {
                    new SqlParameter("@itemNo",itemNo)
                };
              DataBase.ExecuteSql(query, param);
              return true;
          }
          catch (Exception ex)
          {
              ExceptionReporter.WriteLog(ex, ExceptionPostion.TBApply_Data);
              return false;
          }
      }

      /// <summary>
      /// 判断当前使用的OPENID是否已经分配了商家使用
      /// </summary>
      /// <param name="openId"></param>
      /// <returns></returns>
      public static Boolean ChekOpenIDCanUsed(string openId)
      {
          try
          {
              string query = "select 1 from TuiguangPro where openId = @openid ";
              // 设置SQL参数
              SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@openid",openId) 
            };
              DataTable tb = DataBase.ExecuteDt(query, param, CommandType.Text);
              if (tb != null && tb.Rows.Count > 0) { return false; }
              return true;
          }
          catch (Exception ex)
          {
              ExceptionReporter.WriteLog(ex, ExceptionPostion.TBApply_Data);
              return false;
          }
      }

      public static DataTable GetTuiGuangOpenID(string sellerNick)
      {
          try
          {
              string query = "select top 1 openId from TuiguangPro where sellerNick = @sellerNick";
              // 设置SQL参数
              SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@sellerNick",sellerNick) 
            };
              return DataBase.ExecuteDt(query, param, CommandType.Text);
          }
          catch (Exception ex)
          {
              ExceptionReporter.WriteLog(ex, ExceptionPostion.TBApply_Data);
              return null;
          }
      }

      public static DataTable ChekTuiGuangMaxItems(string sellerNick)
      {
          try
          {
              string query = "select 1 from TuiguangPro where sellerNick = @sellerNick and tuiStatus = 1 ";
              // 设置SQL参数
              SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@sellerNick",sellerNick) 
            };
              return DataBase.ExecuteDt(query, param, CommandType.Text);

          }
          catch (Exception ex)
          {
              ExceptionReporter.WriteLog(ex, ExceptionPostion.TBApply_Data);
              return null;
          }
      }

      public static bool ChekTuiGuangItem(string itemNo)
      {

          try
          {
              string query = "select 1 from TuiguangPro where itemNo = @itemNo ";
              // 设置SQL参数
              SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@itemNo",itemNo) 
            };
              DataTable dt = DataBase.ExecuteDt(query, param, CommandType.Text);
              return dt.Rows.Count > 0;
          }
          catch (Exception ex)
          {
              ExceptionReporter.WriteLog(ex, ExceptionPostion.TBApply_Data);
              return false;
          }
      }

      public static DataTable GetTuiGuangItems(string sellerNick)
      {
          try
          {
              string query = "select * from TuiguangPro where sellerNick = @sellerNick order by createTime desc";
              // 设置SQL参数
              SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@sellerNick",sellerNick) 
            };
              return DataBase.ExecuteDt(query, param, CommandType.Text);
          }
          catch (Exception ex)
          {
              ExceptionReporter.WriteLog(ex, ExceptionPostion.TBApply_Data);
              return null;
          }
      }
      #endregion

      #region 店铺管理

      public static bool AddDianPu(SellerShopForTuiGuang obj)
      {
          try
          {
              string query = @"insert into SellerShopForTuiGuang(sellerNick,shopName,cateName,type,address,huoyuan,hasShiTiShop,hasFactory,createTime)
values(@sellerNick,@shopName,@cateName,@type,@address,@huoyuan,@hasShiTiShop,@hasFactory,getdate())";

              SqlParameter[] param = new SqlParameter[] 
                {
                    new SqlParameter("@sellerNick",string.IsNullOrEmpty(obj.SellerNick)?"":obj.SellerNick),
                    new SqlParameter("@shopName",string.IsNullOrEmpty(obj.ShopName)?"":obj.ShopName),
                    new SqlParameter("@cateName",string.IsNullOrEmpty(obj.CateName)?"":obj.CateName),
                    new SqlParameter("@type",string.IsNullOrEmpty(obj.Type)?"":obj.Type),
                    new SqlParameter("@address",string.IsNullOrEmpty(obj.Address)?"":obj.Address),
                    new SqlParameter("@huoyuan",string.IsNullOrEmpty(obj.Huoyuan)?"":obj.Huoyuan),
                    new SqlParameter("@hasShiTiShop",string.IsNullOrEmpty(obj.HasShiTiShop)?"":obj.HasShiTiShop),
                    new SqlParameter("@hasFactory",string.IsNullOrEmpty(obj.HasFactory)?"":obj.HasFactory)
                };
              DataBase.ExecuteSql(query, param);
              return true;
          }
          catch (Exception ex)
          {
              ExceptionReporter.WriteLog(ex, ExceptionPostion.TBApply_Data);
              return false;
          }
      }

      public static bool UpdateDianPu(SellerShopForTuiGuang obj)
      {
          try
          {
              string query = @"update SellerShopForTuiGuang set shopName = @shopName,cateName = @cateName,type = @type,
                               address = @address,huoyuan = @huoyuan,hasShiTiShop = @hasShiTiShop,hasFactory = @hasFactory
                               where sellerNick = @sellerNick";

              SqlParameter[] param = new SqlParameter[] 
                {
                    new SqlParameter("@sellerNick",string.IsNullOrEmpty(obj.SellerNick)?"":obj.SellerNick),
                    new SqlParameter("@shopName",string.IsNullOrEmpty(obj.ShopName)?"":obj.ShopName),
                    new SqlParameter("@cateName",string.IsNullOrEmpty(obj.CateName)?"":obj.CateName),
                    new SqlParameter("@type",string.IsNullOrEmpty(obj.Type)?"":obj.Type),
                    new SqlParameter("@address",string.IsNullOrEmpty(obj.Address)?"":obj.Address),
                    new SqlParameter("@huoyuan",string.IsNullOrEmpty(obj.Huoyuan)?"":obj.Huoyuan),
                    new SqlParameter("@hasShiTiShop",string.IsNullOrEmpty(obj.HasShiTiShop)?"":obj.HasShiTiShop),
                    new SqlParameter("@hasFactory",string.IsNullOrEmpty(obj.HasFactory)?"":obj.HasFactory)
                };
              DataBase.ExecuteSql(query, param);
              return true;
          }
          catch (Exception ex)
          {
              ExceptionReporter.WriteLog(ex, ExceptionPostion.TBApply_Data);
              return false;
          }
      }

      public static bool ChekDianPu(string sellerNick)
      {

          try
          {
              string query = "select 1 from SellerShopForTuiGuang where sellerNick = @sellerNick ";
              // 设置SQL参数
              SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@sellerNick",sellerNick) 
            };
              DataTable dt = DataBase.ExecuteDt(query, param, CommandType.Text);
              return dt.Rows.Count > 0;
          }
          catch (Exception ex)
          {
              ExceptionReporter.WriteLog(ex, ExceptionPostion.TBApply_Data);
              return false;
          }
      }

      public static DataTable GetShopInfo(string sellerNick)
      {
          try
          {
              string query = "select * from SellerShopForTuiGuang where sellerNick = @sellerNick";
              // 设置SQL参数
              SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@sellerNick",sellerNick) 
            };
              return DataBase.ExecuteDt(query, param, CommandType.Text);
          }
          catch (Exception ex)
          {
              ExceptionReporter.WriteLog(ex, ExceptionPostion.TBApply_Data);
              return null;
          }
      }
      #endregion

      #region 管理后台

      public static DataTable GetSellerTuiGuangItems(string sellerNick, string startDate, string endDate, string tuiStatus)
      {
          try
          {
              string query = @"select * from TuiguangPro WHERE 1 = 1 ";
              List<SqlParameter> list = new List<SqlParameter>();
              if (!string.IsNullOrEmpty(sellerNick))
              {
                  query += " AND sellerNick = @sellerNick ";
                  SqlParameter p1 = new SqlParameter("@sellerNick", sellerNick);
                  list.Add(p1);
              }
              if (!string.IsNullOrEmpty(startDate))
              {
                  query += " AND createTime >= @startDate ";
                  SqlParameter p2 = new SqlParameter("@startDate", startDate);
                  list.Add(p2);
              }
              if (!string.IsNullOrEmpty(endDate))
              {
                  query += " AND createTime <= @endDate";
                  SqlParameter p3 = new SqlParameter("@endDate", endDate);
                  list.Add(p3);
              }
              if (!tuiStatus.Equals("---全部---"))
              {
                  if (tuiStatus.Equals("上架中"))
                  {
                      query += " AND tuiStatus = 1";
                  }
                  if (tuiStatus.Equals("已下架"))
                  {
                      query += " AND tuiStatus = 0";
                  }
              }
              query += " order by createTime desc";
              SqlParameter[] strParam = list.ToArray();
              DataTable dt = DataBase.ExecuteDt(query, strParam, CommandType.Text);
              return dt;

          }
          catch (Exception ex)
          {
              ExceptionReporter.WriteLog(ex, ExceptionPostion.TBApply_Data);
              return null;
          }
      }

      #endregion

      #region 刷数据
      public static DataTable GetValidData()
      {
          try
          {
              string query = @"select sellerNick,itemNo from TuiguangPro where cast(endUseTime as datetime) >= getdate() and tuiStatus = 1 ";
              DataTable dt = DataBase.ExecuteDt(query);
              return dt;
          }
          catch (Exception ex)
          {
              ExceptionReporter.WriteLog(ex, ExceptionPostion.TBApply_Data);
              return null;
          }
      }
      public static String AddTuiGuangLog(string sellerNick, string accessNum)
      {
          try
          {
              string query = @"insert into TuiguangLog(sellerNick,accessNum,createTime)values(@sellerNick,@accessNum,getdate())";
              SqlParameter[] param = new SqlParameter[] 
                {
                    new SqlParameter("@sellerNick",sellerNick),
                    new SqlParameter("@accessNum",accessNum)
                };
              DataBase.ExecuteSql(query, param);
              return "1";
          }
          catch (Exception ex)
          {
              ExceptionReporter.WriteLog(ex, ExceptionPostion.TBApply_Data);
              return "0";
          }
      }
      public static String AddTuiGuangLog(string sellerNick, string accessNum, int planCount)
      {
          try
          {
              string query = @"insert into TuiguangLog(sellerNick,accessNum,createTime,planCount)values(@sellerNick,@accessNum,getdate(),@planCount)";
              SqlParameter[] param = new SqlParameter[] 
                {
                    new SqlParameter("@sellerNick",sellerNick),
                    new SqlParameter("@accessNum",accessNum),
                    new SqlParameter("@planCount",planCount)
                };
              DataBase.ExecuteSql(query, param);
              return "1";
          }
          catch (Exception ex)
          {
              ExceptionReporter.WriteLog(ex, ExceptionPostion.TBApply_Data);
              return "0";
          }
      }
      /// <summary>
      /// 同一天同一个客户刷的流量数
      /// </summary>
      /// <param name="sellerNick"></param>
      /// <returns></returns>
      public static DataTable GetLogData(string sellerNick)
      {
          try
          {
              string query = @"select createTime,planCount from TuiguangLog where sellerNick = @sellerNick  
                                 and CONVERT(varchar(100),createTime, 12) = CONVERT(varchar(100),getdate(), 12)  order by createTime desc";
              SqlParameter[] param = new SqlParameter[]
                {
                    new SqlParameter("@sellerNick",sellerNick) 
                };
              return DataBase.ExecuteDt(query, param, CommandType.Text);
          }
          catch (Exception ex)
          {
              ExceptionReporter.WriteLog(ex, ExceptionPostion.TBApply_Data);
              return null;
          }
      }
      #endregion

  }
}
