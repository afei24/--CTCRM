using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Data;
using CTCRM.Components;
using CTCRM.Entity;
using CHENGTUAN.Components;
using CHENGTUAN.Entity;
using CTCRM.DAL;
using System.IO;

namespace CRMService
{
    class MemSync
    {

        //#if DEBUG
        // static byte DeleNum = 1;
        //#else
        static byte DeleNum = 64;
        //#endif
        public delegate string funSyncDele(string strUserName, string strSession, string strTime);
        static funSyncDele[] SyncFunc = new funSyncDele[DeleNum];
        static IAsyncResult[] SyncSync = new IAsyncResult[DeleNum];
        static List<WaitHandle> SyncWait = new List<WaitHandle>();
        static List<string> lsUserSync = new List<string>();

        public void DoExec()
        {
            List<string> lsUserName, lsSession, lsTime;
            //获取需要同步会员的卖家信息
            SqlData.GetSyncMemUser(out lsUserName, out lsSession, out lsTime);

            for (int i = 0; i < lsUserName.Count; i++)
            {
                try
                {
                    //设置已经同步过的卖家状态，防止重复同步数据
                    if (lsUserSync.IndexOf(lsUserName[i]) >= 0)
                    {
                        SellersBLL.SetSyncProcess(lsUserName[i], 0);
                        continue;
                    }
                    if (SyncWait.Count >= DeleNum)
                        WaitHandle.WaitAny(SyncWait.ToArray());
                    for (int k = 0; k < SyncSync.Length; k++)
                    {
                        if (SyncSync[k] == null || SyncSync[k].IsCompleted)
                        {
                            if (SyncFunc[k] != null)  //委托使用过，进行释放
                            {
                                lsUserSync.Remove(SyncFunc[k].EndInvoke(SyncSync[k]));
                                SyncWait.Remove(SyncSync[k].AsyncWaitHandle);
                                SyncSync[k] = null;
                                SyncFunc[k] = null;
                            }
                            lsUserSync.Add(lsUserName[i]);
                            SyncFunc[k] = new funSyncDele(SyncMemDele);
                            SyncSync[k] = SyncFunc[k].BeginInvoke(lsUserName[i], lsSession[i], lsTime[i], null, null);
                            SyncWait.Add(SyncSync[k].AsyncWaitHandle);
                            break;
                        }
                    }
                }
                catch (Exception err)
                {
                    ExceptionReporter.WriteLog(err, ExceptionPostion.TBApply_Data);
                }
            }

        }

        public string SyncMemDele(string strUserName, string strSession, string strTime)
        {
            try
            {
                //初始化系统分组
                InitGroup(strUserName);
                //同步系统订单,全部同步
                if (string.IsNullOrEmpty(strTime))
                {
                    //获取会员数据量
                    string memberNum = BuyerBLL.GetBuyerCount("1", strUserName);
                    if (memberNum.Equals("0") == true)
                    {//如果会员数量为0则添加一个表
                        //获取id
                        string seller_id = SellersBLL.GetSellerIdByNick(strUserName);
                        if (string.IsNullOrEmpty(seller_id) == false)
                        {//如果seller_id不为空则创建一个新表
                            SellersDAL.addBuyer(seller_id);
                        }
                    }
                    BuyerBLL buyerObj = new BuyerBLL();
                    if (buyerObj.SynicBuyersInformation(strUserName, strSession))
                    {
                        //将最新同步数据时间更新写入DB
                        Sellers objSeller = new Sellers();
                        objSeller.Nick = strUserName;
                        SellersBLL.UpdateSellerSynDate(objSeller);
                        SellersBLL.SetSyncProcess(strUserName, 0);
                    }
                }
            }
            catch (Exception err)
            {
                ExceptionReporter.WriteLog(err, ExceptionPostion.TBApply_Data);
            }
            return strUserName;
        }

        #region 初始化卖家的买家系统分组
        /// <summary>
        /// 初始化卖家的买家系统分组；另外功能还需要提供卖家自定义分组。
        /// </summary>
        private void InitGroup(string strNick)
        {
            //同步系统分组功能
            Group obj = new Group();
            obj.Group_name = "新客户";
            obj.SellerNick = strNick;
            obj.Memo = "";
            obj.OpenStatus = true;
            //如果添加分组成功
            if (!BuyerBLL.CheckGroupIsExit(strNick, "新客户"))
            {
                //BuyerBLL.AddBuyerGroup(obj);
                BuyerBLL.AddGroup(obj);
            }

            Group obj2 = new Group();
            obj2.Group_name = "老客户";
            obj2.SellerNick = strNick;
            obj2.Memo = "";
            obj2.OpenStatus = true;
            //如果添加分组成功
            if (!BuyerBLL.CheckGroupIsExit(strNick, "老客户"))
            {
                BuyerBLL.AddGroup(obj2);
            }

            Group obj3 = new Group();
            obj3.Group_name = "休眠3个月";
            obj3.SellerNick = strNick;
            obj3.Memo = "";
            obj3.OpenStatus = true;
            //如果添加分组成功
            if (!BuyerBLL.CheckGroupIsExit(strNick, "休眠3个月"))
            {
                BuyerBLL.AddGroup(obj3);
            }

            Group obj5 = new Group();
            obj5.Group_name = "潜在客户";
            obj5.SellerNick = strNick;
            obj5.Memo = "";
            obj5.OpenStatus = true;
            //如果添加分组成功
            if (!BuyerBLL.CheckGroupIsExit(strNick, "潜在客户"))
            {
                BuyerBLL.AddGroup(obj5);
            }
        }
        #endregion

    }
}
