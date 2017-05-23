$(function () {
    $(".title_li").bind("click", function () {
        var id = $(this).attr("id");
        $(".title_li").css("color", "#00BFE9");
        $(".title_li").css("background-color", "white");
        $(this).css("color", "white");
        $(this).css("background-color", "#00BFE9");
        $(".contect").hide();
        $("." + id).show();
    });
})