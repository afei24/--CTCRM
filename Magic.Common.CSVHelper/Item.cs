using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Magic.Common.CSVHelper
{
    public class Item : BaseEntityObject
    {
        [Describe(EnName = "宝贝名称", Filed = "title", Index = 0)]
        public string Title { get; set; }
        [Describe(EnName = "宝贝类目", Filed = "cid", Index = 1)]
        public string Cid { get; set; }
        [Describe(EnName = "店铺类目", Filed = "seller_cids", Index = 2)]
        public string SellerCids { get; set; }
        [Describe(EnName = "新旧程度", Filed = "stuff_status", Index = 3)]
        public string StuffStatus { get; set; }
        [Describe(EnName = "省", Filed = "location_state", Index = 4)]
        public string LocationState { get; set; }
        [Describe(EnName = "城市", Filed = "location_city", Index = 5)]
        public string LocationCity { get; set; }
        [Describe(EnName = "出售方式", Filed = "item_type", Index = 6)]
        public string ItemType { get; set; }
        [Describe(EnName = "宝贝价格", Filed = "price", Index = 7)]
        public string Price { get; set; }
        [Describe(EnName = "加价幅度", Filed = "auction_increment", Index = 8)]
        public string AuctionIncrement { get; set; }
        [Describe(EnName = "宝贝数量", Filed = "num", Index = 9)]
        public string Num { get; set; }
        [Describe(EnName = "有效期", Filed = "valid_thru", Index = 10)]
        public string ValidThru { get; set; }
        [Describe(EnName = "运费承担", Filed = "freight_payer", Index = 11)]
        public string FreightPayer { get; set; }
        [Describe(EnName = "平邮", Filed = "post_fee", Index = 12)]
        public string PostFee { get; set; }
        [Describe(EnName = "EMS", Filed = "ems_fee", Index = 13)]
        public string EmsFee { get; set; }
        [Describe(EnName = "快递", Filed = "express_fee", Index = 14)]
        public string ExpressFee { get; set; }
        [Describe(EnName = "发票", Filed = "has_invoice", Index = 15)]
        public string HasInvoice { get; set; }
        [Describe(EnName = "保修", Filed = "has_warranty", Index = 16)]
        public string HasWarranty { get; set; }
        [Describe(EnName = "放入仓库", Filed = "approve_status", Index = 17)]
        public string ApproveStatus { get; set; }
        [Describe(EnName = "橱窗推荐", Filed = "has_showcase", Index = 18)]
        public string HasShowcase { get; set; }
        [Describe(EnName = "开始时间", Filed = "list_time", Index = 19)]
        public string ListTime { get; set; }
        [Describe(EnName = "宝贝描述", Filed = "description", Index = 20)]
        public string Description { get; set; }
        [Describe(EnName = "宝贝属性", Filed = "cateProps", Index = 21)]
        public string Cateprops { get; set; }
        [Describe(EnName = "邮费模版ID", Filed = "postage_id", Index = 22)]
        public string PostageId { get; set; }
        [Describe(EnName = "会员打折", Filed = "has_discount", Index = 23)]
        public string HasDiscount { get; set; }
        [Describe(EnName = "修改时间", Filed = "modified", Index = 24)]
        public string Modified { get; set; }
        [Describe(EnName = "上传状态", Filed = "upload_fail_msg", Index = 25)]
        public string UploadFailMsg { get; set; }
        [Describe(EnName = "图片状态", Filed = "picture_status", Index = 26)]
        public string PictureStatus { get; set; }
        [Describe(EnName = "返点比例", Filed = "auction_point", Index = 27)]
        public string AuctionPoint { get; set; }
        [Describe(EnName = "新图片", Filed = "picture", Index = 28)]
        public string Picture { get; set; }
        [Describe(EnName = "视频", Filed = "video", Index = 29)]
        public string Video { get; set; }
        [Describe(EnName = "销售属性组合", Filed = "skuProps", Index = 30)]
        public string Skuprops { get; set; }
        [Describe(EnName = "用户输入ID串", Filed = "inputPids", Index = 31)]
        public string Inputpids { get; set; }
        [Describe(EnName = "用户输入名-值对", Filed = "inputValues", Index = 32)]
        public string Inputvalues { get; set; }
        [Describe(EnName = "商家编码", Filed = "outer_id", Index = 33)]
        public string OuterId { get; set; }
        [Describe(EnName = "销售属性别名", Filed = "propAlias", Index = 34)]
        public string Propalias { get; set; }
        [Describe(EnName = "代充类型", Filed = "auto_fill", Index = 35)]
        public string AutoFill { get; set; }
        [Describe(EnName = "数字ID", Filed = "num_id", Index = 36)]
        public string NumId { get; set; }
        [Describe(EnName = "本地ID", Filed = "local_cid", Index = 37)]
        public string LocalCid { get; set; }
        [Describe(EnName = "宝贝分类", Filed = "navigation_type", Index = 38)]
        public string NavigationType { get; set; }
        [Describe(EnName = "用户名称", Filed = "user_name", Index = 39)]
        public string UserName { get; set; }
        [Describe(EnName = "宝贝状态", Filed = "syncStatus", Index = 40)]
        public string Syncstatus { get; set; }
        [Describe(EnName = "闪电发货", Filed = "is_lighting_consigment", Index = 41)]
        public string IsLightingConsigment { get; set; }
        [Describe(EnName = "新品", Filed = "is_xinpin", Index = 42)]
        public string IsXinpin { get; set; }
        [Describe(EnName = "食品专项", Filed = "foodparame", Index = 43)]
        public string Foodparame { get; set; }
        [Describe(EnName = "尺码库", Filed = "features", Index = 44)]
        public string Features { get; set; }
        [Describe(EnName = "采购地", Filed = "buyareatype", Index = 45)]
        public string Buyareatype { get; set; }
        [Describe(EnName = "库存类型", Filed = "global_stock_type", Index = 46)]
        public string GlobalStockType { get; set; }
        [Describe(EnName = "国家地区", Filed = "global_stock_country", Index = 47)]
        public string GlobalStockCountry { get; set; }
        [Describe(EnName = "库存计数", Filed = "sub_stock_type", Index = 48)]
        public string SubStockType { get; set; }
        [Describe(EnName = "物流体积", Filed = "item_size", Index = 49)]
        public string ItemSize { get; set; }
        [Describe(EnName = "物流重量", Filed = "item_weight", Index = 50)]
        public string ItemWeight { get; set; }
        [Describe(EnName = "退换货承诺", Filed = "sell_promise", Index = 51)]
        public string SellPromise { get; set; }
        [Describe(EnName = "定制工具", Filed = "custom_design_flag", Index = 52)]
        public string CustomDesignFlag { get; set; }
        [Describe(EnName = "无线详情", Filed = "wireless_desc", Index = 53)]
        public string WirelessDesc { get; set; }
        [Describe(EnName = "商品条形码", Filed = "barcode", Index = 54)]
        public string Barcode { get; set; }
        [Describe(EnName = "sku 条形码", Filed = "sku_barcode", Index = 55)]
        public string SkuBarcode { get; set; }
        [Describe(EnName = "7天退货", Filed = "newprepay", Index = 56)]
        public string Newprepay { get; set; }
        [Describe(EnName = "宝贝卖点", Filed = "subtitle", Index = 57)]
        public string Subtitle { get; set; }
        string parrent = "<img.*?src=(.*?jpg)";
        //ImageCompression comporession = new ImageCompression();
        public override void SetWirelessDesc(string userNick, int curr, int total, string gender, string imageHandler, Func<string, Int64, string> genderImageCompleteCallBack)
        {
            switch (gender)
            {
                case "true":
                    if (!string.IsNullOrEmpty(this.WirelessDesc))
                        return;
                    break;
            }
            var matches = System.Text.RegularExpressions.Regex.Matches(this.Description, parrent, RegexOptions.IgnoreCase);
            StringBuilder strBuilder = new StringBuilder();
            strBuilder.Append("<wapDesc>");
            var i = 0;
            int weight = 0;
            /*处理后的图片总量不能超过1572864*/
            ProcessDetail details = new ProcessDetail();
            foreach (Match item in matches)
            {
                try
                {
                    if (weight >= 1572864) break;
                    details.Curr = curr;
                    details.Total = total;
                    details.Process = ((i) / Convert.ToSingle(matches.Count)) + (curr / Convert.ToSingle(total)) * 100;
                    UserProcessRepoter.Instance[userNick] = details;
                    var res = item.Groups[1].Value;
                    Boolean isSuccess = true;
                    var handFilePath = ImageHandler.ImageHandlerClient.Handler(res, this.UserName, gender, imageHandler, ref isSuccess, ref weight);
                    if (!isSuccess) { weight += weight; continue; };
                    if (genderImageCompleteCallBack != null)
                    {
                        if (string.IsNullOrEmpty(handFilePath)) continue;
                        var pictureInfo = new FileInfo(handFilePath);
                        weight += Convert.ToInt32(pictureInfo.Length);
                        if (pictureInfo.Length < 1845) continue;
                        var filePath = genderImageCompleteCallBack(handFilePath, Convert.ToInt64(this.NumId));

                        strBuilder.Append("<img>" + filePath + "</img>");
                        try
                        {
                            if (File.Exists(handFilePath)) File.Delete(handFilePath);
                            if (File.Exists(res)) File.Delete(res);
                        }
                        catch (Exception ex)
                        {

                        }

                    }
                    i++;
                }
                catch (Exception ex)
                {
                    continue;
                }
                strBuilder.Append("</wapDesc>");
                this.WirelessDesc = strBuilder.ToString();
            }
        }
    }
}
