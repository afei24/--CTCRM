$crt = function(obj) { return document.createElement(obj); }
$appById = function(idNObj, prt) { document.getElementById(prt).appendChild(newObj); }
$app = function(newObj, prt) { prt.appendChild(newObj); }
$get = function(obj) { return document.getElementById(obj); }
$setAttr = function(obj, name, value) { obj.setAttribute(name, value); }
$getAttr = function(obj, name) { var value = document.getElementById(obj).getAttribute(name); return obj }
$rmvc = function(obj) {
    if (obj && obj.childNodes && obj.childNodes.length > 0) {
        while (obj && obj.childNodes && obj.childNodes.length > 0) {
            obj.removeChild(obj.childNodes[0]);
        }
    }
}
$removeChild = function(childNode) {
    var prt = document.getElementById(childNode).parentNode;
    if (prt.childNodes) {
        for (var i = 0; i < prt.childNodes.length; i++) {
            prt.removeChild(prt.childNodes[i])
        }
    }
};
$getChild = function(obj, id) { return obj.getElementById(id); }
$remove = function(obj) { obj.parentNode.removeChild(obj); }
$PostAjax = function(_post, _url, _data, _datatype, func) {
    $.ajax({ type: _post, url: _url, data: _data, dataType: _datatype, success: function(res) {
        if (typeof (func) == 'function') {
            func(res);
        }
    },
        Error: function(res) {
            func(res);
        }
    });
}
$appendObjClass = function(obj, className) {
    obj.className = obj.className + " " + className;
}
$appClass = function(obj, style) {
    var nodes = obj.parentNode.parentNode.childNodes;
    for (var i = 0; i < nodes.length; i++) {
        if (nodes[i].nodeName == "LI" && nodes[i].childNodes[1].nodeName == "A")
            nodes[i].childNodes[1].removeAttribute("class");
    }
    obj.className = style;
}
$request=function (paras) {
    var url = location.href;
    var paraString = url.substring(url.indexOf("?") + 1, url.length).split("&");
    var paraObj = {}
    for (i = 0; j = paraString[i]; i++) {
        paraObj[j.substring(0, j.indexOf("=")).toLowerCase()] = j.substring(j.indexOf("=") + 1, j.length);
    }
    var returnValue = paraObj[paras.toLowerCase()];
    if (typeof (returnValue) == "undefined") {
        return "";
    } else {
        return returnValue;
    }
}

//$(".a_contact").click(
//function()
//{
//		var sotext=$("#remarks").val();
//		if(sotext=="选填，如有其它需求请在此处填写"){
//			$("#remarks").css("color","#999").val($(this).text());
//		}else{
//			$("#remarks").css("color","#404040").val(sotext+$(this).text());
//		}
//		return false;
//}
//	)