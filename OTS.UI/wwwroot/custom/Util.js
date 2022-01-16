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

function SearchCustomer() {
    var mdata = {
        sPhone: $("#SearchPhone").val()
    };
    $.ajax({
        url: "/Customer/CustomerSearch",
        type: "post",
        data: mdata,
        success: function (e) {
            if (e != false) {
                $("#CustomerName").val(e.customerName);
                $("#CustomerPhone").val(e.customerPhone);
                $("#CustomerAddress").html(e.customerAddress);
                $("#MarketId").val(e.marketId);

                errorMes("Custome phone already exist in the database", "Error")
                $("#StatusBar").removeAttr("hidden");
                $("#StatusBar").addClass("text-danger");
                $("#StatusBar").html("Custome phone already exist in the database");;
            }
            else {
                $("#CustomerName").removeAttr("disabled", "disabled");
                $("#CustomerPhone").removeAttr("disabled", "disabled");
                $("#CustomerAddress").removeAttr("disabled", "disabled");
                $("#MarketId").removeAttr("disabled", "disabled");
                $("#theButton").removeAttr("disabled", "disabled");

                $("#CustomerName").val("");
                $("#CustomerPhone").val(mdata.sPhone);
                $("#CustomerAddress").html("");
                $("#StatusBar").attr("hidden", true);
                //setAttribute("style", "background-color: red;");
                sucMess("Phone number not exist in database. You can add customer", "Phone Number Checked");                
            }

        }
    })
}
