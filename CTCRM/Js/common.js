function msgbox(msg, event) {
    var save = "", cancel = "";
    if (event != undefined) {
        save = " wBox_save";
        cancel = "&nbsp;&nbsp;<input type='button' class='wBox_close button orange' value='取消' />";
    }

    var content = "<div style='text-align:center;vertical-align: middle; width: 260px; '><p class='" + (event != undefined ? "confirm" : "msgbox") + "'>" + msg + "</p></div><div style='text-align:right;padding:10px 5px 5px 5px;border-top:1px solid #cfeaff'><input type='button' class='wBox_close button orange" + save + "' value='确定' />" + cancel + "</div>";

    if (event != undefined)
        $(this).wBox({ opacity: 0.3, title: "系统消息", show: true, save: event, html: content });
    else
        $(this).wBox({ opacity: 0.3, title: "系统消息", show: true, html: content });
}
//获取url中的参数
function getUrlParam(name) {
    var reg = new RegExp("(^|&)" + name + "=([^&]*)(&|$)"); //构造一个含有目标参数的正则表达式对象
    var r = window.location.search.substr(1).match(reg);  //匹配目标参数
    if (r != null) return unescape(r[2]); return null; //返回参数值
}

//读取cookie
function getCookie(name) {
    var arr, reg = new RegExp("(^| )" + name + "=([^;]*)(;|$)");
    if (arr = document.cookie.match(reg))
        return unescape(arr[2]);
    else
        return null;
}
