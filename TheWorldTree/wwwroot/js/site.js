// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.



//这是关于layui的方法
LayUIMethod:
var LayUIMethod = (function () {
    return {
        TabPageTurnOff: function () {//关闭当前页，并且刷新列表
            parent.location.reload();
            parent.layui.admin.events.closeThisTabs();
        }
    }
})();