$(function () {
    
    //var src = getUrlParam("src");
    //$(".content_child_right").attr("src",src);

    $(".title_li").bind("click", function () {
        var id = $(this).attr("id");
        $(".title_li").css("color", "#00BFE9");
        $(".title_li").css("background-color", "white");
        $(this).css("color", "white");
        $(this).css("background-color", "#00BFE9");
        $(".contect").hide();
        $("." + id).show();
    });

    //移动的菜单
    var moveDiv = $(".move_div");
    //头部最上层div
    var head_div = $("#Navigation_head_div");

    var head_menu_a = $(".n_td_text");
    //鼠标移动到单个菜单栏时改变其背景颜色，并显示移动菜单
    head_menu_a.mouseover(function () {
        moveDiv.css("width", "410");
        switch ((this).id) {
            case "members.aspx":
                member();
                break;
            case "index.aspx":
                index();
                break;
            case "logistics.aspx":
                sendMsgAll();
                break;
            case "message.aspx":
                sendMsg();
                break;
            case "automatic.aspx":
                comment();
                break;
            case "SMSOrder.aspx":
                order();
                break;
            default:
                return;
        }
        if (moveDiv.is(':hidden')) {
            if ((this).id != "index") {
                moveDiv.show();
            }

        }
        //$(this).css("color", "#3E94E1");
        var top = $(this).offset().top;
        //var left = $("#Navigation_head_ul").offset().left + 91;
        var left = $(this).offset().left + 29;
        moveDiv.css({ position: "fixed", 'top': 65, 'left': left, 'z-index': 2 });
    });

    //从单个菜单移开时还原颜色
    head_menu_a.mouseleave(function () {
        $(this).css("color", "#0AC2EB");
    });

    //鼠标从菜单栏移开时注销掉移动菜单
    $(".Navigation_h_menu").mouseleave(function () {
        var x = event.clientX;
        var y = event.clientY;
        var divx1 = moveDiv.offset().left;
        var divy1 = moveDiv.offset().top - 5;
        var gt = document.getElementById("m_div").offsetHeight;
        var wd = document.getElementById("m_div").offsetWidth;
        var divx2 = divx1 + wd;
        var divy2 = divy1 + gt;

        if (x < divx1 || x > divx2 || y < divy1 || y > divy2) {
            moveDiv.hide();
            moveDivClear();
        }

    });

    function clear() {
        var x = event.clientX;
        var y = event.clientY;
        var divx1 = moveDiv.offset().left;
        var divy1 = moveDiv.offset().top - 5;
        var gt = document.getElementById("m_div").offsetHeight;
        var wd = document.getElementById("m_div").offsetWidth;
        var divx2 = divx1 + wd;
        var divy2 = divy1 + gt;

        if (x < divx1 || x > divx2 || y < divy1 || y > divy2) {
            moveDiv.hide();
            moveDivClear();
        }
    }

    //鼠标从移动菜单移开时注销掉本身
    moveDiv.mouseleave(function () {
        moveDiv.hide();
        moveDivClear();
    });

    //清空div
    function moveDivClear() {
        moveDiv.html("");
    }

    //客户管理
    function member() {
        moveDivClear();
        moveDiv.css("height", "155");
        moveDiv.append("<table style='width:100%;'><tr><td class='head_submeum_div1'><label class='head_submeum_lb'>客户管理</td></tr>" +
            "<tr><td class='head_submeum_div2'><ul ><li class='head_submeum_li'><a href='../WIN_Aspx/members.aspx?src=allmember.aspx' class='head_submeum_a' click='document.frames['showContent'].location=this.href;return false'>客户资料</a></li>" +
            "<li class='head_submeum_li'><a href='../WIN_Aspx/members.aspx?src=SynData/buyerExport.aspx' class='head_submeum_a'  click='document.frames['showContent'].location=this.href;return false'>客户资料导出</a></li>" +
            "<li class='head_submeum_li'><a href='../WIN_Aspx/members.aspx?src=../SynData/downloads.aspx' class='head_submeum_a' click='document.frames['showContent'].location=this.href;return false'>数据同步</a></li>" +
            "<li class='head_submeum_li'><a href='../WIN_Aspx/members.aspx?src=member/logisticsMembers.aspx' class='head_submeum_a' click='document.frames['showContent'].location=this.href;return false'>物流未签收</a></li>" +
            "<li class='head_submeum_li'><a href='../WIN_Aspx/members.aspx?src=blacklist.aspx' class='head_submeum_a' click='document.frames['showContent'].location=this.href;return false'>黑名单管理</a></li></ul></td><tr></table>"
            );
    }

    //短信提醒
    function sendMsgAll() {
        moveDivClear();
        moveDiv.css("height", "290");
        //第一排
        moveDiv.append("<table style='width:100%;'><tr><td class='head_submeum_div1'><label class='head_submeum_lb'>短信提醒</td></tr>" +
           "<tr><td class='head_submeum_div2'><ul ><li class='head_submeum_li'><a href='../WIN_Aspx/logistics.aspx?src=member/reminderHis.aspx' class='head_submeum_a' click='document.frames['showContent'].location=this.href;return false' >提醒记录</a></li>" +
             "</ul></td></tr>" +
        //第二排
         "<tr><td class='head_submeum_div1'>订单关怀</td></tr>" +
            "<tr><td class='head_submeum_div2'><ul >" +
            "<li class='head_submeum_li'><a href='../WIN_Aspx/logistics.aspx?src=member/index1.aspx&&type=notplay' class='head_submeum_a' click='document.frames['showContent'].location=this.href;return false'>未付款提醒</a></li>" +
            "<li class='head_submeum_li'><a href='../WIN_Aspx/logistics.aspx?src=member/index1.aspx&&type=pay' class='head_submeum_a' click='document.frames['showContent'].location=this.href;return false'>付款提醒</a></li>" +
            "<li class='head_submeum_li'><a href='../WIN_Aspx/logistics.aspx?src=member/index1.aspx&&type=startSend' class='head_submeum_a' click='document.frames['showContent'].location=this.href;return false'>发货提醒</a></li>" +
            "<li class='head_submeum_li'><a href='../WIN_Aspx/logistics.aspx?src=member/index1.aspx&&type=arivde' class='head_submeum_a' click='document.frames['showContent'].location=this.href;return false'>到达提醒</a></li>" +
            "<li class='head_submeum_li'><a href='../WIN_Aspx/logistics.aspx?src=member/index1.aspx&&type=sign' class='head_submeum_a' click='document.frames['showContent'].location=this.href;return false'>签收提醒</a></li>" +
            "<li class='head_submeum_li'><a href='../WIN_Aspx/logistics.aspx?src=member/index1.aspx&&type=delaySend' class='head_submeum_a' click='document.frames['showContent'].location=this.href;return false'>延迟发货提醒</a></li>" +
             "<li class='head_submeum_li'><a href='../WIN_Aspx/logistics.aspx?src=member/index1.aspx&&type=refund' class='head_submeum_a' click='document.frames['showContent'].location=this.href;return false'>回款提醒</a></li></ul></td></tr></table>"
            );
    }

    //短信群发
    function sendMsg() {
        moveDivClear();
        moveDiv.css("height", "295");
        //行头
        moveDiv.append("<table style='width:100%;'><tr><td class='head_submeum_div1'>短信群发</td></tr>" +
            //第一排
            "<tr><td class='head_submeum_div2'><ul><li class='head_submeum_li'><a href='../WIN_Aspx/message.aspx?src=sendMsg.aspx' class='head_submeum_a' click='document.frames['showContent'].location=this.href;return false'>自有短信群发</a></li>" +
            "<li class='head_submeum_li'><a href='../WIN_Aspx/message.aspx?src=win_memberMsg.aspx' class='head_submeum_a' click='document.frames['showContent'].location=this.href;return false'>会员短信群发</a></li>" +
            "<li class='head_submeum_li'><a href='../WIN_Aspx/message.aspx?src=Smart/msgHis.aspx' class='head_submeum_a' click='document.frames['showContent'].location=this.href;return false'>发送记录</a></li>" +
            "<li class='head_submeum_li'><a href='../WIN_Aspx/message.aspx?src=signModify.aspx' class='head_submeum_a' click='document.frames['showContent'].location=this.href;return false'>修改签名</a></li></ul></div>" +
            "<li class='head_submeum_li'><a href='../WIN_Aspx/message.aspx?src=../shortLink.aspx' class='head_submeum_a' click='document.frames['showContent'].location=this.href;return false'>短链接生成</a></li></ul></td></tr>" +
             //第二排s
             "<tr><td class='head_submeum_div1'>智能营销</td></tr>" +
             "<tr><td class='head_submeum_div2'><ul><li class='head_submeum_li'><a href='../WIN_Aspx/message.aspx?src=Smart/index.aspx' class='head_submeum_a' click='document.frames['showContent'].location=this.href;return false'>新会员营销</a></li>" +
            "<li class='head_submeum_li'><a href='../WIN_Aspx/message.aspx?src=Smart/memberLevel.aspx' class='head_submeum_a' click='document.frames['showContent'].location=this.href;return false'>会员等级营销</a></li>" +
            "<li class='head_submeum_li'><a href='../WIN_Aspx/message.aspx?src=Smart/huoyue.aspx' class='head_submeum_a' click='document.frames['showContent'].location=this.href;return false'>活跃会员营销</a></li>" +
            "<li class='head_submeum_li'><a href='../WIN_Aspx/message.aspx?src=../Smart/unpay.aspx' class='head_submeum_a' click='document.frames['showContent'].location=this.href;return false'>未交易营销</a></li></ul></div>" +
            "<div id='head_submeum_div3'><ul ><li class='head_submeum_li'><a href='../WIN_Aspx/message.aspx?src=Smart/area.aspx' class='head_submeum_a' click='document.frames['showContent'].location=this.href;return false'>地区营销</a></li>" +
            "<li class='head_submeum_li'><a href='../WIN_Aspx/message.aspx?src=Smart/jieri.aspx' class='head_submeum_a' click='document.frames['showContent'].location=this.href;return false'>节日营销</a></li>" +
             "</ul></td></tr></table>");
    }

    //自动评价
    function comment() {
        moveDivClear();
        moveDiv.css("height", "235");
        moveDiv.css("width", "140");
        //行头
        moveDiv.append("<table style='width:100%;'><tr><td class='head_submeum_div1'>评价管理</td></tr>" +
            //第一排
            "<tr><td class='head_submeum_div2'><ul ><li class='head_submeum_li'><a href='../WIN_Aspx/automatic.aspx?src=rate/rateSetting.aspx' class='head_submeum_a' click='document.frames['showContent'].location=this.href;return false'>自动评价</a></li>" +
            "<li class='head_submeum_li'><a href='../WIN_Aspx/automatic.aspx?src=rate/blacklist.aspx' class='head_submeum_a' click='document.frames['showContent'].location=this.href;return false'>黑名单</a></li>" +
            "<li class='head_submeum_li'><a href='../WIN_Aspx/automatic.aspx?src=rate/badList.aspx' class='head_submeum_a' click='document.frames['showContent'].location=this.href;return false'>中差评查询</a></li>" +
            "<li class='head_submeum_li'><a href='../WIN_Aspx/automatic.aspx?src=rate/ratingLog.aspx' class='head_submeum_a' click='document.frames['showContent'].location=this.href;return false'>评价日志</a></li></ul></td></tr></table>");
    }

    //短信订购
    function order() {
        moveDivClear();
        moveDiv.css("width", "140");
        moveDiv.css("height", "120");
        moveDiv.append("<table style='width:100%;'><tr><td class='head_submeum_div1'><label class='head_submeum_lb'>短信订购</td></tr>" +
            "<tr><td class='head_submeum_div2'><ul ><li class='head_submeum_li'><a href='../WIN_Aspx/SMSOrder.aspx?src=messageSetting.aspx' class='head_submeum_a' click='document.frames['showContent'].location=this.href;return false'>短信订购</a></li>" +
            "</ul></td><tr></table>"
            );
    }
    function index() {
    }
    //点击左边二级导航栏
    $(".navigation2").bind("click", function () {
        var src = $(this).attr("id");
        $(".content_child_right").attr("src", src);
    });

    //点击左边一级导航栏
    $(".navigation_div_titile").click(function () {
        var id = $(this).attr("id");
        changeImg(id);
    });

    //$(".img_main").mouseover(function () {

    //    var imgurl = $(this).attr("src");
    //    imgurl = imgurl.substring(0, imgurl.indexOf(".jpg"));
    //    imgurl += "01.jpg";
    //    $(this).attr("src", imgurl);
    //}); 
    //$(".img_main").mouseleave(function () {
    //    var imgurl = $(this).attr("src");
    //    imgurl = imgurl.replace("01","");
    //    $(this).attr("src", imgurl);
    //});

    $(".Navigation_userinfo").hover(function () {
        $(".index_div_top_info").show();
    }, function () {
        $(".index_div_top_info").hide();
    })
    $(".index_div_top_info").hover(function () {
        $(".index_div_top_info").show();
    }, function () {
        $(".index_div_top_info").hide();
    })

    //改变一级导航栏背景图片
    function changeImg(id) {
        var imgurl = $("#" + id).css("background-image");
        if (imgurl.indexOf("01") > 0) {
            $("." + id).hide();
            imgurl = imgurl.replace("01", "");
            $("#" + id).css("background-image", imgurl);
            $("#" + id).css("color", "black");
            return;
        }
        $("." + id).show();
        imgurl = imgurl.substring(0, imgurl.indexOf("."));
        imgurl += "01.png";
        $("#" + id).css("background-image", imgurl);
        $("#" + id).css("color", "white");
    }

    $(".img_main").mouseover(function () {
        var imgurl = $(this).attr("src");
        imgurl = imgurl.replace("_w", "_b");
        $(this).attr("src", imgurl);
    });

    $(".img_main").mouseleave(function () {
        var imgurl = $(this).attr("src");
        imgurl = imgurl.replace("_b", "_w");
        $(this).attr("src", imgurl);
    });

    function goto() {
        window.navigate("automatic.aspx?src=rate/rateSetting.aspx");
    }

  

});


window.onload = function () {
    $.post("/service/memberService.ashx", {
        cmd: "getNews"
    },
function (result) {
    retobj = eval("(" + result + ")");
    if (typeof (retobj.ret)) {
        if (retobj.ret == "0") {
            var count = retobj.news.length;
            for (var i = 0; i < count; i++) {
                var id = "#msg" + (i + 1).toString();
                var msg = $(id);
                msg.html("");
                var title = retobj.news[i].title;
                var content = retobj.news[i].content + " " + retobj.news[i].date;
                msg.append(title);
                msg.attr("title", content);
            }
        } else {
            alert("没有获取到数据！");
        }
    }
});
}