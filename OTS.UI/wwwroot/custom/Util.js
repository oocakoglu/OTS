function errorMes(message, errorTitle) {
    toastr.error(message, errorTitle, toastr.options = {
        "closeButton": true,
        "debug": false,
        "newestOnTop": false,
        "progressBar": true,
        "positionClass": "toast-top-right",
        "preventDuplicates": false,
        "onclick": null,
        "showDuration": "300",
        "hideDuration": "1000",
        "timeOut": "5000",
        "extendedTimeOut": "1000",
        "showEasing": "swing",
        "hideEasing": "linear",
        "showMethod": "fadeIn",
        "hideMethod": "fadeOut"
    })
};

function sucMess(message, sucTitle) {
    toastr.success(message, sucTitle, toastr.options = {
        "closeButton": true,
        "debug": false,
        "newestOnTop": false,
        "progressBar": true,
        "positionClass": "toast-top-right",
        "preventDuplicates": false,
        "onclick": null,
        "showDuration": "300",
        "hideDuration": "1000",
        "timeOut": "5000",
        "extendedTimeOut": "1000",
        "showEasing": "swing",
        "hideEasing": "linear",
        "showMethod": "fadeIn",
        "hideMethod": "fadeOut"
    })
};

function warMess(message, warTitle) {
    toastr.warning(message, warTitle, toastr.options = {
        "closeButton": true,
        "debug": false,
        "newestOnTop": false,
        "progressBar": true,
        "positionClass": "toast-top-right",
        "preventDuplicates": false,
        "onclick": null,
        "showDuration": "300",
        "hideDuration": "1000",
        "timeOut": "5000",
        "extendedTimeOut": "1000",
        "showEasing": "swing",
        "hideEasing": "linear",
        "showMethod": "fadeIn",
        "hideMethod": "fadeOut"
    })
};

function LoginControl() {
    var mydata = {
        UserName: $("#UserName").val(),
        Password: $("#Password").val(),
    }

    $.ajax({
        url: "/Login/LoginControl",
        type: "post",
        data: mydata,
        success: function (returnData) {
            if (mydata.UserName == "" && mydata.Password == "") {
                warMess("Username and Password can not be empty", "Error!");
            }
            else {
                if (returnData != true) {
                    errorMes("Username or Password wrong", "Error!");
                    setInterval(function () {
                        window.location.replace("/");
                    }, 2000);
                }
                else {
                    sucMess(mydata.UserName, "Welcome");
                    setInterval(function () {
                        window.location.replace("/Home/Index");
                    }, 2000);
                }
            }
        }
    });
}