$(function () {
    $("#memberSearch").click(function () {
        $(".div_allmember").toggle();
    });

    var li01 = $(".li_01");
    var li02 = $(".li_02");

    $(".li_01").click(function () {
        $(".tab_03").hide();
        $(".tab_02").show();
        li02.attr("id", "");
        li01.attr("id", "showRet");
    });


    $(".li_02").click(function () {
        $(".tab_02").hide();
        $(".tab_03").show();
        li01.attr("id", "showRet1");
        li02.attr("id", "showRet");
    });


})



