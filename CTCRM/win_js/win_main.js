$(function () {
    //点击首页
    $("#home").bind("click", function () {
        $(".li_navigation2 .三角形").remove();
        $(".iframe_main").attr("src", "/WIN_Aspx/home.aspx");
    })
    //点击一级导航显示二级
    $(".li_navigation").bind("click", function () {
        var li_navigation2 = $(this).attr("id");
        $(".li_navigation").each(function () {
            var src = $(this).find(".tubiao").attr("id") + ".png";
            $(this).find(".tubiao").attr("src", src)
        });
        //点击的导航已经打开
        if ($("#" + li_navigation2 + " .三角形左").attr("src") == "Win_Image/三角形下.png") {

            $("#" + li_navigation2 + " .三角形左").attr("src", "Win_Image/三角形左.png");
            $(".li_navigation2").hide();
            return;
        }
        //全部导航图片恢复
        $(".li_navigation .三角形左").attr("src", "Win_Image/三角形左.png");

        //点击的导航展开
        $("#" + li_navigation2 + " .三角形左").attr("src", "Win_Image/三角形下.png");
        $(this).find(".tubiao").attr("src", $(this).find(".tubiao").attr("id") + "2.png")
        $(".li_navigation2").hide();
        $("." + li_navigation2).show();
        
        //移除和添加背景样式
        $(".li_navigation").removeClass("avn_black");
        $(this).addClass("avn_black");
        $(".li_navigation2").removeClass("avn_black");
        $("." + li_navigation2).addClass("avn_black");

    })


    //点击二级导航跳转
    $(".li_navigation2").bind("click", function () {
        var src = $(this).attr("id");
        $(".iframe_main").attr("src", src);
        $(".li_navigation2 .三角形").remove();
        $(this).append("<img class='三角形' src='Win_Image/三角形左.png' />");
    })
})
function xuyue() {
    $(".iframe_main").attr("src", "WIN_Aspx/messageSetting.aspx");

}