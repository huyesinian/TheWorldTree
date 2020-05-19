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
        },
        IframeTurnOff: function () {//关闭弹出层，并刷新列表
            parent.location.reload();//刷新父级页面的表格
            var index = parent.layer.getFrameIndex(window.name); //先得到当前iframe层的索引
            parent.layer.close(index); //再执行关闭
        }
    }
})();