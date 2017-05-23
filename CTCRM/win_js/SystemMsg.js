window.onload = function () {
    var type = getUrlParam("type");
    if (type == "edit") {
        var id = getUrlParam("SystemMsgID");
        $("#HiddenField1").attr("Value", id);
        //var SystemLink = getUrlParam("SystemLink");
        //$("#TextBoxLink").attr("Value", SystemLink);
        //var SystemMsg = getUrlParam("SystemMsg");
        //$("#TextBoxMsg").attr("Value", SystemMsg);
        var Status = getUrlParam("Status");
        var s = document.getElementById("DropDownListStatus");
        var ops = s.options;
        for (var i = 0; i < ops.length; i++) {
            var tempValue = ops[i].value;
            if (tempValue == Status) 
            {
                ops[i].selected = true;
                break;
            }
        }
    }
};