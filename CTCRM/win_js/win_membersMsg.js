$(function () {
    function showCount() {
        var markcount = $(".strong_userName").text().length + 4;
        $(".textCount").text(markcount);
    };

    ///选择会员按钮
    $("#memberSearch").click(function () {
        var div_all = $(".div_allmember");
        var img = $(".arrow");
        if (div_all.is(":hidden")) {
            img.attr("src", "../Win_Image/三角形左.png");
            div_all.show(600);
        } else {
            img.attr("src", "../Win_Image/三角形下.png");
            div_all.hide(600);
        }
    });

  

    //短网址按钮
    $(".shortUrl").click(function () {
        $(this).attr("target", "_self");
        //window.open("../shortLink.aspx");
        window.location.href = "../shortLink.aspx";
        
    });

    //输入文字时判断字数
    $(".textarea_01").keyup(function () {
        var markcount = $(".strong_userName").text().length + 4;
        var count = $(this).val().length;
        if (count >= 0) {
            getCost(count + markcount);
        }
    });

    ///提交发送短信
    $(".bt_02").click(function () {
        //判断是否选择了发送人，短信是否为空
        if (typeof (arryNum) == "undefined" || arryNum <= 0) { alert("请选择发送对象！"); return; }
        //判断短信内容是否为空
        var msg = $(".textarea_01").val();
        if (msg.length <= 0) { alert("短信内容不能为空！"); return; }
        //判断用户短信数量是否足够
        $.post("/service/memberService.ashx", {
            cmd: "getMsgCount", nick: "asdf"
        },
      function (result) {
          var msgRet = parseInt(result);
          var allcost = getMemberCount();
          if (msgRet == 0 || msgRet < allcost) {
              //短信条数不够
              alert("短信余额不足，请先充值！");
              return;
          } else {
              //短信条数足够
              alert("开始发送短信!");
              PostSendMsg();
          }
      });
    });
});

function PostSendMsg() {
    var content= $(".strong_userName").text()+ $(".textarea_01").val()+"退订回N";

    //筛选
    if (retobj != null && arryNum > 0) {
        if (notSendList.length > 0) {
            for (var i = 0; i < arryNum; i++) {
                if (isDelete(retobj.members[i].nick) == true) {
                    notSendList.splice(i, 1);
                }
            }
        }
        //post申请
        $.post("/service/memberService.ashx", {
            cmd: "sendMsg", data: JSON.stringify(retobj), msgContent: content
        },
   function (result) {
       if (result == "1") {
           $.messager.alert('没有获取到数据！');
           alert("发送完毕!");
       }
   });
    }
}

var retobj = null; //返回结果json
var arryNum = 0;//查询结果总长度
var page = 1;//当前第几页
var div3 = "";//界面上的容器
var pageCount = 0;//页码的数量
var notSendList = new Array();//不发送用户昵称列表

function getUserMsgCount() {
    $.post("/service/memberService.ashx", {
        cmd: "getMsgCount", nick: "asdf"
    },
      function (result) {
          if (result == "1") {
              $.messager.alert('没有获取到数据！');
          }
          var msgRet = parseInt(result);
          var allcost = 0;
          if (msgRet == 0 || msgRet < allcost) {
              return 1;
          } else {
              return 0;
          }
      });
}

function isDelete(nick) {
    for (var i = 0; i < notSendList.length; i++) {
        if (notSendList[i].nick == nick) {
            return true;
        } else {
            return false;
        }
    }
}

function updateCost() {
    var count = $(".textarea_01").val().length;
    var markcount = $(".strong_userName").text().length + 4;
    if (count > 0) {
        getCost(count+markcount);
    }
}

