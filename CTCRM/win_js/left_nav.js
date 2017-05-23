
$(function () {

    var iframe1 = $(".content_child_right");
    var iframeSrc = GetRequest();
    iframe1.attr("src", iframeSrc)
    function GetRequest() {
        var url = location.search; //获取url中"?"符后的字串
        if (url.indexOf("?") != -1) {    //判断是否有参数
            var str = url.substr(5); //从第一个字符开始 因为第0个是?号 获取所有除问号的所有符串
            //strs = str.split("=");   //用等号进行分隔 （因为知道只有一个参数 所以直接用等号进分隔 如果有多个参数 要用&号分隔 再用等号进行分隔）
            str = str.replace("&&", "?");        //直接弹出第一个参数 （如果有多个参数 还要进行循环的）
            return str;
        }
    }


    var title = $(".nav_title");
    var b_nav = null;
    title.click(function () {
        if (b_nav == null) {
            $(this).next().slideDown(500);
            divDownStatus($(this));
            b_nav = $(this);
        } else {
            b_nav.next().slideUp(500);
            divUpstatus(b_nav);
            divDownStatus($(this));
            $(this).next().slideDown(500);
            b_nav = $(this);
        }
    });

    $(".nav_title").next().slideDown(500);
    divDownStatus($(".nav_title"));
    b_nav = $(".nav_title");

    $(".nav_list_li").click(function () {
        var src = $(this).attr("id");
        $(".content_child_right").attr("src", src);
    });

    function divUpstatus(navNode) {
        var img = navNode.find(".nav_img");
        var arrows = navNode.find(".nav_arrows");
        //b_nav.attr("src", b_nav.attr("src").replace("_b", "_w"));
        var img_src = img.attr("src").replace("_w", "_b");
        img.attr("src", img_src);
        var arrows_src = arrows.attr("src").replace("_w", "_b")
        arrows.attr("src", arrows_src);

        navNode.css("background-color", "white");
        navNode.css("color", "black");
    }

    function divDownStatus(navNode) {
        var img = navNode.find(".nav_img");
        var img_src = img.attr("src").replace("_b", "_w");
        img.attr("src", img_src);
        var arrows = navNode.find(".nav_arrows");
        //b_nav.attr("src", b_nav.attr("src").replace("_w", "_b"));
        img.attr("src", img.attr("src").replace("_w", "_b"));
        var arrows_src = arrows.attr("src").replace("_b", "_w")
        arrows.attr("src", arrows_src);
        navNode.css("background-color", "#00BBD6");
        navNode.css("color", "white");
    }
});