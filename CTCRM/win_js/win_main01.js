$(function () {
    var show_div = null;
    var show_msg = null;
    var fm = $("#fm_content");
    $(".div_common_top").click(function () {
        var t_div = $(this);
        if (show_div != null && show_msg.is(t_div) == false) {
            show_div.next().slideUp(500);
            if (show_msg != null) {
                show_msg.attr("src", "Win_Image/三角形下.png");
            }
        }
        if (t_div.next().is(':visible') == true) {
            t_div.next().slideUp(300);
            t_div.find(".img_left_arrow").attr("src", "Win_Image/三角形下.png");
        } else {
            t_div.next().slideDown(300);
            t_div.find(".img_left_arrow").attr("src", "Win_Image/三角形左.png");
        }
        show_div = t_div;
        show_msg = t_div.find(".img_left_arrow");
    });
})
