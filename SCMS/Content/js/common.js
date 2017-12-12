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
function showError(error) {
    var info = document.getElementById("errorInfo");
    info.innerText = error;
    info.style.display = "";
}
function hideError() {
    var info = document.getElementById("errorInfo");
    info.style.display = "none";
}

 function errorInfo() {
    var Request = new Object();
    Request = GetRequest();
    var errorMSG = Request['errorMSG'];
    switch (errorMSG) {
        case "1": showError("用户名或密码错误"); break;
        case "2": showError("无权限"); break;
        case "3": showError("未登录"); break;
        default: hideAllElement(); break;
    }
}