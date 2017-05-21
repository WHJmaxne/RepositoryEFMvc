//模态框操作js函数


/*******弹出表单*********/
function ShowModal(actionUrl, param, title) {
    var $modal = $("#modal-form");
    //表单初始化
    $(".modal-title", $modal).html(title);
    $("#modal-content", $modal).attr("action", actionUrl);

    $.ajax({
        type: "GET",
        url: actionUrl,
        data: param,
        beforeSend: function () {
            //
        },
        success: function (result) {
            $("#modal-content").html(result);
            jQuery.noConflict();
            $('#modal-form').modal('show');
            RegisterForm();//通过Ajax加载返回的页面原有MVC属性验证将失效，需要重新注册验证脚本。
        },
        error: function () {
            //
        },
        complete: function () {
            //
        }
    });
}

/*******注册验证脚本，通过Ajax返回的页面原有MVC属性验证将失效，需要重新注册验证脚本*********/
function RegisterForm() {
    $('#modal-content').removeData('validator');
    $('#modal-content').removeData('unobtrusiveValidation');
    $.validator.unobtrusive.parse('#modal-content');
}

/*******保存表单*********/
