
function CheckContentCount(id) {
    var div_id = id;
    //var user ="【" +getCookie("user")+"】";
    var user = $("#users").val();
    var context = "【" + user + "】" + $("#txt_" + id).val() + "退订回N";
    document.getElementById(div_id).innerHTML = context;

    var count = 1;
    if (context.length <= 70) {
        count = 1;
    }
    else if (context.length > 70 && context.length <= 134) {
        count = 2;
    }
    else if (context.length > 134 && context.length <= 195) {
        count = 3;
    }
    else if (context.length > 195 && context.length <= 260) {
        count = 4;
    }
    document.getElementById("msgTip").innerHTML = "已输入" + context.length + "个字符，将扣除" + count + "条短信。";
}

function selectMsg(node) {
    var user =  $("#users").val() ;
    var tr1 = node.parentNode.parentNode;
    var msgtxt = tr1.firstChild.innerHTML;
    $(".msgMoban").css("display", "none");
    $("#txt_div_nopay_msg").val(msgtxt);
    $("#lb_phoneMsg").text(user+msgtxt);
    $("#txt_div_pay_msg").val(msgtxt);
    $("#div_pay_msg").text(user+msgtxt);
    var textarea_01 = $(".textarea_01");
    if (typeof (textarea_01) != "undefined") {
        textarea_01.text(msgtxt);
        checkCharLength(msgtxt);
    }
}

function checkCharLength(msg) {

    var markcount = $(".strong_userName").text().length + 4;
    var count = msg.length;
    var num = markcount + count;
    if (count >= 0) {
        var cost = 1;
        if (num >= 70) {
            cost = 2
        }
        if (num >= 134) {
            cost = 3
        }
        if (num >= 195) {
            cost = 4
        }

        $(".textCount").text(num);
        if (typeof (arryNum) != "undefined" && arryNum > 0) {
            $(".cost").text(cost);
            var memberCount = getMemberCount();
            $(".allCost").text((cost * memberCount));
        } else {
            $(".allCost").text("0");
            $(".cost").text("0");
        }
    }
}


function Msgclose() {
    $(".msgMoban").css("display", "none");
}

//填写短信表格
function setMsgs(page) {
    //短信内容div对象
    if (msgList != null && msgList.length > 0) {
        var msg_content_div = $(".msgList");
        var op_div = $(".op");
        msg_content_div.html("");
        op_div.html("");
        var tab_str = "<table class='msg_tab' cellspacing='0'>";
        for (var j = 0; j < msgList.length; j++) {
            if ((j + 1) >= (page * 5 - 4) && (j + 1) <= page * 5) {
                tab_str += "<tr><td style='text-align:left;padding-left:5px;height:50px; '>" + msgList[j] +
                        "</td><td style='width:60px;border-left:1px solid #e0d6d6;text-align:center'><input type='button' value='选择' onclick='selectMsg(this)' name='" + j + "'></td></tr>";
            }
        }
        tab_str += "</table>";
        msg_content_div.append(tab_str);
        op_div.append("<div style='font-size:small;margin-top:5px;text-align:right;width:100%;'><input type='button' value='首页' onclick='pageFirst()' /><input type='button' value='上一页'onclick='pageUp()'/>" +
        "<input type='button' value='下一页'onclick='pageDown()' /><input type='button' value='尾页' onclick='pageLast()' />总共"
        + pageCount + "页 当前第" + page + "页 跳转 <input type='text' style='width:40px;' class='go_num' /><input type='button' style='margin-right:5px;' value='GO' onclick='pageGo()'/></div>");
    }
}

//设置短信数量和页数
function setPageNum(type) {
    var num = 0;
    msgList.splice(0, msgList.length);
    for (var j = 0; j < retobj.msg.length; j++) {
        if (retobj.msg[j] != null) {
            if (retobj.msg[j].pageType == type) {
                msgList.push(retobj.msg[j].msgContent);
                num++;
            }
        }
    }
    msgCount = num;
    if (msgCount > 0) {
        pageCount = Math.ceil(msgCount / 6);
    } else {
        pageCount = 0;
    }
}

//下拉框选项变化时触发
function selectChange(select) {
    setPageNum(select);
    setMsgs(1);
}


//上一页
function pageUp() {
    if (page > 1) {
        page = parseInt(page - 1);
        setMsgs(page);
    }
}
//下一页
function pageDown() {
    if (page < pageCount) {
        page = parseInt(page + 1);
        setMsgs(page);
    }
}
//首页
function pageFirst() {
    page = 1;
    setMsgs(1);
}
//最后一页
function pageLast() {
    page = pageCount;
    setMsgs(page);
}
//跳转
function pageGo() {
    var num = $(".go_num").val();
    if (num > 0 && num <= pageCount) {
        page = parseInt(num);
        setMsgs(page);
    }
}

var retobj;
var pageCount = 0;
var msgCount = 0;
var page = 1;
var msgList = new Array();
window.onload = function () {
    $(".msgTemp").click(function () {
        var msg = $(this);
        var msgDiv = $(".msgMoban");
        var typeNum = msg.attr("title");
        //浏览器宽度
        var pagewidth = document.documentElement.clientWidth / 2;
        //浏览器高度
        var pageheight = document.documentElement.clientHeight / 2;
        var divwidth = msgDiv.width() / 2;
        var divheight = msgDiv.height() / 2;
        msgDiv.css({ position: "fixed", 'top': (pageheight - divheight), 'left': (pagewidth - divwidth), 'z-index': 2 });
        var result = "";
        $.post("/service/memberService.ashx", {
            cmd: "getTempMsg",
            type: typeNum
        },
            function (result) {
                retobj = eval("(" + result + ")");
                if (typeof (retobj.ret)) {
                    if (retobj.ret == "0") {
                        msgDiv.css("display", "inline");

                        //拿到类型
                        var typelist = retobj.typelist.split(',');
                        //下拉框对象
                        var select_msg_type = $("#msg_type");
                        if (typelist.length >= 1) {
                            select_msg_type.html("");
                            for (var i = 0; i < typelist.length; i++) {
                                select_msg_type.append("<option value='" + typelist[i] + "'>" + typelist[i] + "</option>");
                            }
                            setPageNum(typelist[0]);
                            setMsgs(1);
                        }
                    } else {
                        alert("没有获取到数据！");
                        $("#bt_ret").val("查看结果(0)");
                    }
                }
            });
    })
};