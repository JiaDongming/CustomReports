
$(function () {

    // 单选下拉框内容改变时调用
    $("#Select1").change(function () {
        var checkResult = checkSearchCondition();
        if (checkResult != "false") {
            $("#hidprojectIDs").val($("#Select1").val());
            doReportCall();
        }
    });

});


function checkSearchCondition() {
    var selectedProjectsStr = $('#Select1').val();
    if ((selectedProjectsStr == "") || (selectedProjectsStr == null)) {
        alert("请选择DevTrack项目！");
        $('#divGlobalReportHTML22').html("");
        return "false";
    }
    return "true";
}


function doReportCall() {

    var selectedProjectsStr = $('#Select1').val();
    var params = "{'selectedProjectsStr':'" + selectedProjectsStr + "'}";

    $.ajax({
        type: "POST",
        url: "Report22.aspx/RefreshGlobalReport22",
        data: params,
        contentType: "application/json; charset=utf-8",
        beforeSend: function (XMLHttpRequest) {
            $('#divGlobalReportHTML22').html("<h5 style='color:red;'>正在生成报表...</h5>");
        },
        success: function (msg) {
            $('#divGlobalReportHTML22').html("");
            if (msg.d) {
                $('#divGlobalReportHTML22').html(msg.d.toString());
            }
        },
        error: function (xhr, msg, e) {
            alert("error");
        }
    });
}