function getCost(num) {
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

function divHide() {
    $(".div_allmember").hide(800);
}

function showRet() {
    $(".tab_02").hide();
    $(".div_members").show();
}


function showRet1() {
    $(".div_members").hide();
    $(".tab_02").show();
}

function hideMemberDiv() {
    $("div_allmember").hide();
}

function searchMember() {
    $("#bt_ret").css("display", "inline");
    $("#bt_ret").val("查询中...");
    var nick = $("#txt_nick").val();
    var level = $("#s_level  option:selected").val();
    var area = $("#s_area  option:selected").val();
    var interval = $("#s_interval  option:selected").val();
    var tradeStartTime = $("#tbx_trade_start").val();
    var tradeEndTime = $("#tbx_trade_end").val();
    var money01 = $("#txt_money01").val();
    var money02 = $("#txt_money02").val();
    var txt_good_count01 = $("#txt_good_count01").val();
    var txt_good_count02 = $("#txt_good_count02").val();
    var day = $("#s_day  option:selected").val();
    var count = $("#txt_buyCount").val();
    var comment = $("#cbx_comment").is(':checked');
    var blacklist = $("#cbx_blacklist").is(':checked');
    var result = "";
    $.post("/service/memberService.ashx", {
        cmd: "getMember", nick: nick.toString(), level: level.toString(), area: area.toString(), interval: interval.toString(), tradeStartTime: tradeStartTime.toString(),
        tradeEndTime: tradeEndTime.toString(), money01: money01.toString(), money02: money02.toString(), txt_good_count01: txt_good_count01.toString(), txt_good_count02: txt_good_count02.toString(),
        day: day.toString(), count: count.toString(), comment: comment.toString(), blacklist: blacklist.toString()
    },
        function (result) {
            retobj = eval("(" + result + ")");
            if (typeof (retobj.ret)) {
                if (retobj.ret == "0") {
                    arryNum = retobj.members.length;
                    page = 1;
                    pageCount = Math.ceil(arryNum / 10);
                    notSendList = new Array();
                    changePage();
                    $("#bt_ret").val("查看结果(" + arryNum + ")");
                    $("#strong_member").text(arryNum);
                    updateCost();
                } else {
                    alert("没有获取到数据！");
                    $("#bt_ret").val("查看结果(0)");
                }
            }
        });
}

function pageUp() {
    if (page > 1) {
        page = parseInt(page - 1);
        changePage();
    }
}

function pageDown() {
    if (page < pageCount) {
        page = parseInt(page + 1);
        changePage();
    }
}

function pageFirst() {
    page = 1;
    changePage();
}

function pageLast() {
    page = pageCount;
    changePage();
}

function pageGo() {
    var num = $(".Go_num").val();
    if (num > 0 && num < pageCount) {
        page = parseInt(num);
    }
    changePage();
}

function changePage() {
    if (retobj != null && arryNum > 0) {
        div3 = $(".tab_memberList");
        div3.empty();
        var tab = "<table class='members'><tr><td>序号</td><td>昵称</td><td>电话</td><td>交易金额</td><td>交易时间</td><td>筛选</td></tr>";
        for (var i = 0; i < arryNum; i++) {
            if ((i + 1) >= (page * 10 - 9) && (i + 1) <= page * 10) { 
                if (checkName(retobj.members[i].nick) == false) {
                    tab += "<tr><td>" + (i + 1).toString() + "</td><td>" + retobj.members[i].nick + "</td><td>" + retobj.members[i].phone + "</td><td>" + retobj.members[i].tradeAmount
                        + "</td><td>" + retobj.members[i].tradeTime + "</td><td><input type='checkbox' value='" + retobj.members[i].nick + "'  onclick='rememberNick(this)' />不发送</td></tr>";
                } else {
                    tab += "<tr><td>" + (i + 1).toString() + "</td><td>" + retobj.members[i].nick + "</td><td>" + retobj.members[i].phone + "</td><td>" + retobj.members[i].tradeAmount
                      + "</td><td>" + retobj.members[i].tradeTime + "</td><td><input type='checkbox' value='" + retobj.members[i].nick + "'  onclick='rememberNick(this)' checked='checked' />不发送</td></tr>";
                }
            }
        }
        tab += "</table>";
        tab += "<div style='width:100%;font-size:small'><input type='button' value='首页' onclick='pageFirst()' /><input type='button' value='上一页'onclick='pageUp()'/>" +
            "<input type='button' value='下一页'onclick='pageDown()' /><input type='button' value='尾页' onclick='pageLast()' />总共" + pageCount + "页 当前第" + page + "页 跳转 <input type='text' class='Go_num' /><input type='button' value='GO' onclick='pageGo()'/></div>";
        div3.append(tab);
    }
}

function checkName(nick) {
    for (var i = 0; i < notSendList.length; i++) {
        if (notSendList[i] == nick) {
            return true;
        }
    }
    return false;
}

function rememberNick(check) {
    var ck_select = $(check);
    var name = ck_select.val();
    var index = notSendList.indexOf(name);
    if (ck_select.attr("checked")) {
        if (index < 0) {
            notSendList.push(name);
        }
    } else {
        if (index > -1) { notSendList.splice(index, 1); }
    }
    $("#strong_member").text(getMemberCount());
    updateCost();
}

function getMemberCount() {
    var allCount = arryNum;
    var listCount = parseInt(notSendList.length);
    var count = allCount - listCount;
    return count;
}