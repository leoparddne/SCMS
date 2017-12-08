function GetRequest() {
    var url = location.search; //获取url中"?"符后的字串
    var theRequest = new Object();
    if (url.indexOf("?") != -1) {
        var str = url.substr(1);
        strs = str.split("&");
        for (var i = 0; i < strs.length; i++) {
            theRequest[strs[i].split("=")[0]] = unescape(strs[i].split("=")[1]);
        }
    }
    return theRequest;
}
function showErrorPWD() {
    var info = document.getElementById("errorInfo");
    info.style.display = "";
    hidePowerDeny();
}
function hideErrorPWD() {
    var info = document.getElementById("errorInfo");
    info.style.display = "none";
}
function showPowerDeny() {
    var info = document.getElementById("powerDeny");
    info.style.display = "";
    hideErrorPWD();
}
function hidePowerDeny() {
    var info = document.getElementById("powerDeny");
    info.style.display = "none";
}
function hideAllElement() {
    hideErrorPWD();
    hidePowerDeny();
}
 function errorInfo() {
    var Request = new Object();
    Request = GetRequest();
    var errorMSG = Request['errorMSG'];
    switch (errorMSG) {
        case "1": showErrorPWD(); break;
        case "2": showPowerDeny(); break;
        default: hideAllElement(); break;
    }
}