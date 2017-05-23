$(function () {
    $("#imgbtnshowJilu").toggle(function () {
        $("#GridView_Jilv").show();
        $("#imgbtnshowJilu").attr("src", "../../Win_Image/closeExport.png");
    }, function () {
        $("#GridView_Jilv").hide();
        $("#imgbtnshowJilu").attr("src", "../../Win_Image/showExport.png");
    })
})