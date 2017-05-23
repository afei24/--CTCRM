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
   public class RemainderDAL
   {
       #region Commnon
       public static Boolean CheckConfigMasterIsExit(string sellerNick)
       {
           try
           {
               string query = @"select 1 from SellerReminderMaster where sellerNick = @sellerNick";
               SqlParameter[] param = new SqlParameter[]
            {
                 new SqlParameter("@sellerNick",sellerNick)
            };
               DataTable dt = DataBase.ExecuteDt(query, param, CommandType.Text);
               if (dt != null && dt.Rows.Count > 0)
               {
                   return true;
               }
               return false;
           }
           catch (Exception ex)
           {
               ExceptionReporter.WriteLog(ex, ExceptionPostion.TBApply_Data);
               return false;
           }
       }

       public static DataTable GetMaster(string sellerNick)
       {
           try
           {
               string query = @"select * from SellerReminderMaster where sellerNick = @sellerNick ";
               SqlParameter[] param = new SqlParameter[]
                {
                    new SqlParameter("@sellerNick",sellerNick)
                };
               DataTable dt = DataBase.ExecuteDt(query, param, CommandType.Text);
               return dt;

           }
           catch (Exception ex)
           {
               ExceptionReporter.WriteLog(ex, ExceptionPostion.TBApply_Data);
               return null;
           }
       }
     
       #endregion

       #region UnPay
       public static Boolean CheckUnPayIsExit(string sellerNick)
       {
           try
           {
               string query = @"select 1 from UnpayReminderConfig where sellerNick = @sellerNick";
               SqlParameter[] param = new SqlParameter[]
            {
                 new SqlParameter("@sellerNick",sellerNick)
            };
               DataTable dt = DataBase.ExecuteDt(query, param, CommandType.Text);
               if (dt != null && dt.Rows.Count > 0)
               {
                   return true;
               }
               return false;
           }
           catch (Exception ex)
           {
               ExceptionReporter.WriteLog(ex, ExceptionPostion.TBApply_Data);
               return false;
           }
       }

       public static bool UpdateUnPayBasic(UnpayReminderConfig obj)
       {
           try
           {
               string query = @"update UnpayReminderConfig 
                                set fromTime = @fromTime,
                                toTime = @toTime,
                                swich = @swich,
                                amountFrom = @amountFrom,
                                amountTo = @amountTo,
                                zhouqi = @zhouqi,
                                updateDate = getdate()
                                where sellerNick = @sellerNick";

               SqlParameter[] param = new SqlParameter[] 
                {
                    new SqlParameter("@fromTime",obj.FromTime),
                    new SqlParameter("@toTime",obj.ToTime),
                    new SqlParameter("@swich",obj.Swichs),
                    new SqlParameter("@amountFrom",obj.AmountFrom),
                    new SqlParameter("@amountTo",obj.AmountTo),
                    new SqlParameter("@zhouqi",obj.Zhouqi),
                    new SqlParameter("@sellerNick",obj.SellerNick)
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

       public static bool UpdateUnPayTop(UnpayReminderConfig obj)
       {
           try
           {
               string query = @"update UnpayReminderConfig set flag = @flag,isAddBlackList = @isAddBlackList where sellerNick = @sellerNick";

               SqlParameter[] param = new SqlParameter[] 
                {
                    new SqlParameter("@flag",obj.Flag),
                    new SqlParameter("@isAddBlackList",obj.IsAddBlackList),
                    new SqlParameter("@sellerNick",obj.SellerNick)
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

       public static bool UpdateUnPayMsg(UnpayReminderConfig obj)
       {
           try
           {
               string query = @"update UnpayReminderConfig set msgContent = @msgContent where sellerNick = @sellerNick";

               SqlParameter[] param = new SqlParameter[] 
                {
                    new SqlParameter("@msgContent",obj.MsgContent),
                    new SqlParameter("@sellerNick",obj.SellerNick)
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
       public static bool UpdateUnPayMaster(SellerReminderMaster obj)
       {
           try
           {
               string query = @"update SellerReminderMaster set unpayOpen = @unpayOpen where sellerNick = @sellerNick";

               SqlParameter[] param = new SqlParameter[] 
                {
                    new SqlParameter("@unpayOpen",obj.UnpayOpen),
                    new SqlParameter("@sellerNick",obj.SellerNick)
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
       public static bool UpdateUnPayBasicIsOpen(UnpayReminderConfig obj)
       {
           try
           {
               string query = @"update UnpayReminderConfig set isOpen = @isOpen where sellerNick = @sellerNick";

               SqlParameter[] param = new SqlParameter[] 
                {
                    new SqlParameter("@isOpen",obj.IsOpen),
                    new SqlParameter("@sellerNick",obj.SellerNick)
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
       public static bool AddUnPay(UnpayReminderConfig obj)
       {
           try
           {
               string query = @"insert into UnpayReminderConfig(sellerNick,fromTime,toTime,swich,amountFrom,amountTo,zhouqi,
flag,isAddBlackList,msgContent,createDate)
values(@sellerNick,@fromTime,@toTime,@swich,@amountFrom,@amountTo,@zhouqi,
@flag,@isAddBlackList,@msgContent,getdate())";

               SqlParameter[] param = new SqlParameter[] 
                {
                    new SqlParameter("@sellerNick",obj.SellerNick),
                    new SqlParameter("@fromTime",obj.FromTime),
                    new SqlParameter("@toTime",obj.ToTime),
                    new SqlParameter("@swich",obj.Swichs),
                    new SqlParameter("@amountFrom",obj.AmountFrom),
                    new SqlParameter("@amountTo",obj.AmountTo),
                    new SqlParameter("@zhouqi",obj.Zhouqi),
                    new SqlParameter("@flag",obj.Flag),
                    new SqlParameter("@isAddBlackList",obj.IsAddBlackList),
                    new SqlParameter("@msgContent",obj.MsgContent)
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


       public static bool AddUnPayBasic(UnpayReminderConfig obj)
       {
           try
           {
               string query = @"insert into UnpayReminderConfig(sellerNick,fromTime,toTime,swich,amountFrom,amountTo,zhouqi,createDate)
values(@sellerNick,@fromTime,@toTime,@swich,@amountFrom,@amountTo,@zhouqi,getdate())";

               SqlParameter[] param = new SqlParameter[] 
                {
                    new SqlParameter("@sellerNick",obj.SellerNick),
                    new SqlParameter("@fromTime",obj.FromTime),
                    new SqlParameter("@toTime",obj.ToTime),
                    new SqlParameter("@swich",obj.Swichs),
                    new SqlParameter("@amountFrom",obj.AmountFrom),
                    new SqlParameter("@amountTo",obj.AmountTo),
                    new SqlParameter("@zhouqi",obj.Zhouqi)
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
       public static bool AddUnPayTop(UnpayReminderConfig obj)
       {
           try
           {
               string query = @"insert into UnpayReminderConfig(sellerNick,flag,isAddBlackList,createDate)
                                values(@sellerNick,@flag,@isAddBlackList,getdate())";

               SqlParameter[] param = new SqlParameter[] 
                {
                    new SqlParameter("@sellerNick",obj.SellerNick),
                    new SqlParameter("@flag",obj.Flag),
                    new SqlParameter("@isAddBlackList",obj.IsAddBlackList)
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
       public static bool AddUnPayMsg(UnpayReminderConfig obj)
       {
           try
           {
               string query = @"insert into UnpayReminderConfig(sellerNick,msgContent,createDate)
                                values(@sellerNick,@msgContent,getdate())";

               SqlParameter[] param = new SqlParameter[] 
                {
                    new SqlParameter("@sellerNick",obj.SellerNick),
                    new SqlParameter("@msgContent",obj.MsgContent)
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

       public static bool AddSellerReminderMasterForUnpay(SellerReminderMaster obj)
       {
           try
           {
               string query = @"insert into SellerReminderMaster(sellerNick,unpayOpen,createDate)values(@sellerNick,@unpayOpen,getdate())";

               SqlParameter[] param = new SqlParameter[] 
                {
                    new SqlParameter("@sellerNick",obj.SellerNick),
                    new SqlParameter("@unpayOpen",obj.UnpayOpen)
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

       public static DataTable GetUnPayBasicByNick(string sellerNick)
       {
           try
           {
               string query = @"select * from UnpayReminderConfig where sellerNick = @sellerNick ";
               SqlParameter[] param = new SqlParameter[]
                {
                    new SqlParameter("@sellerNick",sellerNick)
                };
               DataTable dt = DataBase.ExecuteDt(query, param, CommandType.Text);
               return dt;

           }
           catch (Exception ex)
           {
               ExceptionReporter.WriteLog(ex, ExceptionPostion.TBApply_Data);
               return null;
           }
       }     
       #endregion

       #region Shipping
       public static Boolean CheckShippingIsExit(string sellerNick)
       {
           try
           {
               string query = @"select 1 from ShippingReminderConfig where sellerNick = @sellerNick";
               SqlParameter[] param = new SqlParameter[]
            {
                 new SqlParameter("@sellerNick",sellerNick)
            };
               DataTable dt = DataBase.ExecuteDt(query, param, CommandType.Text);
               if (dt != null && dt.Rows.Count > 0)
               {
                   return true;
               }
               return false;
           }
           catch (Exception ex)
           {
               ExceptionReporter.WriteLog(ex, ExceptionPostion.TBApply_Data);
               return false;
           }
       }
       public static bool UpdateShippingBasic(ShippingReminderConfig obj)
       {
           try
           {
               string query = @"update ShippingReminderConfig 
                                set fromTime = @fromTime,
                                toTime = @toTime,
                                swich = @swich,
                                amountFrom = @amountFrom,
                                amountTo = @amountTo,
                                updateDate = getdate()
                                where sellerNick = @sellerNick";

               SqlParameter[] param = new SqlParameter[] 
                {
                    new SqlParameter("@fromTime",obj.FromTime),
                    new SqlParameter("@toTime",obj.ToTime),
                    new SqlParameter("@swich",obj.Swichs),
                    new SqlParameter("@amountFrom",obj.AmountFrom),
                    new SqlParameter("@amountTo",obj.AmountTo),
                    new SqlParameter("@sellerNick",obj.SellerNick)
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

       public static bool UpdateShippingTop(ShippingReminderConfig obj)
       {
           try
           {
               string query = @"update ShippingReminderConfig set flag = @flag,isAddBlackList = @isAddBlackList where sellerNick = @sellerNick";

               SqlParameter[] param = new SqlParameter[] 
                {
                    new SqlParameter("@flag",obj.Flag),
                    new SqlParameter("@isAddBlackList",obj.IsAddBlackList),
                    new SqlParameter("@sellerNick",obj.SellerNick)
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

       public static bool UpdateShippingMsg(ShippingReminderConfig obj)
       {
           try
           {
               string query = @"update ShippingReminderConfig set msgContent = @msgContent where sellerNick = @sellerNick";

               SqlParameter[] param = new SqlParameter[] 
                {
                    new SqlParameter("@msgContent",obj.MsgContent),
                    new SqlParameter("@sellerNick",obj.SellerNick)
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

       public static bool UpdateShippingMaster(SellerReminderMaster obj)
       {
           try
           {
               string query = @"update SellerReminderMaster set shippingOpen = @shippingOpen where sellerNick = @sellerNick";

               SqlParameter[] param = new SqlParameter[] 
                {
                    new SqlParameter("@shippingOpen",obj.ShippingOpen),
                    new SqlParameter("@sellerNick",obj.SellerNick)
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

       public static bool UpdateShippingBasicIsOpen(ShippingReminderConfig obj)
       {
           try
           {
               string query = @"update ShippingReminderConfig set isOpen = @isOpen where sellerNick = @sellerNick";

               SqlParameter[] param = new SqlParameter[] 
                {
                    new SqlParameter("@isOpen",obj.IsOpen),
                    new SqlParameter("@sellerNick",obj.SellerNick)
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

       public static bool AddShipping(ShippingReminderConfig obj)
       {
           try
           {
               string query = @"insert into ShippingReminderConfig(sellerNick,fromTime,toTime,swich,amountFrom,amountTo,
flag,isAddBlackList,msgContent,createDate)
values(@sellerNick,@fromTime,@toTime,@swich,@amountFrom,@amountTo,
@flag,@isAddBlackList,@msgContent,getdate())";

               SqlParameter[] param = new SqlParameter[] 
                {
                    new SqlParameter("@sellerNick",obj.SellerNick),
                    new SqlParameter("@fromTime",obj.FromTime),
                    new SqlParameter("@toTime",obj.ToTime),
                    new SqlParameter("@swich",obj.Swichs),
                    new SqlParameter("@amountFrom",obj.AmountFrom),
                    new SqlParameter("@amountTo",obj.AmountTo),
                    new SqlParameter("@flag",obj.Flag),
                    new SqlParameter("@isAddBlackList",obj.IsAddBlackList),
                    new SqlParameter("@msgContent",obj.MsgContent)
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


       public static bool AddShippingBasic(ShippingReminderConfig obj)
       {
           try
           {
               string query = @"insert into ShippingReminderConfig(sellerNick,fromTime,toTime,swich,amountFrom,amountTo,createDate)
values(@sellerNick,@fromTime,@toTime,@swich,@amountFrom,@amountTo,getdate())";

               SqlParameter[] param = new SqlParameter[] 
                {
                    new SqlParameter("@sellerNick",obj.SellerNick),
                    new SqlParameter("@fromTime",obj.FromTime),
                    new SqlParameter("@toTime",obj.ToTime),
                    new SqlParameter("@swich",obj.Swichs),
                    new SqlParameter("@amountFrom",obj.AmountFrom),
                    new SqlParameter("@amountTo",obj.AmountTo)
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
       public static bool AddShippingTop(ShippingReminderConfig obj)
       {
           try
           {
               string query = @"insert into ShippingReminderConfig(sellerNick,flag,isAddBlackList,createDate)
                                values(@sellerNick,@flag,@isAddBlackList,getdate())";

               SqlParameter[] param = new SqlParameter[] 
                {
                    new SqlParameter("@sellerNick",obj.SellerNick),
                    new SqlParameter("@flag",obj.Flag),
                    new SqlParameter("@isAddBlackList",obj.IsAddBlackList)
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
       public static bool AddShippingMsg(ShippingReminderConfig obj)
       {
           try
           {
               string query = @"insert into ShippingReminderConfig(sellerNick,msgContent,createDate)
                                values(@sellerNick,@msgContent,getdate())";

               SqlParameter[] param = new SqlParameter[] 
                {
                    new SqlParameter("@sellerNick",obj.SellerNick),
                    new SqlParameter("@msgContent",obj.MsgContent)
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

       public static bool AddSellerReminderMasterForShipping(SellerReminderMaster obj)
       {
           try
           {
               string query = @"insert into SellerReminderMaster(sellerNick,shippingOpen,createDate)values(@sellerNick,@shippingOpen,getdate())";

               SqlParameter[] param = new SqlParameter[] 
                {
                    new SqlParameter("@sellerNick",obj.SellerNick),
                    new SqlParameter("@shippingOpen",obj.ShippingOpen)
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

       public static DataTable GetShippingByNick(string sellerNick)
       {
           try
           {
               string query = @"select * from ShippingReminderConfig where sellerNick = @sellerNick ";
               SqlParameter[] param = new SqlParameter[]
                {
                    new SqlParameter("@sellerNick",sellerNick)
                };
               DataTable dt = DataBase.ExecuteDt(query, param, CommandType.Text);
               return dt;

           }
           catch (Exception ex)
           {
               ExceptionReporter.WriteLog(ex, ExceptionPostion.TBApply_Data);
               return null;
           }
       }     
       #endregion

       #region Arrived
       public static Boolean CheckArrivedIsExit(string sellerNick)
       {
           try
           {
               string query = @"select 1 from ArrivedReminderConfig where sellerNick = @sellerNick";
               SqlParameter[] param = new SqlParameter[]
            {
                 new SqlParameter("@sellerNick",sellerNick)
            };
               DataTable dt = DataBase.ExecuteDt(query, param, CommandType.Text);
               if (dt != null && dt.Rows.Count > 0)
               {
                   return true;
               }
               return false;
           }
           catch (Exception ex)
           {
               ExceptionReporter.WriteLog(ex, ExceptionPostion.TBApply_Data);
               return false;
           }
       }

       public static bool UpdateArrivedBasic(ArrivedReminderConfig obj)
       {
           try
           {
               string query = @"update ArrivedReminderConfig set
                                amountFrom = @amountFrom,
                                amountTo = @amountTo,
                                updateDate = getdate()
                                where sellerNick = @sellerNick";

               SqlParameter[] param = new SqlParameter[] 
                {
                    new SqlParameter("@amountFrom",obj.AmountFrom),
                    new SqlParameter("@amountTo",obj.AmountTo),
                    new SqlParameter("@sellerNick",obj.SellerNick)
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

       public static bool UpdateArrivedTop(ArrivedReminderConfig obj)
       {
           try
           {
               string query = @"update ArrivedReminderConfig set flag = @flag,isAddBlackList = @isAddBlackList where sellerNick = @sellerNick";

               SqlParameter[] param = new SqlParameter[] 
                {
                    new SqlParameter("@flag",obj.Flag),
                    new SqlParameter("@isAddBlackList",obj.IsAddBlackList),
                    new SqlParameter("@sellerNick",obj.SellerNick)
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

       public static bool UpdateArrivedMsg(ArrivedReminderConfig obj)
       {
           try
           {
               string query = @"update ArrivedReminderConfig set msgContent = @msgContent where sellerNick = @sellerNick";

               SqlParameter[] param = new SqlParameter[] 
                {
                    new SqlParameter("@msgContent",obj.MsgContent),
                    new SqlParameter("@sellerNick",obj.SellerNick)
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

       public static bool UpdateArrivedMaster(SellerReminderMaster obj)
       {
           try
           {
               string query = @"update SellerReminderMaster set arrivedOpen = @arrivedOpen where sellerNick = @sellerNick";

               SqlParameter[] param = new SqlParameter[] 
                {
                    new SqlParameter("@arrivedOpen",obj.ArrivedOpen),
                    new SqlParameter("@sellerNick",obj.SellerNick)
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

       public static bool UpdateArrivedBasicIsOpen(ArrivedReminderConfig obj)
       {
           try
           {
               string query = @"update ArrivedReminderConfig set isOpen = @isOpen where sellerNick = @sellerNick";

               SqlParameter[] param = new SqlParameter[] 
                {
                    new SqlParameter("@isOpen",obj.IsOpen),
                    new SqlParameter("@sellerNick",obj.SellerNick)
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

       public static bool AddArrived(ArrivedReminderConfig obj)
       {
           try
           {
               string query = @"insert into ArrivedReminderConfig(sellerNick,amountFrom,amountTo,
                                flag,isAddBlackList,msgContent,createDate)
                                values(@sellerNick,@amountFrom,@amountTo,@flag,@isAddBlackList,@msgContent,getdate())";

               SqlParameter[] param = new SqlParameter[] 
                {
                    new SqlParameter("@sellerNick",obj.SellerNick),
                    new SqlParameter("@amountFrom",obj.AmountFrom),
                    new SqlParameter("@amountTo",obj.AmountTo),
                    new SqlParameter("@flag",obj.Flag),
                    new SqlParameter("@isAddBlackList",obj.IsAddBlackList),
                    new SqlParameter("@msgContent",obj.MsgContent)
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


       public static bool AddArrivedBasic(ArrivedReminderConfig obj)
       {
           try
           {
               string query = @"insert into ArrivedReminderConfig(sellerNick,amountFrom,amountTo,createDate)
values(@sellerNick,@amountFrom,@amountTo,getdate())";

               SqlParameter[] param = new SqlParameter[] 
                {
                    new SqlParameter("@sellerNick",obj.SellerNick),
                    new SqlParameter("@amountFrom",obj.AmountFrom),
                    new SqlParameter("@amountTo",obj.AmountTo)
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
       public static bool AddArrivedTop(ArrivedReminderConfig obj)
       {
           try
           {
               string query = @"insert into ArrivedReminderConfig(sellerNick,flag,isAddBlackList,createDate)
                                values(@sellerNick,@flag,@isAddBlackList,getdate())";

               SqlParameter[] param = new SqlParameter[] 
                {
                    new SqlParameter("@sellerNick",obj.SellerNick),
                    new SqlParameter("@flag",obj.Flag),
                    new SqlParameter("@isAddBlackList",obj.IsAddBlackList)
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
       public static bool AddArrivedMsg(ArrivedReminderConfig obj)
       {
           try
           {
               string query = @"insert into ArrivedReminderConfig(sellerNick,msgContent,createDate)
                                values(@sellerNick,@msgContent,getdate())";

               SqlParameter[] param = new SqlParameter[] 
                {
                    new SqlParameter("@sellerNick",obj.SellerNick),
                    new SqlParameter("@msgContent",obj.MsgContent)
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

       public static bool AddSellerReminderMasterForArrived(SellerReminderMaster obj)
       {
           try
           {
               string query = @"insert into SellerReminderMaster(sellerNick,arrivedOpen,createDate)values(@sellerNick,@arrivedOpen,getdate())";

               SqlParameter[] param = new SqlParameter[] 
                {
                    new SqlParameter("@sellerNick",obj.SellerNick),
                    new SqlParameter("@arrivedOpen",obj.ArrivedOpen)
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

       public static DataTable GetArrivedByNick(string sellerNick)
       {
           try
           {
               string query = @"select * from ArrivedReminderConfig where sellerNick = @sellerNick ";
               SqlParameter[] param = new SqlParameter[]
                {
                    new SqlParameter("@sellerNick",sellerNick)
                };
               DataTable dt = DataBase.ExecuteDt(query, param, CommandType.Text);
               return dt;

           }
           catch (Exception ex)
           {
               ExceptionReporter.WriteLog(ex, ExceptionPostion.TBApply_Data);
               return null;
           }
       }     

       #endregion

       #region Sign
       public static Boolean CheckSignIsExit(string sellerNick)
       {
           try
           {
               string query = @"select 1 from SignReminderConfig where sellerNick = @sellerNick";
               SqlParameter[] param = new SqlParameter[]
            {
                 new SqlParameter("@sellerNick",sellerNick)
            };
               DataTable dt = DataBase.ExecuteDt(query, param, CommandType.Text);
               if (dt != null && dt.Rows.Count > 0)
               {
                   return true;
               }
               return false;
           }
           catch (Exception ex)
           {
               ExceptionReporter.WriteLog(ex, ExceptionPostion.TBApply_Data);
               return false;
           }
       }

       public static bool UpdateSignBasic(SignReminderConfig obj)
       {
           try
           {
               string query = @"update SignReminderConfig set
                                amountFrom = @amountFrom,
                                amountTo = @amountTo,
                                updateDate = getdate()
                                where sellerNick = @sellerNick";

               SqlParameter[] param = new SqlParameter[] 
                {
                    new SqlParameter("@amountFrom",obj.AmountFrom),
                    new SqlParameter("@amountTo",obj.AmountTo),
                    new SqlParameter("@sellerNick",obj.SellerNick)
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

       public static bool UpdateSignTop(SignReminderConfig obj)
       {
           try
           {
               string query = @"update SignReminderConfig set flag = @flag,isAddBlackList = @isAddBlackList where sellerNick = @sellerNick";

               SqlParameter[] param = new SqlParameter[] 
                {
                    new SqlParameter("@flag",obj.Flag),
                    new SqlParameter("@isAddBlackList",obj.IsAddBlackList),
                    new SqlParameter("@sellerNick",obj.SellerNick)
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

       public static bool UpdateSignMsg(SignReminderConfig obj)
       {
           try
           {
               string query = @"update SignReminderConfig set msgContent = @msgContent where sellerNick = @sellerNick";

               SqlParameter[] param = new SqlParameter[] 
                {
                    new SqlParameter("@msgContent",obj.MsgContent),
                    new SqlParameter("@sellerNick",obj.SellerNick)
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

       public static bool UpdateSignMaster(SellerReminderMaster obj)
       {
           try
           {
               string query = @"update SellerReminderMaster set signOpen = @signOpen where sellerNick = @sellerNick";

               SqlParameter[] param = new SqlParameter[] 
                {
                    new SqlParameter("@signOpen",obj.SignOpen),
                    new SqlParameter("@sellerNick",obj.SellerNick)
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

       public static bool UpdateSignBasicIsOpen(SignReminderConfig obj)
       {
           try
           {
               string query = @"update SignReminderConfig set isOpen = @isOpen where sellerNick = @sellerNick";

               SqlParameter[] param = new SqlParameter[] 
                {
                    new SqlParameter("@isOpen",obj.IsOpen),
                    new SqlParameter("@sellerNick",obj.SellerNick)
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

       public static bool AddSign(SignReminderConfig obj)
       {
           try
           {
               string query = @"insert into SignReminderConfig(sellerNick,amountFrom,amountTo,
                                flag,isAddBlackList,msgContent,createDate)
                                values(@sellerNick,@amountFrom,@amountTo,@flag,@isAddBlackList,@msgContent,getdate())";

               SqlParameter[] param = new SqlParameter[] 
                {
                    new SqlParameter("@sellerNick",obj.SellerNick),
                    new SqlParameter("@amountFrom",obj.AmountFrom),
                    new SqlParameter("@amountTo",obj.AmountTo),
                    new SqlParameter("@flag",obj.Flag),
                    new SqlParameter("@isAddBlackList",obj.IsAddBlackList),
                    new SqlParameter("@msgContent",obj.MsgContent)
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


       public static bool AddSignBasic(SignReminderConfig obj)
       {
           try
           {
               string query = @"insert into SignReminderConfig(sellerNick,amountFrom,amountTo,createDate)
values(@sellerNick,@amountFrom,@amountTo,getdate())";

               SqlParameter[] param = new SqlParameter[] 
                {
                    new SqlParameter("@sellerNick",obj.SellerNick),
                    new SqlParameter("@amountFrom",obj.AmountFrom),
                    new SqlParameter("@amountTo",obj.AmountTo)
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
       public static bool AddSignTop(SignReminderConfig obj)
       {
           try
           {
               string query = @"insert into SignReminderConfig(sellerNick,flag,isAddBlackList,createDate)
                                values(@sellerNick,@flag,@isAddBlackList,getdate())";

               SqlParameter[] param = new SqlParameter[] 
                {
                    new SqlParameter("@sellerNick",obj.SellerNick),
                    new SqlParameter("@flag",obj.Flag),
                    new SqlParameter("@isAddBlackList",obj.IsAddBlackList)
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
       public static bool AddSignMsg(SignReminderConfig obj)
       {
           try
           {
               string query = @"insert into SignReminderConfig(sellerNick,msgContent,createDate)
                                values(@sellerNick,@msgContent,getdate())";

               SqlParameter[] param = new SqlParameter[] 
                {
                    new SqlParameter("@sellerNick",obj.SellerNick),
                    new SqlParameter("@msgContent",obj.MsgContent)
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

       public static bool AddSellerReminderMasterForSign(SellerReminderMaster obj)
       {
           try
           {
               string query = @"insert into SellerReminderMaster(sellerNick,signOpen,createDate)values(@sellerNick,@signOpen,getdate())";

               SqlParameter[] param = new SqlParameter[] 
                {
                    new SqlParameter("@sellerNick",obj.SellerNick),
                    new SqlParameter("@signOpen",obj.SignOpen)
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

       public static DataTable GetSignByNick(string sellerNick)
       {
           try
           {
               string query = @"select * from SignReminderConfig where sellerNick = @sellerNick ";
               SqlParameter[] param = new SqlParameter[]
                {
                    new SqlParameter("@sellerNick",sellerNick)
                };
               DataTable dt = DataBase.ExecuteDt(query, param, CommandType.Text);
               return dt;

           }
           catch (Exception ex)
           {
               ExceptionReporter.WriteLog(ex, ExceptionPostion.TBApply_Data);
               return null;
           }
       }     
       #endregion

       #region DelaySipping
       public static Boolean CheckDelaySippingIsExit(string sellerNick)
       {
           try
           {
               string query = @"select 1 from DelaySippingReminderConfig where sellerNick = @sellerNick";
               SqlParameter[] param = new SqlParameter[]
            {
                 new SqlParameter("@sellerNick",sellerNick)
            };
               DataTable dt = DataBase.ExecuteDt(query, param, CommandType.Text);
               if (dt != null && dt.Rows.Count > 0)
               {
                   return true;
               }
               return false;
           }
           catch (Exception ex)
           {
               ExceptionReporter.WriteLog(ex, ExceptionPostion.TBApply_Data);
               return false;
           }
       }

       public static bool UpdateDelaySippingBasic(DelaySippingReminderConfig obj)
       {
           try
           {
               string query = @"update DelaySippingReminderConfig set
                                sendType = @sendType,
                                days = @days,
                                updateDate = getdate()
                                where sellerNick = @sellerNick";

               SqlParameter[] param = new SqlParameter[] 
                {
                    new SqlParameter("@sendType",obj.SendType),
                    new SqlParameter("@days",obj.Days),
                    new SqlParameter("@sellerNick",obj.SellerNick)
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

       public static bool UpdateDelaySippingTop(DelaySippingReminderConfig obj)
       {
           try
           {
               string query = @"update DelaySippingReminderConfig set flag = @flag,isAddBlackList = @isAddBlackList where sellerNick = @sellerNick";

               SqlParameter[] param = new SqlParameter[] 
                {
                    new SqlParameter("@flag",obj.Flag),
                    new SqlParameter("@isAddBlackList",obj.IsAddBlackList),
                    new SqlParameter("@sellerNick",obj.SellerNick)
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

       public static bool UpdateDelaySippingMsg(DelaySippingReminderConfig obj)
       {
           try
           {
               string query = @"update DelaySippingReminderConfig set msgContent = @msgContent where sellerNick = @sellerNick";

               SqlParameter[] param = new SqlParameter[] 
                {
                    new SqlParameter("@msgContent",obj.MsgContent),
                    new SqlParameter("@sellerNick",obj.SellerNick)
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

       public static bool UpdateDelaySippingMaster(SellerReminderMaster obj)
       {
           try
           {
               string query = @"update SellerReminderMaster set delayShipingOpen = @delayShipingOpen where sellerNick = @sellerNick";

               SqlParameter[] param = new SqlParameter[] 
                {
                    new SqlParameter("@delayShipingOpen",obj.DelayShipingOpen),
                    new SqlParameter("@sellerNick",obj.SellerNick)
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

       public static bool UpdateDelaySippingBasicIsOpen(DelaySippingReminderConfig obj)
       {
           try
           {
               string query = @"update DelaySippingReminderConfig set isOpen = @isOpen where sellerNick = @sellerNick";

               SqlParameter[] param = new SqlParameter[] 
                {
                    new SqlParameter("@isOpen",obj.IsOpen),
                    new SqlParameter("@sellerNick",obj.SellerNick)
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

       public static bool AddDelaySipping(DelaySippingReminderConfig obj)
       {
           try
           {
               string query = @"insert into DelaySippingReminderConfig(sellerNick,sendType,days,
                                flag,isAddBlackList,msgContent,createDate)
                                values(@sellerNick,@sendType,@days,@flag,@isAddBlackList,@msgContent,getdate())";

               SqlParameter[] param = new SqlParameter[] 
                {
                    new SqlParameter("@sellerNick",obj.SellerNick),
                    new SqlParameter("@sendType",obj.SendType),
                    new SqlParameter("@days",obj.Days),
                    new SqlParameter("@flag",obj.Flag),
                    new SqlParameter("@isAddBlackList",obj.IsAddBlackList),
                    new SqlParameter("@msgContent",obj.MsgContent)
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


       public static bool AddDelaySippingBasic(DelaySippingReminderConfig obj)
       {
           try
           {
               string query = @"insert into DelaySippingReminderConfig(sellerNick,sendType,days,createDate)
values(@sellerNick,@sendType,@days,getdate())";

               SqlParameter[] param = new SqlParameter[] 
                {
                    new SqlParameter("@sellerNick",obj.SellerNick),
                    new SqlParameter("@sendType",obj.SendType),
                    new SqlParameter("@days",obj.Days)
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
       public static bool AddDelaySippingTop(DelaySippingReminderConfig obj)
       {
           try
           {
               string query = @"insert into DelaySippingReminderConfig(sellerNick,flag,isAddBlackList,createDate)
                                values(@sellerNick,@flag,@isAddBlackList,getdate())";

               SqlParameter[] param = new SqlParameter[] 
                {
                    new SqlParameter("@sellerNick",obj.SellerNick),
                    new SqlParameter("@flag",obj.Flag),
                    new SqlParameter("@isAddBlackList",obj.IsAddBlackList)
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
       public static bool AddDelaySippingMsg(DelaySippingReminderConfig obj)
       {
           try
           {
               string query = @"insert into DelaySippingReminderConfig(sellerNick,msgContent,createDate)
                                values(@sellerNick,@msgContent,getdate())";

               SqlParameter[] param = new SqlParameter[] 
                {
                    new SqlParameter("@sellerNick",obj.SellerNick),
                    new SqlParameter("@msgContent",obj.MsgContent)
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

       public static bool AddSellerReminderMasterForDelayShipping(SellerReminderMaster obj)
       {
           try
           {
               string query = @"insert into SellerReminderMaster(sellerNick,delayShipingOpen,createDate)values(@sellerNick,@delayShipingOpen,getdate())";

               SqlParameter[] param = new SqlParameter[] 
                {
                    new SqlParameter("@sellerNick",obj.SellerNick),
                    new SqlParameter("@delayShipingOpen",obj.DelayShipingOpen)
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

       public static DataTable GetDelaySippingByNick(string sellerNick)
       {
           try
           {
               string query = @"select * from DelaySippingReminderConfig where sellerNick = @sellerNick ";
               SqlParameter[] param = new SqlParameter[]
                {
                    new SqlParameter("@sellerNick",sellerNick)
                };
               DataTable dt = DataBase.ExecuteDt(query, param, CommandType.Text);
               return dt;

           }
           catch (Exception ex)
           {
               ExceptionReporter.WriteLog(ex, ExceptionPostion.TBApply_Data);
               return null;
           }
       }     
       #endregion

       #region Pay

       public static Boolean CheckPayIsExit(string sellerNick)
       {
           try
           {
               string query = @"select 1 from PayReminderConfig where sellerNick = @sellerNick";
               SqlParameter[] param = new SqlParameter[]
            {
                 new SqlParameter("@sellerNick",sellerNick)
            };
               DataTable dt = DataBase.ExecuteDt(query, param, CommandType.Text);
               if (dt != null && dt.Rows.Count > 0)
               {
                   return true;
               }
               return false;
           }
           catch (Exception ex)
           {
               ExceptionReporter.WriteLog(ex, ExceptionPostion.TBApply_Data);
               return false;
           }
       }

       public static bool UpdatePayBasic(PayReminderConfig obj)
       {
           try
           {
               string query = @"update PayReminderConfig set
                                fromTime = @fromTime,
                                toTime = @toTime,
                                amountFrom = @amountFrom,
                                amountTo = @amountTo,
                                updateDate = getdate()
                                where sellerNick = @sellerNick";

               SqlParameter[] param = new SqlParameter[] 
                {
                    new SqlParameter("@fromTime",obj.FromTime),
                    new SqlParameter("@toTime",obj.ToTime),
                     new SqlParameter("@amountFrom",obj.AmountFrom),
                    new SqlParameter("@amountTo",obj.AmountTo),
                    new SqlParameter("@sellerNick",obj.SellerNick)
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

       public static bool UpdatePayMsg(PayReminderConfig obj)
       {
           try
           {
               string query = @"update PayReminderConfig set msgContent = @msgContent where sellerNick = @sellerNick";

               SqlParameter[] param = new SqlParameter[] 
                {
                    new SqlParameter("@msgContent",obj.MsgContent),
                    new SqlParameter("@sellerNick",obj.SellerNick)
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

       public static bool UpdatePayMaster(SellerReminderMaster obj)
       {
           try
           {
               string query = @"update SellerReminderMaster set payOpen = @payOpen where sellerNick = @sellerNick";

               SqlParameter[] param = new SqlParameter[] 
                {
                    new SqlParameter("@payOpen",obj.PayOpen),
                    new SqlParameter("@sellerNick",obj.SellerNick)
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

       public static bool UpdatePayBasicIsOpen(PayReminderConfig obj)
       {
           try
           {
               string query = @"update PayReminderConfig set isOpen = @isOpen where sellerNick = @sellerNick";

               SqlParameter[] param = new SqlParameter[] 
                {
                    new SqlParameter("@isOpen",obj.IsOpen),
                    new SqlParameter("@sellerNick",obj.SellerNick)
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

       public static bool AddPay(PayReminderConfig obj)
       {
           try
           {
               string query = @"insert into PayReminderConfig(sellerNick,fromTime,toTime,
                                amountFrom,amountTo,msgContent,createDate)
                                values(@sellerNick,@fromTime,@toTime,@amountFrom,@amountTo,@msgContent,getdate())";

               SqlParameter[] param = new SqlParameter[] 
                {
                    new SqlParameter("@sellerNick",obj.SellerNick),
                    new SqlParameter("@fromTime",obj.FromTime),
                    new SqlParameter("@toTime",obj.ToTime),
                    new SqlParameter("@amountFrom",obj.AmountFrom),
                    new SqlParameter("@amountTo",obj.AmountTo),
                    new SqlParameter("@msgContent",obj.MsgContent)
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

       public static bool AddPayBasic(PayReminderConfig obj)
       {
           try
           {
               string query = @"insert into PayReminderConfig(sellerNick,fromTime,toTime,amountFrom,amountTo,createDate)
                                values(@sellerNick,@fromTime,@toTime,@amountFrom,@amountTo,getdate())";

               SqlParameter[] param = new SqlParameter[] 
                {
                    new SqlParameter("@sellerNick",obj.SellerNick),
                    new SqlParameter("@fromTime",obj.FromTime),
                     new SqlParameter("@toTime",obj.ToTime),
                    new SqlParameter("@amountFrom",obj.AmountFrom),
                    new SqlParameter("@amountTo",obj.AmountTo)
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

       public static bool AddPayMsg(PayReminderConfig obj)
       {
           try
           {
               string query = @"insert into PayReminderConfig(sellerNick,msgContent,createDate)
                                values(@sellerNick,@msgContent,getdate())";

               SqlParameter[] param = new SqlParameter[] 
                {
                    new SqlParameter("@sellerNick",obj.SellerNick),
                    new SqlParameter("@msgContent",obj.MsgContent)
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

       public static bool AddSellerReminderMasterForPay(SellerReminderMaster obj)
       {
           try
           {
               string query = @"insert into SellerReminderMaster(sellerNick,payOpen,createDate)values(@sellerNick,@payOpen,getdate())";

               SqlParameter[] param = new SqlParameter[] 
                {
                    new SqlParameter("@sellerNick",obj.SellerNick),
                    new SqlParameter("@payOpen",obj.PayOpen)
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

       public static DataTable GetPayByNick(string sellerNick)
       {
           try
           {
               string query = @"select * from PayReminderConfig where sellerNick = @sellerNick ";
               SqlParameter[] param = new SqlParameter[]
                {
                    new SqlParameter("@sellerNick",sellerNick)
                };
               DataTable dt = DataBase.ExecuteDt(query, param, CommandType.Text);
               return dt;

           }
           catch (Exception ex)
           {
               ExceptionReporter.WriteLog(ex, ExceptionPostion.TBApply_Data);
               return null;
           }
       }     

       #endregion

       #region ConfirmPay
       public static Boolean CheckConfirmPayIsExit(string sellerNick)
       {
           try
           {
               string query = @"select 1 from ConfirmPayReminderConfig where sellerNick = @sellerNick";
               SqlParameter[] param = new SqlParameter[]
            {
                 new SqlParameter("@sellerNick",sellerNick)
            };
               DataTable dt = DataBase.ExecuteDt(query, param, CommandType.Text);
               if (dt != null && dt.Rows.Count > 0)
               {
                   return true;
               }
               return false;
           }
           catch (Exception ex)
           {
               ExceptionReporter.WriteLog(ex, ExceptionPostion.TBApply_Data);
               return false;
           }
       }

       public static bool UpdateConfirmPayBasic(ConfirmPayReminderConfig obj)
       {
           try
           {
               string query = @"update ConfirmPayReminderConfig set
                                fromTime = @fromTime,
                                toTime = @toTime,
                                zhouqi = @zhouqi,
                                amountFrom = @amountFrom,
                                amountTo = @amountTo,
                                updateDate = getdate()
                                where sellerNick = @sellerNick";

               SqlParameter[] param = new SqlParameter[] 
                {
                    new SqlParameter("@fromTime",obj.FromTime),
                    new SqlParameter("@toTime",obj.ToTime),
                    new SqlParameter("@zhouqi",obj.ZhouQi),
                    new SqlParameter("@amountFrom",obj.AmountFrom),
                    new SqlParameter("@amountTo",obj.AmountTo),
                    new SqlParameter("@sellerNick",obj.SellerNick)
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

       public static bool UpdateConfirmPayMsg(ConfirmPayReminderConfig obj)
       {
           try
           {
               string query = @"update ConfirmPayReminderConfig set msgContent = @msgContent where sellerNick = @sellerNick";

               SqlParameter[] param = new SqlParameter[] 
                {
                    new SqlParameter("@msgContent",obj.MsgContent),
                    new SqlParameter("@sellerNick",obj.SellerNick)
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

       public static bool UpdatePayConfirmMaster(SellerReminderMaster obj)
       {
           try
           {
               string query = @"update SellerReminderMaster set confirmPayOpen = @confirmPayOpen where sellerNick = @sellerNick";

               SqlParameter[] param = new SqlParameter[] 
                {
                    new SqlParameter("@confirmPayOpen",obj.ConfirmPayOpen),
                    new SqlParameter("@sellerNick",obj.SellerNick)
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

       public static bool UpdatePayConfirmBasicIsOpen(ConfirmPayReminderConfig obj)
       {
           try
           {
               string query = @"update ConfirmPayReminderConfig set isOpen = @isOpen where sellerNick = @sellerNick";

               SqlParameter[] param = new SqlParameter[] 
                {
                    new SqlParameter("@isOpen",obj.IsOpen),
                    new SqlParameter("@sellerNick",obj.SellerNick)
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

       public static bool AddPayConfirm(ConfirmPayReminderConfig obj)
       {
           try
           {
               string query = @"insert into ConfirmPayReminderConfig(sellerNick,fromTime,toTime,zhouqi,
                                amountFrom,amountTo,msgContent,createDate)
                                values(@sellerNick,@fromTime,@toTime,@zhouqi,@amountFrom,@amountTo,@msgContent,getdate())";

               SqlParameter[] param = new SqlParameter[] 
                {
                    new SqlParameter("@sellerNick",obj.SellerNick),
                    new SqlParameter("@fromTime",obj.FromTime),
                    new SqlParameter("@toTime",obj.ToTime),
                    new SqlParameter("@zhouqi",obj.ZhouQi),
                    new SqlParameter("@amountFrom",obj.AmountFrom),
                    new SqlParameter("@amountTo",obj.AmountTo),
                    new SqlParameter("@msgContent",obj.MsgContent)
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

       public static bool AddPayConfirmBasic(ConfirmPayReminderConfig obj)
       {
           try
           {
               string query = @"insert into ConfirmPayReminderConfig(sellerNick,fromTime,toTime,zhouqi,amountFrom,amountTo,createDate)
                                values(@sellerNick,@fromTime,@toTime,@zhouqi,@amountFrom,@amountTo,getdate())";

               SqlParameter[] param = new SqlParameter[] 
                {
                    new SqlParameter("@sellerNick",obj.SellerNick),
                    new SqlParameter("@fromTime",obj.FromTime),
                    new SqlParameter("@toTime",obj.ToTime),
                    new SqlParameter("@zhouqi",obj.ZhouQi),
                    new SqlParameter("@amountFrom",obj.AmountFrom),
                    new SqlParameter("@amountTo",obj.AmountTo)
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

       public static bool AddPayConfirmMsg(ConfirmPayReminderConfig obj)
       {
           try
           {
               string query = @"insert into ConfirmPayReminderConfig(sellerNick,msgContent,createDate)
                                values(@sellerNick,@msgContent,getdate())";

               SqlParameter[] param = new SqlParameter[] 
                {
                    new SqlParameter("@sellerNick",obj.SellerNick),
                    new SqlParameter("@msgContent",obj.MsgContent)
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

       public static bool AddSellerReminderMasterForPayConfrim(SellerReminderMaster obj)
       {
           try
           {
               string query = @"insert into SellerReminderMaster(sellerNick,confirmPayOpen,createDate)values(@sellerNick,@confirmPayOpen,getdate())";

               SqlParameter[] param = new SqlParameter[] 
                {
                    new SqlParameter("@sellerNick",obj.SellerNick),
                    new SqlParameter("@confirmPayOpen",obj.ConfirmPayOpen)
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

       public static DataTable GetPayConfirmByNick(string sellerNick)
       {
           try
           {
               string query = @"select * from ConfirmPayReminderConfig where sellerNick = @sellerNick ";
               SqlParameter[] param = new SqlParameter[]
                {
                    new SqlParameter("@sellerNick",sellerNick)
                };
               DataTable dt = DataBase.ExecuteDt(query, param, CommandType.Text);
               return dt;

           }
           catch (Exception ex)
           {
               ExceptionReporter.WriteLog(ex, ExceptionPostion.TBApply_Data);
               return null;
           }
       }     
       #endregion

       #region GetMsgSendHis

       public static DataTable GetMsgReminderHis(string sellerNick, string buyerNick, string startDate, string endDate, string cellPhone, string sendType)
       {
           try
           {
               string query = @"select sellerNick,buyerNick,cellPhone, CONVERT(varchar(100),sendDate, 23) as sendDate,msgContent from "+ sendType +
                                "  where sellerNick = @sellerNick  ";
               List<SqlParameter> list = new List<SqlParameter>();
               if (!string.IsNullOrEmpty(buyerNick))
               {
                   query += " AND buyerNick = @buyerNick ";
                   SqlParameter p1 = new SqlParameter("@buyerNick", buyerNick);
                   list.Add(p1);
               }

               if (!string.IsNullOrEmpty(startDate))
               {
                   query += " AND sendDate >= @sendDate1 ";
                   SqlParameter P5 = new SqlParameter("@sendDate1", startDate);
                   list.Add(P5);
               }
               if (!string.IsNullOrEmpty(endDate))
               {
                   query += " AND sendDate <= @sendDate2 ";
                   SqlParameter P6 = new SqlParameter("@sendDate2", endDate);
                   list.Add(P6);
               }
               if (!string.IsNullOrEmpty(cellPhone))
               {
                   query += " AND cellPhone = @cellPhone ";
                   SqlParameter P66 = new SqlParameter("@cellPhone", cellPhone);
                   list.Add(P66);
               }

               SqlParameter P11 = new SqlParameter("@sellerNick", sellerNick);
               list.Add(P11);

               query += " order by sendDate desc ";
               SqlParameter[] strParam = list.ToArray();
               DataTable ds = DataBase.ExecuteDt(query, strParam, CommandType.Text);
               return ds;
           }
           catch (Exception ex)
           {
               ExceptionReporter.WriteLog(ex, ExceptionPostion.TBApply_Data);
               return null;
           }
       }

       #endregion

       #region GetReport

       public static string GetMsgHisReport(string sellerNick,string sendType)
       {
           try
           {
               string query = @"select count(1) counter from " + sendType +
                                "  where CONVERT(varchar(100),sendDate, 23)  = CONVERT(varchar(100),getdate(), 23) and sellerNick = @sellerNick  ";
               SqlParameter[] param = new SqlParameter[]
                {
                    new SqlParameter("@sellerNick",sellerNick)
                };
               DataTable dt = DataBase.ExecuteDt(query, param, CommandType.Text);
               if (dt != null && dt.Rows.Count > 0)
               {
                   return dt.Rows[0]["counter"].ToString();
               }
               return "0";
           }
           catch (Exception ex)
           {
               ExceptionReporter.WriteLog(ex, ExceptionPostion.TBApply_Data);
               return "0";
           }
       }

       #endregion

       #region CheckSellerNofitySatus

       public static Boolean CheckSellerNofityForUnpay(string sellerNick)
       {
           try
           {
               string query = @"select 1 from SellerReminderMaster where (shippingOpen = 1
                                or arrivedOpen = 1 or signOpen = 1 or delayShipingOpen = 1 or payOpen = 1
                                or confirmPayOpen = 1 or rateOpen = 1) and  sellerNick = @sellerNick ";
               SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@sellerNick",sellerNick)
            };
               DataTable dt = DataBase.ExecuteDt(query, param, CommandType.Text);
               if (dt != null && dt.Rows.Count > 0)
               {
                   return true;
               }
               return false;
           }
           catch (Exception ex)
           {
               ExceptionReporter.WriteLog(ex, ExceptionPostion.TBApply_Data);
               return false;
           }
       }
       #endregion
   }
}
