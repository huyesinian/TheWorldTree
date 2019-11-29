
$(function () {
	$("#Login").click(function () {
		LoginSys();
	});
});

function LoginSys() {
	if ($.trim($("#name").val()) == "") {
		$("#tips").html("�û�������Ϊ�գ�");
		return;
	}
	if ($.trim($("#password").val()) == "") {
		$("#tips").html("���벻��Ϊ�գ�");
		return;
	}
	$.post('/Account/Login', { userName: $("#name").val(), passWord: $("#password").val()},
		function (data) {
			if (data == "1") {
				var url = getQueryString("url");
				if (url != null) {
					window.location = url;
				}
				else {
					window.location = "/" + $("#local").val() + "/Home/Index";
				}
			} else {
				$("#tips").html(data);
			}
		}, "json");
	return false;
}