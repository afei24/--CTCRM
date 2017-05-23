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
