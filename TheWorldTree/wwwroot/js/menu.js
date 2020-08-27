/**
 
 @Name: layuiSimpleBlog - 极简博客模板
 @Author: xuzhiwen
 @Copyright: layui.com
 
 */


layui.define(['mm', 'jquery'], function (exports) {
    var $ = layui.$, mm = layui.mm;
    var menu = {
        init: function () {
            $('.menu').on('click', function () {
                if ($(this).hasClass('on')) {
                    $(this).removeClass('on')
                    $('.header-down-nav').removeClass('layui-show');
                } else {
                    $(this).addClass('on')
                    $('.header-down-nav').addClass('layui-show');
                }
            })
            window.onresize = function () {
                var curwidth = document.documentElement.clientWidth;
                if (curwidth > 760) {
                    $('.header-down-nav').removeClass('layui-show');
                    $('.menu').removeClass('on');
                }
            };
            var count = $('.list-cont .cont').length;
            $('.volume span').text(count);
            $('.op-list .like').on('click', function () {
                var sayId = $(this).parent().find("input[name='SayId']").val();//获取到对应的关联id
                var oSpan = $(this).children('span');
                var num = parseInt($(oSpan).text())
                var off = $(this).attr('off')
                if (off) {
                    $(this).removeClass('active');
                    off = true;
                    $(oSpan).text(num - 1)
                    $(this).attr('off', '')
                    $.ajax({
                        type: "POST",
                        url: "/GALike/Delete",
                        data: { contentId: sayId, likeSum: num - 1 },
                        dataType: "json",
                        success: function (data) {
                        }
                    });
                    
                } else {
                    $(this).addClass('active');
                    off = false;
                    $(oSpan).text(num + 1)
                    $(this).attr('off', 'true')
                    $.ajax({
                        type: "POST",
                        url: "/GALike/Create",
                        data: { contentId: sayId, useMoudle: "说说", likeSum: num + 1 },
                        dataType: "json",
                        success: function (data) {
                           
                        }
                    });
                 
                }
            });
        },
        off: function () {
            $('.off').on('click', function () {
                var off = $(this).attr('off');
                var chi = $(this).children('i');
                var text = $(this).children('span');
                var cont = $(this).parents('.item').siblings('.review-version');
                if (off) {
                    $(text).text('展开');
                    $(chi).attr('class', 'layui-icon layui-icon-down');
                    $(this).attr('off', '');
                    $(cont).addClass('layui-hide');
                } else {
                    $(text).text('收起');
                    $(chi).attr('class', 'layui-icon layui-icon-up')
                    $(this).attr('off', 'true')
                    $(cont).removeClass('layui-hide')
                }
            })
        },
        submit: function () {
            $('.definite').on('click', function (e) {
                var event = e || event;
                event.preventDefault();
                var $listcont = $(this).parents('.form').siblings('.list-cont').length ? $(this).parents('.form').siblings('.list-cont') : $(this).parents('.form-box').siblings('.list-cont');
                console.log($listcont)
                var img = $(this).parents('form').siblings('img').attr('src');
                var textarea = $(this).parents('.layui-form-item').siblings('.layui-form-text').children('.layui-input-block').children('textarea');
                var sayContentId = $(this).parents('.layui-form').find("input[name='SayContentId']").val();
                var sayUser = $(this).parents('.layui-form').find("input[name='SayUser']").val();
                var name = $(textarea).val();
                //var html = laytplCont.innerHTML;
                //var data = {
                //    avatar: img,
                //    name: sayUser,
                //    cont: name,
                //}
                if (name) {
                    //var cont = mm.renderHtml(html, data);
                    //$listcont.prepend(cont);
                    $.ajax({
                        type: "POST",
                        url: "/FrontHome/FrontSay/OtherMsgBoard",
                        data: { contentId: sayContentId, user: sayUser, msg: name },
                        dataType: "json",
                        success: function (data) {
                            alert('提交成功');
                           
                        },
                        error: function (data) {
                            alert('提交失败');
                        }
                    });
                    //var cunt = $(this).parents('.form-box').siblings('.volume').children('span');
                    //var cunts = $(this).parents('.form-box').siblings('.list-cont').children('.cont').length;
                    textarea.val('')
                } else {
                    layer.msg('请输入内容')
                }
                //cunt.text(cunts);
            })
        }
    }
    exports('menu', menu)
});