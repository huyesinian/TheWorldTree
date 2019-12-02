
$(function () {
	$("#Login").click(function () {
		LoginSys();
	});
});

function LoginSys() {
	if ($.trim($("#name").val()) == "") {
		$("#tips").html("用户名不能为空！");
		return;
	}
	if ($.trim($("#password").val()) == "") {
		$("#tips").html("密码不能为空！");
		return;
	}
	$.post('/Account/Login', { userName: $("#name").val(), passWord: $("#password").val()},
		function (data) {
			if (data == "1") {
					window.location = "/Home/Index";
			} else {
				$("#tips").html(data);
			}
		}, "json");
	return false;
}