/*
Company:成都成团科技有限公司
Anthor:Fan
Remark:弹出成的制作
Verson:1.0
Date:2012年5月1日
Update:null
Method     Remark
Open()     打开对话框
Close()    关闭对话框
*/
function Dialog() {
    this.prtObj = null;
    this.obj = null;
    this.top = null;
    this.left = null;
    this.right = null;
    this.bottom = null;
    this.minHeight = null;
    this.minWidth = null;
    this.opacity = null;
    this.childPosition = null;
}
Dialog.prototype = {
    init: function () {
        // var prt = $get('body');
        var prt = document.body;
        prt.style.position = "relative";
        dialog.prtObj = $crt('DIV');
        dialog.prtObj.id = "prtDiaglog";
        dialog.prtObj.style.width = document.body.clientWidth.toString() + 'px';
        dialog.prtObj.style.height = document.body.clientHeight.toString() + 'px';
        dialog.prtObj.style.left = 0;
        dialog.prtObj.style.top = 0;
        dialog.prtObj.style.background = "#000000";
        dialog.prtObj.style.filter = "alpha(opacity=80)";
        //设置透明图
        if (dialog.opacity == null) {
            dialog.prtObj.style.opacity = 0.5;
        }
        else {
            dialog.prtObj.style.opcity = dialog.opcity;
            dialog.prtObj.style.zIndex = 100;
        }
        dialog.obj = $crt("DIV");
        dialog.obj.id = 'dialog';
        dialog.obj.style.minHeight = dialog.minHeight;
        dialog.obj.style.minWidth = dialog.minWidth;
        dialog.prtObj.style.position = "absolute";
        //        dialog.obj.style.position = dialog.position;
        if (dialog.childPosition == 'absolute') {
            dialog.obj.style.position = 'absolute';
            dialog.DialogAlign();

        }
        else {
            dialog.obj.style.position = dialog.childPosition;
        }
        if (dialog.left != null) {
            dialog.obj.style.left = dialog.left.toString() + 'px';
        }
        if (dialog.top != null) {
            dialog.obj.style.top = dialog.top.toString() + 'px';
        }
        $app(dialog.prtObj, prt);
        $(document).find("select").css("display", "none");
    },
    DOpen: function (obj) {
        dialog.childPosition = 'absolute';
        dialog.minWidth = '280px';
        dialog.minHeight = '13px';
        dialog.init();
        var prt = document.body;
        $("#zhedang").show();
        $("#msgDiv").show();
        $app(dialog.obj, prt);
    },
    DOpen2: function (obj) {
        dialog.childPosition = 'absolute';
        dialog.minWidth = '280px';
        dialog.minHeight = '13px';
        dialog.init();
        var prt = document.body;
        $("#zhezhang2").show();
        $("#msgDiv2").show();
        $app(dialog.obj, prt);
    },
    DClose: function (obj) {
        $remove($get("dialog"));
        $(document).find("select").css("display", "inline");
        $remove($get("prtDiaglog"));
    },
    ClickOpenDiaglog: function (obj) {
        dialog.childPosition = 'relative';
        dialog.left = '250';
        dialog.top = '-500';
        dialog.init();
        dialog.obj.style.zIndex = 1000;
        dialog.obj.style.width = '368px';
        dialog.obj.style.height = '320px';
        dialog.AddStyle();
        $app(dialog.obj, obj.parentNode.parentNode);
    },
    openItemSelectDialog: function (obj) {
        dialog.childPosition = 'relative';
        dialog.left = '0';
        dialog.top = '-380';
        dialog.init();
        dialog.obj.style.zIndex = 1000;
        dialog.obj.style.minWidth = '500px';
        dialog.obj.style.height = 'auto';
        dialog.obj.style.width = '850px';
        dialog.obj.style.clear = 'both';
        dialog.AddStyle();
        $app(dialog.obj, obj.parentNode.parentNode);
    },
    DialogAlign: function () {
        var w = window.screen.width;
        var h = window.screen.height;
        if (dialog.obj.style.width != '') {
            var areaW = dialog.obj.style.width;
            areaW = areaW.toString().subString(0, dialog.obj.style.width.length - 2);
        }
        else {
            var areaW = dialog.obj.style.minWidth;
            areaW = areaW.toString().substring(0, dialog.obj.style.minWidth.length - 2);
        }
        if (dialog.obj.style.height != '') {
            var areaH = dialog.obj.style.height;
            areaH = areaH.toString().subString(0, dialog.obj.style.height.length - 2);
        }
        else {
            var areaH = dialog.obj.style.minHeight;
            areaH = areaH.toString().substring(0, dialog.obj.style.minHeight.length - 2);
        }
        if ((w > areaW)) { dialog.left = Math.floor((w - areaW) / 2); }
        if (h > areaH) { dialog.top = Math.floor((h - areaH) / 3); }
    },
    AddStyle: function () {
        //使用表格解决IE6自适应宽度的问题
        var diaglogTop = $crt('Div');
        diaglogTop.id = 'diaglogtop';
        diaglogTop.innerHTML = "<table class='tbl'><tr><td class='DialogTopPon left'></td><td class='DialogTopMiddle'><span class='itemTitle'></span></td><td class='DialogTopPon right'></td></tr></table>";
        $app(diaglogTop, dialog.obj);
        //添加关闭按钮
        var closeDiaglog = $crt('img');
        closeDiaglog.src = "/images/Diaglog/pic_002.png";
        closeDiaglog.id = 'closeDiaglog';
        //$setAttr(closeDiaglog, 'onclick', 'javascript:dialog.DClose(this,event);')
        closeDiaglog.onclick = function () {
            dialog.DClose(this);
        }
        $app(closeDiaglog, diaglogTop);
        var diaglogMid = $crt("Div");
        diaglogMid.id = 'diaglogMid';
        $app(diaglogMid, dialog.obj);
        var diaglogBottom = $crt('Div');
        diaglogBottom.id = 'diaglogButtom';
        var Btnsumit = $crt("img");
        Btnsumit.id = 'btnSubmit';
        Btnsumit.src = "/images/Diaglog/pic_010.png";
        $app(Btnsumit, diaglogBottom);
        $app(diaglogBottom, dialog.obj);
    }
};
var dialog = new Dialog();
document.onload = function (e) {                 // enter   
    e = e || event; if (e.keyCode == 13) {
        e.cancelBubble = true; e.returnValue = false;
    }
}
