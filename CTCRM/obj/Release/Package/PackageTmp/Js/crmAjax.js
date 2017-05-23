$(document).ready(function() {
    $('#msgTestSend').click(function() {
        $('.message-lay').show();
        $('.message-box').show();
        $.ajax({
            url: "/CRMHandler/CrmHandler.ashx",
            type: "POST",
            success: function(data) {
            if (data.phoneNoError == '0') {
                alert("手机号码不能为空!")
            };
            if (data.phoneNoError2 == '0') {
                alert("手机号码格式不正确!")
            };
            if (data.msgContent == '0') {
                alert("短信内容不能为空!")
            };
                
                $('.message-lay').hide();
                $('.message-box').hide();

            },
            data: "method=sendTestMsg&testNo=" + $('#txtMyCellPhone').val() + "&msgContentVa=" + $('#msgCont').val()
        });
    });



});
