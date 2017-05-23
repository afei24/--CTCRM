using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using Top.Api.Parser;
using Top.Api.Domain;
using Top.Api.Util;
using CTCRM.Entity;

namespace SynTest
{
    public sealed class MessageDecode
    {
        public const string NOTIFY_ITEM = "notify_item";
        public const string NOTIFY_TRADE = "notify_trade";
        public const string NOTIFY_REFUND = "notify_refund";

        public static object DecodeMsg(String msg)
        {
            IDictionary dict = TopUtils.ParseJson(msg);
            if (dict != null && dict.Count > 0)
            {
                IEnumerator em = dict.Keys.GetEnumerator();
                em.MoveNext();
                IDictionary data = dict[em.Current] as IDictionary;

                if (data != null)
                {
                    TopJsonParser tjp = new TopJsonParser();
                    ITopReader reader = new TopJsonReader(data);
                    //if (dict.Contains(NOTIFY_ITEM))
                    //{
                    //    return tjp.FromJson(reader, typeof(NotifyItem));
                    //}
                     if (dict.Contains(NOTIFY_TRADE))
                    {
                        return tjp.FromJson(reader, typeof(NotifyTrade));
                    }
                    //else if (dict.Contains(NOTIFY_REFUND))
                    //{
                    //    return tjp.FromJson(reader, typeof(NotifyRefund));
                    //}
                }
            }
            return null;
        }
    }
}
