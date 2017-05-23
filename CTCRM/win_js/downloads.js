var wpro = null;
var ProFun = null;

function closeProgress() {
    if (wpro != undefined) {
        clearInterval(ProFun);
        $("#spaceused1").progressBar(100);
        wpro.close();
    }
}

function showProgress(msg)                    //根据屏幕的大小显示两个层 
{

    var content = "<div class=\"l_content\">" + msg + "<br /><span class='progressBar' id='spaceused1'>0%</span></div>";
    wpro = $(this).wBox({ opacity: 0.3, title: "系统消息", show: true, noTitle: true, parent: "#samain", html: content });
    $("#spaceused1").progressBar(0, { increment: 120 });
    ProFun = setInterval(progressbar, 1000);
}

function setProgress(per) {
    $("#spaceused1").progressBar(per);
}

$(document).ready(function () {
    CallServer("progress", "");
});

function sync_click() {
    CallServer("syncmember", "");
}

function progressbar() {
    CallServer("progress", "");
}

function ReceiveData(rValue) {
    if (rValue == undefined || rValue == null || rValue == "") return;
    var sarg = rValue.split(',');

    if (sarg[0] == "progress") {
        if (sarg[1] == "0") {
            if (wpro != null) {
                closeProgress();
                __doPostBack("", "updatetime");
            }
        }
        else {
            if (wpro == null)
                showProgress("正在同步会员资料，请耐心等待...");
            else
                setProgress(sarg[1]);
        }
    }
    else if (sarg[0] == "syncmember") {
        if (sarg[1] == "success")
            showProgress("正在同步会员资料，请耐心等待...");
        else
            msgbox("同步会员列表失败！");
    }
}